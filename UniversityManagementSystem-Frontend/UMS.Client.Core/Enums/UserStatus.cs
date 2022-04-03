using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Client.Core.Enums
{
    public enum UserStatus
    {
        // Just created
        Created = 0,

        // User confirmed himself via the link we sent to his mail
        Approved = 1,

        Suspended = 2,

        Deleted = 3
    }
}
