using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.Entities.UniversityBoundEntities;

namespace UMS.Data.Entities
{
    public partial class StudentGrade : UniversityBoundEntity
    {
        public long CourseId { get; set; }
        public long StudentId { get; set; }
        public long Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
