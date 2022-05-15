using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Business.Interface.StudentService;
using UMS.Client.Core;
using UMS.Client.Dtos.Shared;
using UMS.Client.Dtos.Student;
namespace UMS.Client.Business.StudentService
{
    public class EventService : IEventService
    {

        public EventDto Event { get; set; }

        private IHttpService _httpService;

        public EventService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Result<IEnumerable<EventDto>>> GetAll()
        {
            return  await _httpService.SendRequest<Result<IEnumerable<EventDto>>>(HttpMethod.Get, EndpointSettings.ServerRoutes.Student.Event.GetAll);
        }
        public async Task<long> PublishEventForUniversity(EventDto eventDto)
        {
            var result = await _httpService.SendRequest<Result<long>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Student.Event.PublishEventForUniversity, eventDto);
            return result.Data;
        }

        public async Task<long> PublishEventForSocialClub(EventDto eventDto)
        {
            var result = await _httpService.SendRequest<Result<long>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Student.Event.PublishEventForSocialClub, eventDto);
            return result.Data;
        }

        public async Task<Result<bool>> Update(EventDto eventDto)
        {
            return await _httpService.SendRequest<Result<bool>>(HttpMethod.Put, EndpointSettings.ServerRoutes.Student.Event.Update, eventDto);
        }
        public async Task<Result<bool>> Delete(long id)
        {
            return await _httpService.SendRequest<Result<bool>>(HttpMethod.Delete, EndpointSettings.ServerRoutes.Student.Event.Delete + $"/{id}");
        }
        public async Task<Result<bool>> Join(long id)
        {
            return await _httpService.SendRequest<Result<bool>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Student.Event.Join + $"/{id}");
        }
    }
}
