using System;
using System.Collections.Generic;
using System.Text;

namespace UMS.Dto.Authentication
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
