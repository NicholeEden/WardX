using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface.Admission
{
    public interface IPatientAdmit : IAdmissionFile
    {
        

        string PatientName { get; set; }
        string SpecialistName { get; set; }

        List<ISelectOption> BedList { get; set; }

        int BedCount { get; set; }
    }
}
