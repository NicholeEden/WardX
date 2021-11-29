using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Bed : IBed
    {
        [Key]
        public int BedID { get; set; }

        [Required, MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        public bool isAvailable { get; set; }

        #region Entity Framework
        public List<AdmissionFile> AdmissionFiles { get; set; }
        #endregion
    }
}
