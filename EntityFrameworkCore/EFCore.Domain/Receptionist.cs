using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Receptionist : IReceptionist
    {
        [Key]
        public int ClerkID { get; set; }
        public StaffMember isStaffMember { get; set; }

        [Required]
        public int QualificationID { get; set; }
        public Qualification Qualification { get; set; }

        #region Entity Framework
        public List<ClerkComputer> ClerkComputer { get; set; }
        #endregion
    }
}
