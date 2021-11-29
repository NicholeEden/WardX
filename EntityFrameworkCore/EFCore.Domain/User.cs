using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class User : IUser
    {
        [Key]
        public int UserID { get; set; }

        [Required, MaxLength(128)]
        public string UserName { get; set; }

        [Required, MaxLength(1024)]
        public string PasswordHash { get; set; }

        [Required]
        public string Avatar { get; set; }

        #region Entity Framework
        public virtual List<UserRole> UserRoles { get; set; }
        public StaffMember StaffMember { get; set; }
        #endregion
    }
}
