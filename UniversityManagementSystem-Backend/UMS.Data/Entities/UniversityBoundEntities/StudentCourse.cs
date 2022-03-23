using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Data.Entities.UniversityBoundEntities
{
    public class StudentCourse : UniversityBoundEntity
    {
        public long StudentId { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
