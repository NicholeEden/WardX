using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class MedicalAidScheme : IMedicalAidScheme
    {
        [Key]
        public int MedicalAidSchemeID { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }
    }
}
