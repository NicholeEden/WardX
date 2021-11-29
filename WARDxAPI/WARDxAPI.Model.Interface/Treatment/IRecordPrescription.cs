using System.Collections.Generic;
using WARDx.Data;

namespace WARDxAPI.Model.Interface.Treatment
{
    public interface IRecordPrescription
    {
        List<SelectOption> MedicineNameList { get; set; }
        List<SelectOption> DoctorList { get; set; }
        double Dosage { get; set; }
        string DateIssued { get; set; }
        string Instructions { get; set; }

    }
}
