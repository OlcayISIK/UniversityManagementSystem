using System.Collections.Generic;

namespace UMS.Business.Hubs
{
    public class UniversityConnection
    {
        public long? UniversityId { get; set; }
        public  long? SocialClubId { get; set; }
        public List<string> ActiveConnectionIds { get; set; } = new List<string>();
        public bool EventsActive { get; set; }
    }
}
