using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using UMS.Business.Abstract.StudentTransactions;
using UMS.Business.Helpers;
using UMS.Business.Hubs;
using UMS.Core.Enums;
using UMS.Data.Entities;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Dto;
using UMS.Dto.Student;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete.StudentTransactions
{
    public class EventOperations : IEventOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomMapper _mapper;
        private readonly IHubContext<EventHub> _univeristyHub;
        private readonly IHubContext<EventHubForSocialClub> _socialClubHub;

        public EventOperations(IUnitOfWork unitOfWork, CustomMapper mapper, IHubContext<EventHub> univeristyHub, IHubContext<EventHubForSocialClub> socialClubHub)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _univeristyHub = univeristyHub;
            _socialClubHub = socialClubHub;
        }
        public Result<IEnumerable<EventDto>> GetAll()
        {
            var query = _unitOfWork.Events.GetAll();
            var data = _mapper.ProjectTo<EventDto>(query);
            return Result<IEnumerable<EventDto>>.CreateSuccessResult(data);
        }
        public async Task<Result<long>> PublishEventForUniversity(EventDto eventDto)
        {
            var clubEvent = _mapper.Map<Event>(eventDto);
            clubEvent.UniversityId = _unitOfWork.UniversityId;
            _unitOfWork.Events.Add(clubEvent);
            await _unitOfWork.Commit();
            await HubHelper.InvokeHubMethodForUniversity(_univeristyHub, clubEvent.UniversitySocialClubId, SocketMessageType.NewEventSentForUniversity);
            return Result<long>.CreateSuccessResult(clubEvent.Id);
        }
        public async Task<Result<long>> PublishEventForSocialClub(EventDto eventDto)
        {
            var clubEvent = _mapper.Map<Event>(eventDto);
            clubEvent.UniversityId = _unitOfWork.UniversityId;
            _unitOfWork.Events.Add(clubEvent);
            await _unitOfWork.Commit();
            await HubHelper.InvokeHubMethodForGroup(_socialClubHub, clubEvent.UniversityId, SocketMessageType.NewEventReleased);
            return Result<long>.CreateSuccessResult(clubEvent.Id);
        }
        public async Task<Result<bool>> Update(EventDto eventDto)
        {
            var existingData = await _unitOfWork.Events.GetAsTracking(eventDto.Id).FirstOrDefaultAsync();
            if (existingData == null)
                return Result<bool>.CreateErrorResult(ErrorCode.ObjectNotFound);
            //if (studentDto.Image != null)
            //    studentDto.ImageId = await FileStorageHelper.AddOrUpdateImage(studentDto.Image, existingData.ImageId);
            _mapper.Map(eventDto, existingData, Language.English, _unitOfWork.Now);
            await _unitOfWork.Commit();
            return Result<bool>.CreateSuccessResult(true);
        }
        public async Task<Result<bool>> Delete(long eventId)
        {
            _unitOfWork.Events.Remove(eventId);
            await _unitOfWork.Commit();
            return Result<bool>.CreateSuccessResult(true);
        }
        public async Task<Result<EventDto>> Get(long id)
        {
            var query = _unitOfWork.Events.Get(id);
            var data = await _mapper.ProjectTo<EventDto>(query).FirstOrDefaultAsync();
            return Result<EventDto>.CreateSuccessResult(data);
        }
        public async Task<Result<bool>> Join(long id)
        {
            var existingData = await _unitOfWork.Events.GetAsTracking(id).FirstOrDefaultAsync();
            if (existingData == null)
                return Result<bool>.CreateErrorResult(ErrorCode.ObjectNotFound);
            if (existingData.Participants >= existingData.Quota)
                return Result<bool>.CreateErrorResult(ErrorCode.InvalidAction);
            existingData.Participants += 1;
            await _unitOfWork.Commit();
            return Result<bool>.CreateSuccessResult(true);
        }

    }
}
