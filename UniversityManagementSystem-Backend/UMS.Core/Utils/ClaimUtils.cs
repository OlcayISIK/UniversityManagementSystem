using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UMS.Core.Enums;
using UMS.Core.InternalDtos;

namespace UMS.Core.Utils
{
    public static class ClaimUtils
    {
        private const string Username = "name";
        private const string UserId = "uid";
        private const string UniversityId = "usid";
        private const string UserType = "rid";

        public static UMSClaims GetClaims(IEnumerable<Claim> claims)
        {
            var dsc = new UMSClaims();
            if (claims == null) return dsc;
            foreach (var claim in claims)
            {
                switch (claim.Type)
                {
                    //case ClaimTypes.NameIdentifier:
                    //    dsc.UserId = long.Parse(claim.Value);
                    //    break;
                    //case ClaimTypes.Name:
                    //    dsc.Username = claim.Value;
                    //    break;
                    //case ClaimTypes.Sid:
                    //    dsc.UserType = (UserType)int.Parse(claim.Value);
                    //    break;
                    case Username:
                        dsc.Username = claim.Value;
                        break;
                    case UserId:
                        dsc.UserId = long.Parse(claim.Value);
                        break;
                    case UniversityId:
                        dsc.UniversityId = long.Parse(claim.Value);
                        break;
                    case UserType:
                        dsc.UserType = (UserType)int.Parse(claim.Value);
                        break;
                }
            }
            return dsc;
        }

        public static Claim[] CreateTeacherClaims(long userId, string username, UserType userType, long universityId)
        {
            return new[]
            {
                //new Claim(ClaimTypes.Sid,((int)userType).ToString()),
                //new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                //new Claim(ClaimTypes.Name, username)
                new Claim(Username, username),
                new Claim(UserId, userId.ToString()),
                new Claim(UserType, ((int)userType).ToString()),
                new Claim(UniversityId, universityId.ToString())
            };
        }
        public static Claim[] CreateStudentClaims(long userId, string username, UserType userType, long universityId)
        {
            return new[]
            {
                //new Claim(ClaimTypes.Sid,((int)userType).ToString()),
                //new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                //new Claim(ClaimTypes.Name, username)
                new Claim(Username, username),
                new Claim(UserId, userId.ToString()),
                new Claim(UserType, ((int)userType).ToString()),
                new Claim(UniversityId, universityId.ToString())
            };
        }

        public static IEnumerable<Claim> CreateClaims(long userId)
        {
            return new[]
            {
                new Claim(UserId, userId.ToString())
            };
        }

        public static IEnumerable<Claim> CreateClaims(long userId, string username)
        {
            return new[]
            {
                new Claim(UserId, userId.ToString()),
                new Claim(Username, username)
            };
        }
    }
}
