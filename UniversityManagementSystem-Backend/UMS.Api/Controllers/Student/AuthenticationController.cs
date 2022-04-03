using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UMS.Business.Abstract.Shared;
using UMS.Core;
using UMS.Dto;
using UMS.Dto.Authentication;

namespace UMS.Api.Controllers.Student
{
    [ApiController]
    [Route("api/student/[controller]")]
    [ApiExplorerSettings(GroupName = Constants.AuthenticationSchemes.Student)]
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
            return await _authOperations.StudentAuthenticateViaPassword(loginDto);
        }

        // <summary>
        // Authenticate via refresh token
        // </summary>
        [HttpPost("token")]
        public async Task<Result<TokenDto>> AuthenticateViaToken([FromBody] TokenDto token)
        {
            return await _authOperations.StudentAuthenticateViaToken(token.RefreshToken);
        }

        /// <summary>
        /// Logout
        /// </summary>
        [HttpPost("logout")]
        public async Task<Result<bool>> Logout([FromBody] string refreshToken)
        {
            return await _authOperations.StudentLogout(refreshToken);
        }

        /// <summary>
        /// Endpoint for requesting a new password
        /// </summary>
        [HttpPost("ForgotPassword")]
        public async Task<Result<bool>> ForgotPassword([FromBody] string emailAddress)
        {
            return await _authOperations.StudentForgotPassword(emailAddress);
        }

        /// <summary>
        /// Endpoint for resetting a forgotten password
        /// </summary>
        [HttpPost("ResetPassword")]
        public async Task<Result<bool>> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            return await _authOperations.StudentResetPassword(dto);
        }

        /// <summary>
        /// Endpoint for teacher signup
        /// </summary>
        [HttpPost("Signup")]
        public async Task<Result<long>> Signup([FromBody] SignUpDto dto)
        {
            return await _authOperations.StudentSignUp(dto);
        }
    }
}

