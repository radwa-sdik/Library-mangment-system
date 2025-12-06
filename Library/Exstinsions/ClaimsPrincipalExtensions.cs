using System.Security.Claims;

namespace Library.Exstinsions
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetMemberID(this ClaimsPrincipal user)
        {

            if (!user.IsInRole("Member"))
                throw new Exception("User is not an member.");

            var claim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
                throw new Exception("id claim missing.");

            return int.Parse(claim.Value);
        }

        public static int GetAdminID(this ClaimsPrincipal user)
        {
            if(!user.IsInRole("Admin"))
                throw new Exception("User is not an admin.");

            var claim = user.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
                throw new Exception("id claim missing.");

            return int.Parse(claim.Value);
        }
    }
}
