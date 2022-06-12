using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.EF;
using UMS.Data.Entities.UniversityBoundEntities;
using UMS.Repository.Abstract;
using UMS.Repository.Shared.GenericRepositories;

namespace UMS.Repository.Concrete
{
    public class StudentCourseRepository : Repository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(Context context) : base(context)
        {
        }

    }
}
