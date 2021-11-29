using DataAccess.Domain.Interface;
using EFCore.Interface;
using System.Data.SqlClient;

namespace DataAccess.Domain
{
    public class Bed : IBed_DataAccess
    {
        public SqlParameter[] GetUpdateBedStatusParameters(int Id, bool isAvailable)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(IBed.BedID)}", Id),
                new SqlParameter($"@{nameof(IBed.isAvailable)}", isAvailable)
            };
        }

        public SqlParameter[] GetUpdateParameters(IBed bed)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(IBed.BedID)}", bed.BedID),
                new SqlParameter($"@{nameof(IBed.Description)}", bed.Description),
                new SqlParameter($"@{nameof(IBed.isAvailable)}", bed.isAvailable)
            };
        }

        public SqlParameter[] SelectByisAvailableParemeter(bool isAvailable)
        {
            return new SqlParameter[]
            {
                new SqlParameter($"@{nameof(IBed.isAvailable)}", isAvailable)
            };
        }

        public string sp_Select()
        {
            return _StoredProcedureProvider.sp_SelectAvailableBed.ToString();
        }

        public string sp_SelectAllBeds()
        {
            return _StoredProcedureProvider.sp_SelectAllBeds.ToString();
        }

        public string sp_Update()
        {
            return _StoredProcedureProvider.sp_SetBedStatus.ToString();
        }
    }
}
