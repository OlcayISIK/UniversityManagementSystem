using System.Threading.Tasks;

namespace UMS.Business.Hubs
{
    public interface IEventHubForSocialClub
    {
        public Task JoinGroup();
        public Task EventActivationToggled(bool ordersClosed);
    }
}
