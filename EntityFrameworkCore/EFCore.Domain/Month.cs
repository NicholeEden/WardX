using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Month : IMonth
    {
        [Key]
        public int MonthID { get; set; }

        [Required]
        [MaxLength(1024)]
        public string MonthName { get; set; }

        [Required]
        public int StartDate { get; set; }

        [Required]
        public int EndDate { get; set; }
    }
}
