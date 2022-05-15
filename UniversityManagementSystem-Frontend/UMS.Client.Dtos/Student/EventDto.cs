using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Client.Dtos.Student
{
    public class EventDto
    {
        public long Id { get; set; }
        public long UniversityId { get; set; }
        public long UniversitySocialClubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LocationHeader { get; set; }
        public string Location { get; set; }
        public int Quota { get; set; }
        public int Participants { get; set; }
    }
}
