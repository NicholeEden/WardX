using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class NurseType : INurseType
    {
        [Key]
        public int NurseTypeID { get; set; }

        [Required,MaxLength(1024)]
        public string Description { get; set; }
    }
}
