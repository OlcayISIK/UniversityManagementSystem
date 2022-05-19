using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Dto.Student;
using UMS.Dto.Teacher;

namespace UMS.Dto
{
    public class UniversitySocialClubDto
    {
        public long Id { get; set; }
        public long AdvisorId { get; set; }
        public long EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<StudentsUniversitySocialClubDto> StudentsUniversitySocialClubs { get; set; }
        public IEnumerable<EventDto> Events { get; set; }
        public CourseInstructorDto CourseInstructor { get; set; }
    }
}
