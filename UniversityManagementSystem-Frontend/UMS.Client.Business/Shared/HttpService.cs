using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Core;
using UMS.Client.Core.Enums;
using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Shared
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorageService;
        private IConfiguration _configuration;

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new UMS.Client.Business.Helpers.StringConverter() }
        };


        public HttpService(
            HttpClient httpClient,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            IConfiguration configuration
        )
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            _configuration = configuration;
        }

        public async Task<T> SendRequest<T>(HttpMethod httpMethod, string uri, object value = null)
        {
            var request = createRequest(httpMethod, uri, value);
            //string language = await _localStorageService.GetMenuLanguage();
            //AddLanguageHeader(request, language);
            if (await EndpointNeedsAuthentication(uri))
                await AddJwtHeader(request);

            // send request
            using var response = await _httpClient.SendAsync(request);

            // return result if token is still valid
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // TODO fix this
                var currentAccessToken = await _localStorageService.GetAccessToken();
                var currentRefreshToken = await _localStorageService.GetRefreshToken();

                if (string.IsNullOrWhiteSpace(currentRefreshToken))
                {
                    _navigationManager.NavigateTo("account/logout");
                    return default;
                }
                var refreshSuccess = await RefreshAccessToken(currentAccessToken, currentRefreshToken);
                if (!refreshSuccess)
                {
                    _navigationManager.NavigateTo("account/logout");
                    return default;
                }
            }

            // send request
            request = createRequest(httpMethod, uri, value);
            //AddLanguageHeader(request, language);
            if (await EndpointNeedsAuthentication(uri))
                await AddJwtHeader(request);
            using var secondResponse = await _httpClient.SendAsync(request);

            if (secondResponse.IsSuccessStatusCode)
                return await secondResponse.Content.ReadFromJsonAsync<T>(_jsonSerializerOptions);

            throw new Exception("Error in sending request.");
        }

        // DO NOT USE THIS 
        public async Task RefreshAccessToken()
        {
            // TODO fix this
            var currentAccessToken = await _localStorageService.GetAccessToken();
            var currentRefreshToken = await _localStorageService.GetRefreshToken();
            await RefreshAccessToken(currentAccessToken, currentRefreshToken);
        }

        private async Task<bool> RefreshAccessToken(string accessToken, string refreshToken)
        {
            var tokenDto = new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
            var authWithTokenRoute = await GetAuthWithTokenRoute();
            var request = createRequest(HttpMethod.Post, authWithTokenRoute, tokenDto);
            using var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadFromJsonAsync<Result<TokenDto>>(_jsonSerializerOptions);
                if (tokenResponse.Success)
                {
                    await _localStorageService.SetAccessToken(tokenResponse.Data.AccessToken);
                    await _localStorageService.SetRefreshToken(tokenResponse.Data.RefreshToken);
                    return true;
                }

                if (tokenResponse.ErrorCode == ErrorCode.InvalidRefreshToken)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        private async Task<bool> EndpointNeedsAuthentication(string uri)
        {
            var authPassUrl = await GetAuthWithPasswordRoute();
            var authTokenUrl = await GetAuthWithTokenRoute();
            // || uri.Contains("userApproval") || uri.Contains("customerpasswordreset") || uri.Contains("userpasswordreset")
            return !(uri.EndsWith(authPassUrl) || uri.EndsWith(authTokenUrl));
        }

        private async Task AddJwtHeader(HttpRequestMessage request)
        {
            // add jwt auth header if user is logged in and request is to the api url
            var accessToken = await _localStorageService.GetAccessToken();
            var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            if (isApiUrl)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }
        }

        private HttpRequestMessage createRequest(HttpMethod method, string uri, object value = null)
        {
            var request = new HttpRequestMessage(method, uri);
            if (value != null)
                request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return request;
        }

        private async Task<string> GetAuthWithPasswordRoute()
        {
            var appType = await _localStorageService.GetApplicationType();
            //if (appType == ApplicationType.StudentPanel)
            //    return EndpointSettings.ServerRoutes.Student.Authentication.AuthenticateWithPassword;
            //else if (appType == ApplicationType.StudentRepresentativePanel)
            //    return EndpointSettings.ServerRoutes.StudentRepresentative.Authentication.AuthenticateWithPassword;
            if (appType == ApplicationType.TeacherPanel)
                return EndpointSettings.ServerRoutes.Teacher.Authentication.AuthenticateWithPassword;
            else if (appType == ApplicationType.StudentPanel)
                return EndpointSettings.ServerRoutes.Student.Authentication.AuthenticateWithPassword;
            return null;
        }

        private async Task<string> GetAuthWithTokenRoute()
        {
            var appType = await _localStorageService.GetApplicationType();
            if (appType == ApplicationType.StudentPanel)
                return EndpointSettings.ServerRoutes.Student.Authentication.AuthenticateWithToken;
            //else if (appType == ApplicationType.StudentRepresentativePanel)
            //    return EndpointSettings.ServerRoutes.StudentRepresentative.Authentication.AuthenticateWithToken;
            else if (appType == ApplicationType.TeacherPanel)
                return EndpointSettings.ServerRoutes.Teacher.Authentication.AuthenticateWithToken;
            return null;
        }

        private void AddLanguageHeader(HttpRequestMessage request, string language)
        {
            request.Headers.Add("Language", language);
        }
    }
}
