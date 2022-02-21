using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MethodBoundaryAspect.Fody.Attributes;
using Microsoft.AspNetCore.Http;
using UMS.Core.Enums;
using UMS.Core;
using UMS.Core.Exceptions;
using UMS.Core.Utils;

namespace UMS.Api.Helpers
{
    /// <summary>
    /// Attribute for checking user permissions according to their type
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class UserTypeCheckAttribute : OnMethodBoundaryAspect
    {
        private readonly UserType[] _userTypes;

        /// <inheritdoc />
        public UserTypeCheckAttribute(params UserType[] userTypes)
        {
            _userTypes = userTypes;
        }

        /// <summary>
        /// This runs before the actual method
        /// </summary>
        public override void OnEntry(MethodExecutionArgs arg)
        {
            var httpContextAccessor = (IHttpContextAccessor)ServiceLocator.ResolveService(typeof(IHttpContextAccessor));
            if (httpContextAccessor?.HttpContext == null)
            {
                throw new Exception();
            }
            else
            {
                var claims = ClaimUtils.GetClaims(httpContextAccessor.HttpContext.User.Claims);
                if (claims.UserType == UserType.Manager)
                    return;
                var found = false;
                foreach (var userType in _userTypes)
                {
                    if (claims.UserType == userType)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    throw new PermissionDeniedException();
            }
        }
    }
}
