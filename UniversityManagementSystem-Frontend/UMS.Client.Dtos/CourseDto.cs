using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos.Student;

namespace UMS.Client.Dtos
{
    public class CourseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long StudentCourseId { get; set; }
        public long StudentGradeId { get; set; }
        public long CourseInsturctorId { get; set; }
        public long DepartmentId { get; set; }
        public long OnlineCourseId { get; set; }
        public long OnsiteCourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }


        public virtual DepartmentDto Department { get; set; }
        public virtual OnlineCourseDto OnlineCourse { get; set; }
        public virtual OnsiteCourseDto OnsiteCourse { get; set; }
        public virtual ICollection<StudentCourseDto> StudentCourses { get; set; }
        public virtual ICollection<StudentGradeDto> StudentGrades { get; set; }
        public virtual CourseDto Course { get; set; }
    }
}
