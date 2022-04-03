using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.Entities;
using UMS.Dto;
using UMS.Dto.Student;

namespace UMS.Business.Abstract.StudentTransactions
{
    public interface IChatOperations
    {
        Task<Result<IEnumerable<ChatMessage>>> Get(long contactId, long userId);
        Task<Result<long>> Add(ChatMessageDto chatMessage);
    }
}
