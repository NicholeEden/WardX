using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class BloodGroup : IBloodGroup
    {
        [Key]
        public int BloodGroupID { get; set; }

        [Required, MaxLength(1024)]
        public string BloodGroupName { get; set; }

        [Required, MaxLength(1024)]
        public string Description { get; set; }
    }
}
