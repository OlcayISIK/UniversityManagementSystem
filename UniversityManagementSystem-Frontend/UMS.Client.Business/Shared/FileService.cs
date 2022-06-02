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
    public class FileService : IFileService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public FileService(IHttpService httpService,NavigationManager navigationManager,ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<Result<bool>> Uploadfile(FileDto fileDto)
        {
            return await _httpService.SendRequest<Result<bool>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Teacher.FileService.UploadFile, fileDto);
        }
        public async Task<Result<IEnumerable<FileDto>>> GetAll()
        {
            var response = await _httpService.SendRequest<Result<IEnumerable<FileDto>>>(HttpMethod.Get, EndpointSettings.ServerRoutes.Teacher.FileService.GetAll);
            return response;
        }
    }
}