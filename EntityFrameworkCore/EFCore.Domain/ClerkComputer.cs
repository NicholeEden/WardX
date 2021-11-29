using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class ClerkComputer : IClerkComputer
    {
        [Required]
        public int ClerkID { get; set; }
        public Receptionist Receptionist { get; set; }

        [Required]
        public int ComputerSkillID { get; set; }
        public ComputerSkill ComputerSkill { get; set; }

        [Required, MaxLength(50)]
        public string ProficiencyLevel { get; set; }
    }
}
