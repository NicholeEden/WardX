using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Specialization : ISpecialization
    {
        [Key]
        public int SpecializationID { get; set; }

        [Required, MaxLength(1024)]
        public string Description { get; set; }
    }
}
