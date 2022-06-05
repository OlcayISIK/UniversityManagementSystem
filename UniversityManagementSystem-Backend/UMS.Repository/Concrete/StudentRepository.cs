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
    public class StudentRepository : UniversityBoundRepository<Student>, IStudentRepository
    {
        public StudentRepository(Context context) : base(context)
        {
        }
        public IQueryable<Student> GetStudentSocialClubs()
        {
            IQueryable<Student> query = Context.Students
                .Include(student => student.StudentsUniversitySocialClubs)
                .ThenInclude(universityClub => universityClub.UniversitySocialClub);
            return query;
        }

    }
}
