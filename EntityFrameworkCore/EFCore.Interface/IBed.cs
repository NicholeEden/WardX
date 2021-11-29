namespace EFCore.Interface
{
    public interface IBed
    {
        int BedID { get; set; }
        string Description { get; set; }
        bool isAvailable { get; set; }
    }
}
