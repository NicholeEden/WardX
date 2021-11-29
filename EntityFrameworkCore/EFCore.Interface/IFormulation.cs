namespace EFCore.Interface
{
    public interface IFormulation
    {
        int FormulationID { get; set; }
        string Abbreviation { get; set; }
        string Description { get; set; }
    }
}
