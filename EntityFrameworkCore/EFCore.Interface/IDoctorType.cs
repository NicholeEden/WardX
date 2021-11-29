namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Doctor Type table
    /// </summary>
    public interface IDoctorType
    {
        int DoctorTypeID { get; set; }
        string Description { get; set; }
    }
}
