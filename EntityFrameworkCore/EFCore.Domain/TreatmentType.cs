using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class TreatmentType : ITreatmentType
    {
        public int TreatmentTypeID { get; set; }
        [Required, MaxLength(1024)]
        public string Description { get; set; }
    }
}
