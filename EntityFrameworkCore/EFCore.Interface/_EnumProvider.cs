namespace EFCore.Interface
{
    /// <summary>
    /// Defines the options available to the database fields representing gender
    /// </summary>
    public enum Gender
    {
        Female,
        Male,
        Intersex,
        Transgender
    }
    /// <summary>
    /// Defines the options available to the database fields representing Reason
    /// </summary>
    public enum Reason
    {
        SmokeBreak,
        Surgery,
        BloodTests,
        XRays
    }

    /// <summary>
    /// Defines the Medical Aid Plan options on the database
    /// </summary>
    public enum MedicalAidPlans
    {
        Executive = 101,
        Comprehensive,
        Priority,
        Saver,
        Core,
        Smart,
        Keycare,
        Standard,
        Family,
        Premium
    }

    /// <summary>
    /// Defines the Medical Aid Scheme options on the database
    /// </summary>
    public enum MedicalAidSchemes
    {
        Discovery = 101,
        Fedhealth,
        Medihelp,
        Medshield,
        Bonitas,
        Momentum
    }

    /// <summary>
    /// Defines the options available to the database field 'StaffMember.StaffType'
    /// </summary>
    public enum StaffType
    {
        Doctor,
        Nurse,
        Receptionist,
        WardManager
    }

    public enum ShiftSlots
    {
        Day = 101,
        Night = 102
    }

    /// <summary>
    /// Defines the user roles, the integer value represents the primary key 'RoleID' on the database
    /// </summary>
    public enum WARDxRoles
    {
        Administrator = 101,
        Receptionist,
        Specialist,
        General_Practitioner,
        Nurse,
        Sister_Nurse,
        Ward_Manager
    }

    /// <summary>
    /// Defines the Suburb options on the database
    /// </summary>
    public enum Suburbs
    {
        Walmer = 101,
        Summerstrand,
        Humewood,
        SouthEnd,
        ForestHill,
        Schoenmakerskop,
        LovemorePark,
        NorthEnd,
        Korsten,
        WesternHills
    }

    /// <summary>
    /// Defines the Doctor type options on the database
    /// </summary>
    public enum DoctorTypes
    {
        Cardiologist = 101,
        Endocrinologist,
        Surgeon,
        Gastroenterologist,
        Neurologist,
        Radiologist,
        Oncologist,
        Anaesthesiologist,
        Physician,
        GeneralPractitioner,
        Dermatologist
    }

    /// <summary>
    /// Defines the Specialization options on the database
    /// </summary>
    public enum Specializations
    {
        Surgery = 101,
        RadiationOncolology,
        Anesthesiology,
        Oncology,
        Gynecology,
        Dermatology,
        Padiatics,
        Endocrinology,
        Cardiology,
        Neurology,
        Urology,
        Psychiatry,
        PhysicalMedicine,
        GeneralMedicine,
        Midwifery,
        Gastroenterology
    }
}
