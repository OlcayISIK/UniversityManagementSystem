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
            [MaxLength(100)]
            public string Name { get; set; }
            [MaxLength(100)]
            public string FileType { get; set; }
            [MaxLength]
            public byte[] DataFiles { get; set; }
        }
}
