using System.Data;
using EFCore.Interface;

namespace DataAccess.Interface.Integration
{
    public interface INurseMethods
    {
        DataTable Get_Nurse(int NurseID);

        int Add_Nurse(INurse nurse);

        int Update_Nurse(INurse nurse);

        DataTable Get_AllNurses();

    }
}
