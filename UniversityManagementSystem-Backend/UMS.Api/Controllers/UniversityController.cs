using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UMS.Business.Abstract;
using UMS.Core;
using UMS.Dto;
using UMS.Repository.Abstract;

namespace UMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UniversityController : Controller
    {
        private readonly IUniversityOperations _universityOperations;

        /// <inheritdoc />
        public UniversityController(IUniversityOperations universityOperations)
        {
            _universityOperations = universityOperations;
        }
        /// <summary>
        /// Returns a list of Universities.
        /// </summary>
        [HttpGet("getAll")]
        public Result<IEnumerable<UniversityDto>> GetAll()
        {
            return _universityOperations.GetAll();
        }
    }
}
