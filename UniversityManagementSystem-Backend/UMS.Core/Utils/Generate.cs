using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Core.Utils
{
    public class Generate
    {
        public static string PasswordResetToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
