using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Dto.Student;
using UMS.Dto.Teacher;

namespace UMS.Dto
{
    public class StudentsUniversitySocialClubDto
    {
        public long StudentId { get; set; }
        public long UniversitySocialClubId { get; set; }
        public StudentDto Student { get; set; }
        public CourseInstructorDto CourseInstructor { get; set;}
    }
}
