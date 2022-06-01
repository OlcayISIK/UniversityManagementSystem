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
    [ApiExplorerSettings(GroupName = Constants.AuthenticationSchemes.Teacher)]
    public class FileController : Controller
    {
        private readonly IFileOperations _fileOperations;

        /// <inheritdoc />
        public FileController(IFileOperations fileOperations)
        {
            _fileOperations = fileOperations;
        }

        [HttpPost]
        public async Task<Result<bool>> Uploadfile(FileDto fileDto)
        {
            return await _fileOperations.UploadFiles(fileDto);
        }
    }
}