using EFCore.Interface;

namespace BusinessLogic.Model
{
    public class MedicalCondition : IMedicalCondition
    {
        public int MedicalConditionID { get; set; }
        public string Name { get; set; }
        public string Symptom { get; set; }
    }
}
