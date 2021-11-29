using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface.Admission
{
    public interface IPatientAdmissionFileUpdate : IAdmissionFile
    {

        string PatientName { get; set; }
        string SpecialistName { get; set; }
        List<ISelectOption> BedList { get; set; }

    }
}
