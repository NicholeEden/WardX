using DataAccess.Interface.Integration;

namespace DataAccess.Interface
{
    /// <summary>
    /// Defines the accessable data access methods
    /// </summary>
    public interface IDatabaseAccess :
        IAdmissionFileMethods,
        IBarMethods,
        IBedMethods,
        IBloodGroupMethods,
        ICityMethods,
        IClerkComputerMethods,
        IClockingMethods,
        IComputerSkillMethods,
        IDiagnosisMethods,
        IDoctorMethods,
        IDoctorInspectionMethods,
        IDoctorScheduleMethods,
        IDoctorTypeMethods,
        IEmergencyContactMethods,
        IEpauletteMethods,
        IMedicalAidMethods,
        IMedicalAidPlanMethods,
        IMedicalAidSchemeMethods,
        IMedicalConditionMethods,
        IMedicalHistoryMethods,
        IMedicineMethods,
        IMonthMethods,
        INextOfKinMethods,
        INurseMethods,
        INurseBarMethods,
        INurseInspectionMethods,
        INurseScheduleMethods,
        INurseTypeMethods,
        IPatientMethods,
        IPrescriptionMethods,
        IProcedureHistoryMethods,
        IQualificationMethods,
        IReceptionistMethods,
        IReferralMethods,
        IRoleMethods,
        IShiftSlotMethods,
        ISpecializationMethods,
        IStaffMemberMethods,
        ISuburbMethods,
        ITreatmentMethods,
        ITreatmentTypeMethods,
        IUserMethods,
        IUserRoleMethods,
        IVitalSignMethods,
        IPatientMovementMethods
    {
    }
}