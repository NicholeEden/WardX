using DataAccess.Domain.Interface.Component;
using DataAccess.Domain.Interface.Filter;
using DataAccess.Domain.Interface.Function;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Domain.Interface
{
    public interface ITreatment_DataAccess : 
        ICanSelect, 
        ICanInsert,
        ISQLParameter,
        ISelectByPatient
    {
        SqlParameter[] GetInsertParameters(ITreatment treatment);

        SqlParameter[] GetSelectByPatientParameters(int id);
    }
}
