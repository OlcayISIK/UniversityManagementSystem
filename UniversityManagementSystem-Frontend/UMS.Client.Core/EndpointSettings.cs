using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Client.Core
{
    public static class EndpointSettings
    {
        public static class ServerRoutes
        {
            public static class Teacher
            {
                private const string EndpointPrefix = "api/admin";

                public static class Authentication
                {
                    private const string ControllerPrefix = "/Authentication";

                    public const string AuthenticateWithPassword = EndpointPrefix + ControllerPrefix + "/pass";

                    public const string Logout = EndpointPrefix + ControllerPrefix + "/logout";

                    public const string ForgotPassword = EndpointPrefix + ControllerPrefix + "/ForgotPassword";

                    public const string ResetPassword = EndpointPrefix + ControllerPrefix + "/ResetPassword";

                    public const string Signup = EndpointPrefix + ControllerPrefix + "/Signup";
                }
            }
        }
    }
}
