using DataAccess.Domain.Interface;
using DataAccess.Interface;
using EFCore.Interface;
using System;
using System.Data;

namespace DataAccess
{
    public class DatabaseAccess : IDatabaseAccess
    {
        private readonly IQueryManager _queryManager;
        private readonly IBed_DataAccess _bed;
        private readonly IBloodGroup_DataAccess _bloodGroup;
        private readonly IClocking_DataAccess _clocking;
        private readonly IDiagnosis_DataAccess _diagnosis;
        private readonly IDoctor_DataAccess _doctor;
        private readonly IDoctorType_DataAccess _doctorType;
        private readonly IEmergencyContact_DataAccess _emergencyContact;
        private readonly IMedicalAid_DataAccess _medicalAid;
        private readonly IMedicalAidPlan_DataAccess _medicalAidPlan;
        private readonly IMedicalAidScheme_DataAccess _medicalAidScheme;
        private readonly IMedicalCondition_DataAccess _medicalCondition;
        private readonly IMedicine_DataAccess _medicine;
        private readonly IMonth_DataAccess _month;
        private readonly INextOfKin_DataAccess _nextOfKin;
        private readonly INurse_DataAccess _nurse;
        private readonly INurseSchedule_DataAccess _nurseSchedule;
        private readonly IPatient_DataAccess _patient;
        private readonly IReferral_DataAccess _referral;
        private readonly IRole_DataAccess _role;
        private readonly IUser_DataAccess _user;
        private readonly IShiftSlot_DataAccess _shiftSlot;
        private readonly ISpecialization_DataAccess _specialization;
        private readonly IStaffMember_DataAccess _staffMember;
        private readonly ISuburb_DataAccess _suburb;
        private readonly IAdmissionFile_DataAccess _admissionFile;
        private readonly IPrescription_DataAccess _prescription;
        private readonly IPatientMovement_DataAccess _patientMovement;

        private readonly ITreatment_DataAccess _treatment;
        private readonly ITreatmentType_DataAccess _treatmentType;
        private readonly IVitalSign_DataAccess _vitalSign;

        public DatabaseAccess(IQueryManager queryManager,
            IBed_DataAccess bed,
            IBloodGroup_DataAccess bloodGroup,
            IClocking_DataAccess clocking,
            IDiagnosis_DataAccess diagnosis,
            IDoctor_DataAccess doctor,
            IDoctorType_DataAccess doctorType,
            IEmergencyContact_DataAccess emergencyContact,
            IMedicalAid_DataAccess medicalAid,
            IMedicalAidPlan_DataAccess medicalAidPlan,
            IMedicalAidScheme_DataAccess medicalAidScheme,
            IMedicalCondition_DataAccess medicalCondition,
            IMedicine_DataAccess medicine,
            IMonth_DataAccess month,
            INextOfKin_DataAccess nextOfKin,
            INurse_DataAccess nurse,
            INurseSchedule_DataAccess nurseSchedule,
            IPatient_DataAccess patient,
            IReferral_DataAccess referral,
            IRole_DataAccess role,
            IUser_DataAccess user,
            IShiftSlot_DataAccess shiftSlot,
            ISpecialization_DataAccess specialization,
            IStaffMember_DataAccess staffMember,
            ISuburb_DataAccess suburb,
            IAdmissionFile_DataAccess admissionFile,
            IPrescription_DataAccess prescription,
            IPatientMovement_DataAccess patientMovement,

            ITreatment_DataAccess treatment,
            ITreatmentType_DataAccess treatmentType,
            IVitalSign_DataAccess vitalSign)

