using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Dto;

namespace UMS.Business.Abstract.TeacherTransactions
{
    public interface IStudentGradeOperations
    {
        Result<IEnumerable<StudentGradeDto>> GetStudentGrades(long CourseId);
    }
}
