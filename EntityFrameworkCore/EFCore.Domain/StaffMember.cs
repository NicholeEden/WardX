using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class StaffMember : IStaffMember
    {
        [Key]
        public int StaffID { get; set; }

        [Required, MaxLength(1024)]
        public string FirstName { get; set; }

        [Required, MaxLength(1024)]
        public string LastName { get; set; }

        [Required, MaxLength(13)]
        public string EmployeeID { get; set; }

        [Required, MaxLength(1024)]
        public string EmailAddress { get; set; }

        [Required, MaxLength(1024)]
        public string AddressLine1 { get; set; }

        [MaxLength(1024)]
        public string AddressLine2 { get; set; }

        [Required, MaxLength(10)]
        public string WorkNumber { get; set; }

        [Required, MaxLength(10)]
        public string MobileNumber { get; set; }

        [Required]
        public bool isActive { get; set; }

        [Required]
        public int SuburbID { get; set; }
        public Suburb Suburb { get; set; }

        [Required]
        public int UserID { get; set; }
        public User User { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public StaffType StaffType { get; set; }

        #region Entity Framework
        public virtual Nurse Nurse { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Receptionist Receptionist { get; set; }
        #endregion

    }
}
