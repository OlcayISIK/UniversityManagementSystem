﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Dto.Authentication
{
    public class ResetPasswordDto
    {
        public string PasswordResetToken { get; set; }
        public string NewPassword { get; set; }
    }
}