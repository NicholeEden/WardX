using EFCore.Interface;
using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain
{
    public class MedicationSchedule : IMedicationSchedule
    {
        public int MedicationScheduleID { get; set; }

        [Required, MaxLength(1024)]
        public string SchedulingStatus { get; set; }
    }
}