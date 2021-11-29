using EFCore.Domain;
using EFCore.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace EFCore.ExtensionMethod
{
    public static class DomainSeed
    {
        #region Password Encryption
        private static string Hash(string password, int iterations)
        {
            byte[] salt;
            int hashSize = 20;
            int saltSize = 16;

            // create salt
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[saltSize]);

            // create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(hashSize);

            // create a byte array to combine salt and hash
            var hashBytes = new byte[saltSize + hashSize];
            // copy salt to hashBytes
            Array.Copy(salt, 0, hashBytes, 0, saltSize);
            // copy hash to hashBytes
            Array.Copy(hash, 0, hashBytes, saltSize, hashSize);

            // convert to base64 string
            var base64Hash = Convert.ToBase64String(hashBytes);

            // format hash with extra information
            return string.Format("$HWMS06${0}${1}", iterations, base64Hash);
        }
        #endregion

        #region AdmissionFile
        public static void SeedingAdmissionFile(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdmissionFile>().HasData(
                new AdmissionFile
                {
                    AdmissionFileID = 101,
                    PatientID = 101,
                    AdmissionDate = Convert.ToDateTime("2020/12/05"),
                    AssignedSpecialistID = 105,
                    DischargeDate = Convert.ToDateTime("2020/12/15"),
                    BedID = 101,
                    PrescriptionID = 101,
                    Notes = "none"
                },

                new AdmissionFile
                {
                    AdmissionFileID = 102,
                    PatientID = 102,
                    AdmissionDate = Convert.ToDateTime("2021/01/02"),
                    AssignedSpecialistID = 102,
                    DischargeDate = Convert.ToDateTime("2021/01/10"),
                    BedID = 103,
                    PrescriptionID = 103,
                    Notes = "Patient is feeling pain upon arrival"
                },

                new AdmissionFile
                {
                    AdmissionFileID = 103,
                    PatientID = 103,
                    AdmissionDate = Convert.ToDateTime("2021/01/19"),
                    AssignedSpecialistID = 104,
                    DischargeDate = null,
                    BedID = 106,
                    PrescriptionID = null,
                    Notes = "none"
                },

                new AdmissionFile
                {
                    AdmissionFileID = 104,
                    PatientID = 104,
                    AdmissionDate = Convert.ToDateTime("2020/01/18"),
                    AssignedSpecialistID = 108,
                    DischargeDate = null,
                    BedID = 102,
                    PrescriptionID = null,
                    Notes = "Patient has recent injury on the leg"
                },

                new AdmissionFile
                {
                    AdmissionFileID = 105,
                    PatientID = 105,
                    AdmissionDate = Convert.ToDateTime("2020/01/21"),
                    AssignedSpecialistID = 103,
                    DischargeDate = null,
                    BedID = 104,
                    PrescriptionID = null,
                    Notes = "none"
                });
        }
        #endregion

        #region Bar
        public static void SeedingBar(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bar>().HasData(
                new Bar { BarID = 101, Colour = "Green", Description = "Registered Midwife" },
                new Bar { BarID = 102, Colour = "White", Description = "Nursing Education Tutor" },
                new Bar { BarID = 103, Colour = "Navy Blue", Description = "Registered Psychiatric Nurse" },
                new Bar { BarID = 104, Colour = "Dark Saxe Blue", Description = "Registered Mental Nurse" },
                new Bar { BarID = 105, Colour = "Light Saxe Blue", Description = "Registered Mental Defectives Nurse" },
                new Bar { BarID = 106, Colour = "Yellow", Description = "Public Health Nursing" },
                new Bar { BarID = 107, Colour = "Silver", Description = "Nursing Admin" }
                );
        }
        #endregion

        #region Bed
        public static void SeedingBed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bed>().HasData(
                new Bed { BedID = 101, Description = "HWMSB01", isAvailable = true },
                new Bed { BedID = 102, Description = "HWMSB02", isAvailable = false },
                new Bed { BedID = 103, Description = "HWMSB03", isAvailable = true },
                new Bed { BedID = 104, Description = "HWMSB04", isAvailable = false },
                new Bed { BedID = 105, Description = "HWMSB05", isAvailable = true },
                new Bed { BedID = 106, Description = "HWMSB06", isAvailable = false },
                new Bed { BedID = 107, Description = "HWMSB07", isAvailable = true },
                new Bed { BedID = 108, Description = "HWMSB08", isAvailable = true },
                new Bed { BedID = 109, Description = "HWMSB09", isAvailable = true },
                new Bed { BedID = 110, Description = "HWMSB10", isAvailable = true },
                new Bed { BedID = 111, Description = "HWMSB11", isAvailable = true },
                new Bed { BedID = 112, Description = "HWMSB12", isAvailable = true },
                new Bed { BedID = 113, Description = "HWMSB13", isAvailable = true },
                new Bed { BedID = 114, Description = "HWMSB14", isAvailable = true },
                new Bed { BedID = 115, Description = "HWMSB15", isAvailable = true },
                new Bed { BedID = 116, Description = "HWMSB16", isAvailable = true },
                new Bed { BedID = 117, Description = "HWMSB17", isAvailable = true },
                new Bed { BedID = 118, Description = "HWMSB18", isAvailable = true },
                new Bed { BedID = 119, Description = "HWMSB19", isAvailable = true },
                new Bed { BedID = 120, Description = "HWMSB20", isAvailable = true });
        }
        #endregion

        #region Blood Group
        public static void SeedingBloodGroup(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodGroup>().HasData(
                new BloodGroup { BloodGroupID = 100, BloodGroupName = "O Negative", Description = "Universal Donor" },
                new BloodGroup { BloodGroupID = 101, BloodGroupName = "A Positive", Description = "Can donate to type A and AB positive" },
                new BloodGroup { BloodGroupID = 102, BloodGroupName = "AB Postive", Description = "Can donate to type AB positive" },
                new BloodGroup { BloodGroupID = 103, BloodGroupName = "B Postive", Description = "Can donate to type B and AB positive" },
                new BloodGroup { BloodGroupID = 104, BloodGroupName = "O Postive", Description = "Can donate to type O, A, B, AB postive" },
                new BloodGroup { BloodGroupID = 105, BloodGroupName = "A Negative", Description = "Can donate to type A, AB positive and negative" },
                new BloodGroup { BloodGroupID = 106, BloodGroupName = "AB Negative", Description = "Can donate to type AB positive and negative" },
                new BloodGroup { BloodGroupID = 107, BloodGroupName = "B Negative", Description = "Can donate to type B, AB positive and negative" });
        }
        #endregion

        #region City
        public static void SeedingCity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { CityID = 101, CityName = "Port Elizabeth" });
        }
        #endregion

        #region Clocking
        public static void SeedingClocking(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clocking>().HasData(
                new Clocking { ClockingID = 101, ClockInTime = new DateTime(2020, 1, 23, 5, 0, 0), ClockOutTime = new DateTime(2020, 1, 23, 16, 0, 0), isClockedIn = true, NurseID = 112 },
                new Clocking { ClockingID = 102, ClockInTime = new DateTime(2020, 2, 25, 5, 0, 0), ClockOutTime = new DateTime(2020, 2, 25, 16, 05, 0), isClockedIn = true, NurseID = 114 },
                new Clocking { ClockingID = 103, ClockInTime = new DateTime(2020, 1, 27, 5, 0, 0), ClockOutTime = new DateTime(2020, 3, 25, 16, 05, 0), isClockedIn = true, NurseID = 115 },
                new Clocking { ClockingID = 104, ClockInTime = new DateTime(2020, 2, 29, 5, 10, 0), ClockOutTime = new DateTime(2020, 4, 25, 16, 05, 0), isClockedIn = true, NurseID = 116 },
                new Clocking { ClockingID = 105, ClockInTime = new DateTime(2020, 1, 2, 5, 0, 0), ClockOutTime = new DateTime(2020, 5, 25, 16, 05, 0), isClockedIn = true, NurseID = 117 },
                new Clocking { ClockingID = 106, ClockInTime = new DateTime(2020, 2, 4, 5, 30, 0), ClockOutTime = new DateTime(2020, 6, 25, 16, 15, 0), isClockedIn = true, NurseID = 118 },
                new Clocking { ClockingID = 107, ClockInTime = new DateTime(2020, 1, 5, 5, 0, 0), ClockOutTime = new DateTime(2020, 7, 25, 16, 05, 0), isClockedIn = true, NurseID = 119 });
        }
        #endregion

        #region Computer Skill
        public static void SeedingComputerSkill(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComputerSkill>().HasData(
                new ComputerSkill { ComputerSkillID = 101, Application = "MS Office" },
                new ComputerSkill { ComputerSkillID = 102, Application = "Spreadsheets" },
                new ComputerSkill { ComputerSkillID = 103, Application = "Email Communication" },
                new ComputerSkill { ComputerSkillID = 104, Application = "Data Visualization" });
        }
        #endregion

        #region Doctor
        public static void SeedingDoctor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    DoctorID = 101,
                    DoctorTypeID = DoctorTypes.GeneralPractitioner,
                    SpecializationID = Specializations.GeneralMedicine,
                    PracticeNumber = "HWMS-0090565"
                },
                new Doctor
                {
                    DoctorID = 102,
                    DoctorTypeID = DoctorTypes.Gastroenterologist,
                    SpecializationID = Specializations.Gastroenterology,
                    PracticeNumber = "HWMS-0090875"
                },
                new Doctor
                {
                    DoctorID = 103,
                    DoctorTypeID = DoctorTypes.Anaesthesiologist,
                    SpecializationID = Specializations.Anesthesiology,
                    PracticeNumber = "HWMS-0091560"
                },
                new Doctor
                {
                    DoctorID = 104,
                    DoctorTypeID = DoctorTypes.Cardiologist,
                    SpecializationID = Specializations.Cardiology,
                    PracticeNumber = "HWMS-0091500"
                },
                new Doctor
                {
                    DoctorID = 105,
                    DoctorTypeID = DoctorTypes.Dermatologist,
                    SpecializationID = Specializations.Dermatology,
                    PracticeNumber = "HWMS-0091550"
                },
                new Doctor
                {
                    DoctorID = 106,
                    DoctorTypeID = DoctorTypes.Oncologist,
                    SpecializationID = Specializations.Oncology,
                    PracticeNumber = "HWMS-0091575"
                },
                new Doctor
                {
                    DoctorID = 107,
                    DoctorTypeID = DoctorTypes.Physician,
                    SpecializationID = Specializations.PhysicalMedicine,
                    PracticeNumber = "HWMS-0091770"
                },
                new Doctor
                {
                    DoctorID = 108,
                    DoctorTypeID = DoctorTypes.Radiologist,
                    SpecializationID = Specializations.RadiationOncolology,
                    PracticeNumber = "HWMS-0091580"
                },
                new Doctor
                {
                    DoctorID = 109,
                    DoctorTypeID = DoctorTypes.Surgeon,
                    SpecializationID = Specializations.Surgery,
                    PracticeNumber = "HWMS-0091590"
                },
                new Doctor
                {
                    DoctorID = 110,
                    DoctorTypeID = DoctorTypes.Neurologist,
                    SpecializationID = Specializations.Psychiatry,
                    PracticeNumber = "HWMS-0091595"
                },
                new Doctor
                {
                    DoctorID = 111,
                    DoctorTypeID = DoctorTypes.GeneralPractitioner,
                    SpecializationID = Specializations.PhysicalMedicine,
                    PracticeNumber = "HWMS-0091795"
                });
        }
        #endregion

        #region Doctor Type
        public static void SeedingDoctorType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorType>().HasData(
                new DoctorType { DoctorTypeID = 101, Description = "Cardiologist" },
                new DoctorType { DoctorTypeID = 102, Description = "Endocrinologist" },
                new DoctorType { DoctorTypeID = 103, Description = "Surgeon" },
                new DoctorType { DoctorTypeID = 104, Description = "Gastroenterologist" },
                new DoctorType { DoctorTypeID = 105, Description = "Neurologist" },
                new DoctorType { DoctorTypeID = 106, Description = "Radiologist" },
                new DoctorType { DoctorTypeID = 107, Description = "Oncologist" },
                new DoctorType { DoctorTypeID = 108, Description = "Anesthesiologist" },
                new DoctorType { DoctorTypeID = 109, Description = "Physician" },
                new DoctorType { DoctorTypeID = 110, Description = "General Practitioner" },
                new DoctorType { DoctorTypeID = 111, Description = "Dermatologist" });
        }
        #endregion

        #region Diagnosis
        public static void SeedingDiagnosis(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnosis>().HasData(
                new Diagnosis
                {
                    DiagnosedBy = 101,
                    DiagnosisDate = DateTime.Now.AddDays(-2),
                    DiagnosisDetals = "Mild esophageal scaring is causing difficulty consuming solid foods.",
                    DiagnosisID = 101,
                    MedicalConditionID = 101
                },
                new Diagnosis
                {
                    DiagnosedBy = 101,
                    DiagnosisDate = DateTime.Now.AddDays(-2),
                    DiagnosisDetals = "Skin is very tender, may cause patient to be prone to cuts.",
                    DiagnosisID = 102,
                    MedicalConditionID = 104
                },
                new Diagnosis
                {
                    DiagnosedBy = 111,
                    DiagnosisDate = DateTime.Now.AddDays(-2),
                    DiagnosisDetals = "Fungi caused inflammation in the left lung.",
                    DiagnosisID = 103,
                    MedicalConditionID = 102
                },
                new Diagnosis
                {
                    DiagnosedBy = 111,
                    DiagnosisDate = DateTime.Now.AddDays(-2),
                    DiagnosisDetals = "Bruising along the soles of the feet.",
                    DiagnosisID = 104,
                    MedicalConditionID = 109
                },
                new Diagnosis
                {
                    DiagnosedBy = 101,
                    DiagnosisDate = DateTime.Now.AddDays(-2),
                    DiagnosisDetals = "Patient is experiencing abdominal pain and muscle tenderness.",
                    DiagnosisID = 105,
                    MedicalConditionID = 112
                },
                new Diagnosis
                {
                    DiagnosedBy = 111,
                    DiagnosisDate = DateTime.Now.AddDays(-2),
                    DiagnosisDetals = "Patient is experiencing abdominal pain.",
                    DiagnosisID = 106,
                    MedicalConditionID = 112
                });
        }
        #endregion

        #region Referral
        public static void SeedingReferral(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Referral>().HasData(
                new Referral
                {
                    AdmissionDate = DateTime.Now.AddDays(14),
                    DiagnosisID = 101,
                    PatientID = 101,
                    Reason = "Esophageal inflammation is sever along the left side of the neck.",
                    ReferralID = 101,
                    ReferringDoctorID = 101,
                    SpecialistID = 102,
                    isAdmitted = true
                },
                new Referral
                {
                    AdmissionDate = DateTime.Now.AddDays(14),
                    DiagnosisID = 102,
                    PatientID = 102,
                    Reason = "Dull pain causes loss of appetite.",
                    ReferralID = 102,
                    ReferringDoctorID = 101,
                    SpecialistID = 105,
                    isAdmitted = true
                },
                new Referral
                {
                    AdmissionDate = DateTime.Now.AddDays(14),
                    DiagnosisID = 103,
                    PatientID = 103,
                    Reason = "Patient has difficulty breathing.",
                    ReferralID = 103,
                    ReferringDoctorID = 111,
                    SpecialistID = 104,
                    isAdmitted = true
                },
                new Referral
                {
                    AdmissionDate = DateTime.Now.AddDays(14),
                    DiagnosisID = 104,
                    PatientID = 104,
                    Reason = "Aggressive leukemia treatment required.",
                    ReferralID = 104,
                    ReferringDoctorID = 111,
                    SpecialistID = 108,
                    isAdmitted = true
                },
                new Referral
                {
                    AdmissionDate = DateTime.Now.AddDays(14),
                    DiagnosisID = 105,
                    PatientID = 105,
                    Reason = "Surgical removal of the overactive gland may be required.",
                    ReferralID = 105,
                    ReferringDoctorID = 101,
                    SpecialistID = 103,
                    isAdmitted = true
                },
                new Referral
                {
                    AdmissionDate = DateTime.Now.AddDays(14),
                    DiagnosisID = 106,
                    PatientID = 106,
                    Reason = "Surgical removal of the overactive gland may be required.",
                    ReferralID = 106,
                    ReferringDoctorID = 111,
                    SpecialistID = 103,
                    isAdmitted = false
                });
        }
        #endregion

        #region Nurse Type
        public static void SeedingNurseType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NurseType>().HasData(
                new NurseType { NurseTypeID = 101, Description = "Registered Nurse" },
                new NurseType { NurseTypeID = 102, Description = "Midwife Nurse" },
                new NurseType { NurseTypeID = 103, Description = "Nurse Practitioner" },
                new NurseType { NurseTypeID = 104, Description = "Oncology Nurse" },
                new NurseType { NurseTypeID = 105, Description = "Licensed Practical Nurse" });
        }
        #endregion

        #region Qualification
        public static void SeedingQualification(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Qualification>().HasData(
              new Qualification { QualificationID = 101, Description = "Public Administration and Management", Title = "National Diploma" },
              new Qualification { QualificationID = 102, Description = "Higher Certificate in Office Administration", Title = "National Senior Certificate (NSC)" },
              new Qualification { QualificationID = 103, Description = "Public Relations Management", Title = "National Diploma" },
              new Qualification { QualificationID = 104, Description = "Bachelor of Commerce Honours in Organizational Psychology ", Title = "Honours Degree" });
        }
        #endregion

        #region Shift Slot
        public static void SeedingShiftSlot(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShiftSlot>().HasData(
                new ShiftSlot { ShiftSlotID = 101, Description = "Morning", StartTime = new DateTime(2020, 6, 23, 5, 0, 0), EndTime = new DateTime(2020, 6, 23, 16, 0, 0) },
                new ShiftSlot { ShiftSlotID = 102, Description = "Evening", StartTime = new DateTime(2020, 6, 23, 17, 0, 0), EndTime = new DateTime(2020, 6, 24, 5, 0, 0) });
        }
        #endregion

        #region Specialization
        public static void SeedingSpecialization(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>().HasData(
               new Specialization { SpecializationID = 101, Description = "Surgery" },
               new Specialization { SpecializationID = 102, Description = "Radiation Oncology" },
               new Specialization { SpecializationID = 103, Description = "Anesthesiology" },
               new Specialization { SpecializationID = 104, Description = "Oncology" },
               new Specialization { SpecializationID = 105, Description = "Gynecology" },
               new Specialization { SpecializationID = 106, Description = "Dermatology" },
               new Specialization { SpecializationID = 107, Description = "Paediatrics" },
               new Specialization { SpecializationID = 108, Description = "Endocrinology" },
               new Specialization { SpecializationID = 109, Description = "Cardiology" },
               new Specialization { SpecializationID = 110, Description = "Neurology" },
               new Specialization { SpecializationID = 111, Description = "Urology" },
               new Specialization { SpecializationID = 112, Description = "Psychiatry" },
               new Specialization { SpecializationID = 113, Description = "Physical Medicine & Occupational Therapy" },
               new Specialization { SpecializationID = 114, Description = "General Medicine" },
               new Specialization { SpecializationID = 115, Description = "Midwifery" },
               new Specialization { SpecializationID = 116, Description = "Gastroenterology" });
        }
        #endregion

        #region Staff Member
        public static void SeedingStaffMember(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffMember>().HasData(
                new StaffMember
                {
                    StaffID = 101,
                    FirstName = "Aldridge",
                    LastName = "Abbington",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020101",
                    EmailAddress = "A.Abbington@wardx.co.za",
                    AddressLine1 = "52 Rubin Cres",
                    AddressLine2 = "",
                    WorkNumber = "0214217894",
                    MobileNumber = "0824127849",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.Summerstrand,
                    UserID = 101
                },
                new StaffMember
                {
                    StaffID = 102,
                    FirstName = "Roland",
                    LastName = "Alger",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020102",
                    EmailAddress = "R.Alger@wardx.co.za",
                    AddressLine1 = "38 Blackthorn Ave",
                    AddressLine2 = "Forest Hill",
                    WorkNumber = "0214217824",
                    MobileNumber = "0824224217",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.Humewood,
                    UserID = 102
                },
                new StaffMember
                {
                    StaffID = 103,
                    FirstName = "Tammy",
                    LastName = "Aberdeen",
                    Gender = Gender.Female,
                    EmployeeID = "HWMS062020103",
                    EmailAddress = "T.Aberdeen@wardx.co.za",
                    AddressLine1 = "12 La Roche Dr",
                    AddressLine2 = "",
                    WorkNumber = "0411100743",
                    MobileNumber = "0417430417",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.Humewood,
                    UserID = 103
                },
                new StaffMember
                {
                    StaffID = 104,
                    FirstName = "Benjamin Byron",
                    LastName = "Davis",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020104",
                    EmailAddress = "B.Davis@wardx.co.za",
                    AddressLine1 = "13 La Roche Dr",
                    AddressLine2 = "",
                    WorkNumber = "0411753743",
                    MobileNumber = "0417957517",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.LovemorePark,
                    UserID = 104
                },
                new StaffMember
                {
                    StaffID = 105,
                    FirstName = "Roger",
                    LastName = "Clark",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020105",
                    EmailAddress = "R.Clark@wardx.co.za",
                    AddressLine1 = "14 La Roche Dr",
                    AddressLine2 = "",
                    WorkNumber = "0411754413",
                    MobileNumber = "0417936887",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.Schoenmakerskop,
                    UserID = 105
                },
                new StaffMember
                {
                    StaffID = 106,
                    FirstName = "Rob",
                    LastName = "Wiethoff",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020106",
                    EmailAddress = "R.Wiethoff@wardx.co.za",
                    AddressLine1 = "15 La Roche Dr",
                    AddressLine2 = "",
                    WorkNumber = "0414164413",
                    MobileNumber = "0417782887",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.LovemorePark,
                    UserID = 106
                },
                new StaffMember
                {
                    StaffID = 107,
                    FirstName = "Cali Elizabeth",
                    LastName = "Moore",
                    Gender = Gender.Female,
                    EmployeeID = "HWMS062020107",
                    EmailAddress = "C.Moore@wardx.co.za",
                    AddressLine1 = "18 La Roche Dr",
                    AddressLine2 = "",
                    WorkNumber = "0414166483",
                    MobileNumber = "0417784748",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.ForestHill,
                    UserID = 107
                },
                new StaffMember
                {
                    StaffID = 108,
                    FirstName = "Marissa",
                    LastName = "Buccianti",
                    Gender = Gender.Female,
                    EmployeeID = "HWMS062020108",
                    EmailAddress = "M.Buccianti@wardx.co.za",
                    AddressLine1 = "21 La Roche Dr",
                    AddressLine2 = "",
                    WorkNumber = "0415546483",
                    MobileNumber = "0419634748",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.Humewood,
                    UserID = 108
                },
                new StaffMember
                {
                    StaffID = 109,
                    FirstName = "Jo",
                    LastName = "Armeniox",
                    Gender = Gender.Female,
                    EmployeeID = "HWMS062020109",
                    EmailAddress = "J.Armeniox@wardx.co.za",
                    AddressLine1 = "23 La Roche Dr",
                    AddressLine2 = "",
                    WorkNumber = "0415546113",
                    MobileNumber = "0419612498",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.NorthEnd,
                    UserID = 109
                },
                new StaffMember
                {
                    StaffID = 110,
                    FirstName = "Samantha",
                    LastName = "Strelitz",
                    Gender = Gender.Female,
                    EmployeeID = "HWMS062020110",
                    EmailAddress = "S.Strelitz@wardx.co.za",
                    AddressLine1 = "25 La Roche Dr",
                    AddressLine2 = "",
                    WorkNumber = "0415465113",
                    MobileNumber = "0413753498",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.Schoenmakerskop,
                    UserID = 110
                },
                new StaffMember
                {
                    StaffID = 111,
                    FirstName = "Sophia",
                    LastName = "Marzocchi",
                    Gender = Gender.Female,
                    EmployeeID = "HWMS062020111",
                    EmailAddress = "S.Marzocchi@wardx.co.za",
                    AddressLine1 = "75 Roach Ave",
                    AddressLine2 = "Dale Drive",
                    WorkNumber = "0515465113",
                    MobileNumber = "0412020111",
                    isActive = true,
                    StaffType = StaffType.Doctor,
                    SuburbID = (int)Suburbs.Korsten,
                    UserID = 111
                },
                new StaffMember
                {
                    StaffID = 112,
                    FirstName = "Don",
                    LastName = "Creech",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020112",
                    EmailAddress = "D.Creech@wardx.co.za",
                    AddressLine1 = "79 Roach Ave",
                    AddressLine2 = "Dale Drive",
                    WorkNumber = "0515465783",
                    MobileNumber = "0412020112",
                    isActive = true,
                    StaffType = StaffType.Nurse,
                    SuburbID = (int)Suburbs.NorthEnd,
                    UserID = 112
                },
                new StaffMember
                {
                    StaffID = 113,
                    FirstName = "Daron",
                    LastName = "McFarland",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020113",
                    EmailAddress = "D.McFarland@wardx.co.za",
                    AddressLine1 = "105 Roach Ave",
                    AddressLine2 = "Dale Drive",
                    WorkNumber = "0515463573",
                    MobileNumber = "0412020113",
                    isActive = true,
                    StaffType = StaffType.Receptionist,
                    SuburbID = (int)Suburbs.Korsten,
                    UserID = 113
                },
                new StaffMember
                {
                    StaffID = 114,
                    FirstName = "Nick",
                    LastName = "Birch",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020114",
                    EmailAddress = "N.Birch@wardx.co.za",
                    AddressLine1 = "104 Roachella Street ",
                    AddressLine2 = "Country Drive",
                    WorkNumber = "0515968836",
                    MobileNumber = "0419875200",
                    isActive = true,
                    StaffType = StaffType.Nurse,
                    SuburbID = (int)Suburbs.Walmer,
                    UserID = 114
                },
                new StaffMember
                {
                    StaffID = 115,
                    FirstName = "Missy",
                    LastName = "Foreman-Greenwald",
                    Gender = Gender.Female,
                    EmployeeID = "HWMS062020115",
                    EmailAddress = "M.Foreman-Greenwald@wardx.co.za",
                    AddressLine1 = "25 Flyton Ave",
                    AddressLine2 = "Dickson Drive",
                    WorkNumber = "0519966587",
                    MobileNumber = "0412625403",
                    isActive = true,
                    StaffType = StaffType.Nurse,
                    SuburbID = (int)Suburbs.SouthEnd,
                    UserID = 115
                },

                new StaffMember
                {
                    StaffID = 116,
                    FirstName = "Andrew",
                    LastName = "Globerman",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020118",
                    EmailAddress = "A.Glouberman@wardx.co.za",
                    AddressLine1 = "1050 Hillside Downs",
                    AddressLine2 = "",
                    WorkNumber = "0510003650",
                    MobileNumber = "0412035596",
                    isActive = true,
                    StaffType = StaffType.Nurse,
                    SuburbID = (int)Suburbs.LovemorePark,
                    UserID = 116
                },

                new StaffMember
                {
                    StaffID = 117,
                    FirstName = "Jessi",
                    LastName = "Glaser",
                    Gender = Gender.Female,
                    EmployeeID = "HWMS062020117",
                    EmailAddress = "J.Glaser@wardx.co.za",
                    AddressLine1 = "4525 Piestry Drive",
                    AddressLine2 = "The Factory",
                    WorkNumber = "0515656893",
                    MobileNumber = "0418932718",
                    isActive = true,
                    StaffType = StaffType.Nurse,
                    SuburbID = (int)Suburbs.SouthEnd,
                    UserID = 117
                },

                new StaffMember
                {
                    StaffID = 118,
                    FirstName = "Gina",
                    LastName = "Alverez",
                    Gender = Gender.Female,
                    EmployeeID = "HWMS062020118",
                    EmailAddress = "G.Alverez@wardx.co.za",
                    AddressLine1 = "134 Heugh Road",
                    AddressLine2 = "The Loft",
                    WorkNumber = "0515859632",
                    MobileNumber = "0419837960",
                    isActive = true,
                    StaffType = StaffType.Nurse,
                    SuburbID = (int)Suburbs.Walmer,
                    UserID = 118
                },

                new StaffMember
                {
                    StaffID = 119,
                    FirstName = "Matthew",
                    LastName = "MacDell",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020119",
                    EmailAddress = "M.MacDell@wardx.co.za",
                    AddressLine1 = "1223 Pepperment CLose",
                    AddressLine2 = "Sundowns Estate",
                    WorkNumber = "0515435960",
                    MobileNumber = "0410215496",
                    isActive = true,
                    StaffType = StaffType.Nurse,
                    SuburbID = (int)Suburbs.Summerstrand,
                    UserID = 119
                },

                new StaffMember
                {
                    StaffID = 120,
                    FirstName = "Jay",
                    LastName = "Bilzerian",
                    Gender = Gender.Male,
                    EmployeeID = "HWMS062020120",
                    EmailAddress = "J.Bilzerian@wardx.co.za",
                    AddressLine1 = "102 Beach Road",
                    AddressLine2 = "",
                    WorkNumber = "0517896542",
                    MobileNumber = "0412020213",
                    isActive = true,
                    StaffType = StaffType.WardManager,
                    SuburbID = (int)Suburbs.Summerstrand,
                    UserID = 120
                });
        }
        #endregion

        #region Receptionist
        public static void SeedingReceptionist(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receptionist>().HasData(
                new Receptionist
                {
                    ClerkID = 113,
                    QualificationID = 102
                });
        }
        #endregion

        #region Suburb
        public static void SeedingSuburb(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suburb>().HasData(
                new Suburb { SuburbID = 101, SuburbName = "Walmer", PostalCode = "6070", CityID = 101 },
                new Suburb { SuburbID = 102, SuburbName = "Summerstrand", PostalCode = "6001", CityID = 101 },
                new Suburb { SuburbID = 103, SuburbName = "Humewood", PostalCode = "6013", CityID = 101 },
                new Suburb { SuburbID = 104, SuburbName = "South End", PostalCode = "6001", CityID = 101 },
                new Suburb { SuburbID = 105, SuburbName = "Forest Hill", PostalCode = "6001", CityID = 101 },
                new Suburb { SuburbID = 106, SuburbName = "Schoenmakerskop", PostalCode = "6011", CityID = 101 },
                new Suburb { SuburbID = 107, SuburbName = "Lovemore Park", PostalCode = "6070", CityID = 101 },
                new Suburb { SuburbID = 108, SuburbName = "North End", PostalCode = "6001", CityID = 101 },
                new Suburb { SuburbID = 109, SuburbName = "Korsten", PostalCode = "6020", CityID = 101 },
                new Suburb { SuburbID = 110, SuburbName = "Western Hills", PostalCode = "6025", CityID = 101 });
        }
        #endregion

        #region WARDx User
        public static void SeedingUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 101,
                    UserName = "HWMS062020101",
                    PasswordHash = Hash("A.Abbington@wardx.co.za", 10000),
                    Avatar = "001-lego"
                },
                new User
                {
                    UserID = 102,
                    UserName = "HWMS062020102",
                    PasswordHash = Hash("R.Alger@wardx.co.za", 10000),
                    Avatar = "001-lego"
                },
                new User
                {
                    UserID = 103,
                    UserName = "HWMS062020103",
                    PasswordHash = Hash("T.Aberdeen@wardx.co.za", 10000),
                    Avatar = "017-lego"
                },
                new User
                {
                    UserID = 104,
                    UserName = "HWMS062020104",
                    PasswordHash = Hash("B.Davis@wardx.co.za", 10000),
                    Avatar = "007-lego"
                },
                new User
                {
                    UserID = 105,
                    UserName = "HWMS062020105",
                    PasswordHash = Hash("R.Clark@wardx.co.za", 10000),
                    Avatar = "014-lego"
                },
                new User
                {
                    UserID = 106,
                    UserName = "HWMS062020106",
                    PasswordHash = Hash("R.Wiethoff@wardx.co.za", 10000),
                    Avatar = "018-lego"
                },
                new User
                {
                    UserID = 107,
                    UserName = "HWMS062020107",
                    PasswordHash = Hash("C.Moore@wardx.co.za", 10000),
                    Avatar = "003-lego"
                },
                new User
                {
                    UserID = 108,
                    UserName = "HWMS062020108",
                    PasswordHash = Hash("M.Buccianti@wardx.co.za", 10000),
                    Avatar = "013-lego"
                },
                new User
                {
                    UserID = 109,
                    UserName = "HWMS062020109",
                    PasswordHash = Hash("J.Armeniox@wardx.co.za", 10000),
                    Avatar = "021-lego"
                },
                new User
                {
                    UserID = 110,
                    UserName = "HWMS062020110",
                    PasswordHash = Hash("S.Strelitz@wardx.co.za", 10000),
                    Avatar = "072-woman"
                },
                new User
                {
                    UserID = 111,
                    UserName = "HWMS062020111",
                    PasswordHash = Hash("S.Marzocchi@wardx.co.za", 10000),
                    Avatar = "058-thief"
                },
                new User
                {
                    UserID = 112,
                    UserName = "HWMS062020112",
                    PasswordHash = Hash("D.Creech@wardx.co.za", 10000),
                    Avatar = "041-businessman"
                },
                new User
                {
                    UserID = 113,
                    UserName = "HWMS062020113",
                    PasswordHash = Hash("D.McFarland@wardx.co.za", 10000),
                    Avatar = "036-mariachi"
                },
                new User
                {
                    UserID = 114,
                    UserName = "HWMS062020114",
                    PasswordHash = Hash("N.Birch@wardx.co.za", 10000),
                    Avatar = "014-lego"
                },
                new User
                {
                    UserID = 115,
                    UserName = "HWMS062020115",
                    PasswordHash = Hash("M.Foreman-Greenwald@wardx.co.za", 10000),
                    Avatar = "017-lego"
                },
                new User
                {
                    UserID = 116,
                    UserName = "HWMS062020116",
                    PasswordHash = Hash("A.Glouberman@wardx.co.za", 10000),
                    Avatar = "032-boy"
                },
                new User
                {
                    UserID = 117,
                    UserName = "HWMS062020117",
                    PasswordHash = Hash("J.Glaser@wardx.co.za", 10000),
                    Avatar = "021-lego"
                },
                new User
                {
                    UserID = 118,
                    UserName = "HWMS062020118",
                    PasswordHash = Hash("G.Alverez@wardx.co.za", 10000),
                    Avatar = "024-lego"
                },
                new User
                {
                    UserID = 119,
                    UserName = "HWMS062020119",
                    PasswordHash = Hash("M.MacDell@wardx.co.za", 10000),
                    Avatar = "029-explorer"
                },
                new User
                {
                    UserID = 120,
                    UserName = "HWMS062020120",
                    PasswordHash = Hash("J.Bilzerian@wardx.co.za", 10000),
                    Avatar = "041-businessman"
                });
        }
        #endregion

        #region WARDx Role
        public static void SeedingRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 101, RoleName = "Administrator" },
                new Role { RoleID = 102, RoleName = "Receptionist" },
                new Role { RoleID = 103, RoleName = "Specialist" },
                new Role { RoleID = 104, RoleName = "General Practitioner" },
                new Role { RoleID = 105, RoleName = "Nurse" },
                new Role { RoleID = 106, RoleName = "Sister Nurse" },
                new Role { RoleID = 107, RoleName = "Ward Manager" });
        }
        #endregion

        #region WARDx User Role
        public static void SeedingUserRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    RoleID = (int)WARDxRoles.General_Practitioner,
                    UserID = 101
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Specialist,
                    UserID = 102
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Specialist,
                    UserID = 103
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Specialist,
                    UserID = 104
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Specialist,
                    UserID = 105
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Specialist,
                    UserID = 106
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Specialist,
                    UserID = 107
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Specialist,
                    UserID = 108
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Specialist,
                    UserID = 109
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Specialist,
                    UserID = 110
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.General_Practitioner,
                    UserID = 111
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Nurse,
                    UserID = 112
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Receptionist,
                    UserID = 113
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Nurse,
                    UserID = 114
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Nurse,
                    UserID = 115
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Nurse,
                    UserID = 116
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Nurse,
                    UserID = 117
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Nurse,
                    UserID = 118
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Nurse,
                    UserID = 119
                },
                new UserRole
                {
                    RoleID = (int)WARDxRoles.Ward_Manager,
                    UserID = 120
                });

        }
        #endregion

        #region Patient
        public static void SeedingPatient(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    PatientID = 101,
                    FirstName = "John",
                    LastName = "Smith",
                    Gender = Gender.Male,
                    IDNumber = "9007107005123",
                    DOB = Convert.ToDateTime("1990/07/10"),
                    EmailAddress = "J.Smith@techbuzz.co.za",
                    MobileNumber = "0745017520",
                    AddressLine1 = "50 Seaview Street",
                    SuburbID = (int)Suburbs.ForestHill
                },
                new Patient
                {
                    PatientID = 102,
                    FirstName = "Sarah",
                    LastName = "Connor",
                    Gender = Gender.Female,
                    IDNumber = "9506308951437",
                    DOB = Convert.ToDateTime("1995/06/30"),
                    EmailAddress = "s223186430@mandela.ac.za",
                    MobileNumber = "0849851122",
                    AddressLine1 = "28 Albert Street",
                    SuburbID = (int)Suburbs.Humewood
                },
                new Patient
                {
                    PatientID = 103,
                    FirstName = "Stephanie",
                    LastName = "Panisello",
                    Gender = Gender.Female,
                    IDNumber = "8007158951437",
                    DOB = Convert.ToDateTime("1980/07/15"),
                    EmailAddress = "S.Panisello@techbuzz.co.za",
                    MobileNumber = "0849871582",
                    AddressLine1 = "8 Clark Street",
                    SuburbID = (int)Suburbs.Korsten
                },
                new Patient
                {
                    PatientID = 104,
                    FirstName = "Nick",
                    LastName = "Apostolides",
                    Gender = Gender.Male,
                    IDNumber = "8904106951857",
                    DOB = Convert.ToDateTime("1989/04/10"),
                    EmailAddress = "N.Apostolides@techbuzz.co.za",
                    MobileNumber = "0840984108",
                    AddressLine1 = "8 Doreen Drive",
                    SuburbID = (int)Suburbs.LovemorePark
                },
                new Patient
                {
                    PatientID = 105,
                    FirstName = "Jolene",
                    LastName = "Andersen",
                    Gender = Gender.Transgender,
                    IDNumber = "8504203951422",
                    DOB = Convert.ToDateTime("1985/04/20"),
                    EmailAddress = "J.Andersen@techbuzz.co.za",
                    MobileNumber = "0840039514",
                    AddressLine1 = "8 Deveroux Ave",
                    SuburbID = (int)Suburbs.Schoenmakerskop
                },
                new Patient
                {
                    PatientID = 106,
                    FirstName = "Pam",
                    LastName = "Oliver",
                    Gender = Gender.Intersex,
                    IDNumber = "8010053951422",
                    DOB = Convert.ToDateTime("1980/10/05"),
                    EmailAddress = "P.Oliver@techbuzz.co.za",
                    MobileNumber = "0845550514",
                    AddressLine1 = "8 Deveroux Ave",
                    SuburbID = (int)Suburbs.Schoenmakerskop
                });
        }
        #endregion

        #region Patient Movement
        public static void SeedingPatientMovement(this ModelBuilder modelBuilder)
        {
            var day1 = DateTime.Now.AddDays(-3);
            var day2 = DateTime.Now.AddDays(-2);
            var day3 = DateTime.Now.AddDays(-1);

            modelBuilder.Entity<PatientMovement>().HasData(
                new PatientMovement
                {
                    AdmissionFileID = 103,
                    CheckOutTime = day1,
                    CheckInTime = day1.AddMinutes(15),
                    isCheckedOut = false,
                    MoveDate = day1,
                    PatientMovementID = 101,
                    Reason = Reason.BloodTests
                },
                new PatientMovement
                {
                    AdmissionFileID = 103,
                    CheckOutTime = day2,
                    CheckInTime = day2.AddMinutes(120),
                    isCheckedOut = false,
                    MoveDate = day2,
                    PatientMovementID = 102,
                    Reason = Reason.Surgery
                },
                new PatientMovement
                {
                    AdmissionFileID = 103,
                    CheckOutTime = day3,
                    CheckInTime = day3.AddMinutes(30),
                    isCheckedOut = false,
                    MoveDate = day3,
                    PatientMovementID = 103,
                    Reason = Reason.XRays
                },
                new PatientMovement
                {
                    AdmissionFileID = 104,
                    CheckOutTime = day1,
                    CheckInTime = day1.AddMinutes(15),
                    isCheckedOut = false,
                    MoveDate = day1,
                    PatientMovementID = 104,
                    Reason = Reason.XRays
                },
                new PatientMovement
                {
                    AdmissionFileID = 104,
                    CheckOutTime = day2,
                    CheckInTime = day2.AddMinutes(120),
                    isCheckedOut = false,
                    MoveDate = day2,
                    PatientMovementID = 105,
                    Reason = Reason.Surgery
                },
                new PatientMovement
                {
                    AdmissionFileID = 104,
                    CheckOutTime = day3,
                    CheckInTime = day3.AddMinutes(30),
                    isCheckedOut = false,
                    MoveDate = day3,
                    PatientMovementID = 106,
                    Reason = Reason.BloodTests
                });
        }

        #endregion

        #region Prescription
        public static void SeedingPrescription(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                PrescriptionID = 101,
                MedicationID = 107,
                DoctorID = 102,
                Dosage = 1,
                DateIssued = Convert.ToDateTime("2020/12/15"),
                Instruction = "Take dosage every 4 to 6 hours",
            },


            new Prescription
            {
                PrescriptionID = 103,
                MedicationID = 106,
                DoctorID = 105,
                Dosage = 1,
                DateIssued = Convert.ToDateTime("2021/01/10"),
                Instruction = "Once a day beginning 6 hours after the procedure and continuing for 1 year",
            });
        }
        #endregion

        #region Next of Kin
        public static void SeedingNextofKin(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NextOfKin>().HasData(
                new NextOfKin
                {
                    NextOfKinID = 101,
                    PatientID = 101,
                    FirstName = "Molly",
                    LastName = "Smith",
                    Gender = Gender.Female,
                    Relationship = "Mother",
                    EmailAddress = "M.Smith@techbuzz.co.za",
                    MobileNumber = "0747477520",
                    AddressLine1 = "50 Seaview Street",
                    SuburbID = (int)Suburbs.ForestHill
                },
                new NextOfKin
                {
                    NextOfKinID = 102,
                    PatientID = 102,
                    FirstName = "Roland",
                    LastName = "Connor",
                    Gender = Gender.Male,
                    Relationship = "Father",
                    EmailAddress = "R.Connor@techbuzz.co.za",
                    MobileNumber = "0761367520",
                    AddressLine1 = "50 Seaview Street",
                    SuburbID = (int)Suburbs.Humewood
                },
                new NextOfKin
                {
                    NextOfKinID = 103,
                    PatientID = 103,
                    FirstName = "Joel",
                    LastName = "Panisello",
                    Gender = Gender.Female,
                    Relationship = "Partner",
                    EmailAddress = "Joel.Panisello@techbuzz.co.za",
                    MobileNumber = "0761390200",
                    AddressLine1 = "8 Clark Street",
                    SuburbID = (int)Suburbs.Korsten
                },
                new NextOfKin
                {
                    NextOfKinID = 104,
                    PatientID = 104,
                    FirstName = "Ted",
                    LastName = "Apostolides",
                    Gender = Gender.Male,
                    Relationship = "Partner",
                    EmailAddress = "T.Apostolides@techbuzz.co.za",
                    MobileNumber = "0761314690",
                    AddressLine1 = "8 Doreen Drive",
                    SuburbID = (int)Suburbs.LovemorePark
                },
                new NextOfKin
                {
                    NextOfKinID = 105,
                    PatientID = 105,
                    FirstName = "Renier",
                    LastName = "Andersen",
                    Gender = Gender.Intersex,
                    Relationship = "Partner",
                    EmailAddress = "R.Andersen@techbuzz.co.za",
                    MobileNumber = "0761324680",
                    AddressLine1 = "8 Deveroux Ave",
                    SuburbID = (int)Suburbs.Schoenmakerskop
                },
                new NextOfKin
                {
                    NextOfKinID = 106,
                    PatientID = 106,
                    FirstName = "Bob",
                    LastName = "Oliver",
                    Gender = Gender.Intersex,
                    Relationship = "Partner",
                    EmailAddress = "B.Oliver@techbuzz.co.za",
                    MobileNumber = "0761399980",
                    AddressLine1 = "8 Deveroux Ave",
                    SuburbID = (int)Suburbs.Schoenmakerskop
                });
        }
        #endregion

        #region Medical Aid
        public static void SeedingMedicalAid(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalAid>().HasData(
                new MedicalAid
                {
                    MedicalAidSchemeID = MedicalAidSchemes.Discovery,
                    MedicalAidPlanID = MedicalAidPlans.Family,
                    MemberNumber = "005493103",
                    PrincipalFirstName = "Molly",
                    PrincipalLastName = "Smith",
                    DependantCode = "005494301",
                    PatientID = 101
                },
                new MedicalAid
                {
                    MedicalAidSchemeID = MedicalAidSchemes.Discovery,
                    MedicalAidPlanID = MedicalAidPlans.Smart,
                    MemberNumber = "005698103",
                    PrincipalFirstName = "Roland",
                    PrincipalLastName = "Connor",
                    DependantCode = "005430071",
                    PatientID = 102
                },
                new MedicalAid
                {
                    MedicalAidSchemeID = MedicalAidSchemes.Fedhealth,
                    MedicalAidPlanID = MedicalAidPlans.Executive,
                    MemberNumber = "005646523",
                    PrincipalFirstName = "Stephanie",
                    PrincipalLastName = "Panisello",
                    DependantCode = "005491271",
                    PatientID = 103
                },
                new MedicalAid
                {
                    MedicalAidSchemeID = MedicalAidSchemes.Momentum,
                    MedicalAidPlanID = MedicalAidPlans.Core,
                    MemberNumber = "005425323",
                    PrincipalFirstName = "Nick",
                    PrincipalLastName = "Apostolides",
                    DependantCode = "005468571",
                    PatientID = 104
                },
                new MedicalAid
                {
                    MedicalAidSchemeID = MedicalAidSchemes.Bonitas,
                    MedicalAidPlanID = MedicalAidPlans.Smart,
                    MemberNumber = "005446223",
                    PrincipalFirstName = "Jolene",
                    PrincipalLastName = "Andersen",
                    DependantCode = "005067371",
                    PatientID = 105
                },
                new MedicalAid
                {
                    MedicalAidSchemeID = MedicalAidSchemes.Medshield,
                    MedicalAidPlanID = MedicalAidPlans.Family,
                    MemberNumber = "005455523",
                    PrincipalFirstName = "Jolene",
                    PrincipalLastName = "Andersen",
                    DependantCode = "005777371",
                    PatientID = 106
                });
        }
        #endregion

        #region Medical Aid Plan
        public static void SeedingMedicalAidPlan(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalAidPlan>().HasData(
                new MedicalAidPlan { MedicalAidPlanID = 101, Name = "Executive Plan" },
                new MedicalAidPlan { MedicalAidPlanID = 102, Name = "Comprehensive Plan" },
                new MedicalAidPlan { MedicalAidPlanID = 103, Name = "Priority Plan" },
                new MedicalAidPlan { MedicalAidPlanID = 104, Name = "Saver Plan" },
                new MedicalAidPlan { MedicalAidPlanID = 105, Name = "Core Plan" },
                new MedicalAidPlan { MedicalAidPlanID = 106, Name = "Smart Plan" },
                new MedicalAidPlan { MedicalAidPlanID = 107, Name = "Keycare Plan" },
                new MedicalAidPlan { MedicalAidPlanID = 108, Name = "Standard Plan" },
                new MedicalAidPlan { MedicalAidPlanID = 109, Name = "Family Plan" },
                new MedicalAidPlan { MedicalAidPlanID = 110, Name = "Premium Plan" });
        }
        #endregion

        #region Medical Aid Scheme
        public static void SeedingMedicalAidScheme(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalAidScheme>().HasData(
                new MedicalAidScheme { MedicalAidSchemeID = 101, Name = "Discovery Health" },
                new MedicalAidScheme { MedicalAidSchemeID = 102, Name = "Fedhealth" },
                new MedicalAidScheme { MedicalAidSchemeID = 103, Name = "Medihelp" },
                new MedicalAidScheme { MedicalAidSchemeID = 104, Name = "Medshield" },
                new MedicalAidScheme { MedicalAidSchemeID = 105, Name = "Bonitas" },
                new MedicalAidScheme { MedicalAidSchemeID = 106, Name = "Momentum" });
        }
        #endregion

        #region Medical Condition
        public static void SeedingMedicalCondition(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalCondition>().HasData(
                new MedicalCondition
                {
                    MedicalConditionID = 101,
                    Name = "Esophageal cancer",
                    Symptom = "Symptoms often include difficulty in swallowing and weight loss."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 102,
                    Name = "Pneumonia",
                    Symptom = "Symptoms typically include some combination of productive or dry cough, chest pain, fever and difficulty breathing."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 103,
                    Name = "Colorectal cancer",
                    Symptom = "Symptoms may include blood in the stool, a change in bowel movements, weight loss, and fatigue."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 104,
                    Name = "Ulcer",
                    Symptom = "The skin around the ulcer may be red, swollen, and tender."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 105,
                    Name = "Anemia",
                    Symptom = "Symptoms may include confusion, feeling like one is going to pass out, loss of consciousness, and increased thirst."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 106,
                    Name = "Lower gastrointestinal bleeding",
                    Symptom = "Bleeding which involves a bleed anywhere from the ileocecal valve to the anus."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 107,
                    Name = "Cachexia",
                    Symptom = "Systemic inflammation from these conditions can cause detrimental changes to metabolism and body composition."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 108,
                    Name = "Hodgkin lymphoma",
                    Symptom = "Symptoms may include fever, night sweats, and weight loss."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 109,
                    Name = "Leukemia",
                    Symptom = "Symptoms may include bleeding and bruising, feeling tired, fever, and an increased risk of infections."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 110,
                    Name = "Liver cancer",
                    Symptom = "Symptoms of liver cancer may include a lump or pain in the right side below the rib cage, swelling of the abdomen, yellowish skin, easy bruising, weight loss and weakness."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 111,
                    Name = "Paraneoplastic syndrome",
                    Symptom = "The most common presentation is a fever."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 112,
                    Name = "Hypercalcaemia",
                    Symptom = "Symptoms include cardiac arrhythmias (especially in those taking digoxin), fatigue, nausea, vomiting (emesis), loss of appetite, abdominal pain, & paralytic ileus."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 113,
                    Name = "Hyponatremia",
                    Symptom = "Symptoms of hyponatremia include nausea and vomiting, headache, short-term memory loss, confusion, lethargy, fatigue, loss of appetite, irritability, muscle weakness, spasms or cramps, seizures, and decreased consciousness or coma."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 114,
                    Name = "Lymphadenopathy",
                    Symptom = "Inflammation of the lymphatic vessels is known as lymphangitis."
                },
                new MedicalCondition
                {
                    MedicalConditionID = 115,
                    Name = "Splenomegaly",
                    Symptom = "Symptoms may include abdominal pain, chest pain, chest pain similar to pleuritic pain when stomach, bladder or bowels are full, back pain, early satiety due to splenic encroachment, or the symptoms of anemia due to accompanying cytopenia."
                });
        }
        #endregion

        #region NurseSchedule
        public static void SeedingNurseSchedule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NurseSchedule>().HasData(
                new NurseSchedule
                {
                    ScheduleID = 101,
                    isAvailable = true,
                    ShiftSlotID = 101,
                    NurseID = 114,
                    MonthID = 101
                },
                new NurseSchedule
                {
                    ScheduleID = 102,
                    isAvailable = true,
                    ShiftSlotID = 101,
                    NurseID = 115,
                    MonthID = 102
                },
                new NurseSchedule
                {
                    ScheduleID = 103,
                    isAvailable = true,
                    ShiftSlotID = 101,
                    NurseID = 116,
                    MonthID = 103
                },
                new NurseSchedule
                {
                    ScheduleID = 104,
                    isAvailable = true,
                    ShiftSlotID = 102,
                    NurseID = 117,
                    MonthID = 101
                },
                new NurseSchedule
                {
                    ScheduleID = 105,
                    isAvailable = true,
                    ShiftSlotID = 102,
                    NurseID = 118,
                    MonthID = 102
                },
                new NurseSchedule
                {
                    ScheduleID = 106,
                    isAvailable = true,
                    ShiftSlotID = 102,
                    NurseID = 119,
                    MonthID = 103
                });
        }

        #endregion

        #region Treatment Type
        public static void SeedingTreatmentType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreatmentType>().HasData(
               new TreatmentType { TreatmentTypeID = 101, Description = "Changed Wound Dressing" },
               new TreatmentType { TreatmentTypeID = 102, Description = "Replace IV Bag" },
               new TreatmentType { TreatmentTypeID = 103, Description = "Draw Blood Sample" },
               new TreatmentType { TreatmentTypeID = 104, Description = "Change Bed Pad" },
               new TreatmentType { TreatmentTypeID = 105, Description = "Change Catheter Bag" },
               new TreatmentType { TreatmentTypeID = 106, Description = "Specimen Collection" },
               new TreatmentType { TreatmentTypeID = 107, Description = "Blood Transfusion" },
               new TreatmentType { TreatmentTypeID = 108, Description = "Intubate" },
               new TreatmentType { TreatmentTypeID = 109, Description = "Stitch Wound(s)" },
               new TreatmentType { TreatmentTypeID = 110, Description = "Hygiene Care" }
               );
        }
        #endregion

        #region Medication
        public static void SeedingMedication(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medication>().HasData(
                new Medication
                {
                    MedicationID = 101,
                    MedicationName = "Altertamine",
                    MedicationScheduleID = 103,
                    MedicationStrength = "100 mg",
                    ExpiryDate = DateTime.Now.Date.AddYears(2),
                    FormulationID = 101
                },
                 new Medication
                 {
                     MedicationID = 102,
                     MedicationName = "Capecitabine",
                     MedicationScheduleID = 103,
                     MedicationStrength = "500 mg",
                     ExpiryDate = DateTime.Now.Date.AddYears(2),
                     FormulationID = 101
                 },
                  new Medication
                  {
                      MedicationID = 103,
                      MedicationName = "Cisplatin",
                      MedicationScheduleID = 103,
                      MedicationStrength = "50 mg",
                      ExpiryDate = DateTime.Now.Date.AddYears(2),
                      FormulationID = 101
                  },
                   new Medication
                   {
                       MedicationID = 104,
                       MedicationName = "Amoxil",
                       MedicationScheduleID = 102,
                       MedicationStrength = "500 mg",
                       ExpiryDate = DateTime.Now.Date.AddYears(2),
                       FormulationID = 102
                   },
                    new Medication
                    {
                        MedicationID = 105,
                        MedicationName = "Morphine",
                        MedicationScheduleID = 104,
                        MedicationStrength = "10 mg",
                        ExpiryDate = DateTime.Now.Date.AddYears(2),
                        FormulationID = 105
                    },
                    new Medication
                    {
                        MedicationID = 106,
                        MedicationName = "Asprin",
                        MedicationScheduleID = 101,
                        MedicationStrength = "325 mg",
                        ExpiryDate = DateTime.Now.Date.AddYears(1),
                        FormulationID = 102
                    },
                    new Medication
                    {
                        MedicationID = 107,
                        MedicationName = "Oxycodone",
                        MedicationScheduleID = 104,
                        MedicationStrength = "10 mg",
                        ExpiryDate = DateTime.Now.Date.AddYears(1),
                        FormulationID = 103
                    },
                    new Medication
                    {
                        MedicationID = 108,
                        MedicationName = "Insulin Mixtard",
                        MedicationScheduleID = 103,
                        MedicationStrength = " mg",
                        ExpiryDate = DateTime.Now.Date.AddYears(1),
                        FormulationID = 105
                    },
                    new Medication
                    {
                        MedicationID = 109,
                        MedicationName = "Methadone",
                        MedicationScheduleID = 103,
                        MedicationStrength = "10 mg",
                        ExpiryDate = DateTime.Now.Date.AddYears(1),
                        FormulationID = 102
                    },
                    new Medication
                    {
                        MedicationID = 110,
                        MedicationName = "Ibuprofen",
                        MedicationScheduleID = 102,
                        MedicationStrength = " 200 mg",
                        ExpiryDate = DateTime.Now.Date.AddYears(1),
                        FormulationID = 103
                    }
                    );

        }
        #endregion

        #region Formulation
        public static void SeedingFormulation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formulation>().HasData(
               new Formulation { FormulationID = 101, Abbreviation = "Liq", Description = "Liquid" },
               new Formulation { FormulationID = 102, Abbreviation = "tab.", Description = "Tablet" },
               new Formulation { FormulationID = 103, Abbreviation = "cap.", Description = "Capsule" },
               new Formulation { FormulationID = 104, Abbreviation = "gtt", Description = "Drops" },
               new Formulation { FormulationID = 105, Abbreviation = "inj", Description = "Injection" }
               );
        }
        #endregion

        #region Medication Schedule
        public static void SeedingMedicationSchedule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicationSchedule>().HasData(
               new MedicationSchedule { MedicationScheduleID = 101, SchedulingStatus = "General" },
               new MedicationSchedule { MedicationScheduleID = 102, SchedulingStatus = "Pharmacy Medicine" },
               new MedicationSchedule { MedicationScheduleID = 103, SchedulingStatus = "Prescription Only" },
               new MedicationSchedule { MedicationScheduleID = 104, SchedulingStatus = "Controlled Drug" }
               );
        }
        #endregion

        #region Month
        public static void SeedingMonth(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Month>().HasData(
                new Month { MonthID = 101, MonthName = "January", StartDate = 1, EndDate = 31 },
                new Month { MonthID = 102, MonthName = "February", StartDate = 1, EndDate = 29 },
                new Month { MonthID = 103, MonthName = "March", StartDate = 1, EndDate = 31 },
                new Month { MonthID = 104, MonthName = "April", StartDate = 1, EndDate = 30 },
                new Month { MonthID = 105, MonthName = "May", StartDate = 1, EndDate = 31 },
                new Month { MonthID = 106, MonthName = "June", StartDate = 1, EndDate = 30 },
                new Month { MonthID = 107, MonthName = "July", StartDate = 1, EndDate = 31 },
                new Month { MonthID = 108, MonthName = "August", StartDate = 1, EndDate = 31 },
                new Month { MonthID = 109, MonthName = "September", StartDate = 1, EndDate = 30 },
                new Month { MonthID = 110, MonthName = "October", StartDate = 1, EndDate = 31 },
                new Month { MonthID = 111, MonthName = "November", StartDate = 1, EndDate = 30 },
                new Month { MonthID = 112, MonthName = "December", StartDate = 1, EndDate = 31 });
        }
        #endregion

        #region Nurse
        public static void SeedingNurse(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nurse>().HasData(
                new Nurse
                {
                    NurseID = 112,
                    isWardManager = false,
                    isHeadNurse = false,
                    SpecializationID = (int)Specializations.GeneralMedicine,
                    NurseTypeID = 102
                },
                new Nurse
                {
                    NurseID = 114,
                    isWardManager = false,
                    isHeadNurse = false,
                    SpecializationID = (int)Specializations.GeneralMedicine,
                    NurseTypeID = 102
                },
                new Nurse
                {
                    NurseID = 115,
                    isWardManager = false,
                    isHeadNurse = false,
                    SpecializationID = (int)Specializations.GeneralMedicine,
                    NurseTypeID = 102
                },
                new Nurse
                {
                    NurseID = 116,
                    isWardManager = false,
                    isHeadNurse = false,
                    SpecializationID = (int)Specializations.GeneralMedicine,
                    NurseTypeID = 102
                },
                new Nurse
                {
                    NurseID = 117,
                    isWardManager = false,
                    isHeadNurse = false,
                    SpecializationID = (int)Specializations.GeneralMedicine,
                    NurseTypeID = 102
                },
                new Nurse
                {
                    NurseID = 118,
                    isWardManager = false,
                    isHeadNurse = false,
                    SpecializationID = (int)Specializations.GeneralMedicine,
                    NurseTypeID = 102
                },
                new Nurse
                {
                    NurseID = 119,
                    isWardManager = false,
                    isHeadNurse = false,
                    SpecializationID = (int)Specializations.GeneralMedicine,
                    NurseTypeID = 102
                },
                new Nurse
                {
                    NurseID = 120,
                    isWardManager = true,
                    isHeadNurse = false,
                    SpecializationID = (int)Specializations.GeneralMedicine,
                    NurseTypeID = 102
                });
        }
        #endregion

        #region VitalSign
        public static void SeedingVitalSign(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VitalSign>().HasData(
                new VitalSign
                {
                    VitalSignID = 101,
                    BloodGroupID = 103,
                    BodyTemperature = "34",
                    BloodPressure = "80/120",
                    PulseRate = "90/140",
                    Hypoglycemia = "150",
                    Weight = "82",
                    BMI = "21"

                },
                new VitalSign
                {
                    VitalSignID = 102,
                    BloodGroupID = 105,
                    BodyTemperature = "36",
                    BloodPressure = "70/120",
                    PulseRate = "100/160",
                    Hypoglycemia = "130",
                    Weight = "82",
                    BMI = "21"

                },
                new VitalSign
                {
                    VitalSignID = 103,
                    BloodGroupID = 101,
                    BodyTemperature = "33,7",
                    BloodPressure = "80/120",
                    PulseRate = "130/140",
                    Hypoglycemia = "140",
                    Weight = "100",
                    BMI = "35"

                });
        }
        #endregion
    }
}
