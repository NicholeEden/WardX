using DataAccess.Domain.Interface;
using System.Data.SqlClient;
using EFCore.Interface;

namespace DataAccess.Domain
{
    public class Doctor : IDoctor_DataAccess
    {
        public SqlParameter[] GetDoctorIDParameter(int ID)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@doctorID", ID)
            };
        }

        public string sp_SelectByDoctorGP()
        {
            return _StoredProcedureProvider.sp_SelectDoctorGP.ToString();
        }

        public string sp_SelectByDoctorSpecialist()
        {
            return _StoredProcedureProvider.sp_SelectDoctorSpecialist.ToString();
        }

        public string sp_SelectByRequestDoctor()
        {
            throw new System.NotImplementedException();
        }
    }
}
