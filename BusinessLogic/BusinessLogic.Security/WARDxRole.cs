using BusinessLogic.Interface;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Security
{
    public class WARDxRole : IdentityRole, IWARDxRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}