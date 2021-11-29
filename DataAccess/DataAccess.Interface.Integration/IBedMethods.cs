using EFCore.Interface;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IBedMethods
    {
        DataTable GetAllBeds();
        DataTable GetAvailableBeds(bool isAvailable);
        int Update_BedStatus(int ID, bool isAvailable);
    }
}
