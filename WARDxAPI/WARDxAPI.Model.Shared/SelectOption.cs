using WARDxAPI.Model.Interface;

namespace WARDxAPI.Model.Shared
{
    public class SelectOption : ISelectOption
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Subtext { get; set; }
    }
}
