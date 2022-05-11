using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UMS.Business.Abstract.Shared;
using UMS.Business.Helpers;
using UMS.Core;
using UMS.Core.Enums;
using UMS.Core.InternalDtos;
using UMS.Core.Utils;
using UMS.Data.Entities;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Dto;
using UMS.Dto.Authentication;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete.Shared
{
    public class AuthenticationOperations : IAuthenticationOperations
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationOperations(AppSettings appSettings, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _appSettings = appSettings;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        #region Student
        public async Task<Result<TokenDto>> StudentAuthenticateViaPassword(LoginDto loginDto)
        {
            if (!Validate.Username(loginDto.Username) || !Validate.Password(loginDto.Password))
                return Result<TokenDto>.CreateErrorResult(ErrorCode.InvalidUsernameOrPassword);
            var user = await _unitOfWork.Students.Where(x => x.Username == loginDto.Username).FirstOrDefaultAsync();
            if (user == null)
                return Result<TokenDto>.CreateErrorResult(ErrorCode.InvalidUsernameOrPassword);
            var success = new CustomPasswordHasher().VerifyPassword(user.HashedPassword, loginDto.Password);
            if (!success)
                return Result<TokenDto>.CreateErrorResult(ErrorCode.InvalidUsernameOrPassword);
            var token = TokenGenerator.CreateStudentToken(user.Id, user.Username, user.UserType, user.UniversityId, _appSettings.TokenOptions);
            await _unitOfWork.RedisTransactions.Set(new RedisToken { TokenValue = token.RefreshToken, UserId = user.Id, ConsumerType = ApiConsumerType.Student, TokenType = RedisTokenType.RefreshToken, Username = user.Username }, _appSettings.TokenOptions.RefreshTokenLifetime);
            return Result<TokenDto>.CreateSuccessResult(token);
        }

        public async Task<Result<TokenDto>> StudentAuthenticateViaToken(string refreshToken)
        {
            var token = await _unitOfWork.RedisTokens.Get(refreshToken);
            if (token == null || token.ConsumerType != ApiConsumerType.Student || token.TokenType != RedisTokenType.RefreshToken)
                return Result<TokenDto>.CreateErrorResult(ErrorCode.InvalidRefreshToken);
            await _unitOfWork.RedisTokens.Remove(refreshToken);
            var user = await _unitOfWork.Students.Get(token.UserId).FirstOrDefaultAsync();
            var newToken = TokenGenerator.CreateStudentToken(user.Id, user.Username, user.UserType, user.UniversityId, _appSettings.TokenOptions);
            await _unitOfWork.RedisTokens.Set(new RedisToken { TokenValue = newToken.RefreshToken, UserId = token.UserId, ConsumerType = ApiConsumerType.Student, TokenType = RedisTokenType.RefreshToken, Username = user.Username }, _appSettings.TokenOptions.RefreshTokenLifetime);
            return Result<TokenDto>.CreateSuccessResult(newToken);
        }

        public async Task<Result<bool>> StudentForgotPassword(string emailAddress)
        {
            emailAddress = emailAddress.Trim().ToLower();
            var user = _unitOfWork.Students.Where(x => x.Email == emailAddress).FirstOrDefault();

            if (user == null)
                return Result<bool>.CreateErrorResult(ErrorCode.InvalidUsernameOrPassword);

            var token = Generate.PasswordResetToken();
            // send confirmation mail
            var url = $"{ServiceLocator.AppSettings.ClientUrl}/userPasswordReset?token={token}";
            await _unitOfWork.RedisTransactions.Set(new RedisToken
            {
                UserId = user.Id,
                ConsumerType = ApiConsumerType.Teacher,
                TokenType = RedisTokenType.PasswordResetToken,
                TokenValue = token
            }, 2 * 60);
            await _unitOfWork.Commit();
            return Result<bool>.CreateSuccessResult(true);
        }

        public async Task<Result<bool>> StudentLogout(string refreshToken)
        {
            await _unitOfWork.RedisTransactions.Remove(refreshToken);
            return Result<bool>.CreateSuccessResult(true);
        }

        public async Task<Result<bool>> StudentResetPassword(ResetPasswordDto dto)
        {
            var token = await _unitOfWork.RedisTransactions.Get(dto.PasswordResetToken);
            if (token == null || token.ConsumerType != ApiConsumerType.Student || token.TokenType != RedisTokenType.PasswordResetToken)
                return Result<bool>.CreateErrorResult(ErrorCode.InvalidPasswordResetToken);
            var customer = await _unitOfWork.Students.GetAsTracking(token.UserId).FirstOrDefaultAsync();
            customer.HashedPassword = new CustomPasswordHasher().HashPassword(dto.NewPassword);
            await _unitOfWork.Commit();
            await _unitOfWork.RedisTransactions.Remove(dto.PasswordResetToken);
            return Result<bool>.CreateSuccessResult(true);
        }

        public async Task<Result<long>> StudentSignUp(SignUpDto dto)
        {
            if (!Validate.Username(dto.Email) || !Validate.Password(dto.Password))
                return Result<long>.CreateErrorResult(ErrorCode.InvalidUsernameOrPassword);
            var existingMail = await _unitOfWork.Students.Where(x => x.Email == dto.Email || x.Username == dto.Username).FirstOrDefaultAsync();
            if (existingMail != null)
                return Result<long>.CreateErrorResult(ErrorCode.ObjectAlreadyExists);
            var now = DateTime.UtcNow;

            // create user
            var entity = _unitOfWork.Students.Add(new Student
            {
                EnrollmentDate = DateTime.Now,
                Username = dto.Username,
                CreatedAt = now,
                Email = dto.Email,
                LastModifiedAt = now,
                Name = dto.Name,
                Surname = dto.Surname,
                HashedPassword = new CustomPasswordHasher().HashPassword(dto.Password),
                Status = UserStatus.Created
            });
            await _unitOfWork.Commit();
            return Result<long>.CreateSuccessResult(entity.Id);
        }

        #endregion

        #region StudentRespresentative

        public Task<Result<TokenDto>> StudentRespresentativeAuthenticateViaPassword(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TokenDto>> StudentRespresentativeAuthenticateViaToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> StudentRespresentativeForgotPassword(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> StudentRespresentativeLogout(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> StudentRespresentativeResetPassword(ResetPasswordDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<Result<long>> StudentRespresentativeSignUp(SignUpDto dto)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Teacher

        public async Task<Result<TokenDto>> TeacherAuthenticateViaPassword(LoginDto loginDto)
        {
            if (!Validate.Username(loginDto.Username) || !Validate.Password(loginDto.Password))
                return Result<TokenDto>.CreateErrorResult(ErrorCode.InvalidUsernameOrPassword);
            var user = await _unitOfWork.Teachers.Where(x => x.Username == loginDto.Username).FirstOrDefaultAsync();
            if (user == null)
                return Result<TokenDto>.CreateErrorResult(ErrorCode.InvalidUsernameOrPassword);
            var success = new CustomPasswordHasher().VerifyPassword(user.HashedPassword, loginDto.Password);
            if (!success)
                return Result<TokenDto>.CreateErrorResult(ErrorCode.InvalidUsernameOrPassword);
            var token = TokenGenerator.CreateTeacherToken(user.Id, user.Username, user.UserType, user.UniversityId, _appSettings.TokenOptions);
            await _unitOfWork.RedisTransactions.Set(new RedisToken { TokenValue = token.RefreshToken, UserId = user.Id, ConsumerType = ApiConsumerType.Teacher, TokenType = RedisTokenType.RefreshToken, Username = user.Username }, _appSettings.TokenOptions.RefreshTokenLifetime);
            return Result<TokenDto>.CreateSuccessResult(token);
        }

        //public async Task<Result<TokenDto>> TeacherAuthenticateViaToken(string refreshToken)
        //{
        //    var token = await _unitOfWork.RedisTransactions.Get(refreshToken);
        //    if (token == null || !(token.ConsumerType == ApiConsumerType.Teacher || token.ConsumerType == ApiConsumerType.Teacher) || token.TokenType != RedisTokenType.RefreshToken)
        //        return Result<TokenDto>.CreateErrorResult(ErrorCode.InvalidRefreshToken);
        //    await _unitOfWork.RedisTransactions.Remove(refreshToken);
        //    TokenDto newToken = null;
        //    if (token.ConsumerType == ApiConsumerType.Teacher)
        //        newToken = TokenGenerator.CreateTeacherToken(token.UserId,token.Username,token. _appSettings.TokenOptions);
        //    await _unitOfWork.RedisTransactions.Set(new RedisToken { TokenValue = newToken.RefreshToken, UserId = token.UserId, ConsumerType = token.ConsumerType, TokenType = RedisTokenType.RefreshToken }, _appSettings.TokenOptions.RefreshTokenLifetime);
        //    return Result<TokenDto>.CreateSuccessResult(newToken);
        //}

        public async Task<Result<bool>> TeacherForgotPassword(string emailAddress)
        {
            emailAddress = emailAddress.Trim().ToLower();
            var user = _unitOfWork.Teachers.Where(x => x.Email == emailAddress).FirstOrDefault();

            if (user == null)
                return Result<bool>.CreateErrorResult(ErrorCode.InvalidUsernameOrPassword);

            var token = Generate.PasswordResetToken();
            // send confirmation mail
            var url = $"{ServiceLocator.AppSettings.ClientUrl}/userPasswordReset?token={token}";
            await _unitOfWork.RedisTransactions.Set(new RedisToken
            {
                UserId = user.Id,
                ConsumerType = ApiConsumerType.Teacher,
                TokenType = RedisTokenType.PasswordResetToken,
                TokenValue = token
            }, 2 * 60);
            await _unitOfWork.Commit();
            return Result<bool>.CreateSuccessResult(true);
        }

        public async Task<Result<bool>> TeacherLogout(string refreshToken)
        {
            await _unitOfWork.RedisTransactions.Remove(refreshToken);
            return Result<bool>.CreateSuccessResult(true);
        }

        public async Task<Result<bool>> TeacherResetPassword(ResetPasswordDto dto)
        {
            var token = await _unitOfWork.RedisTransactions.Get(dto.PasswordResetToken);
            if (token == null || token.ConsumerType != ApiConsumerType.Teacher || token.TokenType != RedisTokenType.PasswordResetToken)
                return Result<bool>.CreateErrorResult(ErrorCode.InvalidPasswordResetToken);
            var customer = await _unitOfWork.Teachers.GetAsTracking(token.UserId).FirstOrDefaultAsync();
            customer.HashedPassword = new CustomPasswordHasher().HashPassword(dto.NewPassword);
            await _unitOfWork.Commit();
            await _unitOfWork.RedisTransactions.Remove(dto.PasswordResetToken);
            return Result<bool>.CreateSuccessResult(true);
        }

        public async Task<Result<long>> TeacherSignUp(SignUpDto dto)
        {
            if (!Validate.Username(dto.Username) || !Validate.Password(dto.Password))
                return Result<long>.CreateErrorResult(ErrorCode.InvalidUsernameOrPassword);
            var existingMail = await _unitOfWork.Teachers.Where(x => x.Email == dto.Email || x.Username == dto.Username).FirstOrDefaultAsync();
            if (existingMail != null)
                return Result<long>.CreateErrorResult(ErrorCode.ObjectAlreadyExists);
            var now = DateTime.UtcNow;

            // create user
            var entity = _unitOfWork.Teachers.Add(new CourseInstructor
            {
                Username = dto.Username,
                EnrollmentDate = now,
                CreatedAt = now,
                Email = dto.Email,
                LastModifiedAt = now,
                Name = dto.Name,
                Surname = dto.Surname,
                HashedPassword = new CustomPasswordHasher().HashPassword(dto.Password),
                Status = UserStatus.Created
            });
            await _unitOfWork.Commit();
            return Result<long>.CreateSuccessResult(entity.Id);
        }


        #endregion
    }
}
