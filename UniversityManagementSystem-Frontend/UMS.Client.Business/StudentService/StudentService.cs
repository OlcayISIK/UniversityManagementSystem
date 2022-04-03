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
    public class StudentService : IStudentService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public StudentService(IHttpService httpService, NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<Result<IEnumerable<StudentDto>>> GetAll()
        {
            var response = await _httpService.SendRequest<Result<IEnumerable<StudentDto>>>(HttpMethod.Get, EndpointSettings.ServerRoutes.Student.StudentService.GetAll);
            return response;
        }
        public async Task<Result<StudentDto>> Get(long userId)
        {
            var response = await _httpService.SendRequest<Result<StudentDto>>(HttpMethod.Get, EndpointSettings.ServerRoutes.Student.StudentService.Get + $"/{userId}");
            return response;
        }
    }
}
