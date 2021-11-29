namespace EFCore.Interface
{
    public interface IEpaulette
    {
        int EpauletteID { get; set; }
        string Colour { get; set; }
        string Description { get; set; }
    }
}
