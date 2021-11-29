namespace EFCore.Interface
{
    public interface INurse
    {
        int NurseID { get; set; }
       
        bool isWardManager { get; set; }
        bool isHeadNurse { get; set; }
        int SpecializationID { get; set; }
        int NurseTypeID { get; set; }
    }
}
