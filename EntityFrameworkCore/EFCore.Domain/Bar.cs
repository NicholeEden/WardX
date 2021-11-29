using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Bar : IBar
    {
        [Key]
        public int BarID { get; set; }

        [Required, MaxLength(1024)]
        public string Colour { get; set; }

        [Required, MaxLength(1024)]
        public string Description { get; set; }
    }
}
