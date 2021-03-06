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
        public long StudentCourseId { get; set; }
        public long? FileId { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public UserStatus Status { get; set; }
        public bool IsStudentRepresentative { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<StudentsUniversitySocialClub> StudentsUniversitySocialClubs { get; set; }
        public virtual ICollection<File> Files{ get; set; }
    }
}
