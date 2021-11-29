using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class EmergencyContact : IEmergencyContact_DataAccess
    {
        public SqlParameter[] GetInsertParameters(IEmergencyContact emergencyContact)
        {
            throw new System.NotImplementedException();
        }

        public SqlParameter[] GetSelectByPatientParameters(int id)
        {
            throw new System.NotImplementedException();
        }

        public SqlParameter[] GetUpdateParameters(IEmergencyContact emergencyContact)
        {
            throw new System.NotImplementedException();
        }

        public string sp_Insert()
        {
            throw new System.NotImplementedException();
        }

        public string sp_SelectByPatient()
        {
            throw new System.NotImplementedException();
        }

        public string sp_Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
