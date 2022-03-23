using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.Entities.UniversityBoundEntities;

namespace UMS.Data.Entities
{
    public partial class Department : UniversityBoundEntity
    {
        public Department()
        {
            Courses = new HashSet<Course>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public long Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
