using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Client.Core.Enums
{
    public enum SocketMessageType
    {
        NewEventReleased = 0,
        NewEventReceivedEveryone = 1,
        NewEventSentForUniversity = 2,
    }
}
