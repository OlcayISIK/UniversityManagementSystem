using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UMS.Data.EF;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Repository.Abstract;
using UMS.Repository.Shared.GenericRepositories;

namespace UMS.Repository.Concrete
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(Context context) : base(context)
        {
        }
        public IQueryable<Course> GetStudentCourses(long id)
        {
            IQueryable<Course> query = Context.Courses
                .Include(student => student.StudentCourses.Where(o => o.StudentId == id))
                .ThenInclude(studentcourse => studentcourse.Student);
            return query;
        }

    }
}
