using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UMS.Client.Business.Interface;
using UMS.Client.Core.Enums;

namespace UMS.Client.Business
{
    public class AuthenticationService : IAuthenticationService
    {
            Dictionary<UserType,List<Pages>> AuthenticationDictionary = new Dictionary<UserType, List<Pages>> {
            [UserType.Teacher] = new List<Pages> { Pages.Home},
            [UserType.Student] = new List<Pages> { Pages.Home },

        };

        public bool ControlAuthentication(Pages page, UserType user)
        {
            foreach (var pages in AuthenticationDictionary[user])
            {
                if (pages == page) {
                    return true;
                }
            }
            return false;
        }
    }
}
