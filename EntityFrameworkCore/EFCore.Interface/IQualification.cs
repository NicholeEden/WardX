namespace EFCore.Interface
{
    public interface IQualification
    {
        int QualificationID { get; set; }
        string Title { get; set; }
        string Description { get; set; }
    }
}
