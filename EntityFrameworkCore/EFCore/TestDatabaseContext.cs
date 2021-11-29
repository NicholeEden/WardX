using EFCore.Domain;
using EFCore.ExtensionMethod;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class TestDatabaseContext : DbContext
    {
        public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configuration

            modelBuilder.ConfigureClerkComputer();

            modelBuilder.ConfigureNurse();

            modelBuilder.ConfigureDoctorInspection();

            modelBuilder.ConfigureNurseBar();

            modelBuilder.ConfigureMedicalHistory();

            modelBuilder.ConfigureReceptionist();

            modelBuilder.ConfigureAdmissionFile();

            modelBuilder.ConfigureDoctor();

            modelBuilder.ConfigureNurseInspection();

            modelBuilder.ConfigurePrescription();

            modelBuilder.ConfigureUser();

            modelBuilder.ConfigureUserRole();

            modelBuilder.ConfigurePatient();

            modelBuilder.ConfigureMedicalAid();

            modelBuilder.ConfigureEmergencyContact();

            modelBuilder.ConfigureNextOfKin();

            modelBuilder.ConfigurePatientVital();

            modelBuilder.ConfigureReferral();

            
            #endregion

            #region Data Seeding
            modelBuilder.SeedingAdmissionFile();

            modelBuilder.SeedingBar();

            modelBuilder.SeedingBed();

            modelBuilder.SeedingBloodGroup();

            modelBuilder.SeedingCity();

            modelBuilder.SeedingComputerSkill();

            modelBuilder.SeedingDoctor();

            modelBuilder.SeedingDoctorType();

            modelBuilder.SeedingNurseType();

            modelBuilder.SeedingQualification();

            modelBuilder.SeedingShiftSlot();

            modelBuilder.SeedingSpecialization();

            modelBuilder.SeedingStaffMember();

            modelBuilder.SeedingSuburb();

            modelBuilder.SeedingRole();

            modelBuilder.SeedingUser();

            modelBuilder.SeedingPatient();

            modelBuilder.SeedingPrescription();

            modelBuilder.SeedingMedicalAid();

            modelBuilder.SeedingMedicalAidPlan();

            modelBuilder.SeedingMedicalAidScheme();

            modelBuilder.SeedingMedicalCondition();

            modelBuilder.SeedingMedication();

            modelBuilder.SeedingMedicationSchedule();

            modelBuilder.SeedingNextofKin();

            modelBuilder.SeedingTreatmentType();

            modelBuilder.SeedingFormulation();

            modelBuilder.SeedingMonth();

            modelBuilder.SeedingReferral();

            modelBuilder.SeedingDiagnosis();

            modelBuilder.SeedingReceptionist();

            modelBuilder.SeedingUserRole();

            modelBuilder.SeedingNurseSchedule();

            modelBuilder.SeedingNurse();

            modelBuilder.SeedingClocking();

            modelBuilder.SeedingPatientMovement();

            #endregion
        }

        #region Database Sets
        //the database tables are all declared here
        public DbSet<AdmissionFile> AdmissionFile { get; set; }
        public DbSet<Bar> Bar { get; set; }
        public DbSet<Bed> Bed { get; set; }
        public DbSet<BloodGroup> BloodGroup { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<ClerkComputer> ClerkComputer { get; set; }
        public DbSet<Clocking> Clocking { get; set; }
        public DbSet<ComputerSkill> ComputerSkill { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<DoctorInspection> DoctorInspection { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedule { get; set; }
        public DbSet<DoctorType> DoctorType { get; set; }
        public DbSet<EmergencyContact> EmergencyContact { get; set; }
        public DbSet<MedicalAid> MedicalAid { get; set; }
        public DbSet<MedicalAidPlan> MedicalAidPlan { get; set; }
        public DbSet<MedicalAidScheme> MedicalAidScheme { get; set; }
        public DbSet<MedicalCondition> MedicalCondition { get; set; }
        public DbSet<MedicalHistory> MedicalHistory { get; set; }
        public DbSet<Month> Month { get; set; }
        public DbSet<NextOfKin> NextOfKin { get; set; }
        public DbSet<Nurse> Nurse { get; set; }
        public DbSet<NurseBar> NurseBar { get; set; }
        public DbSet<NurseInspection> NurseInspection { get; set; }
        public DbSet<NurseSchedule> NurseSchedule { get; set; }
        public DbSet<NurseType> NurseType { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<ProcedureHistory> ProcedureHistory { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<Receptionist> Receptionist { get; set; }
        public DbSet<Referral> Referral { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ShiftSlot> ShiftSlot { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<StaffMember> StaffMember { get; set; }
        public DbSet<Suburb> Suburb { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<VitalSign> VitalSign { get; set; }
        public DbSet<Formulation> Formulation { get; set; }
       
        public DbSet<PatientMovement> PatientMovement { get; set; }
        public DbSet<PatientVital> PatientVital { get; set; }
        public DbSet<Medication> Medication { get; set; }
        public DbSet<MedicationSchedule> MedicationSchedule { get; set; }
        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<Medication> TreatmentType { get; set; }


        #endregion
    }
}