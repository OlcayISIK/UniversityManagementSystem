using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Data.Entities.UniversityBoundEntities
{
    public class File : UniversityBoundEntity
    {

        public long? StudentId { get; set; }
        public long? CourseId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string FileType { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public bool IsPrivate { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
