using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMS.Business.Abstract.Shared;
using UMS.Core;
using UMS.Dto;

namespace UMS.Api.Controllers.Teacher
{
    [ApiController]
    [Route("api/teacher/[controller]")]
    [ApiExplorerSettings(GroupName = Constants.AuthenticationSchemes.Student)]
    public class FileController : Controller
    {
        private readonly IFileOperations _fileOperations;

        /// <inheritdoc />
        public FileController(IFileOperations fileOperations)
        {
            _fileOperations = fileOperations;
        }

        [HttpPost("UploadFile")]
        public async Task<Result<bool>> Uploadfile(FileDto fileDto)
        {
            return await _fileOperations.UploadFiles(fileDto);
        }
        [HttpGet("GetAll/{studentId}")]
        public async Task<Result<IEnumerable<FileDto>>> GetAll(long studentId)
        {
            return await _fileOperations.GetAll(studentId);
        }

        [HttpGet("GetAllForTeacher/{courseInstructorId}")]
        public async Task<Result<IEnumerable<FileDto>>> GetAllForTeacher(long courseInstructorId)
        {
            return await _fileOperations.GetAllForTeacher(courseInstructorId);
        }

        [HttpGet("Get/{fileId}")]
        public Result<IEnumerable<FileDto>> Get(long fileId)
        {
            return _fileOperations.Get(fileId);
        }
    }
}