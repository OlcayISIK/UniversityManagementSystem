using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Data.Entities.UniversityBoundEntities
{
    public class Event : UniversityBoundEntity
    {
        public  long UniversitySocialClubId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LocationHeader { get; set; }
        public string Location { get; set; }
        public int Quota { get; set; }
        public int Participants { get; set; }
        public UniversitySocialClub UniversitySocialClub { get; set; }

    }
}
