using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos.Shared;
using UMS.Client.Dtos.Student;

namespace UMS.Client.Business.Interface.StudentService
{
    public interface IEventService
    {
        Task<Result<IEnumerable<EventDto>>> GetAll();
        Task<long> PublishEventForUniversity(EventDto eventDto);
        Task<long> PublishEventForSocialClub(EventDto eventDto);
        Task<Result<bool>> Update(EventDto eventDto);
        Task<Result<bool>> Delete(long id);
        Task<Result<bool>> Join(long id);


    }
}
