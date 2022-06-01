using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UMS.Business.Abstract.TeacherTransactions;
using UMS.Core;
using UMS.Dto;
using UMS.Repository.Abstract;

namespace UMS.Api.Controllers.Teacher
{
    [ApiController]
    [Route("api/teacher/[controller]")]
    [ApiExplorerSettings(GroupName = Constants.AuthenticationSchemes.Teacher)]
    public class StudentGradeController : Controller
    {
        private readonly IStudentGradeOperations _studentGradeOperations;

        /// <inheritdoc />
        public StudentGradeController(IStudentGradeOperations studentGradeOperations)
        {
            _studentGradeOperations = studentGradeOperations;
        }

        /// <summary>
        /// Returns a list of Courses for Teachers.
        /// </summary>
        [HttpGet("GetStudentGrades/{CourseId}")]
        public Result<IEnumerable<StudentGradeDto>> GetStudentGrades(long CourseId)
        {
            return _studentGradeOperations.GetStudentGrades(CourseId);
        }
    }
}
