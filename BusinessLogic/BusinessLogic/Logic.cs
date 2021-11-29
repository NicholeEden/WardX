using BusinessLogic.Interface;
using BusinessLogic.Model;
using DataAccess.Interface;
using EFCore.Interface;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace BusinessLogic
{
    public class Logic : IBusinessLogic
    {
        /// <summary>
        /// Data Access layer methods
        /// </summary>
        private readonly IDatabaseAccess _databaseAccess;

        /// <summary>
        /// Generic methods to convert data
        /// </summary>
        private readonly IDataProvider _dataProvider;

        /// <summary>
        /// 
        /// </summary>
        SmtpClient client;

        public Logic(IDataProvider dataProvider)
        {
            _databaseAccess = ScopeProvider.DataAccessScope();
            _dataProvider = dataProvider;
        }

        #region Patient Processor
        public Patient GetPatient(int id)
        {
            // get data table from the database
            var table = _databaseAccess.Get_Patient(id);
            // convert the data table to a class objects
            return _dataProvider.GetClassFromTable<Patient>(table);
        }

        public List<Patient> GetPatients()
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_Patient();
            // convert the data table to a list of class objects
            return _dataProvider.GetClassListFromTable<Patient>(table);
        }

        public List<Patient> GetPatientsNoReferral()
        {
            // get data table from the database
            var table = _databaseAccess.Get_PatientNoReferral();
            // convert the data table to a list of class objects
            return _dataProvider.GetClassListFromTable<Patient>(table);
        }

        public List<Patient> GetPatients(string keyword)
        {
            // get data table from the database
            var table = _databaseAccess.Get_Patient(keyword);
            // convert the data table to a list of class objects
            return _dataProvider.GetClassListFromTable<Patient>(table);
        }

        public MedicalAidPlan GetAidPlan(int medicalAidPlanID)
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_MedicalAidPlan();
            // convert the data table to a list of class objects
            var plan = _dataProvider.GetClassListFromTable<MedicalAidPlan>(table);
            // find and return the object that matches the specified parameter
            return plan.Find(entity => entity.MedicalAidPlanID == medicalAidPlanID);
        }

        public MedicalAidScheme GetAidScheme(int medicalAidSchemeID)
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_MedicalAidScheme();
            // convert the data table to a list of class objects
            var scheme = _dataProvider.GetClassListFromTable<MedicalAidScheme>(table);
            // find and return the object that matches the specified parameter
            return scheme.Find(entity => entity.MedicalAidSchemeID == medicalAidSchemeID);
        }

        public MedicalAid GetMedicalAid(int patientID)
        {
            // get data table from the database
            var table = _databaseAccess.Get_MedicalAid(patientID);
            // convert the data table to a class objects
            return _dataProvider.GetClassFromTable<MedicalAid>(table);
        }

        public NextOfKin GetNextOfKin(int patientID)
        {
            // get data table from the database
            var table = _databaseAccess.Get_NextOfKin(patientID);
            // convert the data table to a class objects
            return _dataProvider.GetClassFromTable<NextOfKin>(table);
        }

        public Suburb GetSuburb(int suburbID)
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_Suburb();
            // convert the data table to a list of class objects
            var suburb = _dataProvider.GetClassListFromTable<Suburb>(table);
            // find and return the object that matches the specified parameter
            return suburb.Find(entity => entity.SuburbID == suburbID);
        }

        public ProcessResult CreateProfile(IPatient patient, INextOfKin kin, IMedicalAid medicalAid)
        {
            // add patient entry to database
            var patientID = _databaseAccess.Add_Patient(patient);

            // the primary key is not returned
            if (patientID < 101)
            {
                //TODO: Implement delete on database
                return ProcessResult.PatientFailed;
            }

            // add next of kin entry to database
            kin.PatientID = patientID;
            var result = _databaseAccess.Add_NextOfKin(kin);

            // insert failed
            if (result < 1)
            {
                //TODO: Implement delete on database
                return ProcessResult.NextofKinFailed;
            }

            // add medical aid entry to database
            medicalAid.PatientID = patientID;
            result = _databaseAccess.Add_MedicalAid(medicalAid);

            // insert failed
            if (result < 1)
            {
                //TODO: Implement delete on database
                return ProcessResult.MedicalAidFailed;
            }

            // no errors encountered
            return ProcessResult.Succeeded;
        }

        public MedicalCondition GetMedicalCondition(int medicalConditionID)
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_MedicalCondition();
            // convert the data table to a list of class objects
            var condition = _dataProvider.GetClassListFromTable<MedicalCondition>(table);
            // find and return the object that matches the specified parameter
            return condition.Find(entity => entity.MedicalConditionID == medicalConditionID);
        }

        public List<MedicalCondition> GetMedicalConditions()
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_MedicalCondition();
            // convert the data table to a list of class objects
            return _dataProvider.GetClassListFromTable<MedicalCondition>(table);
        }

        public ProcessResult CreateReferral(IDiagnosis diagnosis, IReferral referral)
        {
            // add diagnosis entry to database
            var diagnosisID = _databaseAccess.Add_Diagnosis(diagnosis);

            // the primary key is not returned
            if (diagnosisID < 101)
            {
                //TODO: Implement delete on database
                return ProcessResult.DiagnosisFailed;
            }

            // add referral entry to database
            referral.DiagnosisID = diagnosisID;
            var result = _databaseAccess.Add_Referral(referral);

            // insert failed
            if (result < 1)
            {
                //TODO: Implement delete on database
                return ProcessResult.ReferralFailed;
            }

            // no errors encountered
            return ProcessResult.Succeeded;
        }

        public Diagnosis GetDiagnosis(int diagnosisID)
        {
            /// get data table from the database
            var table = _databaseAccess.Get_Diagnosis(diagnosisID);
            // convert the data table to a class objects
            return _dataProvider.GetClassFromTable<Diagnosis>(table);
        }

        public Referral GetReferral(int patientID)
        {
            // get data table from the database
            var table = _databaseAccess.Get_Referral(patientID);
            // convert the data table to a objects
            return _dataProvider.GetClassFromTable<Referral>(table);
        }

        public List<Referral> GetPendingReferral()
        {
            // get data table from the database
            var table = _databaseAccess.Get_PendingReferrals();
            // concert the data table to a list of objects
            return _dataProvider.GetClassListFromTable<Referral>(table);
        }

        public List<ReferralTimeline> GetReferralTimelines(int patientID)
        {
            // get data table from the database
            var table = _databaseAccess.Get_PatientReferralTimeline(patientID);
            // concert the data table to a list of objects
            return _dataProvider.GetClassListFromTable<ReferralTimeline>(table);
        }

        public List<TreatmentTimeline> GetTreatmentTimelines(int patientID)
        {
            // get data table from the database
            var table = _databaseAccess.Get_PatientTreatmentTimeline(patientID);
            // concert the data table to a list of objects
            return _dataProvider.GetClassListFromTable<TreatmentTimeline>(table);
        }
        #endregion

        #region DropDown Processor
        public Dictionary<string, string> GetMedicalConditionList()
        {
            // get data table the from database
            var table = _databaseAccess.GetAll_MedicalCondition();
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(IMedicalCondition.MedicalConditionID),
                nameof(IMedicalCondition.Name));
        }

        public Dictionary<string, string> GetGPDoctorList()
        {
            // get data table the from database
            var table = _databaseAccess.GetAll_DoctorGP();
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(IDoctor.DoctorID),
                nameof(IStaffMember.FirstName));
        }

        public Dictionary<string, string> GetSpecialistDoctorList()
        {
            // get data table the from database
            var table = _databaseAccess.GetAll_DoctorSpecialist();
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(IDoctor.DoctorID),
                nameof(IStaffMember.FirstName),
                nameof(IStaffMember.LastName),
                nameof(IDoctor.PracticeNumber));
        }

        public Dictionary<string, string> GetSuburbs()
        {
            // get data table the from database
            var table = _databaseAccess.GetAll_Suburb();
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(ISuburb.SuburbID),
                nameof(ISuburb.SuburbName));
        }

        public Dictionary<string, string> GetMedicalAidSchemes()
        {
            // get data table the from database
            var table = _databaseAccess.GetAll_MedicalAidScheme();
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(IMedicalAidScheme.MedicalAidSchemeID),
                nameof(IMedicalAidScheme.Name));
        }

        public Dictionary<string, string> GetMedicalAidPlans()
        {
            // get data table the from database
            var table = _databaseAccess.GetAll_MedicalAidPlan();
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(IMedicalAidPlan.MedicalAidPlanID),
                nameof(IMedicalAidPlan.Name));
        }
        public Dictionary<string, string> GetReasonList()
        {

            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetAdmissionFileList()
        {
            var table = _databaseAccess.Get_AllAdmissionFile();
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(IAdmissionFile.AdmissionFileID),
                nameof(IAdmissionFile.PatientID));
        }

        public Dictionary<string, string> GetBeds()
        {
            var table = _databaseAccess.GetAvailableBeds(true);
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(IBed.BedID),
                nameof(IBed.Description));
        }

        public Dictionary<string, string> GetPrescriptionList()
        {
            var table = _databaseAccess.Get_AllPrecsription();
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(IPrescription.PrescriptionID),
                nameof(IPrescription.Instruction));
        }

        public Dictionary<string, string> GetPatientList()
        {
            var table = _databaseAccess.GetAll_Patient();
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(IPatient.PatientID),
                nameof(IPatient.FirstName));
        }
        #endregion

        #region Admission Processor
        public List<Referral> GetReferrals(bool isAdmitted)
        {
            // get data table the from database
            var table = _databaseAccess.Get_AllReferral(isAdmitted);
            // convert the data table to a list of class objects
            var referrals = _dataProvider.GetClassListFromTable<Referral>(table);
            return referrals;
        }

        public List<AdmissionFile> GetAdmissionFiles()
        {
            // get data table the from database
            var table = _databaseAccess.Get_AllAdmissionFile();
            // convert the data table to a list of class objects
            var admissionFiles = _dataProvider.GetClassListFromTable<AdmissionFile>(table);
            return admissionFiles;
        }

        public AdmissionFile GetAdmissionFile(int patientID)
        {
            // get data table the from database
            var table = _databaseAccess.Get_AllAdmissionFile();
            // convert the data table to a class objects
            var admissionFiles = _dataProvider.GetClassListFromTable<AdmissionFile>(table);
            // return only the matching admission file
            var file = admissionFiles.Find(list => list.PatientID == patientID);
            // return matching file
            return file;
        }

        public ProcessResult CreateAdmission(IAdmissionFile admissionFile, int bedID, bool isAvailable, int referralID, bool isAdmitted)
        {
            // add AdmissionFile entry to database
            var result = _databaseAccess.Add_AdmissionFile(admissionFile);

            // changing the specified bed status isAvaiable to the bed entry in the database
            var setBedStatus = _databaseAccess.Update_BedStatus(bedID, isAvailable);

            // changing the specified referral status isAvaiable to the bed entry in the database
            var setReferralStatus = _databaseAccess.Update_ReferralStatus(referralID, isAdmitted);

            // insert failed
            if (result < 1 && setBedStatus < 1 && setReferralStatus < 1)
            {
                //TODO: Implement delete on database
                return ProcessResult.AdmissionFileFailed;
            }

            
            // no errors encountered
            return ProcessResult.Succeeded;
        }

        public ProcessResult UpdateAdmission(IAdmissionFile admissionFile, int bedID, bool isAvailable)
        {
            // add AdmissionFile entry to database
            var result = _databaseAccess.Update_AdmissionFile(admissionFile);

            // changing the specified bed status isAvaiable to the bed entry in the database
            var setBedStatus = _databaseAccess.Update_BedStatus(bedID, isAvailable);

            // insert failed
            if (result < 1 && setBedStatus < 1)
            {
                //TODO: Implement delete on database
                return ProcessResult.AdmissionFileFailed;
            }


            // no errors encountered
            return ProcessResult.Succeeded;
        }

        public ProcessResult UpdateAdmissionWithDischarge(IAdmissionFile admissionFile, int bedID, bool isAvailable)
        {
            var result = _databaseAccess.Update_AdmissionFileDischarge(admissionFile);

            // changing the specified bed status isAvaiable to the bed entry in the database
            var setBedStatus = _databaseAccess.Update_BedStatus(bedID, isAvailable);

            // insert failed
            if (result < 1 && setBedStatus < 1)
            {
                //TODO: Implement delete on database
                return ProcessResult.AdmissionFileFailed;
            }


            // no errors encountered
            return ProcessResult.Succeeded;
        }

        public AdmissionFile GetAdmissionFileByadmissionID(int admissionFileID)
        {

            // get data table the from database
            var table = _databaseAccess.Get_AllAdmissionFile();
            // convert the data table to a class objects
            var admissionFiles = _dataProvider.GetClassListFromTable<AdmissionFile>(table);
            // return only the matching admission file
            var file = admissionFiles.Find(list => list.AdmissionFileID == admissionFileID);
            // return matching file
            return file;
        }

        public List<Bed> GetAllBeds()
        {
            var table = _databaseAccess.GetAllBeds();

            var allBeds = _dataProvider.GetClassListFromTable<Bed>(table);

            return allBeds;
        }


        public List<Bed> GetAllAvailableBeds(bool isAvailable)
        {
            var table = _databaseAccess.GetAvailableBeds(isAvailable);

            var beds = _dataProvider.GetClassListFromTable<Bed>(table)
                .FindAll(status => status.isAvailable == isAvailable);

            return beds;
        }

        public Prescription GetPrescription(int patient)
        {
            var table = _databaseAccess.Get_Prescription(patient);
            // convert the data table to a class objects
            var _prescription = _dataProvider.GetClassFromTable<Prescription>(table);
            return _prescription;
        }

        public List<Prescription> GetPrescriptions()
        {
            // get data table the from database
            var table = _databaseAccess.Get_AllPrecsription();
            // convert the data table to a class objects
            var prescription = _dataProvider.GetClassListFromTable<Prescription>(table);
            return prescription;
        }

        #endregion

        #region Move Processor
        public List<PatientMovement> GetPatientMovements()
        {
            // get data table the from database
            var table = _databaseAccess.GetAll_PatientMovement();
            // convert the data table to a list of class objects
            var condition = _dataProvider.GetClassListFromTable<PatientMovement>(table);
            return condition;
        }

        public List<PatientMovement> GetDateRangeReport(IPatient patient, System.DateTime startDate, System.DateTime endDate)
        {
            // get data table the from database
            var table = _databaseAccess.GetPatientMovementByDateRange(patient, startDate, endDate);
            // convert the data table to a list of class objects
            var condition = _dataProvider.GetClassListFromTable<PatientMovement>(table);
            return condition;
        }

        public List<PatientMovement> GetPatientMovementByReason(int reason)
        {
            // get data table the from database
            var table = _databaseAccess.GetAll_PatientMovement();
            // convert the data table to a list of Patient Movement class objects
            var list = _dataProvider.GetClassListFromTable<PatientMovement>(table);

            //find any that match the provided reason
            var move = list.FindAll(x => x.Reason == (Reason)reason);

            return move;
        }

        public List<PatientMovement> GetCheckOutStatusList(bool isCheckedOut)
        {
            // get data table the from database
            var table = _databaseAccess.GetPatientMovementByCheckOutStatus(isCheckedOut);
            // convert the data table to a list of class objects
             var condition = _dataProvider.GetClassListFromTable<PatientMovement>(table)
                .FindAll(status=>status.isCheckedOut == isCheckedOut);
            
            return condition;
            
           
        }
        public ProcessResult AddCheckOut(IPatientMovement patientMovement)
        {
           var result = _databaseAccess.Add_PatientCheckOut(patientMovement);
            if (result > 0)
            {
                return ProcessResult.Succeeded;
            }
            return ProcessResult.Failed;
        }

        public void UpdateCheckOut(IPatientMovement patientMovement)
        {
            var result = _databaseAccess.Update_PatientCheckOut(patientMovement);
            
        }

        public PatientMovement GetPatientMovementFile(int patientMoveID)
        {
            // get data table the from database
            var table = _databaseAccess.GetAll_PatientMovement();
            // convert the data table to a class objects
            var patientMovements = _dataProvider.GetClassListFromTable<PatientMovement>(table);
            // return only the matching admission file
            var file = patientMovements.Find(list => list.PatientMovementID == patientMoveID);
            // return matching file
            return file;

        }

        public List<PatientMovement> GetNotifications(System.DateTime latetime, bool isCheckedOut)
        {
            // get data table the from database
            var table = _databaseAccess.GetNotifications(latetime, isCheckedOut);
            // convert the data table to a list of class objects
            var condition = _dataProvider.GetClassListFromTable<PatientMovement>(table);
            return condition;
        }
        #endregion

        #region Treatment Processor

        public ProcessResult AddPrescription (IPrescription prescription)
        {
            var result = _databaseAccess.Add_Prescription(prescription);
            if (result > 0)
            {
                return ProcessResult.Succeeded;
            }
            return ProcessResult.Failed;
        }

        public ProcessResult AddTreatment(ITreatment treatment)
        {
            var result = _databaseAccess.Add_Treatment(treatment);
            if (result > 0)
            {
                return ProcessResult.Succeeded;
            }
            return ProcessResult.Failed;
        }

        public ProcessResult AddVitalSign(IVitalSign vitalSign)
        {
            var result = _databaseAccess.Add_VitalSigns(vitalSign);
            if (result > 0)
            {
                return ProcessResult.Succeeded;
            }
            return ProcessResult.Failed;
        }

        public List<Medication> GetMedicationList()
        {
            // get data table the from database
            var table = _databaseAccess.Get_AllMedicine();
            // convert the data table to a list of class objects
            var condition = _dataProvider.GetClassListFromTable<Medication>(table);
            return condition;
        }
        public List<BloodGroup> GetBloodGroupList()
        {
            // get data table the from database
            var table = _databaseAccess.Get_AllBloodGroup();
            // convert the data table to a list of class objects
            var condition = _dataProvider.GetClassListFromTable<BloodGroup>(table);
            return condition;
        }
        public List<TreatmentType> GetTreatmentTypeList()
        {
            // get data table the from database
            var table = _databaseAccess.Get_AllTreatmentType();
            // convert the data table to a list of class objects
            var condition = _dataProvider.GetClassListFromTable<TreatmentType>(table);
            return condition;
        }
        public List<VitalSign> GetVitals(int admissionFileNo)
        {
            // get data table the from database
            var table = _databaseAccess.Get_VitalSigns(admissionFileNo);
            // convert the data table to a list of class objects
            var condition = _dataProvider.GetClassListFromTable<VitalSign>(table);
            return condition;
        }
        public List<Prescription> GetPrescriptions(int admissionFileNo)
        {
            // get data table the from database
            var table = _databaseAccess.Get_AllPrecsription();
            // convert the data table to a list of class objects
            var condition = _dataProvider.GetClassListFromTable<Prescription>(table);
            return condition;
        }
        #endregion

        #region EmailSender
        public bool SendEmail(ClientType type,
            NetworkCredential credential,
            string fromEmail,
            string toEmail,
            string subject,
            string body)
        {
            
            // resolve the SmtpClient
            switch (type)
            {
                case ClientType.Microsoft:
                    client = new SmtpClient("smtp.live.com", 587);
                    break;
                case ClientType.Google:
                    client = new SmtpClient("smtp.gmail.com", 587);
                    break;
                case ClientType.Yahoo:
                    return false;
                default:
                    return false;
            }

            // enable encryption
            client.EnableSsl = true;
            // out going email handler
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            // credentials for authentication
            client.Credentials = credential;

            // set default sender
            Email.DefaultSender = new SmtpSender(client);

            IFluentEmail email;
            try
            {
                // configure email
                email = Email.From(fromEmail)
                    .To(toEmail)
                    .Subject(subject)
                    .Body(body);
            }
            catch (System.Exception)
            {

                return false;
            }

            // send email
            var response = email.SendAsync();

            // true if email was sent
            return response.Result.Successful;
        }
        #endregion

        public List<Doctor> GetGPDoctors()
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_DoctorGP();
            // convert the data table to a list of class objects
            var doctor = _dataProvider.GetClassListFromTable<Doctor>(table);
            return doctor;
        }

        public List<Doctor> GetSpecialistDoctors()
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_DoctorSpecialist();
            // convert the data table to a list of class objects
            var doctor = _dataProvider.GetClassListFromTable<Doctor>(table);
            return doctor;
        }

        public Specialization GetSpecialization(int specializationID)
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_Specialization();
            // convert the data table to a list of class objects
            var specialization = _dataProvider.GetClassListFromTable<Specialization>(table);
            // find and return the object that matches the specified parameter
            return specialization.Find(entity => entity.SpecializationID == specializationID);
        }

        public Doctor GetGPDoctor(int doctorID)
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_DoctorGP();
            // convert the data table to a list of class objects
            var doctor = _dataProvider.GetClassListFromTable<Doctor>(table)
                .Find(doc => doc.DoctorID ==  doctorID);
            return doctor;
        }

        public Doctor GetSpecialistDoctor(int doctorID)
        {
            // get data table from the database
            var table = _databaseAccess.GetAll_DoctorSpecialist();
            // convert the data table to a list of class objects
            var doctor = _dataProvider.GetClassListFromTable<Doctor>(table)
                .Find(doc => doc.DoctorID == doctorID);
            return doctor;
        }

        #region Scheduling
        public List<Nurse> GetNurseID()
        {
            // get data table the from database
            var nurseTbl = _databaseAccess.Get_AllNurses();
            // convert the data table to a class objects
            var nurse = _dataProvider.GetClassListFromTable<Nurse>(nurseTbl);
            return nurse;
        }

        public Dictionary<string, string> GetNurseList()
        {
            // get data table the from database
            var table = _databaseAccess.Get_AllNurses();
            // convert to a list
            return _dataProvider.ForDropdownList(table,
                nameof(INurse.NurseID),
                nameof(IStaffMember.FirstName));
        }

        public Dictionary<string, string> GetMonths()
        {
            var monthList = new Dictionary<string, string>();
            return monthList;
        }   


        public Dictionary<string, string> GetShiftSlots()
        {
            var slotList = new Dictionary<string, string>();
            return slotList;
        }

        public bool isShiftAvailable(int ShiftSlotID)
        {
            throw new System.NotImplementedException();
        }

        public List<INurseSchedule> GetNurseSchedules()
        {
            throw new System.NotImplementedException();
        }

        public INurse GetNurse(int nurseID)
        {
            throw new System.NotImplementedException();
        }

        public IStaffMember GetStaffMember(int nurseID)
        {
            throw new System.NotImplementedException();
        }

        public IMonth GetMonth(int monthID)
        {
            throw new System.NotImplementedException();
        }

        public IShiftSlot GetShiftSlot(int shiftSlotID)
        {
            throw new System.NotImplementedException();
        }
        public ProcessResult AddNurses(INurse nurse)
        {
            var result = _databaseAccess.Add_Nurse(nurse);

            if (result > 0)
            {
                return ProcessResult.Succeeded;
            }
            return ProcessResult.Failed;
        }


        public List<Nurse> GetNurses()
        {
            // get data table from the database
            var table = _databaseAccess.Get_AllNurses();
            // convert the data table to a list of class objects
            var nurse = _dataProvider.GetClassListFromTable<Nurse>(table);
            return nurse;
        }

        public IClocking GetClocking(int nurseID)
        {
            // get data table the from database
            var table = _databaseAccess.Get_ClockingByNurse(nurseID);
            // convert the data table to a list of class objects
            var clocking = _dataProvider.GetClassListFromTable<PatientMovement>(table);
                      

            return (IClocking)clocking;


        }

       

        #endregion

    }
}