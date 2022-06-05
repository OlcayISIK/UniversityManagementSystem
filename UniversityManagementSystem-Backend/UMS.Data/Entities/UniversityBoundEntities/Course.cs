using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.Entities.UniversityBoundEntities;

namespace UMS.Data.Entities.UniversityBoundEntities
{
    public partial class Course : UniversityBoundEntity
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
            StudentGrades = new HashSet<StudentGrade>();
        }
        public string Name { get; set; }
        public long StudentCourseId { get; set; }
        public long? StudentGradeId { get; set; }
        public long CourseInstructorId { get; set; }
        public long DepartmentId { get; set; }
        public long? FileId { get; set; }
        public long? OnlineCourseId { get; set; }
        public long? OnsiteCourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }


        public virtual Department Department { get; set; }
        public virtual OnlineCourse OnlineCourse { get; set; }
        public virtual OnsiteCourse OnsiteCourse { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
        public virtual ICollection<File> Files{ get; set; }
        public virtual CourseInstructor CourseInstructor { get; set; }
    }
}
