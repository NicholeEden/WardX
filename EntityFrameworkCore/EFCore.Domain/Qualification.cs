using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Qualification : IQualification
    {
        [Key]
        public int QualificationID { get; set; }

        [Required, MaxLength(1024)]
        public string Title { get; set; }

        [Required, MaxLength(1024)]
        public string Description { get; set; }
    }
}
