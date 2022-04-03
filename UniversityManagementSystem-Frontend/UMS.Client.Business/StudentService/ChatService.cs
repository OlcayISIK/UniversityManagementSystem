using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Business.Interface.StudentService;
using UMS.Client.Core;
using UMS.Client.Dtos.Shared;
using UMS.Client.Dtos.Student;

namespace UMS.Client.Business.StudentService
{
    public class ChatService : IChatService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public ChatService(IHttpService httpService, NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<Result<IEnumerable<ChatMessage>>> Get(ChatDto chatDto)
        {
            var response = await _httpService.SendRequest<Result<IEnumerable<ChatMessage>>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Student.Chat.Get, chatDto);
            return response;
        }
        public async Task<Result<long>> Add(ChatMessage chatMessage)
        {
            var response = await _httpService.SendRequest<Result<long>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Student.Chat.Add, chatMessage);
            return response;
        }
    }
}
