using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UMS.Business.Abstract.TeacherTransactions;
using UMS.Core;
using UMS.Dto;
using UMS.Dto.Student;
using UMS.Dto.Teacher;

namespace UMS.Api.Controllers.Teacher
{
    [ApiController]
    [Route("api/teacher/[controller]")]
    [ApiExplorerSettings(GroupName = Constants.AuthenticationSchemes.Teacher)]
    public class TeacherController : Controller
    {
        private readonly ITeacherOperations _teacherOperations;

        /// <inheritdoc />
        public TeacherController(ITeacherOperations teacherOperations)
        {
            _teacherOperations = teacherOperations;
        }

        /// <summary>
        /// Returns a list of Teachers.
        /// </summary>
        [HttpGet("getAll")]
        public Result<IEnumerable<CourseInstructorDto>> GetAll()
        {
            return _teacherOperations.GetAll();
        }

        /// <summary>
        /// Return a spesific Teacher.
        /// </summary>
        [HttpGet("get/{userId}")]
        public async Task<Result<CourseInstructorDto>> Get(long userId)
        {
            return await _teacherOperations.Get(userId);
        }
        /// <summary>
        /// Update a spesific Teacher.
        /// </summary>
        [HttpPut("update")]
        public async Task<Result<bool>> Update(CourseInstructorDto courseInstructorDto)
        {
            return await _teacherOperations.Update(courseInstructorDto);
        }
    }
}
