using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class DoctorType : IDoctorType
    {
        [Key]
        public int DoctorTypeID { get; set; }

        [Required, MaxLength(1024)]
        public string Description { get; set; }
    }
}
