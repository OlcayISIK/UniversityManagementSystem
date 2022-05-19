using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMS.Business.Helpers;
using UMS.Core.Enums;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Dto;
using UMS.Dto.Student;
using UMS.Repository.Shared;

namespace UMS.Business.Abstract.StudentTransactions
{
    public class UniversitySocialClubOperations : IUniversitySocialClubOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomMapper _mapper;

        public UniversitySocialClubOperations(IUnitOfWork unitOfWork, CustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<IEnumerable<UniversitySocialClubDto>> GetAll()
        {
            var query = _unitOfWork.UniversitySocialClubs.GetParticipantsOfSocialClub();
            var data =  _mapper.ProjectTo<UniversitySocialClubDto>(query);
            return Result<IEnumerable<UniversitySocialClubDto>>.CreateSuccessResult(data);
        }

        public async Task<Result<bool>> Join(StudentsUniversitySocialClubDto studentsUniversitySocialClubDto)
        {
            var existingData = await _unitOfWork.Students.GetStudentSocialClubs().Where(x => !x.IsDeleted && x.Id == studentsUniversitySocialClubDto.StudentId).FirstOrDefaultAsync();
            if (existingData == null)
                return Result<bool>.CreateErrorResult(ErrorCode.ObjectNotFound);
            var newConnection = new StudentsUniversitySocialClub()
            {
                StudentId = studentsUniversitySocialClubDto.StudentId,
                UniversitySocialClubId = studentsUniversitySocialClubDto.UniversitySocialClubId
            };
            existingData.StudentsUniversitySocialClubs.Add(newConnection);
            await _unitOfWork.Commit();
            return Result<bool>.CreateSuccessResult(true);
        }
    }
}
