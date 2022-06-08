using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMS.Business.Abstract.TeacherTransactions;
using UMS.Business.Helpers;
using UMS.Core.Enums;
using UMS.Dto;
using UMS.Dto.Student;
using UMS.Dto.Teacher;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete.TeacherTransactions
{
    internal class TeacherOperations : ITeacherOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomMapper _mapper;

        public TeacherOperations(IUnitOfWork unitOfWork, CustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Result<IEnumerable<CourseInstructorDto>> GetAll()
        {
            var query = _unitOfWork.Teachers.GetAll();
            var data = _mapper.ProjectTo<CourseInstructorDto>(query);
            return Result<IEnumerable<CourseInstructorDto>>.CreateSuccessResult(data);
        }
        public async Task<Result<CourseInstructorDto>> Get(long id)
        {
            var query = _unitOfWork.Teachers.Get(id);
            var data = await _mapper.ProjectTo<CourseInstructorDto>(query).FirstOrDefaultAsync();
            return Result<CourseInstructorDto>.CreateSuccessResult(data);
        }
        public async Task<Result<CourseDto>> GetStudents(long courseInstructorId)
        {
            var query = _unitOfWork.Courses.GetAll().Where(x => x.CourseInstructorId == courseInstructorId);
            var data = await _mapper.ProjectTo<CourseDto>(query).FirstOrDefaultAsync();
            return Result<CourseDto>.CreateSuccessResult(data);
        }
        public async Task<Result<bool>> Update(CourseInstructorDto courseInstructorDto)
        {
            var existingData = await _unitOfWork.Students.GetAsTracking(courseInstructorDto.Id).FirstOrDefaultAsync();
            if (existingData == null)
                return Result<bool>.CreateErrorResult(ErrorCode.ObjectNotFound);
            //if (studentDto.Image != null)
            //    studentDto.ImageId = await FileStorageHelper.AddOrUpdateImage(studentDto.Image, existingData.ImageId);
            _mapper.Map(courseInstructorDto, existingData, Language.English, _unitOfWork.Now);
            await _unitOfWork.Commit();
            return Result<bool>.CreateSuccessResult(true);
        }
    }
}
