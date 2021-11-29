using EFCore.Interface;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IAdmissionFileMethods
    {
        DataTable Get_AdmissionFile(int patientID);
        DataTable Get_AllAdmissionFile();

        DataTable Get_AdmissionFileByID(int admissionFileID);

        int Add_AdmissionFile(IAdmissionFile admissionFile);
        int Update_AdmissionFile(IAdmissionFile admissionFile);
        int Update_AdmissionFileDischarge(IAdmissionFile admission);
    }
}
