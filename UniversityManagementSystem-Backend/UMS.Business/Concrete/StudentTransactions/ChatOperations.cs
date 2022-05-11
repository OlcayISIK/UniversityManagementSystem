using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Business.Abstract.StudentTransactions;
using UMS.Business.Helpers;
using UMS.Data.Entities;
using UMS.Dto;
using UMS.Dto.Student;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete.StudentTransactions
{
    public class ChatOperations : IChatOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomMapper _mapper;

        public ChatOperations(IUnitOfWork unitOfWork, CustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<ChatMessage>>> Get(long contactId, long userId)
        {
            var query = await _unitOfWork.ChatMessages
            .Where(h => (h.FromUserId == contactId && h.ToUserId == userId) || (h.FromUserId == userId && h.ToUserId == contactId))
            .OrderBy(a => a.CreatedAt)
            .Include(a => a.ToUser)
            .Include(a => a.FromUser)
            .Select(x => new ChatMessage
            {
                FromUserId = x.FromUserId,
                Message = x.Message,
                CreatedAt = x.CreatedAt,
                Id = x.Id,
                FromUser = x.FromUser,
                ToUserId = x.ToUserId,
                ToUser = x.ToUser,
            }).ToListAsync();
            return Result<IEnumerable<ChatMessage>>.CreateSuccessResult(query);
        }

        public async Task<Result<long>> Add(ChatMessageDto messageDto)
        {
            var message = _mapper.Map<ChatMessage>(messageDto);
            //message.ToUser = _unitOfWork.Students.Get(message.ToUserId).FirstOrDefault();
            _unitOfWork.ChatMessages.Add(message);
            await _unitOfWork.Commit();
            return Result<long>.CreateSuccessResult(message.Id);
        }
    }
}
