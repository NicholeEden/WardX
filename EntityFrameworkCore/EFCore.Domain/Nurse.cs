using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Nurse : INurse
    {
        [Key]
        public int NurseID { get; set; }
        public StaffMember isStaffMember { get; set; }



        [Required]
        public bool isWardManager { get; set; }

        [Required]
        public bool isHeadNurse { get; set; }

        [Required]
        public int SpecializationID { get; set; }
        public Specialization Specialization { get; set; }

        [Required]
        public int NurseTypeID { get; set; }
        public NurseType NurseType { get; set; }

        #region Entity Framework
        public List<NurseBar> NurseBar { get; set; }
        public List<NurseInspection> NurseInspection { get; set; } 
        #endregion
    }
}
