using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Role : IRole
    {
        [Key]
        public int RoleID { get; set; }

        [Required, MaxLength(1024)]
        public string RoleName { get; set; }

        #region Entity Framework
        public virtual List<UserRole> UserRoles { get; set; }
        #endregion
    }
}
