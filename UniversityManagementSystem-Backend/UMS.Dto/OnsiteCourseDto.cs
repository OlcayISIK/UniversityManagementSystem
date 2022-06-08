using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Dto
{
    public class OnsiteCourseDto
    {
        public long Id { get; set; }
        public int CourseId { get; set; }
        public string Location { get; set; }
        public string Days { get; set; }
        public DateTime Time { get; set; }

        public virtual CourseDto Course { get; set; }
    }
}
