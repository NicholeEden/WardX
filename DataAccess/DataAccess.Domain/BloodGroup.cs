using DataAccess.Domain.Interface;
using EFCore.Interface;
using System;
namespace DataAccess.Domain
{
    public class BloodGroup : IBloodGroup_DataAccess
    {
        public string sp_Select()
        {
            //return _StoredProcedureProvider.sp_SelectBloodGroup.ToString();
            throw new NotImplementedException();
        }
    }
}
