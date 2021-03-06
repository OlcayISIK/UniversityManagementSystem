using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Core.Enums;

namespace UMS.Client.Business.Shared
{
    public class PageAuthenticationService : IPageAuthenticationService
    {
        Dictionary<UserType, List<Pages>> AuthenticationDictionary = new Dictionary<UserType, List<Pages>>
        {
            [UserType.Teacher] = new List<Pages> { Pages.Home, Pages.TeacherSettings, Pages.Events, Pages.TeacherCourses, Pages.Library, Pages.TeacherStudents, Pages.SocialClubs },
            [UserType.Student] = new List<Pages> { Pages.Home, Pages.Chat,Pages.Events, Pages.StudentSettings, Pages.SocialClubs, Pages.Library, Pages.Courses,Pages.StudentGrades },
            [UserType.StudentRepresentative] = new List<Pages> { Pages.Home, Pages.Chat, Pages.Events, Pages.StudentSettings, Pages.Library}

        };

        public bool ControlAuthentication(Pages page, UserType user)
        {
            foreach (var pages in AuthenticationDictionary[user])
            {
                if (pages == page)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
