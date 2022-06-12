using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos;
using UMS.Client.Dtos.Shared;
using UMS.Client.Dtos.Student;

namespace UMS.Client.Business.Interface.StudentService
{
    public interface IStudentService
    {
        Task<Result<IEnumerable<StudentDto>>> GetAll();
        Task<Result<StudentDto>> Get(long userId);
        Task<Result<bool>> Update(StudentDto studentDto);
        Task<Result<IEnumerable<StudentCourseDto>>> GetStudentCourses(long id);
        Task<Result<IEnumerable<StudentGradeDto>>> GetStudentGrades(long id);
    }
}
