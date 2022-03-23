using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Dto
{
    public class UniversitySocialClubDto
    {
        public long Id { get; set; }
        public long ClubLeaderId { get; set; }
        public long AdvisorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public StudentDto Student { get; set; }
        //public CourseInstructorDto CourseInstructor { get; set; }
    }
}
