using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Dto.Student;

namespace UMS.Dto
{
    public class StudentGradeDto
    {
        public long CourseId { get; set; }
        public long StudentId { get; set; }
        public long Grade { get; set; }

        public virtual CourseDto Course { get; set; }
        public virtual StudentDto Student { get; set; }
    }
}
