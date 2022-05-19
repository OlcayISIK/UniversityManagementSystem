using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Data.Entities.UniversityBoundEntities
{
    public class StudentsUniversitySocialClub
    {
        [ForeignKey("StudentId")]
        public long StudentId { get; set; }
        [ForeignKey("UniversitySocialClubId")]
        public long UniversitySocialClubId { get; set; }
        public UniversitySocialClub UniversitySocialClub { get; set; }
        public Student Student { get; set; }

    }
}
