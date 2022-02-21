using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mesero.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UMS.Business.Helpers;
using UMS.Core.Enums;
using UMS.Core.InternalDtos;
using UMS.Core.Utils;
using UMS.Dto;
using UMS.Dto.Authentication;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete
{
    public class AuthenticationOperations : IAuthentictionOperations
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
        public Task<Result<TokenDto>> StudentAuthenticateViaPassword(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TokenDto>> StudentAuthenticateViaToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> StudentForgotPassword(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> StudentLogout(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> StudentResetPassword(ResetPasswordDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<Result<long>> StudentSignUp(SignUpDto dto)
        {
            throw new NotImplementedException();
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
            // await _unitOfWork.RedisTokens.Set(new RedisToken { TokenValue = token.RefreshToken, UserId = user.Id, ConsumerType = ApiConsumerType.Admin, TokenType = RedisTokenType.RefreshToken, Username = user.Username }, _appSettings.TokenOptions.RefreshTokenLifetime);
            return Result<TokenDto>.CreateSuccessResult(token);
        }

        public Task<Result<TokenDto>> TeacherAuthenticateViaToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> TeacherForgotPassword(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TokenDto>> TeacherLoginToUserCompany(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> TeacherLogout(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> TeacherResetPassword(ResetPasswordDto dto)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
