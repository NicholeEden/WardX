using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Migrations
{
    public partial class HWMS06Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bar",
                columns: table => new
                {
                    BarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colour = table.Column<string>(maxLength: 1024, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bar", x => x.BarID);
                });

            migrationBuilder.CreateTable(
                name: "Bed",
                columns: table => new
                {
                    BedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1024, nullable: false),
                    isAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bed", x => x.BedID);
                });

            migrationBuilder.CreateTable(
                name: "BloodGroup",
                columns: table => new
                {
                    BloodGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroupName = table.Column<string>(maxLength: 1024, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGroup", x => x.BloodGroupID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Clocking",
                columns: table => new
                {
                    ClockingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseID = table.Column<int>(nullable: false),
                    ClockInTime = table.Column<DateTime>(nullable: false),
                    ClockOutTime = table.Column<DateTime>(nullable: false),
                    isClockedIn = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clocking", x => x.ClockingID);
                });

            migrationBuilder.CreateTable(
                name: "ComputerSkill",
                columns: table => new
                {
                    ComputerSkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Application = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerSkill", x => x.ComputerSkillID);
                });

            migrationBuilder.CreateTable(
                name: "DoctorType",
                columns: table => new
                {
                    DoctorTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorType", x => x.DoctorTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Formulation",
                columns: table => new
                {
                    FormulationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(maxLength: 1024, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulation", x => x.FormulationID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAidPlan",
                columns: table => new
                {
                    MedicalAidPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAidPlan", x => x.MedicalAidPlanID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAidScheme",
                columns: table => new
                {
                    MedicalAidSchemeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAidScheme", x => x.MedicalAidSchemeID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCondition",
                columns: table => new
                {
                    MedicalConditionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 1024, nullable: false),
                    Symptom = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCondition", x => x.MedicalConditionID);
                });

            migrationBuilder.CreateTable(
                name: "MedicationSchedule",
                columns: table => new
                {
                    MedicationScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchedulingStatus = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationSchedule", x => x.MedicationScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "Month",
                columns: table => new
                {
                    MonthID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthName = table.Column<string>(maxLength: 1024, nullable: false),
                    StartDate = table.Column<int>(nullable: false),
                    EndDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.MonthID);
                });

            migrationBuilder.CreateTable(
                name: "NurseType",
                columns: table => new
                {
                    NurseTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseType", x => x.NurseTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    QualificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1024, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.QualificationID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "ShiftSlot",
                columns: table => new
                {
                    ShiftSlotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1024, nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftSlot", x => x.ShiftSlotID);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    SpecializationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.SpecializationID);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    TreatmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseID = table.Column<int>(nullable: false),
                    PatientID = table.Column<int>(nullable: false),
                    TreatmentTypeID = table.Column<int>(nullable: false),
                    ObservationNotes = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.TreatmentID);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentType",
                columns: table => new
                {
                    TreatmentTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentType", x => x.TreatmentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 128, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 1024, nullable: false),
                    Avatar = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "VitalSign",
                columns: table => new
                {
                    VitalSignID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGroupID = table.Column<int>(nullable: false),
                    DateRecorded = table.Column<DateTime>(nullable: false),
                    Hypoglycemia = table.Column<string>(maxLength: 50, nullable: false),
                    BodyTemperature = table.Column<string>(maxLength: 50, nullable: false),
                    PulseRate = table.Column<string>(maxLength: 50, nullable: false),
                    BloodPressure = table.Column<string>(maxLength: 50, nullable: false),
                    Weight = table.Column<string>(maxLength: 50, nullable: false),
                    BMI = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSign", x => x.VitalSignID);
                    table.ForeignKey(
                        name: "FK_VitalSign_BloodGroup_BloodGroupID",
                        column: x => x.BloodGroupID,
                        principalTable: "BloodGroup",
                        principalColumn: "BloodGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suburb",
                columns: table => new
                {
                    SuburbID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuburbName = table.Column<string>(maxLength: 1024, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 4, nullable: false),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburb", x => x.SuburbID);
                    table.ForeignKey(
                        name: "FK_Suburb_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    DiagnosisID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalConditionID = table.Column<int>(nullable: false),
                    DiagnosedBy = table.Column<int>(nullable: false),
                    DiagnosisDetals = table.Column<string>(maxLength: 1024, nullable: false),
                    DiagnosisDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.DiagnosisID);
                    table.ForeignKey(
                        name: "FK_Diagnosis_MedicalCondition_MedicalConditionID",
                        column: x => x.MedicalConditionID,
                        principalTable: "MedicalCondition",
                        principalColumn: "MedicalConditionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
                columns: table => new
                {
                    MedicationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(maxLength: 1024, nullable: false),
                    MedicationScheduleID = table.Column<int>(nullable: false),
                    MedicationStrength = table.Column<string>(maxLength: 1024, nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    FormulationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medication", x => x.MedicationID);
                    table.ForeignKey(
                        name: "FK_Medication_Formulation_FormulationID",
                        column: x => x.FormulationID,
                        principalTable: "Formulation",
                        principalColumn: "FormulationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medication_MedicationSchedule_MedicationScheduleID",
                        column: x => x.MedicationScheduleID,
                        principalTable: "MedicationSchedule",
                        principalColumn: "MedicationScheduleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    IDNumber = table.Column<string>(maxLength: 13, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 1024, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 10, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 1024, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 1024, nullable: true),
                    SuburbID = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patient_Suburb_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburb",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffMember",
                columns: table => new
                {
                    StaffID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 1024, nullable: false),
                    LastName = table.Column<string>(maxLength: 1024, nullable: false),
                    EmployeeID = table.Column<string>(maxLength: 13, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 1024, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 1024, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 1024, nullable: true),
                    WorkNumber = table.Column<string>(maxLength: 10, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 10, nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    SuburbID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    StaffType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMember", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_StaffMember_Suburb_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburb",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffMember_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                columns: table => new
                {
                    EmergencyContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 1024, nullable: false),
                    LastName = table.Column<string>(maxLength: 1024, nullable: false),
                    Relationship = table.Column<string>(maxLength: 128, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 1024, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 10, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 1024, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 1024, nullable: true),
                    SuburbID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => x.EmergencyContactID);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_Suburb_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburb",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalAid",
                columns: table => new
                {
                    MedicalAidSchemeID = table.Column<int>(nullable: false),
                    MedicalAidPlanID = table.Column<int>(nullable: false),
                    PatientID = table.Column<int>(nullable: false),
                    MedicalAidSchemeID1 = table.Column<int>(nullable: true),
                    MedicalAidPlanID1 = table.Column<int>(nullable: true),
                    MemberNumber = table.Column<string>(maxLength: 128, nullable: false),
                    PrincipalFirstName = table.Column<string>(maxLength: 1024, nullable: false),
                    PrincipalLastName = table.Column<string>(maxLength: 1024, nullable: false),
                    DependantCode = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalAid", x => new { x.MedicalAidPlanID, x.MedicalAidSchemeID, x.PatientID });
                    table.ForeignKey(
                        name: "FK_MedicalAid_MedicalAidPlan_MedicalAidPlanID1",
                        column: x => x.MedicalAidPlanID1,
                        principalTable: "MedicalAidPlan",
                        principalColumn: "MedicalAidPlanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalAid_MedicalAidScheme_MedicalAidSchemeID1",
                        column: x => x.MedicalAidSchemeID1,
                        principalTable: "MedicalAidScheme",
                        principalColumn: "MedicalAidSchemeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalAid_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false),
                    Diagnosis = table.Column<string>(maxLength: 1024, nullable: false),
                    ExistingCondition = table.Column<string>(maxLength: 1024, nullable: false),
                    BMI = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Allergies = table.Column<string>(maxLength: 50, nullable: false),
                    BloodGroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_BloodGroup_BloodGroupID",
                        column: x => x.BloodGroupID,
                        principalTable: "BloodGroup",
                        principalColumn: "BloodGroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NextOfKin",
                columns: table => new
                {
                    NextOfKinID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 1024, nullable: false),
                    LastName = table.Column<string>(maxLength: 1024, nullable: false),
                    Relationship = table.Column<string>(maxLength: 128, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 1024, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 10, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 1024, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 1024, nullable: true),
                    SuburbID = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKin", x => x.NextOfKinID);
                    table.ForeignKey(
                        name: "FK_NextOfKin_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NextOfKin_Suburb_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburb",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureHistory",
                columns: table => new
                {
                    ProcedureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 1024, nullable: false),
                    AppointmentTime = table.Column<DateTime>(nullable: false),
                    ProcedureDescription = table.Column<string>(maxLength: 1024, nullable: false),
                    PatientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureHistory", x => x.ProcedureID);
                    table.ForeignKey(
                        name: "FK_ProcedureHistory_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(nullable: false),
                    SpecializationID = table.Column<int>(nullable: false),
                    DoctorTypeID = table.Column<int>(nullable: false),
                    PracticeNumber = table.Column<string>(maxLength: 128, nullable: false),
                    SpecializationID1 = table.Column<int>(nullable: true),
                    DoctorTypeID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctor_StaffMember_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "StaffMember",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_DoctorType_DoctorTypeID1",
                        column: x => x.DoctorTypeID1,
                        principalTable: "DoctorType",
                        principalColumn: "DoctorTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_Specialization_SpecializationID1",
                        column: x => x.SpecializationID1,
                        principalTable: "Specialization",
                        principalColumn: "SpecializationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    NurseID = table.Column<int>(nullable: false),
                    isWardManager = table.Column<bool>(nullable: false),
                    isHeadNurse = table.Column<bool>(nullable: false),
                    SpecializationID = table.Column<int>(nullable: false),
                    NurseTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.NurseID);
                    table.ForeignKey(
                        name: "FK_Nurse_StaffMember_NurseID",
                        column: x => x.NurseID,
                        principalTable: "StaffMember",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nurse_NurseType_NurseTypeID",
                        column: x => x.NurseTypeID,
                        principalTable: "NurseType",
                        principalColumn: "NurseTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nurse_Specialization_SpecializationID",
                        column: x => x.SpecializationID,
                        principalTable: "Specialization",
                        principalColumn: "SpecializationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receptionist",
                columns: table => new
                {
                    ClerkID = table.Column<int>(nullable: false),
                    QualificationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionist", x => x.ClerkID);
                    table.ForeignKey(
                        name: "FK_Receptionist_StaffMember_ClerkID",
                        column: x => x.ClerkID,
                        principalTable: "StaffMember",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receptionist_Qualification_QualificationID",
                        column: x => x.QualificationID,
                        principalTable: "Qualification",
                        principalColumn: "QualificationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorInspection",
                columns: table => new
                {
                    DoctorInspectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(maxLength: 1024, nullable: false),
                    DoctorID = table.Column<int>(nullable: false),
                    PatientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorInspection", x => x.DoctorInspectionID);
                    table.ForeignKey(
                        name: "FK_DoctorInspection_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorInspection_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSchedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftSlotID = table.Column<int>(nullable: false),
                    isAvailable = table.Column<bool>(nullable: false),
                    DoctorID = table.Column<int>(nullable: false),
                    MonthID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSchedule", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_DoctorSchedule_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSchedule_Month_MonthID",
                        column: x => x.MonthID,
                        principalTable: "Month",
                        principalColumn: "MonthID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSchedule_ShiftSlot_ShiftSlotID",
                        column: x => x.ShiftSlotID,
                        principalTable: "ShiftSlot",
                        principalColumn: "ShiftSlotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationID = table.Column<int>(nullable: false),
                    DoctorID = table.Column<int>(nullable: false),
                    Dosage = table.Column<double>(nullable: false),
                    DateIssued = table.Column<DateTime>(nullable: false),
                    Instruction = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescription_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Referral",
                columns: table => new
                {
                    ReferralID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(nullable: false),
                    DiagnosisID = table.Column<int>(nullable: false),
                    SpecialistID = table.Column<int>(nullable: false),
                    ReferringDoctorID = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(maxLength: 1024, nullable: false),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    isAdmitted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referral", x => x.ReferralID);
                    table.ForeignKey(
                        name: "FK_Referral_Diagnosis_DiagnosisID",
                        column: x => x.DiagnosisID,
                        principalTable: "Diagnosis",
                        principalColumn: "DiagnosisID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referral_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referral_Doctor_SpecialistID",
                        column: x => x.SpecialistID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NurseBar",
                columns: table => new
                {
                    NurseID = table.Column<int>(nullable: false),
                    BarID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseBar", x => new { x.NurseID, x.BarID });
                    table.ForeignKey(
                        name: "FK_NurseBar_Bar_BarID",
                        column: x => x.BarID,
                        principalTable: "Bar",
                        principalColumn: "BarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseBar_Nurse_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurse",
                        principalColumn: "NurseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NurseInspection",
                columns: table => new
                {
                    NurseInspectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(maxLength: 1024, nullable: false),
                    NurseID = table.Column<int>(nullable: false),
                    PatientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseInspection", x => x.NurseInspectionID);
                    table.ForeignKey(
                        name: "FK_NurseInspection_Nurse_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurse",
                        principalColumn: "NurseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NurseInspection_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NurseSchedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isAvailable = table.Column<bool>(nullable: false),
                    ShiftSlotID = table.Column<int>(nullable: false),
                    NurseID = table.Column<int>(nullable: false),
                    MonthID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NurseSchedule", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_NurseSchedule_Month_MonthID",
                        column: x => x.MonthID,
                        principalTable: "Month",
                        principalColumn: "MonthID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseSchedule_Nurse_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurse",
                        principalColumn: "NurseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NurseSchedule_ShiftSlot_ShiftSlotID",
                        column: x => x.ShiftSlotID,
                        principalTable: "ShiftSlot",
                        principalColumn: "ShiftSlotID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClerkComputer",
                columns: table => new
                {
                    ClerkID = table.Column<int>(nullable: false),
                    ComputerSkillID = table.Column<int>(nullable: false),
                    ProficiencyLevel = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClerkComputer", x => new { x.ClerkID, x.ComputerSkillID });
                    table.ForeignKey(
                        name: "FK_ClerkComputer_Receptionist_ClerkID",
                        column: x => x.ClerkID,
                        principalTable: "Receptionist",
                        principalColumn: "ClerkID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClerkComputer_ComputerSkill_ComputerSkillID",
                        column: x => x.ComputerSkillID,
                        principalTable: "ComputerSkill",
                        principalColumn: "ComputerSkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionFile",
                columns: table => new
                {
                    AdmissionFileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(nullable: false),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    AssignedSpecialistID = table.Column<int>(nullable: false),
                    DischargeDate = table.Column<DateTime>(nullable: true),
                    BedID = table.Column<int>(nullable: false),
                    PrescriptionID = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionFile", x => x.AdmissionFileID);
                    table.ForeignKey(
                        name: "FK_AdmissionFile_Doctor_AssignedSpecialistID",
                        column: x => x.AssignedSpecialistID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionFile_Bed_BedID",
                        column: x => x.BedID,
                        principalTable: "Bed",
                        principalColumn: "BedID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionFile_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionFile_Prescription_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientMovement",
                columns: table => new
                {
                    PatientMovementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionFileID = table.Column<int>(nullable: false),
                    MoveDate = table.Column<DateTime>(nullable: false),
                    CheckInTime = table.Column<DateTime>(nullable: true),
                    CheckOutTime = table.Column<DateTime>(nullable: false),
                    isCheckedOut = table.Column<bool>(nullable: false),
                    Reason = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMovement", x => x.PatientMovementID);
                    table.ForeignKey(
                        name: "FK_PatientMovement_AdmissionFile_AdmissionFileID",
                        column: x => x.AdmissionFileID,
                        principalTable: "AdmissionFile",
                        principalColumn: "AdmissionFileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientVital",
                columns: table => new
                {
                    VitalSignID = table.Column<int>(nullable: false),
                    AdmisssionFileID = table.Column<int>(nullable: false),
                    AdmissionFileID = table.Column<int>(nullable: true),
                    DateRecorded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVital", x => new { x.AdmisssionFileID, x.VitalSignID });
                    table.ForeignKey(
                        name: "FK_PatientVital_AdmissionFile_AdmissionFileID",
                        column: x => x.AdmissionFileID,
                        principalTable: "AdmissionFile",
                        principalColumn: "AdmissionFileID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Bar",
                columns: new[] { "BarID", "Colour", "Description" },
                values: new object[,]
                {
                    { 101, "Green", "Registered Midwife" },
                    { 102, "White", "Nursing Education Tutor" },
                    { 103, "Navy Blue", "Registered Psychiatric Nurse" },
                    { 104, "Dark Saxe Blue", "Registered Mental Nurse" },
                    { 105, "Light Saxe Blue", "Registered Mental Defectives Nurse" },
                    { 106, "Yellow", "Public Health Nursing" },
                    { 107, "Silver", "Nursing Admin" }
                });

            migrationBuilder.InsertData(
                table: "Bed",
                columns: new[] { "BedID", "Description", "isAvailable" },
                values: new object[,]
                {
                    { 120, "HWMSB20", true },
                    { 119, "HWMSB19", true },
                    { 118, "HWMSB18", true },
                    { 117, "HWMSB17", true },
                    { 116, "HWMSB16", true },
                    { 115, "HWMSB15", true },
                    { 114, "HWMSB14", true },
                    { 112, "HWMSB12", true },
                    { 111, "HWMSB11", true },
                    { 113, "HWMSB13", true },
                    { 109, "HWMSB09", true },
                    { 108, "HWMSB08", true },
                    { 107, "HWMSB07", true },
                    { 106, "HWMSB06", false },
                    { 105, "HWMSB05", true },
                    { 104, "HWMSB04", false },
                    { 103, "HWMSB03", true },
                    { 102, "HWMSB02", false },
                    { 101, "HWMSB01", true },
                    { 110, "HWMSB10", true }
                });

            migrationBuilder.InsertData(
                table: "BloodGroup",
                columns: new[] { "BloodGroupID", "BloodGroupName", "Description" },
                values: new object[,]
                {
                    { 107, "B Negative", "Can donate to type B, AB positive and negative" },
                    { 106, "AB Negative", "Can donate to type AB positive and negative" },
                    { 105, "A Negative", "Can donate to type A, AB positive and negative" },
                    { 104, "O Postive", "Can donate to type O, A, B, AB postive" },
                    { 100, "O Negative", "Universal Donor" },
                    { 102, "AB Postive", "Can donate to type AB positive" },
                    { 101, "A Positive", "Can donate to type A and AB positive" },
                    { 103, "B Postive", "Can donate to type B and AB positive" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityName" },
                values: new object[] { 101, "Port Elizabeth" });

            migrationBuilder.InsertData(
                table: "Clocking",
                columns: new[] { "ClockingID", "ClockInTime", "ClockOutTime", "NurseID", "isClockedIn" },
                values: new object[,]
                {
                    { 105, new DateTime(2020, 1, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 25, 16, 5, 0, 0, DateTimeKind.Unspecified), 117, true },
                    { 106, new DateTime(2020, 2, 4, 5, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 25, 16, 15, 0, 0, DateTimeKind.Unspecified), 118, true },
                    { 104, new DateTime(2020, 2, 29, 5, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 25, 16, 5, 0, 0, DateTimeKind.Unspecified), 116, true },
                    { 107, new DateTime(2020, 1, 5, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 25, 16, 5, 0, 0, DateTimeKind.Unspecified), 119, true },
                    { 102, new DateTime(2020, 2, 25, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 25, 16, 5, 0, 0, DateTimeKind.Unspecified), 114, true },
                    { 101, new DateTime(2020, 1, 23, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), 112, true },
                    { 103, new DateTime(2020, 1, 27, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 25, 16, 5, 0, 0, DateTimeKind.Unspecified), 115, true }
                });

            migrationBuilder.InsertData(
                table: "ComputerSkill",
                columns: new[] { "ComputerSkillID", "Application" },
                values: new object[,]
                {
                    { 101, "MS Office" },
                    { 102, "Spreadsheets" },
                    { 103, "Email Communication" },
                    { 104, "Data Visualization" }
                });

            migrationBuilder.InsertData(
                table: "DoctorType",
                columns: new[] { "DoctorTypeID", "Description" },
                values: new object[,]
                {
                    { 111, "Dermatologist" },
                    { 110, "General Practitioner" },
                    { 109, "Physician" },
                    { 108, "Anesthesiologist" },
                    { 107, "Oncologist" },
                    { 103, "Surgeon" },
                    { 105, "Neurologist" },
                    { 104, "Gastroenterologist" },
                    { 102, "Endocrinologist" },
                    { 101, "Cardiologist" },
                    { 106, "Radiologist" }
                });

            migrationBuilder.InsertData(
                table: "Formulation",
                columns: new[] { "FormulationID", "Abbreviation", "Description" },
                values: new object[,]
                {
                    { 104, "gtt", "Drops" },
                    { 103, "cap.", "Capsule" },
                    { 105, "inj", "Injection" },
                    { 101, "Liq", "Liquid" },
                    { 102, "tab.", "Tablet" }
                });

            migrationBuilder.InsertData(
                table: "MedicalAidPlan",
                columns: new[] { "MedicalAidPlanID", "Name" },
                values: new object[,]
                {
                    { 101, "Executive Plan" },
                    { 102, "Comprehensive Plan" },
                    { 103, "Priority Plan" },
                    { 104, "Saver Plan" },
                    { 105, "Core Plan" },
                    { 106, "Smart Plan" },
                    { 107, "Keycare Plan" },
                    { 108, "Standard Plan" },
                    { 109, "Family Plan" },
                    { 110, "Premium Plan" }
                });

            migrationBuilder.InsertData(
                table: "MedicalAidScheme",
                columns: new[] { "MedicalAidSchemeID", "Name" },
                values: new object[,]
                {
                    { 106, "Momentum" },
                    { 105, "Bonitas" },
                    { 104, "Medshield" },
                    { 101, "Discovery Health" },
                    { 102, "Fedhealth" },
                    { 103, "Medihelp" }
                });

            migrationBuilder.InsertData(
                table: "MedicalCondition",
                columns: new[] { "MedicalConditionID", "Name", "Symptom" },
                values: new object[,]
                {
                    { 110, "Liver cancer", "Symptoms of liver cancer may include a lump or pain in the right side below the rib cage, swelling of the abdomen, yellowish skin, easy bruising, weight loss and weakness." },
                    { 115, "Splenomegaly", "Symptoms may include abdominal pain, chest pain, chest pain similar to pleuritic pain when stomach, bladder or bowels are full, back pain, early satiety due to splenic encroachment, or the symptoms of anemia due to accompanying cytopenia." },
                    { 114, "Lymphadenopathy", "Inflammation of the lymphatic vessels is known as lymphangitis." },
                    { 113, "Hyponatremia", "Symptoms of hyponatremia include nausea and vomiting, headache, short-term memory loss, confusion, lethargy, fatigue, loss of appetite, irritability, muscle weakness, spasms or cramps, seizures, and decreased consciousness or coma." },
                    { 112, "Hypercalcaemia", "Symptoms include cardiac arrhythmias (especially in those taking digoxin), fatigue, nausea, vomiting (emesis), loss of appetite, abdominal pain, & paralytic ileus." },
                    { 111, "Paraneoplastic syndrome", "The most common presentation is a fever." },
                    { 109, "Leukemia", "Symptoms may include bleeding and bruising, feeling tired, fever, and an increased risk of infections." },
                    { 108, "Hodgkin lymphoma", "Symptoms may include fever, night sweats, and weight loss." },
                    { 107, "Cachexia", "Systemic inflammation from these conditions can cause detrimental changes to metabolism and body composition." },
                    { 106, "Lower gastrointestinal bleeding", "Bleeding which involves a bleed anywhere from the ileocecal valve to the anus." },
                    { 105, "Anemia", "Symptoms may include confusion, feeling like one is going to pass out, loss of consciousness, and increased thirst." },
                    { 104, "Ulcer", "The skin around the ulcer may be red, swollen, and tender." },
                    { 103, "Colorectal cancer", "Symptoms may include blood in the stool, a change in bowel movements, weight loss, and fatigue." },
                    { 102, "Pneumonia", "Symptoms typically include some combination of productive or dry cough, chest pain, fever and difficulty breathing." },
                    { 101, "Esophageal cancer", "Symptoms often include difficulty in swallowing and weight loss." }
                });

            migrationBuilder.InsertData(
                table: "MedicationSchedule",
                columns: new[] { "MedicationScheduleID", "SchedulingStatus" },
                values: new object[,]
                {
                    { 104, "Controlled Drug" },
                    { 103, "Prescription Only" },
                    { 102, "Pharmacy Medicine" },
                    { 101, "General" }
                });

            migrationBuilder.InsertData(
                table: "Month",
                columns: new[] { "MonthID", "EndDate", "MonthName", "StartDate" },
                values: new object[,]
                {
                    { 112, 31, "December", 1 },
                    { 111, 30, "November", 1 },
                    { 110, 31, "October", 1 },
                    { 109, 30, "September", 1 },
                    { 108, 31, "August", 1 },
                    { 107, 31, "July", 1 },
                    { 102, 29, "February", 1 },
                    { 105, 31, "May", 1 },
                    { 104, 30, "April", 1 },
                    { 103, 31, "March", 1 },
                    { 101, 31, "January", 1 },
                    { 106, 30, "June", 1 }
                });

            migrationBuilder.InsertData(
                table: "NurseType",
                columns: new[] { "NurseTypeID", "Description" },
                values: new object[,]
                {
                    { 105, "Licensed Practical Nurse" },
                    { 104, "Oncology Nurse" },
                    { 102, "Midwife Nurse" },
                    { 101, "Registered Nurse" },
                    { 103, "Nurse Practitioner" }
                });

            migrationBuilder.InsertData(
                table: "Qualification",
                columns: new[] { "QualificationID", "Description", "Title" },
                values: new object[,]
                {
                    { 101, "Public Administration and Management", "National Diploma" },
                    { 102, "Higher Certificate in Office Administration", "National Senior Certificate (NSC)" },
                    { 103, "Public Relations Management", "National Diploma" },
                    { 104, "Bachelor of Commerce Honours in Organizational Psychology ", "Honours Degree" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 106, "Sister Nurse" },
                    { 107, "Ward Manager" },
                    { 105, "Nurse" },
                    { 103, "Specialist" },
                    { 102, "Receptionist" },
                    { 101, "Administrator" },
                    { 104, "General Practitioner" }
                });

            migrationBuilder.InsertData(
                table: "ShiftSlot",
                columns: new[] { "ShiftSlotID", "Description", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 101, "Morning", new DateTime(2020, 6, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 23, 5, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, "Evening", new DateTime(2020, 6, 24, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 23, 17, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "SpecializationID", "Description" },
                values: new object[,]
                {
                    { 112, "Psychiatry" },
                    { 111, "Urology" },
                    { 113, "Physical Medicine & Occupational Therapy" },
                    { 110, "Neurology" },
                    { 115, "Midwifery" },
                    { 116, "Gastroenterology" },
                    { 114, "General Medicine" },
                    { 109, "Cardiology" },
                    { 103, "Anesthesiology" },
                    { 107, "Paediatrics" },
                    { 106, "Dermatology" },
                    { 105, "Gynecology" },
                    { 104, "Oncology" },
                    { 108, "Endocrinology" },
                    { 102, "Radiation Oncology" },
                    { 101, "Surgery" }
                });

            migrationBuilder.InsertData(
                table: "TreatmentType",
                columns: new[] { "TreatmentTypeID", "Description" },
                values: new object[,]
                {
                    { 110, "Hygiene Care" },
                    { 109, "Stitch Wound(s)" },
                    { 108, "Intubate" },
                    { 107, "Blood Transfusion" },
                    { 106, "Specimen Collection" },
                    { 104, "Change Bed Pad" },
                    { 103, "Draw Blood Sample" },
                    { 102, "Replace IV Bag" },
                    { 101, "Changed Wound Dressing" },
                    { 105, "Change Catheter Bag" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Avatar", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { 111, "058-thief", "$HWMS06$10000$K0XnTJahNPKXAS2QOQl6SrmWkWQ7fuJNJfFAL7t9ssC2MPzz", "HWMS062020111" },
                    { 117, "021-lego", "$HWMS06$10000$DqtBJ85m2JBE5d8bC5H/PB3w95u7sCdhTtCRZ3Abl3rIoYwA", "HWMS062020117" },
                    { 118, "024-lego", "$HWMS06$10000$zIX0XYt6YlWAYWQ2exmBaVHXgNe0NEl/HRNh2BsxyQnPKru2", "HWMS062020118" },
                    { 116, "032-boy", "$HWMS06$10000$zmTZKfoDzfA53+Bee+N9Z/hfCZlipBYZOi0NKB4W2eqnxM9m", "HWMS062020116" },
                    { 115, "017-lego", "$HWMS06$10000$dAOeXtspxkqy9MEj0nPQycLr+36tG1s4es7BRsS0NV8oSl47", "HWMS062020115" },
                    { 114, "014-lego", "$HWMS06$10000$cW6RU4u8GjO7wF7i52Ug5Fe+h5ZA+ZKVflRsHecaqGgt8Lbl", "HWMS062020114" },
                    { 113, "036-mariachi", "$HWMS06$10000$veq/Cr7cRqfeoh5b6QppBXs92sXLWd6gG9bw58K9fUw+XxkI", "HWMS062020113" },
                    { 112, "041-businessman", "$HWMS06$10000$AWpJVzNCv6MOrpRSbFevT4j/xBoVWNA7vW+7i0eSfBiZCg9X", "HWMS062020112" },
                    { 110, "072-woman", "$HWMS06$10000$62Ka4ncOkRKIxXo3ivnpXcLsL5/W2USmro/k5maeJRwiuw/q", "HWMS062020110" },
                    { 102, "001-lego", "$HWMS06$10000$1Pe0ZeHvtvn0C3WdWzvv4KasL2psdAlokhy6NxZok6iyx2pb", "HWMS062020102" },
                    { 108, "013-lego", "$HWMS06$10000$veu2Er28oYupxxIgi2uuws2oUgZ8+PEUVVe74motl51frx+h", "HWMS062020108" },
                    { 107, "003-lego", "$HWMS06$10000$dCU/tNEume2bRadF+DMJ9iHR4GmpE+hmPIZsZifIq+HoO5cI", "HWMS062020107" },
                    { 106, "018-lego", "$HWMS06$10000$D9suRuWsDo1ZRk3c8Luf8DVyO/VwxK//a4pdoubZCx+wXtx9", "HWMS062020106" },
                    { 105, "014-lego", "$HWMS06$10000$8yOHaatwa5N/NykUdWTrc0kuHgJqkpeJGHfNDsngr2iG2k6a", "HWMS062020105" },
                    { 104, "007-lego", "$HWMS06$10000$SYW4siAsSBp7OrlmhPLqvw5+O4HGFdG2fu2NoLjamzjF1QgV", "HWMS062020104" },
                    { 103, "017-lego", "$HWMS06$10000$jcz5Ei8Of4Lv1sJmyqhjv2+9e2oaOcwQfPK9r1NG/QSDIqA4", "HWMS062020103" },
                    { 101, "001-lego", "$HWMS06$10000$uiVvIEQW83F9aJAjzfiFAlhFqvE0jG+nOR5XKxhDa5o8T8VL", "HWMS062020101" },
                    { 119, "029-explorer", "$HWMS06$10000$x3cGndJF6m0LscGv+1U0tm1PkbQHfkaWPMQnzumiQErsFLIf", "HWMS062020119" },
                    { 109, "021-lego", "$HWMS06$10000$vb0D1GhPre89GQyfZ3JURPBCxi5/FYwaQhwRaLK2OKcMYn7/", "HWMS062020109" },
                    { 120, "041-businessman", "$HWMS06$10000$EOaRcD70oxk2IiB5IK0B/hOTBrgMabnuCMHGfbBmxIbuLsOK", "HWMS062020120" }
                });

            migrationBuilder.InsertData(
                table: "Diagnosis",
                columns: new[] { "DiagnosisID", "DiagnosedBy", "DiagnosisDate", "DiagnosisDetals", "MedicalConditionID" },
                values: new object[,]
                {
                    { 101, 101, new DateTime(2021, 1, 30, 8, 5, 31, 577, DateTimeKind.Local).AddTicks(3971), "Mild esophageal scaring is causing difficulty consuming solid foods.", 101 },
                    { 103, 111, new DateTime(2021, 1, 30, 8, 5, 31, 577, DateTimeKind.Local).AddTicks(5927), "Fungi caused inflammation in the left lung.", 102 },
                    { 102, 101, new DateTime(2021, 1, 30, 8, 5, 31, 577, DateTimeKind.Local).AddTicks(5889), "Skin is very tender, may cause patient to be prone to cuts.", 104 },
                    { 104, 111, new DateTime(2021, 1, 30, 8, 5, 31, 577, DateTimeKind.Local).AddTicks(5930), "Bruising along the soles of the feet.", 109 },
                    { 105, 101, new DateTime(2021, 1, 30, 8, 5, 31, 577, DateTimeKind.Local).AddTicks(5931), "Patient is experiencing abdominal pain and muscle tenderness.", 112 },
                    { 106, 111, new DateTime(2021, 1, 30, 8, 5, 31, 577, DateTimeKind.Local).AddTicks(5933), "Patient is experiencing abdominal pain.", 112 }
                });

            migrationBuilder.InsertData(
                table: "Medication",
                columns: new[] { "MedicationID", "ExpiryDate", "FormulationID", "MedicationName", "MedicationScheduleID", "MedicationStrength" },
                values: new object[,]
                {
                    { 108, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 105, "Insulin Mixtard", 103, " mg" },
                    { 107, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 103, "Oxycodone", 104, "10 mg" },
                    { 105, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 105, "Morphine", 104, "10 mg" },
                    { 109, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 102, "Methadone", 103, "10 mg" },
                    { 103, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 101, "Cisplatin", 103, "50 mg" },
                    { 102, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 101, "Capecitabine", 103, "500 mg" },
                    { 101, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 101, "Altertamine", 103, "100 mg" },
                    { 110, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 103, "Ibuprofen", 102, " 200 mg" },
                    { 104, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 102, "Amoxil", 102, "500 mg" },
                    { 106, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Local), 102, "Asprin", 101, "325 mg" }
                });

            migrationBuilder.InsertData(
                table: "Suburb",
                columns: new[] { "SuburbID", "CityID", "PostalCode", "SuburbName" },
                values: new object[,]
                {
                    { 101, 101, "6070", "Walmer" },
                    { 109, 101, "6020", "Korsten" },
                    { 110, 101, "6025", "Western Hills" },
                    { 103, 101, "6013", "Humewood" },
                    { 104, 101, "6001", "South End" },
                    { 102, 101, "6001", "Summerstrand" },
                    { 106, 101, "6011", "Schoenmakerskop" },
                    { 107, 101, "6070", "Lovemore Park" },
                    { 108, 101, "6001", "North End" },
                    { 105, 101, "6001", "Forest Hill" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleID", "UserID" },
                values: new object[,]
                {
                    { 105, 118 },
                    { 104, 111 },
                    { 105, 117 },
                    { 105, 116 },
                    { 105, 115 },
                    { 105, 114 },
                    { 102, 113 },
                    { 105, 112 },
                    { 103, 110 },
                    { 103, 106 },
                    { 103, 108 },
                    { 103, 107 },
                    { 103, 105 },
                    { 103, 104 },
                    { 103, 103 },
                    { 103, 102 },
                    { 104, 101 },
                    { 105, 119 },
                    { 103, 109 },
                    { 107, 120 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientID", "AddressLine1", "AddressLine2", "DOB", "EmailAddress", "FirstName", "Gender", "IDNumber", "LastName", "MobileNumber", "SuburbID" },
                values: new object[,]
                {
                    { 103, "8 Clark Street", null, new DateTime(1980, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "S.Panisello@techbuzz.co.za", "Stephanie", 0, "8007158951437", "Panisello", "0849871582", 109 },
                    { 102, "28 Albert Street", null, new DateTime(1995, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "s223186430@mandela.ac.za", "Sarah", 0, "9506308951437", "Connor", "0849851122", 103 },
                    { 104, "8 Doreen Drive", null, new DateTime(1989, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "N.Apostolides@techbuzz.co.za", "Nick", 1, "8904106951857", "Apostolides", "0840984108", 107 },
                    { 101, "50 Seaview Street", null, new DateTime(1990, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Smith@techbuzz.co.za", "John", 1, "9007107005123", "Smith", "0745017520", 105 },
                    { 106, "8 Deveroux Ave", null, new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P.Oliver@techbuzz.co.za", "Pam", 2, "8010053951422", "Oliver", "0845550514", 106 },
                    { 105, "8 Deveroux Ave", null, new DateTime(1985, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.Andersen@techbuzz.co.za", "Jolene", 3, "8504203951422", "Andersen", "0840039514", 106 }
                });

            migrationBuilder.InsertData(
                table: "StaffMember",
                columns: new[] { "StaffID", "AddressLine1", "AddressLine2", "EmailAddress", "EmployeeID", "FirstName", "Gender", "LastName", "MobileNumber", "StaffType", "SuburbID", "UserID", "WorkNumber", "isActive" },
                values: new object[,]
                {
                    { 114, "104 Roachella Street ", "Country Drive", "N.Birch@wardx.co.za", "HWMS062020114", "Nick", 1, "Birch", "0419875200", 1, 101, 114, "0515968836", true },
                    { 112, "79 Roach Ave", "Dale Drive", "D.Creech@wardx.co.za", "HWMS062020112", "Don", 1, "Creech", "0412020112", 1, 108, 112, "0515465783", true },
                    { 109, "23 La Roche Dr", "", "J.Armeniox@wardx.co.za", "HWMS062020109", "Jo", 0, "Armeniox", "0419612498", 0, 108, 109, "0415546113", true },
                    { 116, "1050 Hillside Downs", "", "A.Glouberman@wardx.co.za", "HWMS062020118", "Andrew", 1, "Globerman", "0412035596", 1, 107, 116, "0510003650", true },
                    { 106, "15 La Roche Dr", "", "R.Wiethoff@wardx.co.za", "HWMS062020106", "Rob", 1, "Wiethoff", "0417782887", 0, 107, 106, "0414164413", true },
                    { 104, "13 La Roche Dr", "", "B.Davis@wardx.co.za", "HWMS062020104", "Benjamin Byron", 1, "Davis", "0417957517", 0, 107, 104, "0411753743", true },
                    { 110, "25 La Roche Dr", "", "S.Strelitz@wardx.co.za", "HWMS062020110", "Samantha", 0, "Strelitz", "0413753498", 0, 106, 110, "0415465113", true },
                    { 105, "14 La Roche Dr", "", "R.Clark@wardx.co.za", "HWMS062020105", "Roger", 1, "Clark", "0417936887", 0, 106, 105, "0411754413", true },
                    { 107, "18 La Roche Dr", "", "C.Moore@wardx.co.za", "HWMS062020107", "Cali Elizabeth", 0, "Moore", "0417784748", 0, 105, 107, "0414166483", true },
                    { 117, "4525 Piestry Drive", "The Factory", "J.Glaser@wardx.co.za", "HWMS062020117", "Jessi", 0, "Glaser", "0418932718", 1, 104, 117, "0515656893", true },
                    { 115, "25 Flyton Ave", "Dickson Drive", "M.Foreman-Greenwald@wardx.co.za", "HWMS062020115", "Missy", 0, "Foreman-Greenwald", "0412625403", 1, 104, 115, "0519966587", true },
                    { 108, "21 La Roche Dr", "", "M.Buccianti@wardx.co.za", "HWMS062020108", "Marissa", 0, "Buccianti", "0419634748", 0, 103, 108, "0415546483", true },
                    { 103, "12 La Roche Dr", "", "T.Aberdeen@wardx.co.za", "HWMS062020103", "Tammy", 0, "Aberdeen", "0417430417", 0, 103, 103, "0411100743", true },
                    { 102, "38 Blackthorn Ave", "Forest Hill", "R.Alger@wardx.co.za", "HWMS062020102", "Roland", 1, "Alger", "0824224217", 0, 103, 102, "0214217824", true },
                    { 120, "102 Beach Road", "", "J.Bilzerian@wardx.co.za", "HWMS062020120", "Jay", 1, "Bilzerian", "0412020213", 3, 102, 120, "0517896542", true },
                    { 119, "1223 Pepperment CLose", "Sundowns Estate", "M.MacDell@wardx.co.za", "HWMS062020119", "Matthew", 1, "MacDell", "0410215496", 1, 102, 119, "0515435960", true },
                    { 101, "52 Rubin Cres", "", "A.Abbington@wardx.co.za", "HWMS062020101", "Aldridge", 1, "Abbington", "0824127849", 0, 102, 101, "0214217894", true },
                    { 118, "134 Heugh Road", "The Loft", "G.Alverez@wardx.co.za", "HWMS062020118", "Gina", 0, "Alverez", "0419837960", 1, 101, 118, "0515859632", true },
                    { 111, "75 Roach Ave", "Dale Drive", "S.Marzocchi@wardx.co.za", "HWMS062020111", "Sophia", 0, "Marzocchi", "0412020111", 0, 109, 111, "0515465113", true },
                    { 113, "105 Roach Ave", "Dale Drive", "D.McFarland@wardx.co.za", "HWMS062020113", "Daron", 1, "McFarland", "0412020113", 2, 109, 113, "0515463573", true }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorID", "DoctorTypeID", "DoctorTypeID1", "PracticeNumber", "SpecializationID", "SpecializationID1" },
                values: new object[,]
                {
                    { 106, 107, null, "HWMS-0091575", 104, null },
                    { 101, 110, null, "HWMS-0090565", 114, null },
                    { 110, 105, null, "HWMS-0091595", 112, null },
                    { 105, 111, null, "HWMS-0091550", 106, null },
                    { 111, 110, null, "HWMS-0091795", 113, null },
                    { 102, 104, null, "HWMS-0090875", 116, null },
                    { 103, 108, null, "HWMS-0091560", 103, null },
                    { 108, 106, null, "HWMS-0091580", 102, null },
                    { 109, 103, null, "HWMS-0091590", 101, null },
                    { 107, 109, null, "HWMS-0091770", 113, null },
                    { 104, 101, null, "HWMS-0091500", 109, null }
                });

            migrationBuilder.InsertData(
                table: "MedicalAid",
                columns: new[] { "MedicalAidPlanID", "MedicalAidSchemeID", "PatientID", "DependantCode", "MedicalAidPlanID1", "MedicalAidSchemeID1", "MemberNumber", "PrincipalFirstName", "PrincipalLastName" },
                values: new object[,]
                {
                    { 105, 106, 104, "005468571", null, null, "005425323", "Nick", "Apostolides" },
                    { 109, 104, 106, "005777371", null, null, "005455523", "Jolene", "Andersen" },
                    { 109, 101, 101, "005494301", null, null, "005493103", "Molly", "Smith" },
                    { 106, 101, 102, "005430071", null, null, "005698103", "Roland", "Connor" },
                    { 101, 102, 103, "005491271", null, null, "005646523", "Stephanie", "Panisello" },
                    { 106, 105, 105, "005067371", null, null, "005446223", "Jolene", "Andersen" }
                });

            migrationBuilder.InsertData(
                table: "NextOfKin",
                columns: new[] { "NextOfKinID", "AddressLine1", "AddressLine2", "EmailAddress", "FirstName", "Gender", "LastName", "MobileNumber", "PatientID", "Relationship", "SuburbID" },
                values: new object[,]
                {
                    { 102, "50 Seaview Street", null, "R.Connor@techbuzz.co.za", "Roland", 1, "Connor", "0761367520", 102, "Father", 103 },
                    { 105, "8 Deveroux Ave", null, "R.Andersen@techbuzz.co.za", "Renier", 2, "Andersen", "0761324680", 105, "Partner", 106 },
                    { 106, "8 Deveroux Ave", null, "B.Oliver@techbuzz.co.za", "Bob", 2, "Oliver", "0761399980", 106, "Partner", 106 },
                    { 103, "8 Clark Street", null, "Joel.Panisello@techbuzz.co.za", "Joel", 0, "Panisello", "0761390200", 103, "Partner", 109 },
                    { 104, "8 Doreen Drive", null, "T.Apostolides@techbuzz.co.za", "Ted", 1, "Apostolides", "0761314690", 104, "Partner", 107 },
                    { 101, "50 Seaview Street", null, "M.Smith@techbuzz.co.za", "Molly", 0, "Smith", "0747477520", 101, "Mother", 105 }
                });

            migrationBuilder.InsertData(
                table: "Nurse",
                columns: new[] { "NurseID", "NurseTypeID", "SpecializationID", "isHeadNurse", "isWardManager" },
                values: new object[,]
                {
                    { 116, 102, 114, false, false },
                    { 112, 102, 114, false, false },
                    { 114, 102, 114, false, false },
                    { 115, 102, 114, false, false },
                    { 120, 102, 114, false, true },
                    { 119, 102, 114, false, false },
                    { 118, 102, 114, false, false },
                    { 117, 102, 114, false, false }
                });

            migrationBuilder.InsertData(
                table: "Receptionist",
                columns: new[] { "ClerkID", "QualificationID" },
                values: new object[] { 113, 102 });

            migrationBuilder.InsertData(
                table: "AdmissionFile",
                columns: new[] { "AdmissionFileID", "AdmissionDate", "AssignedSpecialistID", "BedID", "DischargeDate", "Notes", "PatientID", "PrescriptionID" },
                values: new object[,]
                {
                    { 104, new DateTime(2020, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 102, null, "Patient has recent injury on the leg", 104, null },
                    { 103, new DateTime(2021, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 106, null, "none", 103, null },
                    { 105, new DateTime(2020, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 104, null, "none", 105, null }
                });

            migrationBuilder.InsertData(
                table: "NurseSchedule",
                columns: new[] { "ScheduleID", "MonthID", "NurseID", "ShiftSlotID", "isAvailable" },
                values: new object[,]
                {
                    { 104, 101, 117, 102, true },
                    { 102, 102, 115, 101, true },
                    { 101, 101, 114, 101, true },
                    { 106, 103, 119, 102, true },
                    { 105, 102, 118, 102, true },
                    { 103, 103, 116, 101, true }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "PrescriptionID", "DateIssued", "DoctorID", "Dosage", "Instruction", "MedicationID" },
                values: new object[,]
                {
                    { 101, new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 1.0, "Take dosage every 4 to 6 hours", 107 },
                    { 103, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 1.0, "Once a day beginning 6 hours after the procedure and continuing for 1 year", 106 }
                });

            migrationBuilder.InsertData(
                table: "Referral",
                columns: new[] { "ReferralID", "AdmissionDate", "DiagnosisID", "PatientID", "Reason", "ReferringDoctorID", "SpecialistID", "isAdmitted" },
                values: new object[,]
                {
                    { 105, new DateTime(2021, 2, 15, 8, 5, 31, 576, DateTimeKind.Local).AddTicks(8276), 105, 105, "Surgical removal of the overactive gland may be required.", 101, 103, true },
                    { 106, new DateTime(2021, 2, 15, 8, 5, 31, 576, DateTimeKind.Local).AddTicks(8284), 106, 106, "Surgical removal of the overactive gland may be required.", 111, 103, false },
                    { 103, new DateTime(2021, 2, 15, 8, 5, 31, 576, DateTimeKind.Local).AddTicks(8268), 103, 103, "Patient has difficulty breathing.", 111, 104, true },
                    { 104, new DateTime(2021, 2, 15, 8, 5, 31, 576, DateTimeKind.Local).AddTicks(8274), 104, 104, "Aggressive leukemia treatment required.", 111, 108, true },
                    { 102, new DateTime(2021, 2, 15, 8, 5, 31, 576, DateTimeKind.Local).AddTicks(8165), 102, 102, "Dull pain causes loss of appetite.", 101, 105, true },
                    { 101, new DateTime(2021, 2, 15, 8, 5, 31, 576, DateTimeKind.Local).AddTicks(3757), 101, 101, "Esophageal inflammation is sever along the left side of the neck.", 101, 102, true }
                });

            migrationBuilder.InsertData(
                table: "AdmissionFile",
                columns: new[] { "AdmissionFileID", "AdmissionDate", "AssignedSpecialistID", "BedID", "DischargeDate", "Notes", "PatientID", "PrescriptionID" },
                values: new object[,]
                {
                    { 101, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 101, new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "none", 101, 101 },
                    { 102, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 103, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient is feeling pain upon arrival", 102, 103 }
                });

            migrationBuilder.InsertData(
                table: "PatientMovement",
                columns: new[] { "PatientMovementID", "AdmissionFileID", "CheckInTime", "CheckOutTime", "MoveDate", "Reason", "isCheckedOut" },
                values: new object[,]
                {
                    { 104, 104, new DateTime(2021, 1, 29, 8, 20, 31, 582, DateTimeKind.Local).AddTicks(7243), new DateTime(2021, 1, 29, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7243), new DateTime(2021, 1, 29, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7243), 3, false },
                    { 105, 104, new DateTime(2021, 1, 30, 10, 5, 31, 582, DateTimeKind.Local).AddTicks(7281), new DateTime(2021, 1, 30, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7281), new DateTime(2021, 1, 30, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7281), 1, false },
                    { 106, 104, new DateTime(2021, 1, 31, 8, 35, 31, 582, DateTimeKind.Local).AddTicks(7284), new DateTime(2021, 1, 31, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7284), new DateTime(2021, 1, 31, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7284), 2, false },
                    { 101, 103, new DateTime(2021, 1, 29, 8, 20, 31, 582, DateTimeKind.Local).AddTicks(7243), new DateTime(2021, 1, 29, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7243), new DateTime(2021, 1, 29, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7243), 2, false },
                    { 102, 103, new DateTime(2021, 1, 30, 10, 5, 31, 582, DateTimeKind.Local).AddTicks(7281), new DateTime(2021, 1, 30, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7281), new DateTime(2021, 1, 30, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7281), 1, false },
                    { 103, 103, new DateTime(2021, 1, 31, 8, 35, 31, 582, DateTimeKind.Local).AddTicks(7284), new DateTime(2021, 1, 31, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7284), new DateTime(2021, 1, 31, 8, 5, 31, 582, DateTimeKind.Local).AddTicks(7284), 3, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionFile_AssignedSpecialistID",
                table: "AdmissionFile",
                column: "AssignedSpecialistID");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionFile_BedID",
                table: "AdmissionFile",
                column: "BedID");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionFile_PatientID",
                table: "AdmissionFile",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionFile_PrescriptionID",
                table: "AdmissionFile",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_ClerkComputer_ComputerSkillID",
                table: "ClerkComputer",
                column: "ComputerSkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_MedicalConditionID",
                table: "Diagnosis",
                column: "MedicalConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DoctorTypeID1",
                table: "Doctor",
                column: "DoctorTypeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecializationID1",
                table: "Doctor",
                column: "SpecializationID1");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorInspection_DoctorID",
                table: "DoctorInspection",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorInspection_PatientID",
                table: "DoctorInspection",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedule_DoctorID",
                table: "DoctorSchedule",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedule_MonthID",
                table: "DoctorSchedule",
                column: "MonthID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedule_ShiftSlotID",
                table: "DoctorSchedule",
                column: "ShiftSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_PatientID",
                table: "EmergencyContact",
                column: "PatientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_SuburbID",
                table: "EmergencyContact",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAid_MedicalAidPlanID1",
                table: "MedicalAid",
                column: "MedicalAidPlanID1");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAid_MedicalAidSchemeID1",
                table: "MedicalAid",
                column: "MedicalAidSchemeID1");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAid_PatientID",
                table: "MedicalAid",
                column: "PatientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_BloodGroupID",
                table: "MedicalHistory",
                column: "BloodGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_FormulationID",
                table: "Medication",
                column: "FormulationID");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_MedicationScheduleID",
                table: "Medication",
                column: "MedicationScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKin_PatientID",
                table: "NextOfKin",
                column: "PatientID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKin_SuburbID",
                table: "NextOfKin",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_NurseTypeID",
                table: "Nurse",
                column: "NurseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_SpecializationID",
                table: "Nurse",
                column: "SpecializationID");

            migrationBuilder.CreateIndex(
                name: "IX_NurseBar_BarID",
                table: "NurseBar",
                column: "BarID");

            migrationBuilder.CreateIndex(
                name: "IX_NurseInspection_NurseID",
                table: "NurseInspection",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_NurseInspection_PatientID",
                table: "NurseInspection",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedule_MonthID",
                table: "NurseSchedule",
                column: "MonthID");

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedule_NurseID",
                table: "NurseSchedule",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_NurseSchedule_ShiftSlotID",
                table: "NurseSchedule",
                column: "ShiftSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_SuburbID",
                table: "Patient",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMovement_AdmissionFileID",
                table: "PatientMovement",
                column: "AdmissionFileID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVital_AdmissionFileID",
                table: "PatientVital",
                column: "AdmissionFileID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DoctorID",
                table: "Prescription",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureHistory_PatientID",
                table: "ProcedureHistory",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_QualificationID",
                table: "Receptionist",
                column: "QualificationID");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_DiagnosisID",
                table: "Referral",
                column: "DiagnosisID");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_PatientID",
                table: "Referral",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Referral_SpecialistID",
                table: "Referral",
                column: "SpecialistID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMember_SuburbID",
                table: "StaffMember",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMember_UserID",
                table: "StaffMember",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suburb_CityID",
                table: "Suburb",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserID",
                table: "UserRole",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSign_BloodGroupID",
                table: "VitalSign",
                column: "BloodGroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClerkComputer");

            migrationBuilder.DropTable(
                name: "Clocking");

            migrationBuilder.DropTable(
                name: "DoctorInspection");

            migrationBuilder.DropTable(
                name: "DoctorSchedule");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "MedicalAid");

            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropTable(
                name: "NextOfKin");

            migrationBuilder.DropTable(
                name: "NurseBar");

            migrationBuilder.DropTable(
                name: "NurseInspection");

            migrationBuilder.DropTable(
                name: "NurseSchedule");

            migrationBuilder.DropTable(
                name: "PatientMovement");

            migrationBuilder.DropTable(
                name: "PatientVital");

            migrationBuilder.DropTable(
                name: "ProcedureHistory");

            migrationBuilder.DropTable(
                name: "Referral");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "TreatmentType");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "VitalSign");

            migrationBuilder.DropTable(
                name: "Receptionist");

            migrationBuilder.DropTable(
                name: "ComputerSkill");

            migrationBuilder.DropTable(
                name: "MedicalAidPlan");

            migrationBuilder.DropTable(
                name: "MedicalAidScheme");

            migrationBuilder.DropTable(
                name: "Formulation");

            migrationBuilder.DropTable(
                name: "MedicationSchedule");

            migrationBuilder.DropTable(
                name: "Bar");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "Nurse");

            migrationBuilder.DropTable(
                name: "ShiftSlot");

            migrationBuilder.DropTable(
                name: "AdmissionFile");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "BloodGroup");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "NurseType");

            migrationBuilder.DropTable(
                name: "Bed");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "MedicalCondition");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "StaffMember");

            migrationBuilder.DropTable(
                name: "DoctorType");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Suburb");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
