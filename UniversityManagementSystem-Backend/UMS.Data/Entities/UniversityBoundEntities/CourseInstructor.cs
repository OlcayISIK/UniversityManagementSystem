using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core.Enums;

namespace UMS.Data.Entities.UniversityBoundEntities
{
    public class CourseInstructor : UniversityBoundEntity
    {
        public long CourseId { get; set; }
        public long UniversitySocialClubId { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public UserStatus Status { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public UniversitySocialClub UniversitySocialClub { get; set; }
    }
}
