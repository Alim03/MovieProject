using System.Security.Claims;

namespace MovieProject.Web.HttpHandler
{
    public static class ClaimsExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            var claimValue = principal.Claims.SingleOrDefault(item => item.Type == ClaimTypes.NameIdentifier);
            if (claimValue != null && claimValue.Value != null)
            {
                return Convert.ToInt32(claimValue.Value);
            }

            return default;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            var claimValue = principal.Claims.SingleOrDefault(item => item.Type == ClaimTypes.Email);
            if (claimValue != null && claimValue.Value != null)
            {
                return claimValue.Value;
            }

            return default;
        }
   
    }
}
