using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Data.Entities.UniversityBoundEntities
{
    public class UniversitySocialClub : UniversityBoundEntity
    {
        [ForeignKey("CourseInstructorId")]
        public long AdvisorId { get; set; }
        public long EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<StudentsUniversitySocialClub> StudentsUniversitySocialClubs { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public CourseInstructor CourseInstructor { get; set; }
    }
}
