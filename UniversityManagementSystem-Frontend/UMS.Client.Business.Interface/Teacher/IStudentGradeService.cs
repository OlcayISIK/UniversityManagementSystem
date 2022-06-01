using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos;
using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Interface.Teacher
{
    public interface IStudentGradeService
    {
        Task<Result<IEnumerable<StudentGradeDto>>> GetStudentGrades(long CourseId);
    }
}
