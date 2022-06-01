using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using UMS.Core.Enums;
using UMS.Core.InternalDtos;
using UMS.Core.Utils;
using UMS.Dto.Authentication;

namespace UMS.Business.Helpers
{
    public static class TokenGenerator
    {
        public static TokenDto CreateTeacherToken(long userId, string username, UserType userType, long universityId, TokenOptions tokenOptions)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenOptions.TeacherSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(ClaimUtils.CreateTeacherClaims(userId, username, userType, universityId)),
                Expires = DateTime.UtcNow.AddMinutes(tokenOptions.AccessTokenLifetime),
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            var refreshToken = Guid.NewGuid().ToString();
            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        public static TokenDto CreateStudentToken(long userId, string username, UserType userType, long universityId, TokenOptions tokenOptions)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenOptions.StudentSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(ClaimUtils.CreateStudentClaims(userId, username, userType, universityId)),
                Expires = DateTime.UtcNow.AddMinutes(tokenOptions.AccessTokenLifetime),
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            var refreshToken = Guid.NewGuid().ToString();
            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

    }
}
