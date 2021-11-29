using System.Data;
using EFCore.Interface;

namespace DataAccess.Interface.Integration

{
    public interface IMonthMethods
    {
        DataTable Get_Month(int MonthID);

    }
}
