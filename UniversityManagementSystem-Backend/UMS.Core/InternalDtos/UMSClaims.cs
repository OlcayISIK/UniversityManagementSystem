using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core.Enums;

namespace UMS.Core.InternalDtos
{
    public class UMSClaims
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public UserType UserType { get; set; }
        public long UniversityId { get; set; }
    }
}
