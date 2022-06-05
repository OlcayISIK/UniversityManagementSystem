using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos.Student;

namespace UMS.Client.Dtos.Shared
{
    public class FileDto
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public long UniversityId { get; set; }
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
        public virtual StudentDto Student { get; set; }
        public virtual CourseDto Course { get; set; }
    }
}
