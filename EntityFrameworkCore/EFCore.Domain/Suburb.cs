using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class Suburb : ISuburb
    {
        [Key]
        public int SuburbID { get; set; }

        [Required, MaxLength(1024)]
        public string SuburbName { get; set; }

        [Required, MaxLength(4)]
        public string PostalCode { get; set; }

        [Required]
        public int CityID { get; set; }
        public City City { get; set; }

        #region Entity Framework
        public List<EmergencyContact> EmergencyContact { get; set; }
        public List<NextOfKin> NextOfKin { get; set; }
        #endregion
    }
}