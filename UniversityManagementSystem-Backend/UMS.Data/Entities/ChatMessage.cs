using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Data.Entities.UniversityBoundEntities;

namespace UMS.Data.Entities
{
    public class ChatMessage : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FromUserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ToUserId { get; set; }
        public string Message { get; set; }
        public virtual Student FromUser { get; set; }

        public virtual Student ToUser { get; set; }
    }
}
