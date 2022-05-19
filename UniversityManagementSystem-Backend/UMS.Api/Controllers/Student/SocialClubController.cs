using Microsoft.AspNetCore.Mvc;
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
    public class SocialClubController : Controller
    {
        private readonly IUniversitySocialClubOperations _socialClubOperations;

        /// <inheritdoc />
        public SocialClubController(IUniversitySocialClubOperations socialClubOperations)
        {
            _socialClubOperations = socialClubOperations;
        }
        /// <summary>
        /// Returns a list of university social clubs.
        /// </summary>
        [HttpGet("getAll")]
        public Result<IEnumerable<UniversitySocialClubDto>> GetAll()
        {
            return _socialClubOperations.GetAll();
        }
        [HttpPost("join")]
        public async Task<Result<bool>> Join(StudentsUniversitySocialClubDto studentsUniversitySocialClubDto)
        {
            return await _socialClubOperations.Join(studentsUniversitySocialClubDto);
        }
    }
}
