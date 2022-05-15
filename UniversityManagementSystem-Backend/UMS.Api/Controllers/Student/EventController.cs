using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UMS.Business.Abstract.StudentTransactions;
using UMS.Core;
using UMS.Dto;
using UMS.Dto.Student;

namespace UMS.Api.Controllers.Student
{
    [ApiController]
    [Route("api/student/[controller]")]
    [ApiExplorerSettings(GroupName = Constants.AuthenticationSchemes.Student)]
    public class EventController : Controller
    {
        private readonly IEventOperations _eventOperations;

        /// <inheritdoc />
        public EventController(IEventOperations eventOperations)
        {
            _eventOperations = eventOperations;
        }
        /// <summary>
        /// Returns a list of Events.
        /// </summary>
        [HttpGet("getAll")]
        public Result<IEnumerable<EventDto>> GetAll()
        {
            return _eventOperations.GetAll();
        }
        /// <summary>
        /// Publish Event for University.
        /// </summary>
        [HttpPost("publishEventForUniversity")]
        public async Task<Result<long>> PublishEventForUniversityAsync(EventDto eventDto)
        {
            return await _eventOperations.PublishEventForUniversity(eventDto);
        }
        /// <summary>
        /// Publish Event for Social Club Members.
        /// </summary>
        [HttpPost("publishEventForSocialClub")]
        public async Task<Result<long>> PublishEventForSocialClubAsync(EventDto eventDto)
        {
            return await _eventOperations.PublishEventForSocialClub(eventDto);
        }
        /// <summary>
        /// Update Event
        /// </summary>
        [HttpPut("update")]
        public async Task<Result<bool>> Update(EventDto eventDto)
        {
            return await _eventOperations.Update(eventDto);
        }
        /// <summary>
        /// Delete Event
        /// </summary>
        [HttpDelete("delete/{eventId}")]
        public async Task<Result<bool>> Delete(long eventId)
        {
            return await _eventOperations.Delete(eventId);
        }

        [HttpPost("join/{eventId}")]
        public async Task<Result<bool>> Join(long eventId)
        {
            return await _eventOperations.Join(eventId);
        }
    }
}
