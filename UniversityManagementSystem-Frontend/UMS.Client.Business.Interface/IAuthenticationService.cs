using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Core.Enums;

namespace UMS.Client.Business.Interface
{
    public interface IAuthenticationService
    {
        bool ControlAuthentication(Pages page,UserType user);
    }
}
