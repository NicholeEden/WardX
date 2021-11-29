using EFCore.Interface;

namespace BusinessLogic.Model
{
    public class Suburb : ISuburb
    {
        public int SuburbID { get; set; }
        public string SuburbName { get; set; }
        public string PostalCode { get; set; }
        public int CityID { get; set; }
    }
}
