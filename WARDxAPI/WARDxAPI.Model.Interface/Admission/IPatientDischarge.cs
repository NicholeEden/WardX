using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface.Admission
{
    public interface IPatientDischarge : IAdmissionFile
    {
        string PatientName { get; set; }


    }
}
