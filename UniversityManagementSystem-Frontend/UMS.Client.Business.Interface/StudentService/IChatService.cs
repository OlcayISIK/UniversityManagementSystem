using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos.Shared;
using UMS.Client.Dtos.Student;

namespace UMS.Client.Business.Interface.StudentService
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatMessage>>> Get(ChatDto chatDto);
        Task<Result<long>> Add(ChatMessage chatMessage);
    }
}