        {
            _queryManager = queryManager;
            _bed = bed;
            _bloodGroup = bloodGroup;
            _clocking = clocking;
            _diagnosis = diagnosis;
            _doctor = doctor;
            _doctorType = doctorType;
            _emergencyContact = emergencyContact;
            _medicalAid = medicalAid;
            _medicalAidPlan = medicalAidPlan;
            _medicalAidScheme = medicalAidScheme;
            _medicalCondition = medicalCondition;
            _medicine = medicine;
            _month = month;
            _nextOfKin = nextOfKin;
            _nurse = nurse;
            _nurseSchedule = nurseSchedule;
            _patient = patient;
            _referral = referral;
            _role = role;
            _user = user;
            _shiftSlot = shiftSlot;
            _specialization = specialization;
            _staffMember = staffMember;
            _suburb = suburb;
            _admissionFile = admissionFile;
            _prescription = prescription;
            _patientMovement = patientMovement;

            _treatment = treatment;
            _treatmentType = treatmentType;
            _vitalSign = vitalSign;
        }

        #region AdmissionFile
        public DataTable Get_AdmissionFile(int patientID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _admissionFile.sp_SelectByPatient(),
                                             parameters: _admissionFile.GetSelectByPatientParameters(patientID));
        }

        public DataTable Get_AllAdmissionFile()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _admissionFile.sp_Select());
        }

        public DataTable Get_AdmissionFileByID(int admissionFileID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _admissionFile.sp_SelectByAdmissionFileID(),
                                              parameters: _admissionFile.GetSelectAdmissionFile(admissionFileID));
        }

        public int Add_AdmissionFile(IAdmissionFile admission)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _admissionFile.sp_Insert(),
                                                parameters: _admissionFile.GetInsertParameters(admission));
        }

        public int Update_AdmissionFile(IAdmissionFile admission)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _admissionFile.sp_Update(),
                                                parameters: _admissionFile.GetUpdateParameters(admission));
        }

        public int Update_AdmissionFileDischarge(IAdmissionFile admission)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _admissionFile.sp_UpdateByDischarge(),
                                                 parameters: _admissionFile.GetUpdateDischargeParameters(admission));
        }
        #endregion

        #region Bed
        public DataTable GetAllBeds()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _bed.sp_SelectAllBeds());
        }

        public DataTable GetAvailableBeds(bool isAvailable)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _bed.sp_Select(),
                                              parameters: _bed.SelectByisAvailableParemeter(isAvailable));
        }

        public int Update_BedStatus(int ID, bool isAvailable)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _bed.sp_Update(),
                                                parameters: _bed.GetUpdateBedStatusParameters(ID, isAvailable));
        }
        #endregion

        #region BloodGroup
        public DataTable Get_AllBloodGroup()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _bloodGroup.sp_Select());
        }
        #endregion

        #region Diagnosis
        public int Add_Diagnosis(IDiagnosis diagnosis)
        {
            return _queryManager.ExecuteNonQuery(
                storedProcedure: _diagnosis.sp_Insert(),
                parameters: _diagnosis.GetInsertParameters(diagnosis),
                nameof(IDiagnosis.DiagnosisID));
        }

        public DataTable Get_Diagnosis(int diagnosisID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _diagnosis.sp_SelectBySelf(),
                parameters: _diagnosis.GetIDParameter(diagnosisID));
        }
        #endregion

        #region Doctor
        public DataTable GetAll_DoctorGP()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _doctor.sp_SelectByDoctorGP());
        }

        public DataTable GetAll_DoctorSpecialist()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _doctor.sp_SelectByDoctorSpecialist());
        }
        #endregion

        #region DoctorType
        public DataTable Get_DoctorType()
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _doctorType.sp_Select());
        }
        #endregion

        #region EmergencyContact
        public int Add_EmergencyContact(IEmergencyContact contact)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _emergencyContact.sp_Insert(),
                parameters: _emergencyContact.GetInsertParameters(contact));
        }

        public DataTable Get_EmergencyContact(int patientID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _emergencyContact.sp_SelectByPatient(),
                parameters: _emergencyContact.GetSelectByPatientParameters(patientID));
        }


        public DataTable Get_Month()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _month.sp_GetMonth());
        }

        public int Update_EmergencyContact(IEmergencyContact contact)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _emergencyContact.sp_Update(),
                parameters: _emergencyContact.GetUpdateParameters(contact));
        }
        #endregion

        #region MedicalAid
        public int Add_MedicalAid(IMedicalAid aid)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _medicalAid.sp_Insert(),
                parameters: _medicalAid.GetInsertParameters(aid));
        }

        public DataTable Get_MedicalAid(int patientID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _medicalAid.sp_SelectByPatient(),
                parameters: _medicalAid.GetPatientIDParameter(patientID));
        }

        public int Update_MedicalAid(IMedicalAid aid)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _medicalAid.sp_Update(),
                parameters: _medicalAid.GetUpdateParameters(aid));
        }
        #endregion

        #region MedicalAidPlan
        public DataTable GetAll_MedicalAidPlan()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _medicalAidPlan.sp_Select());
        }
        #endregion

        #region MedicalAidScheme
        public DataTable GetAll_MedicalAidScheme()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _medicalAidScheme.sp_Select());
        }
        #endregion

        #region MedicalCondition
        public DataTable GetAll_MedicalCondition()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _medicalCondition.sp_Select());
        }
        #endregion

        #region Medicine
        public DataTable Get_AllMedicine()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _medicine.sp_Select());
        }
        #endregion

        #region NextOfKin
        public int Add_NextOfKin(INextOfKin kin)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _nextOfKin.sp_Insert(),
                parameters: _nextOfKin.GetInsertParameters(kin));
        }

        public DataTable Get_NextOfKin(int patientID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _nextOfKin.sp_SelectByPatient(),
                parameters: _nextOfKin.GetPatientIDParameter(patientID));
        }

        public int Update_NextOfKin(INextOfKin kin)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _nextOfKin.sp_Update(),
                parameters: _nextOfKin.GetUpdateParameters(kin));
        }
        #endregion

        #region Patient
        public int Add_Patient(IPatient patient)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _patient.sp_Insert(),
                parameters: _patient.GetInsertParameters(patient),
                nameof(IPatient.PatientID));
        }

        public DataTable GetAll_Patient()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _patient.sp_Select());
        }

        public DataTable Get_Patient(int patientID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _patient.sp_SelectByPatient(),
                parameters: _patient.GetIDParameter(patientID));
        }

        public DataTable Get_Patient(string name)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _patient.sp_SelectByName(),
                parameters: _patient.GetNameParameter(name));
        }

        public int Update_Patient(IPatient patient)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _patient.sp_Update(),
                parameters: _patient.GetUpdateParameters(patient));
        }
        public DataTable Get_PatientNoReferral()
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _patient.sp_GetPatientNoReferral());
        }

        public DataTable Get_PatientReferralTimeline(int patientID)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _patient.sp_GetPatientReferralTimeline(),
                parameters: _patient.GetIDParameter(patientID));
        }

        public DataTable Get_PatientTreatmentTimeline(int patientID)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _patient.sp_GetPatientTreatmentTimeline(),
                parameters: _patient.GetIDParameter(patientID));
        }
        #endregion

        #region Prescription
        public DataTable Get_Prescription(int patientID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _prescription.sp_SelectByPatient(),
                                             parameters: _prescription.GetSelectByPatientParameters(patientID));
        }

        public DataTable Get_AllPrecsription()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _prescription.sp_Select());
        }

        public int Add_Prescription(IPrescription prescriptions)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _prescription.sp_Insert(),
                                              parameters: _prescription.GetInsertParameters(prescriptions),
                                              nameof(IAdmissionFile.AdmissionFileID));
        }

        public int Update_Prescription(IPrescription prescriptions)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _prescription.sp_Update(),
                                              parameters: _prescription.GetUpdateParameters(prescriptions));
        }
        #endregion

        #region Referral
        public int Add_Referral(IReferral referral)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _referral.sp_Insert(),
                parameters: _referral.GetInsertParameters(referral));
        }

        public DataTable Get_Referral(int patientID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _referral.sp_SelectByPatient(),
                parameters: _referral.GetPatientIDParameter(patientID));
        }

        public DataTable Get_AllReferral(bool isAdmitted)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _referral.sp_Select(),
                 parameters: _referral.GetReferralByisAdmittedParameter(isAdmitted));
        }

        public int Update_Referral(IReferral referrals)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _referral.sp_Update(),
                                                parameters: _referral.GetUpdateParameters(referrals));
        }

        public int Update_ReferralStatus(int ID, bool isAdmitted)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _referral.sp_UpdateStatus(),
                                                 parameters: _referral.GetUpdateReferralStatus(ID, isAdmitted));
        }

        public DataTable Get_PendingReferrals()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _referral.sp_SelectPending());
        }
        #endregion

        #region Specialization
        public DataTable GetAll_Specialization()
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _specialization.sp_Select());
        }
        #endregion

        #region Suburb
        public DataTable GetAll_Suburb()
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _suburb.sp_Select());
        }
        #endregion

        #region PatientMovement
        public int Add_PatientCheckOut(IPatientMovement patientMov)
        {
            return _queryManager.ExecuteNonQuery(
                storedProcedure: _patientMovement.sp_Insert(),
                parameters: _patientMovement.GetInsertParameters(patientMov)
                );
        }

        public DataTable GetAll_PatientMovement()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _patientMovement.sp_Select());
        }

        public DataTable GetPatientMovementByPatientID(int PatientID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _patientMovement.sp_SelectByPatient(),
                parameters: _patientMovement.GetSelectByPatientIDParameter(PatientID)
                );
        }


        public DataTable GetPatientMovementByCheckOutStatus(bool isCheckedOut)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _patientMovement.sp_SelectByStatus(),
                  parameters: _patientMovement.GetSelectByStatusParameter(isCheckedOut));
        }


        public int Update_PatientCheckOut(IPatientMovement patientMove)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _patientMovement.sp_Update(),
                parameters: _patientMovement.GetUpdateParameters(patientMove));
        }

        public DataTable GetPatientMovementByDateRange(IPatient patient, DateTime startDate, DateTime endDate)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _patientMovement.sp_SelectByDateRange(),
                parameters: _patientMovement.GetSelectByDateRangeParameters(patient, startDate, endDate));
        }


        public DataTable GetPatientMovementByReason(int reason)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _patientMovement.sp_SelectByReason(),
                parameters: _patientMovement.GetSelectByReasonParameter(reason));

        }
        public DataTable GetPatientMovementByID(int moveID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _patientMovement.sp_SelectBySelf(),
                  parameters: _patientMovement.GetSelectByMoveIDParameter(moveID));
        }

        public DataTable GetNotifications(DateTime latetime, bool isCheckedOut)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _patientMovement.sp_SelectByNotification(),
                  parameters: _patientMovement.GetSelectByNotificationParameters(latetime,isCheckedOut));
        }
        #endregion


        #region Treatment

        public DataTable Get_Treatment(int PatientID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _treatment.sp_SelectByPatient(),
                                             parameters: _treatment.GetSelectByPatientParameters(PatientID));
        }

        public int Add_Treatment(ITreatment treatment)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _treatment.sp_Insert(),
                                             parameters: _treatment.GetInsertParameters(treatment));
        }
        #endregion

        #region TreatmentType
        public DataTable Get_AllTreatmentType()
        {
            return _queryManager.ExecuteQuery(storedProcedure: _treatmentType.sp_Select());
        }
        #endregion

        #region VitaslSign
        public DataTable Get_VitalSigns(int AdmissionFileID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _vitalSign.sp_SelectByAdmissionFileID(),
               parameters: _vitalSign.GetSelectByAdmissionFileParameters(AdmissionFileID));
        }

        public int Add_VitalSigns(IVitalSign vitalsign)
        {
            return _queryManager.ExecuteNonQuery(storedProcedure: _vitalSign.sp_Insert(),
                parameters: _vitalSign.GetInsertParameters(vitalsign));

        }
        #endregion

        #region Authentication
        public DataTable Auth_FindUserByID(int userID)
        {
            return _queryManager.ExecuteQuery(
             storedProcedure: _user.sp_SelectUserByUserID(),
             parameters: _user.GetSelectByUserIDParameters(userID));
        }

        public DataTable Auth_FindUserByName(string userName)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _user.sp_SelectUserByUserName(),
                parameters: _user.GetSelectByUserNameParameters(userName));
        }

        public DataTable Auth_FindRoleByID(int roleID)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _role.sp_SelectRoleByID(),
                parameters: _role.GetSelectByRoleIDParameters(roleID));
        }

        public DataTable Auth_FindRoleByName(string roleName)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _role.sp_SelectRoleByRoleName(),
                parameters: _role.GetSelectByRoleNameParameters(roleName));
        }

        public DataTable Auth_FindUserByRoleName(string roleName)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _user.sp_SelectUsersByRoleName(),
                _role.GetSelectByRoleNameParameters(roleName));
        }
        public DataTable Auth_FindRoleByUserID(int userID)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _role.sp_SelectRolesByUserID(),
                parameters: _role.GetSelectByUserIDParameters(userID));
        }
        #endregion

        #region Scheduling

        public DataTable Get_NurseSchedule(int ShiftSLotID)
        {
            return _queryManager.ExecuteQuery(
            storedProcedure: _nurseSchedule.sp_Get_Schedule(),
            parameters: _nurseSchedule.GetShiftSlotID(ShiftSLotID));
        }

        public DataTable Get_Clocking(int NurseID)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _clocking.sp_Get_Clocking(),
                parameters: _clocking.GetNurseIDParameter(NurseID));
        }

        public DataTable Get_Month(int MonthID)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _month.sp_GetMonth(),
                parameters: _month.GetMonthID(MonthID));
        }

        public DataTable Get_Nurse(int NurseID)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _nurse.sp_Get_Nurse(),
                parameters: _nurse.GetNurseID(NurseID));
        }


        public int Add_Nurse(INurse nurse)
        {
            throw new System.NotImplementedException();
        }

        public int Update_Nurse(INurse nurse)
        {
            throw new System.NotImplementedException();
        }

        public int Add_NurseSchedule(int ShiftSlotID)
        {
            throw new System.NotImplementedException();
        }

        public int Update_NurseSchedule(INurseSchedule nurseSchedule)
        {
            throw new System.NotImplementedException();
        }

        public DataTable Get_NurseType(INurseType nurseType)
        {
            throw new System.NotImplementedException();
        }

        public DataTable Get_ShiftSlot(IShiftSlot shiftSlot)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _shiftSlot.sp_Get_ShiftSlot(),
                parameters: _shiftSlot.GetShiftSlotID(shiftSlot));
        }
        #endregion

        public DataTable Get_Specialization(ISpecialization specialization)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetDoctor_ContactInfo(int doctorID)
        {
            return _queryManager.ExecuteQuery(storedProcedure: _doctor.sp_SelectByRequestDoctor(),
                parameters: _doctor.GetDoctorIDParameter(doctorID));
        }
        public DataTable Get_AllNurses()
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _nurse.sp_Select());
        }

        public DataTable Get_NurseScheduleByNurse(int nurseID)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _nurseSchedule.sp_GetNurseScheduleByNurse(),
                parameters: _nurseSchedule.GetNurseIDParameter(nurseID));
        }

        public DataTable Get_ClockingByNurse(int nurseID)
        {
            return _queryManager.ExecuteQuery(
                storedProcedure: _clocking.sp_Get_Clocking(),
                parameters: _clocking.GetNurseIDParameter(nurseID));
        }

        
    }
}