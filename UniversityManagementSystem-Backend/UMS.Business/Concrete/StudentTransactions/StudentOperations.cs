using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Business.Abstract.StudentTransactions;
using UMS.Business.Helpers;
using UMS.Core.InternalDtos;
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
    }
}
