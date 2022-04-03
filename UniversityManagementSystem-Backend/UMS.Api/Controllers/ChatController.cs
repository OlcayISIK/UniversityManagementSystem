using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UMS.Business.Abstract.StudentTransactions;
using UMS.Core;
using UMS.Data.Entities;
using UMS.Dto;
using UMS.Dto.Student;

namespace UMS.Api.Controllers
{
    [ApiController]
    [Route("api/student/[controller]")]
    [ApiExplorerSettings(GroupName = Constants.AuthenticationSchemes.Student)]
    public class ChatController : Controller
    {
        private readonly IChatOperations _chatOperations;
        private readonly IStudentOperations _studentOperations;


        /// <inheritdoc />
        public ChatController(IChatOperations chatOperations, IStudentOperations studentOperations)
        {
            _chatOperations = chatOperations;
            _studentOperations = studentOperations;
        }

        [HttpPost("getConversation")]
        public async Task<Result<IEnumerable<ChatMessage>>> GetConversation(ChatDto chatDto)
        {
            var userId = chatDto.UserId;
            var contactId = chatDto.ContactId;
            var messages = await _chatOperations.Get(contactId,userId);
            return messages;
        }
        [HttpPost("AddMessage")]
        public async Task<Result<long>> AddMessage(ChatMessageDto message)
        {
            return await _chatOperations.Add(message);
        }
    }
}
