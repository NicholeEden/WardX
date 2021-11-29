using EFCore.Interface;
using System.Collections;
using System.Collections.Generic;

namespace EFCore.Tests
{
    public class InterfaceTestData : IEnumerable<object[]>
    {
        // TODO: Implement these objects using inline data to avoid duplication
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { typeof(IAdmissionFile),
                new string[]{ "FileNo", "AdmissionDate", "DischargeDate", "Notes",
                    "PatientID", "DoctorID" } },

            new object[] { typeof(IBar),
                new string[]{"BarID", "Colour", "Description" } },

            new object[] { typeof(IBed),
                new string[]{ "BedID", "Descrption", "isAvailable" } },

            new object[] { typeof(IBloodGroup),
                new string[]{ "BloodGroupID", "BloodGroupName", "Description" } },

            new object[] { typeof(ICity),
                new string[]{ "CityID", "CityName" } },

            new object[] { typeof(IClerkComputer),
                new string[]{ "ClerkID", "ComputerSkillID", "ProficiencyLevel" } },

            new object[] { typeof(IComputerSkill),
                new string[]{ "ComputerSkillID", "Application" } },

            new object[] { typeof(IDoctor),
                new string[]{ "DoctorID", "SpecializationID", "DoctorTypeID" } },

            new object[] { typeof(IDoctorInspection),
                new string[]{ "DoctorInspectionID", "DoctorID", "PatientID", "Date",
                    "Comments" } },

            new object[] { typeof(IDoctorSchedule),
                new string[]{ "ScheduleID", "DoctorID", "MonthID", "ShiftSlotID",
                    "isAvailable" } },

            new object[] { typeof(IDoctorType),
                new string[]{ "DoctorTypeID", "Description" } },

            new object[] { typeof(IEpaulette),
                new string[]{ "EpauletteID", "Colour", "Description" } },

            new object[] { typeof(IMedicalHistory),
                new string[]{ "PatientID", "Diagnosis", "ExistingCondition", "BMI",
                    "Weight", "Allergies", "BloodGroupID" } },

            new object[] { typeof(IMonth),
                new string[]{ "MonthID", "MonthName", "StartDate", "EndDate" } },

            new object[] { typeof(INurse),
                new string[]{ "NurseID", "EpauletteID", "isWardManager", "isHeadNurse",
                    "SpecializationID", "NurseTypeID" } },

            new object[] { typeof(INurseBar),
                new string[]{ "BarID", "NurseID" } },

            new object[] { typeof(INurseInspection),
                new string[]{ "NurseInspectionID", "NurseID", "PatientID", "Date",
                    "Time", "Comments" } },

            new object[] { typeof(INurseSchedule),
                new string[]{ "ScheduleID", "isAvailable", "NurseID", "MonthID",
                    "ShiftSlotID" } },

            new object[] { typeof(INurseType),
                new string[]{ "NurseTypeID", "Description" } },

            new object[] { typeof(IPatient),
                new string[]{ "PatientID", "FirstName", "LastName", "IDNumber", "DOB",
                    "EmailAddress", "MobileNumber", "AddressLine1", "AddressLine2",
                    "VitalSignID", "SuburbID", "BedID" } },

            new object[] { typeof(IPrescription),
                new string[]{ "ScriptID", "PatientID", "DoctorID", "DateIssued", "Notes" } },

            new object[] { typeof(IProcedureHistory),
                new string[]{ "ProcedureID", "AppointmentDate", "AppointmentTime",
                    "ProcedureDescription", "PatientID", "Notes" } },

            new object[] { typeof(IQualification),
                new string[]{ "QualificationID", "Title", "Description" } },

            new object[] { typeof(IReceptionist),
                new string[]{ "ClerkID", "QualificationID" } },

            new object[] { typeof(IRole),
                new string[]{ "RoleID", "RoleName" } },

            new object[] { typeof(IShiftSlot),
                new string[]{ "SlotID", "Description", "StartTime", "EndTime" } },

            new object[] { typeof(ISpecialization),
                new string[]{ "SpecializationID", "Description" } },

            new object[] { typeof(IStaffMember),
                new string[]{ "StaffID", "FirstName", "LastName", "EmployeeID", "EmailAddress",
                    "AddressLine1", "AddressLine2", "SuburbID", "WorkNumber", "MobileNumber",
                    "isActive", "StaffType", "UserID" } },

            new object[] { typeof(ISuburb),
                new string[]{ "SuburbID", "SuburbName", "PostalCode", "CityID" } },

            new object[] { typeof(IUser),
                new string[]{ "UserID", "UserName", "PasswordHash" } },

            new object[] { typeof(IUserRole),
                new string[]{ "UserID", "RoleID" } },

            new object[] { typeof(IVitalSign),
                new string[]{ "VitalSignID", "DateRecorded", "Hypoglycemia", "BodyTemperature",
                    "PulseRate", "BloodPressure" } },
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
