using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class NurseBar : INurseBar
    {
        [Key]
        public int NurseID { get; set; }

        public Nurse Nurse { get; set; }

        [Required]
        public int BarID { get; set; }

        public Bar Bar { get; set; }
    }
}
