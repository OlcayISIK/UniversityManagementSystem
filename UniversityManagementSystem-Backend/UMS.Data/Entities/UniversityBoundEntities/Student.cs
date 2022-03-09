using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core.Enums;

namespace UMS.Data.Entities.UniversityBoundEntities
{
    public class Student : UniversityBoundEntity
    {
        public long StudentId { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public int CourseId { get; set; }
        public int CourseInstructorId { get; set; }
        public UserStatus Status { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
