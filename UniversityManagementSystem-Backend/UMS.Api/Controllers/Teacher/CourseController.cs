using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UMS.Business.Abstract.Shared;
using UMS.Core;
using UMS.Dto;

namespace UMS.Api.Controllers.Teacher
{
    [ApiController]
    [Route("api/teacher/[controller]")]
    [ApiExplorerSettings(GroupName = Constants.AuthenticationSchemes.Teacher)]
    public class CourseController : Controller
    {
        private readonly ICourseOperations _courseOperations;

        /// <inheritdoc />
        public CourseController(ICourseOperations courseOperations)
        {
            _courseOperations = courseOperations;
        }

        /// <summary>
        /// Returns a list of Courses for Teachers.
        /// </summary>
        [HttpGet("getAll/{courseInstructorId}")]
        public Result<IEnumerable<CourseDto>> GetAll(long courseInstructorId)
        {
            return _courseOperations.GetAll(courseInstructorId);
        }

    }
}
