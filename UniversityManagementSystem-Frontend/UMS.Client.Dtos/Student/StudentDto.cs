using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Core.Enums;

namespace UMS.Client.Dtos.Student
{
    public class StudentDto
    {
        public long Id { get; set; }
        public long StudentCourseId { get; set; }
        public long? UniversitySocialClubId { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public UserStatus Status { get; set; }
        public bool IsStudentRepresentative { get; set; }
        public virtual ICollection<StudentCourseDto> StudentCourses { get; set; }
        public virtual ICollection<StudentsUniversitySocialClubDto> StudentsUniversitySocialClubs { get; set; }
    }
}
