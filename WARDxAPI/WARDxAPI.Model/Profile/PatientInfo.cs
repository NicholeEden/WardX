using BusinessLogic.Model;
using EFCore.Interface;
using System.ComponentModel.DataAnnotations;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Profile
{
    public class PatientInfo : IPatientInfo
    {
        public IPatient Patient { get; set; }
        public INextOfKin NextOfKin { get; set; }
        public IMedicalAid MedicalAid { get; set; }
        public ISuburb PatientSuburb { get; set; }
        public ISuburb KinSuburb { get; set; }
        public IMedicalAidPlan MedicalAidPlan { get; set; }
        public IMedicalAidScheme MedicalAidScheme { get; set; }
        public IDiagnosis Diagnosis { get; set; }
        public IMedicalCondition MedicalCondition { get; set; }
        public Doctor GPDoctor { get; set; }
        public Doctor Specialist { get; set; }

        [Required,
            MinLength(5, ErrorMessage = "The header is too short."),
            Display(Name = "HEADER")]
        public string EmailHeader { get; set; }

        [Required,
            MaxLength(1024, ErrorMessage = "The email content has exceeded the size."),
            Display(Name = "BODY")]
        public string EmailBody { get; set; }
        public int ReturnID { get; set; }

        [Required,
            DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}
