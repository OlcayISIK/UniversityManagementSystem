using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Data.Entities
{
    public partial class OnsiteCourse
    {
        public int CourseId { get; set; }
        public string Location { get; set; }
        public string Days { get; set; }
        public DateTime Time { get; set; }

        public virtual Course Course { get; set; }
    }
}
