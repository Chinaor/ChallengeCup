using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChallengeCup.Util
{
    public static class UserUtil
    {

        public static string GetCurrentUser(HttpContext httpContext)
        {
            var claims = httpContext.User.Claims;

            foreach (var claim in claims)
            {
                if (ClaimTypes.NameIdentifier.Equals(claim.Type))
                {
                    return claim.Value;
                }
            }
            return null;
        }

        public static string GetCurrentUserParam(HttpContext httpContext, string param)
        {
            if (string.IsNullOrWhiteSpace(param))
                return null;

            var claims = httpContext.User.Claims;

            foreach (var claim in claims)
            {
                if (param.Equals(claim.Type))
                {
                    return claim.Value;
                }
            }
            return null;
        }
    }
}
