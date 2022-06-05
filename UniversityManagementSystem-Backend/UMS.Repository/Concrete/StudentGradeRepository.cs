using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMS.Data.EF;
using UMS.Data.Entities;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Repository.Abstract;
using UMS.Repository.Shared.GenericRepositories;

namespace UMS.Repository.Concrete
{
    public class StudentGradeRepository : UniversityBoundRepository<StudentGrade>, IStudentGradeRepository
    {
        public StudentGradeRepository(Context context) : base(context)
        {
        }

        public IQueryable<StudentGrade> GetStudentGrades(long CourseId)
        {
            IQueryable<StudentGrade> query = Context.StudentGrades
                .Include(student => student.Student).Where(x => x.CourseId == CourseId);
            return query;
        }
    }
}
