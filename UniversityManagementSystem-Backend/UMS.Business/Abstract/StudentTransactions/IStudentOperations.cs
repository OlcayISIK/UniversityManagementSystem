using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Dto;
using UMS.Dto.Student;

namespace UMS.Business.Abstract.StudentTransactions
{
    public interface IStudentOperations
    {
        Result<IEnumerable<StudentDto>> GetAll();
        Task<Result<StudentDto>> Get(long id);
        Task<Result<bool>> Update(StudentDto studentDto);
        Task<Result<IEnumerable<CourseDto>>> GetStudentCourses(long id);
        Task<Result<IEnumerable<StudentGradeDto>>> GetStudentGrades(long id);
    }
}
