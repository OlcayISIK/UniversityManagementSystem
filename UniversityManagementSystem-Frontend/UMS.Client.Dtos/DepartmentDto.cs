using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Client.Dtos
{
    public class DepartmentDto
    {
        public long Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public long Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }

        public virtual ICollection<CourseDto> Courses { get; set; }
    }
}
