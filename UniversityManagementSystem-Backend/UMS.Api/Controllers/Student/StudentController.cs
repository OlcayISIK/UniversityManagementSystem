﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UMS.Business.Abstract.StudentTransactions;
using UMS.Core;
using UMS.Dto;
using UMS.Dto.Student;

namespace UMS.Api.Controllers.Student
{
    [ApiController]
    [Route("api/student/[controller]")]
    [ApiExplorerSettings(GroupName = Constants.AuthenticationSchemes.Student)]
    public class StudentController : Controller
    {
        private readonly IStudentOperations _studentOperations;

        /// <inheritdoc />
        public StudentController(IStudentOperations studentOperations)
        {
            _studentOperations = studentOperations;
        }

        /// <summary>
        /// Returns a list of Students.
        /// </summary>
        [HttpGet("getAll")]
        public Result<IEnumerable<StudentDto>> GetAll()
        {
            return _studentOperations.GetAll();
        }

        /// <summary>
        /// Return a spesific Student.
        /// </summary>
        [HttpGet("get/{userId}")]
        public async Task<Result<StudentDto>> Get(long userId)
        {
            return await _studentOperations.Get(userId);
        }
    }
}