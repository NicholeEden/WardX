using EFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.ExtensionMethod
{
    public static class DomainConfig
    {
        #region Patient
        public static void ConfigurePatient(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasOne<EmergencyContact>(patient => patient.EmergencyContact)
                      .WithOne(emergency => emergency.Patient)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<NextOfKin>(patient => patient.NextOfKin)
                      .WithOne(nextofkin => nextofkin.Patient)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<MedicalAid>(patient => patient.MedicalAid)
                      .WithOne(medicalaid => medicalaid.Patient)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
        #endregion

        #region ClerkComputer
        public static void ConfigureClerkComputer(this ModelBuilder modelBuilder)
        {
            // configure the 'ClerkComputer' entity by creating an anonymous object 'clerkComputer' using a lambda expression
            modelBuilder.Entity<ClerkComputer>(clerkComputer =>
            {
                // configure the primary key by using the 'HasOne()' method
                // by creating an anonymous object 'compositeKey' to represent 'clerkComputer'
                // we create a new object that represents the composite key 'ClerkID' and 'ComputerID'
                clerkComputer.HasKey(compositeKey => new { compositeKey.ClerkID, compositeKey.ComputerSkillID });

                // configure the point to point relationship from 'ClerkComputer' to 'Receptionist'
                // we invoke the 'HasOne()' method and specify the 'Receptionist' table as our target table
                // by creating an anonymous object 'clerkComputer' we select the object in the 'ClerkComputer'
                // table that points to the 'Receptionist' table
                clerkComputer.HasOne<Receptionist>(clerkComp => clerkComp.Receptionist)
                              // by creating an anonymous object 'receptionist' we select the object in the 'Receptionist'
                              // table that points to the 'ClerkComputer' table 
                              .WithMany(receptionist => receptionist.ClerkComputer)
                              // we specify the foreign key object in the 'ClerkComputer' table
                              .HasForeignKey(clerkComp => clerkComp.ClerkID);
            });
        }
        #endregion

        #region Nurse
        public static void ConfigureNurse(this ModelBuilder modelBuilder)
        {
            // configure nurse table
            modelBuilder.Entity<Nurse>(entity =>
            {
                // configure relationship from nurse to staff member
                entity.HasOne<StaffMember>(nurse => nurse.isStaffMember)
                     .WithOne(staff => staff.Nurse)
                     .HasForeignKey<Nurse>(fk => fk.NurseID);
            });
        }
        #endregion

        #region DoctorInspection
        public static void ConfigureDoctorInspection(this ModelBuilder modelBuilder)
        {
            // this table now uses a surrogate key
            modelBuilder.Entity<DoctorInspection>(doctorInsepction =>
            {

                doctorInsepction.HasOne<Doctor>(docInsepction => docInsepction.Doctor)
                                .WithMany(doctor => doctor.DoctorInspection)
                                // do not track if foreign key relationship still exists
                                .OnDelete(DeleteBehavior.Restrict);

                doctorInsepction.HasOne<Patient>(docInsepction => docInsepction.Patient)
                                .WithMany(patient => patient.DoctorInspection)
                                // do not track if foreign key relationship still exists
                                .OnDelete(DeleteBehavior.Restrict);
            });
        }
        #endregion

        #region NurseBar
        public static void ConfigureNurseBar(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NurseBar>(nurseBar =>
            {
                nurseBar.HasKey(compositeKey => new { compositeKey.NurseID, compositeKey.BarID });
            });
        }
        #endregion

        #region MedicalHistory
        public static void ConfigureMedicalHistory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalHistory>(entity =>
            {
                entity.HasKey(medical => medical.PatientID);

                entity.HasOne<Patient>(medical => medical.Patient)
                      .WithMany(patient => patient.MedicalHistory)
                      .HasForeignKey(medical => medical.PatientID);
            });
        }
        #endregion

        #region Reception
        public static void ConfigureReceptionist(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receptionist>(receptionist =>
            {
                // configure relationship from receptionist to staff member
                receptionist.HasOne<StaffMember>(recept => recept.isStaffMember)
                            .WithOne(staff => staff.Receptionist)
                            .HasForeignKey<Receptionist>(fk => fk.ClerkID);
            });
        }
        #endregion

        #region AdmissionFile
        public static void ConfigureAdmissionFile(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdmissionFile>(addFile =>
            {
                addFile.HasKey(admission => admission.AdmissionFileID);

                addFile.HasOne<Doctor>(admission => admission.Doctor)
                       .WithMany(doctor => doctor.AdmissionFiles)
                       .OnDelete(DeleteBehavior.Restrict);

                addFile.HasOne<Patient>(admission => admission.Patient)
                       .WithMany(patient => patient.AdmissionFiles)
                       .OnDelete(DeleteBehavior.Restrict);

                addFile.HasOne<Bed>(admission => admission.Bed)
                       .WithMany(bed => bed.AdmissionFiles)
                       .OnDelete(DeleteBehavior.Restrict);
            });
        }
        #endregion

        #region Doctor
        public static void ConfigureDoctor(this ModelBuilder modelBuilder)
        {
            // configure doctor nurse
            modelBuilder.Entity<Doctor>(entity =>
            {
                // configure relationship from doctor to staff member
                entity.HasOne<StaffMember>(doctor => doctor.IsStaffMember)
                      .WithOne(staff => staff.Doctor)
                      .HasForeignKey<Doctor>(fk => fk.DoctorID);
            });
        }
        #endregion

        #region NurseInspection
        public static void ConfigureNurseInspection(this ModelBuilder modelBuilder)
        {
            // this table now uses a surrogate key
            modelBuilder.Entity<NurseInspection>(entity =>
            {
                entity.HasOne<Nurse>(nurseInspection => nurseInspection.Nurse)
                      .WithMany(nurse => nurse.NurseInspection)
                      // do not track if foreign key relationship still exists
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Patient>(nurseInspection => nurseInspection.Patient)
                      .WithMany(patient => patient.NurseInspection)
                      // do not track if foreign key relationship still exists
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
        #endregion

        #region Prescription
        public static void ConfigurePrescription(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasOne<Doctor>(entityP => entityP.Doctor)
                .WithMany(entityDoc => entityDoc.Prescriptions)
                //do not track if foreign key relationship still exists
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
        #endregion

        #region User
        public static void ConfigureUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne<StaffMember>(user => user.StaffMember)
                      .WithOne(staff => staff.User);
            });
        }
        #endregion

        #region UserRole
        public static void ConfigureUserRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>(nurseBar =>
            {
                nurseBar.HasKey(compositeKey => new { compositeKey.RoleID, compositeKey.UserID });
            });
        }
        #endregion

        #region MedicalAid
        public static void ConfigureMedicalAid(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalAid>(entity =>
            {
                entity.HasKey(compositeKey => new { compositeKey.MedicalAidPlanID, compositeKey.MedicalAidSchemeID, compositeKey.PatientID });
            });
        }
        #endregion

        #region EmergencyContact
        public static void ConfigureEmergencyContact(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmergencyContact>(entity =>
            {
                entity.HasOne<Suburb>(contact => contact.Suburb)
                      .WithMany(suburb => suburb.EmergencyContact)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
        #endregion

        #region NextOfKin
        public static void ConfigureNextOfKin(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NextOfKin>(entity =>
            {
                entity.HasOne<Suburb>(kin => kin.Suburb)
                      .WithMany(suburb => suburb.NextOfKin)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
        #endregion

        #region PatientVital
        public static void ConfigurePatientVital(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientVital>(nurseBar =>
            {
                nurseBar.HasKey(compositeKey => new { compositeKey.AdmisssionFileID, compositeKey.VitalSignID });
            });
        }
        #endregion

        #region Referral
        public static void ConfigureReferral(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Referral>(entity =>
            {
                entity.HasOne<Doctor>(referral => referral.Doctor)
                      .WithMany(doctor => doctor.Referrals)
                      .HasForeignKey(referral => referral.ReferringDoctorID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Doctor>(referral => referral.Doctor)
                      .WithMany(doctor => doctor.Referrals)
                      .HasForeignKey(referral => referral.SpecialistID)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
        #endregion
    }
}
