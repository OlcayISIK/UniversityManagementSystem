using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Core.Enums
{
    public enum UserType
    {
        Teacher = 0,
        Student = 1,

        /// <summary>
        /// Managers have access to everything by default
        /// </summary>
        Manager = 9,
    }
}
