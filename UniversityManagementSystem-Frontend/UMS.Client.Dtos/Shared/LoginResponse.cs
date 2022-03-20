using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Core.Enums;

namespace UMS.Client.Dtos.Shared
{
    public class LoginResponse
    {
        public TokenDto Data { get; set; }
        public bool Success { get; set; }
        public ErrorCode ErrorCode { get; set; }
    }
}
