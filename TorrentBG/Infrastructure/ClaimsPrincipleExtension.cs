namespace TorrentBG.Infrastructure
{
    using System.Security.Claims;
    using static Areas.Admin.AdminConstants;
    public static  class ClaimsPrincipleExtension
    {
        public static bool IsAdmin(this ClaimsPrincipal user) => user.IsInRole(AdministratorRoleName);
        
           
        
    }
}
