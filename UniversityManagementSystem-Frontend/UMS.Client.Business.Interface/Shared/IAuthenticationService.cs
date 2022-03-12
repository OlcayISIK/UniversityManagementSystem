using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Interface.Shared
{
    public interface IAuthenticationService
    {
        #region Teacher

        Task<Result<TokenDto>> TeacherAuthenticateViaPassword(LoginDto loginDto);
        //Task<Result<TokenDto>> TeacherAuthenticateViaToken(string refreshToken);
        Task<Result<long>> TeacherSignUp(SignUpDto dto);
        Task TeacherLogout(string refreshToken);
        Task<Result<bool>> TeacherForgotPassword(string emailAddress);
        Task<Result<bool>> TeacherResetPassword(ResetPasswordDto dto);

        #endregion

        #region Student

        Task<Result<TokenDto>> StudentAuthenticateViaPassword(LoginDto loginDto);
        //Task<Result<TokenDto>> StudentAuthenticateViaToken(string refreshToken);
        Task<Result<bool>> StudentLogout(string refreshToken);
        Task<Result<long>> StudentSignUp(SignUpDto dto);
        Task<Result<bool>> StudentForgotPassword(string emailAddress);
        Task<Result<bool>> StudentResetPassword(ResetPasswordDto dto);

        #endregion

        #region StudentRespresentative

        Task<Result<TokenDto>> StudentRespresentativeAuthenticateViaPassword(LoginDto loginDto);
        //Task<Result<TokenDto>> StudentRespresentativeAuthenticateViaToken(string refreshToken);
        Task<Result<bool>> StudentRespresentativeLogout(string refreshToken);
        Task<Result<long>> StudentRespresentativeSignUp(SignUpDto dto);
        Task<Result<bool>> StudentRespresentativeForgotPassword(string emailAddress);
        Task<Result<bool>> StudentRespresentativeResetPassword(ResetPasswordDto dto);

        #endregion

    }
}
