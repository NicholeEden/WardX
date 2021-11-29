using System.Data;
using EFCore.Interface;

namespace DataAccess.Interface.Integration
{
    public interface INurseTypeMethods
    {
        DataTable Get_NurseType(INurseType nurseType);
    }
}
