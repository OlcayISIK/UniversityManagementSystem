using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Core;
using UMS.Client.Core.Enums;
using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Shared
{
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public AuthenticationService(IHttpService httpService,NavigationManager navigationManager,ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            var url = _navigationManager.Uri.ToLower();
            if (url.Contains("admin/login"))
            {
                return;
            }
            const long millisecondsOf8Hour = 28800000;
            try
            {
                DateTime refreshToken = await _localStorageService.GetRefreshTokenTime();
                if ((DateTime.Now.ToUniversalTime() - refreshToken).TotalMilliseconds > millisecondsOf8Hour)
                {
                    // Go Logout if eight hour passed before last login.
                    _navigationManager.NavigateTo("/account/logout");
                    return;
                }
            }
            catch
            {
                _navigationManager.NavigateTo("/account/logout");
                return;
            }
            IsLoggedInNonAsync = await IsLoggedIn();
        }
        public bool IsLoggedInNonAsync { get; set; }

        public async Task<bool> IsLoggedIn()
        {
            // TODO fix this. It should check if refresh token is expired or not
            var accessToken = await _localStorageService.GetAccessToken();
            return accessToken != null;
        }

        #region Student
        public async Task<Result<TokenDto>> StudentAuthenticateViaPassword(LoginDto loginDto)
        {
            var response = await _httpService.SendRequest<Result<TokenDto>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Student.Authentication.AuthenticateWithPassword, loginDto);
            if (response.Data == null)
            {
                return response;
            }
            await _localStorageService.SetAccessToken(response.Data.AccessToken);
            await _localStorageService.SetRefreshToken(response.Data.RefreshToken);
            await _localStorageService.SetApplicationType(ApplicationType.StudentPanel);
            IsLoggedInNonAsync = true;
            return response;
        }

        public Task<Result<bool>> StudentForgotPassword(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> StudentLogout(string refreshToken)
        {
            var response = await _httpService.SendRequest<Result<bool>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Student.Authentication.Logout, refreshToken);
            IsLoggedInNonAsync = false;
            await _localStorageService.RemoveTokens();
            _navigationManager.NavigateTo("user/StudentLogin");
            return response;
        }

        public async Task<Result<bool>> StudentResetPassword(ResetPasswordDto dto)
        {
            Console.WriteLine("debug");
            return await _httpService.SendRequest<Result<bool>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Student.Authentication.ResetPassword, dto);
        }

        public  async Task<Result<long>> StudentSignUp(SignUpDto dto)
        {
            return  await _httpService.SendRequest<Result<long>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Student.Authentication.Signup, dto);
        }
        #endregion

        #region StudentRespresentative
        //public Task<Result<TokenDto>> StudentRespresentativeAuthenticateViaPassword(LoginDto loginDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Result<bool>> StudentRespresentativeForgotPassword(string emailAddress)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Result<bool>> StudentRespresentativeLogout(string refreshToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Result<bool>> StudentRespresentativeResetPassword(ResetPasswordDto dto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Result<long>> StudentRespresentativeSignUp(SignUpDto dto)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        #region Teacher
        public async Task<Result<TokenDto>> TeacherAuthenticateViaPassword(LoginDto loginDto)
        {
            var response = await _httpService.SendRequest<Result<TokenDto>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Teacher.Authentication.AuthenticateWithPassword, loginDto);
            if (response.Data == null)
            {
                return response;
            }
            await _localStorageService.SetAccessToken(response.Data.AccessToken);
            await _localStorageService.SetRefreshToken(response.Data.RefreshToken);
            await _localStorageService.SetApplicationType(ApplicationType.TeacherPanel);
            IsLoggedInNonAsync = true;
            return response;
        }

        public Task<Result<bool>> TeacherForgotPassword(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public async Task TeacherLogout(string refreshToken)
        {
            IsLoggedInNonAsync = false;
            await _localStorageService.RemoveTokens();
            _navigationManager.NavigateTo("teacher/login");
        }

        public async Task<Result<bool>> TeacherResetPassword(ResetPasswordDto dto)
        {
            return await _httpService.SendRequest<Result<bool>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Teacher.Authentication.ResetPassword, dto);
        }

        public async Task<Result<long>> TeacherSignUp(SignUpDto dto)
        {
            return await _httpService.SendRequest<Result<long>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Teacher.Authentication.Signup, dto);
        }

        #endregion

    }
}