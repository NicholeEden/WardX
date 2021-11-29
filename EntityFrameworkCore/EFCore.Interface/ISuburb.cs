namespace EFCore.Interface
{
    /// <summary>
    /// Defines the database fields present in the Suburb table
    /// </summary>
    public interface ISuburb
    {
        int SuburbID { get; set; }
        string SuburbName { get; set; }
        string PostalCode { get; set; }
        int CityID { get; set; }
    }
}
