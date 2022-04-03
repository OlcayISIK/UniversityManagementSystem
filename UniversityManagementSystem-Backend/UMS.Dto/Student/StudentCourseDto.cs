using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Dto.Student
{
    public class StudentCourseDto
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long CourseId { get; set; }
        public CourseDto Course { get; set; }
        public StudentDto Student { get; set; }
    }
}
