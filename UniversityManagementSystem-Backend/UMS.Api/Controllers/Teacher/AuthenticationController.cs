using Mesero.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using UMS.Core;
using UMS.Dto;
using UMS.Dto.Authentication;

namespace UMS.Api.Controllers.Teacher
{
    [ApiController]
    [Route("api/user/[controller]")]
    [ApiExplorerSettings(GroupName = Constants.AuthenticationSchemes.Teacher)]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationOperations _authOperations;

        /// <inheritdoc />
        public AuthenticationController(IAuthenticationOperations authOperations)
        {
            _authOperations = authOperations;
        }

        /// <summary>
        /// Authenticate via password
        /// </summary>
        [HttpPost("pass")]
        public async Task<Result<TokenDto>> AuthenticateViaPassword([FromBody] LoginDto loginDto)
        {
            return await _authOperations.TeacherAuthenticateViaPassword(loginDto);
        }

        /// <summary>
        /// Authenticate via refresh token
        /// </summary>
        //[HttpPost("token")]
        //public async Task<Result<TokenDto>> AuthenticateViaToken([FromBody] TokenDto token)
        //{
        //    return await _authOperations.TeacherAuthenticateViaToken(token.RefreshToken);
        //}

        /// <summary>
        /// Logout
        /// </summary>
        [HttpPost("logout")]
        public async Task<Result<bool>> Logout([FromBody] string refreshToken)
        {
            return await _authOperations.TeacherLogout(refreshToken);
        }

        /// <summary>
        /// Endpoint for requesting a new password
        /// </summary>
        [HttpPost("ForgotPassword")]
        public async Task<Result<bool>> ForgotPassword([FromBody] string emailAddress)
        {
            return await _authOperations.TeacherForgotPassword(emailAddress);
        }

        /// <summary>
        /// Endpoint for resetting a forgotten password
        /// </summary>
        [HttpPost("ResetPassword")]
        public async Task<Result<bool>> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            return await _authOperations.TeacherResetPassword(dto);
        }
    }
}
