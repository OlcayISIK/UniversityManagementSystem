using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Dtos.Student;

namespace UMS.Client.Dtos.Shared
{
    public class ChatMessage
    {
        public long Id { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual StudentDto FromUser { get; set; }
        public virtual StudentDto ToUser { get; set; }
    }
}
