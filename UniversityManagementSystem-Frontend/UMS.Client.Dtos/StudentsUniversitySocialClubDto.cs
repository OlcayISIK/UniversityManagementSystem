using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos.Student;
using UMS.Client.Dtos.Teacher;

namespace UMS.Client.Dtos
{
    public class StudentsUniversitySocialClubDto
    {
        public long StudentId { get; set; }
        public long UniversitySocialClubId { get; set; }
        public StudentDto Student { get; set; }
        public CourseInstructorDto CourseInstructor { get; set; }
    }
}
