using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Dto.Student;
using UMS.Dto.Teacher;

namespace UMS.Dto
{
    public class CourseDto
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public long StudentCourseId { get; set; }
        public long StudentGradeId { get; set; }
        public long CourseInstructorId { get; set; }
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
        public virtual CourseInstructorDto CourseInstructor { get; set;}

    }
}
