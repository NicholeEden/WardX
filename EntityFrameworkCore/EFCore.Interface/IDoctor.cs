namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Doctor table
    /// </summary>
    public interface IDoctor
    {
        int DoctorID { get; set; }
        Specializations SpecializationID { get; set; }
        DoctorTypes DoctorTypeID { get; set; }
        string PracticeNumber { get; set; }
    }
}
