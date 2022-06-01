using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Business.Interface.Teacher;
using UMS.Client.Core;
using UMS.Client.Dtos;
using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Teacher
{
    public class StudentGradeService : IStudentGradeService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public StudentGradeService(IHttpService httpService, NavigationManager navigationManager,
            ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<Result<IEnumerable<StudentGradeDto>>> GetStudentGrades(long CourseId)
        {
            var response = await _httpService.SendRequest<Result<IEnumerable<StudentGradeDto>>>(HttpMethod.Get, EndpointSettings.ServerRoutes.Teacher.StudentGradeService.GetStudentGrades + $"/{CourseId}");
            return response;
        }
    }
}
