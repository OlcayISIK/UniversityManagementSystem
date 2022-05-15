using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Dto;
using UMS.Dto.Student;
using UMS.Dto.Teacher;

namespace UMS.Business.Abstract.TeacherTransactions
{
    public interface ITeacherOperations
    {
        Result<IEnumerable<CourseInstructorDto>> GetAll();
        Task<Result<CourseInstructorDto>> Get(long id);
        Task<Result<bool>> Update(CourseInstructorDto courseInstructorDto);
    }
}
