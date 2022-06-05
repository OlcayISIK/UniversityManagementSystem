using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.Entities;
using UMS.Repository.Shared.GenericRepositories;

namespace UMS.Repository.Abstract
{
    public interface IStudentGradeRepository : IUniversityBoundRepository<StudentGrade>
    {
        IQueryable<StudentGrade> GetStudentGrades(long CourseId);
    }
}
