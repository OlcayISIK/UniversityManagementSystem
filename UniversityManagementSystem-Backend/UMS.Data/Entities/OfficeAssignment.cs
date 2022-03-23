using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.Entities.UniversityBoundEntities;

namespace UMS.Data.Entities
{
    public partial class OfficeAssignment : UniversityBoundEntity
    {
        public int CourseInstructorId { get; set; }
        public string Location { get; set; }
        public byte[] Timestamp { get; set; }

        public virtual CourseInstructor CourseInstructor { get; set; }
    }
}
