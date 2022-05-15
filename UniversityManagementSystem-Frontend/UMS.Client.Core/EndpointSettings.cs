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
                private const string EndpointPrefix = "api/teacher";

                public static class Authentication
                {
                    private const string ControllerPrefix = "/Authentication";

                    public const string AuthenticateWithPassword = EndpointPrefix + ControllerPrefix + "/pass";

                    public const string Logout = EndpointPrefix + ControllerPrefix + "/logout";

                    public const string AuthenticateWithToken = EndpointPrefix + ControllerPrefix + "/token";

                    public const string ForgotPassword = EndpointPrefix + ControllerPrefix + "/ForgotPassword";

                    public const string ResetPassword = EndpointPrefix + ControllerPrefix + "/ResetPassword";

                    public const string Signup = EndpointPrefix + ControllerPrefix + "/Signup";
                }
                public static class TeacherService
                {
                    public const string ControllerPrefix = "/Teacher";
                    public const string GetAll = EndpointPrefix + ControllerPrefix + "/getAll";
                    public const string Get = EndpointPrefix + ControllerPrefix + "/get";
                }
            }
            public static class Student
            {
                private const string EndpointPrefix = "api/student";

                public static class Authentication
                {
                    private const string ControllerPrefix = "/Authentication";

                    public const string AuthenticateWithPassword = EndpointPrefix + ControllerPrefix + "/pass";

                    public const string Logout = EndpointPrefix + ControllerPrefix + "/logout";

                    public const string AuthenticateWithToken = EndpointPrefix + ControllerPrefix + "/token";

                    public const string ForgotPassword = EndpointPrefix + ControllerPrefix + "/ForgotPassword";

                    public const string ResetPassword = EndpointPrefix + ControllerPrefix + "/ResetPassword";

                    public const string Signup = EndpointPrefix + ControllerPrefix + "/Signup";
                }
                public static class StudentService
                {
                    public const string ControllerPrefix = "/Student";
                    public const string GetAll = EndpointPrefix + ControllerPrefix + "/getAll";
                    public const string Get = EndpointPrefix + ControllerPrefix + "/get";
                }
                public static class Chat
                {
                    public const string ControllerPrefix = "/Chat";
                    public const string Get = EndpointPrefix + ControllerPrefix + "/getConversation";
                    public const string Add = EndpointPrefix + ControllerPrefix + "/AddMessage"; 
                }
                public static class SocialClub
                {
                    public const string ControllerPrefix = "/SocialClub";
                    public const string GetAll = EndpointPrefix + ControllerPrefix + "/getAll";
                    public const string Join = EndpointPrefix + ControllerPrefix + "/Join";
                }
                public static class Event
                {
                    public const string ControllerPrefix = "/Event";
                    public const string GetAll = EndpointPrefix + ControllerPrefix + "/getAll";
                    public const string PublishEventForSocialClub = EndpointPrefix + ControllerPrefix + "/publishEventForSocialClub";
                    public const string PublishEventForUniversity = EndpointPrefix + ControllerPrefix + "/publishEventForUniversity";
                    public const string Update = EndpointPrefix + ControllerPrefix + "/Update";
                    public const string Delete = EndpointPrefix + ControllerPrefix + "/Delete";
                    public const string Join = EndpointPrefix + ControllerPrefix + "/Join";
                }
            }

        }
    }
}
