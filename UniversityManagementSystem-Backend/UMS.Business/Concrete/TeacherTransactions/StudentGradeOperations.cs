using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Business.Abstract.TeacherTransactions;
using UMS.Business.Helpers;
using UMS.Data.Entities;
using UMS.Dto;
using UMS.Dto.Teacher;
using UMS.Repository.Abstract;
using UMS.Repository.Shared;

namespace UMS.Business.Concrete.TeacherTransactions
{
    public class StudentGradeOperations : IStudentGradeOperations
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CustomMapper _mapper;

        public StudentGradeOperations(IUnitOfWork unitOfWork, CustomMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Result<IEnumerable<StudentGradeDto>> GetStudentGrades(long CourseId)
        {
            var query = _unitOfWork.StudentGrades.GetStudentGrades(CourseId);
            var data = _mapper.ProjectTo<StudentGradeDto>(query);
            return Result<IEnumerable<StudentGradeDto>>.CreateSuccessResult(data);
        }
    }
}
