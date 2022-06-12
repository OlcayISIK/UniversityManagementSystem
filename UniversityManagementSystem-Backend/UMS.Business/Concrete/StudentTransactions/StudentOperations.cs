using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Business.Abstract.StudentTransactions;
using UMS.Business.Helpers;
using UMS.Core.Enums;
using UMS.Core.InternalDtos;
using UMS.Data.Entities;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Dto;
using UMS.Dto.Student;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete.StudentTransactions
{
    public class StudentOperations : IStudentOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomMapper _mapper;

        public StudentOperations(IUnitOfWork unitOfWork, CustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Result<IEnumerable<StudentDto>> GetAll()
        {
            var query = _unitOfWork.Students.GetAll();
            var data =  _mapper.ProjectTo<StudentDto>(query);
            return Result<IEnumerable<StudentDto>>.CreateSuccessResult(data);
        }
        public async Task<Result<StudentDto>> Get(long id)
        {
            var query = _unitOfWork.Students.Get(id);
            var data = await _mapper.ProjectTo<StudentDto>(query).FirstOrDefaultAsync();
            return Result<StudentDto>.CreateSuccessResult(data);
        }
        public async Task<Result<bool>> Update(StudentDto studentDto)
        {
            var existingData = await _unitOfWork.Students.GetAsTracking(studentDto.Id).FirstOrDefaultAsync();
            if (existingData == null)
                return Result<bool>.CreateErrorResult(ErrorCode.ObjectNotFound);
            //if (studentDto.Image != null)
            //    studentDto.ImageId = await FileStorageHelper.AddOrUpdateImage(studentDto.Image, existingData.ImageId);
            _mapper.Map(studentDto, existingData,Language.English, _unitOfWork.Now);
            await _unitOfWork.Commit();
            return Result<bool>.CreateSuccessResult(true);
        }
        public async Task<Result<IEnumerable<StudentCourseDto>>> GetStudentCourses(long id)
        {
            var query =  _unitOfWork.StudentCourses.GetAll().Where(x => x.StudentId == id);
            if (query == null)
                return Result<IEnumerable<StudentCourseDto>>.CreateErrorResult(ErrorCode.ObjectNotFound);
            var data = _mapper.ProjectTo<StudentCourseDto>(query);
            return Result<IEnumerable<StudentCourseDto>>.CreateSuccessResult(data);
        }

        public async Task<Result<IEnumerable<StudentGradeDto>>> GetStudentGrades(long id)
        {
            var query = _unitOfWork.StudentGrades.GetAll().Where(x => x.StudentId == id);
            if (query == null)
                return Result<IEnumerable<StudentGradeDto>>.CreateErrorResult(ErrorCode.ObjectNotFound);
            var data = _mapper.ProjectTo<StudentGradeDto>(query);
            return Result<IEnumerable<StudentGradeDto>>.CreateSuccessResult(data);
        }
    }
}
