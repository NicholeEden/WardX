using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class UserRole : IUserRole
    {
        [Required]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
