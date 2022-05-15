using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Dto;
using UMS.Dto.Student;

namespace UMS.Business.Abstract.StudentTransactions
{
    public interface IEventOperations
    {
        Task<Result<long>> PublishEventForSocialClub(EventDto eventDto);
        Task<Result<long>> PublishEventForUniversity(EventDto eventDto);
        Result<IEnumerable<EventDto>> GetAll();
        Task<Result<bool>> Update(EventDto eventDto);
        Task<Result<bool>> Delete(long eventId);
        Task<Result<bool>> Join(long id);
    }
}
