using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Admission;

namespace WARDxAPI.Model.Admission
{
    public class PatientAdmitDiagnosis : IPatientAdmitDiagnosis
    {
        public Dictionary<string, string> ConditionList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ISelectOption> DoctorList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DiagnosisID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MedicalConditionID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DiagnosedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DiagnosisDetals { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DiagnosisDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
