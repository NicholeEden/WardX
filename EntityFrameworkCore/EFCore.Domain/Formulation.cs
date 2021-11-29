using EFCore.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Formulation : IFormulation
    {
        [Key]
        public int FormulationID { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Abbreviation { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Description { get; set; }
    }
}
