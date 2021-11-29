using EFCore.Interface;

namespace BusinessLogic.Model
{
    public class MedicalAidScheme : IMedicalAidScheme
    {
        public int MedicalAidSchemeID { get; set; }
        public string Name { get; set; }
    }
}
