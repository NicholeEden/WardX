using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDx.Data;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Treatment
{
    public class RecordVitals : IRecordVitals
    {
        [Required]
        public int VitalSignID { get; set; }
        public int BloodGroupID { get; set; }
        [Required]
        public string Hypoglycemia { get; set; }
        [Required]
        public string BodyTemperature { get; set; }
        [Required]
        public string PulseRate { get; set; }
        [Required]
        public string BloodPressure { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        public string BMI { get; set; }
        public List<SelectOption> BloodGroupList { get; set; }
        public string DateRecorded { get; set; }

    }
}
