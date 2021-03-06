using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Core.Enums
{
    public enum ApiConsumerType
    {
        /// <summary>
        /// University Teachers, consumers of the teacher API's
        /// </summary>
        Teacher = 0,

        /// <summary>
        /// University Students, consumers of the student API's
        /// </summary>
        Student = 1,

        /// <summary>
        /// Administrators of the system
        /// </summary>
        Admin = 2
    }
}
