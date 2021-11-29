using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Interface.Integration
{
    public interface ITreatmentMethods
    {
        DataTable Get_Treatment(int PatientID);
        int Add_Treatment(ITreatment treatment);
    }
}
