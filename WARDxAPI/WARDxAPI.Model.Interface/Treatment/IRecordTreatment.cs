using EFCore.Interface;
using System.Collections.Generic;
using WARDx.Data;

namespace WARDxAPI.Model.Interface.Treatment
{
    public interface IRecordTreatment : ITreatment
    {
        List<SelectOption> NurseList { get; set; }
        Dictionary<string, string> PatientList { get; set; }
        List<SelectOption> TreatmentTypeList { get; set; }

    }
}
