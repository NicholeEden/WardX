using EFCore.Interface;

namespace BusinessLogic.Model
{
    public class MedicalAidPlan : IMedicalAidPlan
    {
        public int MedicalAidPlanID { get; set; }
        public string Name { get; set; }
    }
}
