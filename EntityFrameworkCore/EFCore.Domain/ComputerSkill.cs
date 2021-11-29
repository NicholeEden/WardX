using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class ComputerSkill : IComputerSkill
    {
        [Key]
        public int ComputerSkillID { get; set; }

        [Required, MaxLength(1024)]
        public string Application { get; set; }
    }
}
