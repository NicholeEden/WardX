using EFCore.Interface;

namespace BusinessLogic.Model
{
    public class Specialization : ISpecialization
    {
        public int SpecializationID { get; set; }
        public string Description { get; set; }
    }
}
