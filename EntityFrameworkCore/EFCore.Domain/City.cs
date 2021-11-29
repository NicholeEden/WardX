using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class City : ICity
    {
        [Key]
        public int CityID { get; set; }

        [Required, MaxLength(1024)]
        public string CityName { get; set; }
    }
}
