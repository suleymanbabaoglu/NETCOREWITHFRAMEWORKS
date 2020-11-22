using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace SAMPLE.Helpers
{
    public static class ClaimHelper
    {
        public static int GetUserId(this ControllerBase controllerBase)
        {
            var claim = controllerBase.User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier);
            if (claim == null)
                return -1;

            int.TryParse(claim.Value, out int id);
            return id;
        }

        public static string GetUserEmail(this ControllerBase controllerBase)
        {
            var claim = controllerBase.User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Email);
            if (claim == null)
                return string.Empty;
            return claim.Value;
        }
        public static int GetUserId(HttpContext httpContext)
        {
            if (httpContext == null)
                return -1;

            var claim = httpContext.User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier);
            if (claim == null)
                return -1;

            int.TryParse(claim.Value, out int id);
            return id;
        }

        public static string GetUserEmail(HttpContext httpContext)
        {
            if (httpContext == null)
                return string.Empty;

            var claim = httpContext.User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Email);
            if (claim == null)
                return string.Empty;
            return claim.Value;
        }
    }
}
