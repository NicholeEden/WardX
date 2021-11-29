using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Profile;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Model.Profile
{
    public class PatientDiagnosis : IPatientDiagnosis
    {
        public Dictionary<string, string> ConditionList { get; set; }
        public List<ISelectOption> DoctorList { get; set; }
        public int DiagnosisID { get; set; }

        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Medical Condition")]
        public int MedicalConditionID { get; set; }

        [Required,
            Range(101, int.MaxValue),
            Display(Name = "Diagnosed By")]
        public int DiagnosedBy { get; set; }

        [MaxLength(1024),
            Display(Name = "Diagnosis Details (optional)")]
        public string DiagnosisDetals { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public IStatusBoxModel Status { get; set; } = new StatusBoxModel
        {
            SectionName = "Diagnosis Information"
        };
    }
}
