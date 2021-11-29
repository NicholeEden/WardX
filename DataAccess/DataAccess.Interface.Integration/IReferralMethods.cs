using EFCore.Interface;
using System.Data;

namespace DataAccess.Interface.Integration
{
    public interface IReferralMethods
    {
        /// <summary>
        /// Returns the Referral values based on the Patient ID
        /// </summary>
        /// <returns></returns>
        DataTable Get_Referral(int patientID);

        /// <summary>
        /// Returns the Referrals that have not been admitted
        /// </summary>
        /// <returns></returns>
        DataTable Get_PendingReferrals();

        /// <summary>
        /// Inserts a new Referral entry
        /// </summary>
        /// <returns></returns>
        int Add_Referral(IReferral referral);

        DataTable Get_AllReferral(bool isAmitted);

        int Update_Referral(IReferral referral);

        int Update_ReferralStatus(int ID, bool isAdmitted);
    }
}