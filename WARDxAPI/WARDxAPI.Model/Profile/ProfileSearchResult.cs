using EFCore.Interface;
using WARDxAPI.Model.Interface.Profile;

namespace WARDxAPI.Model.Profile
{
    public class ProfileSearchResult : IProfileSearchResult
    {
        public IPatient Patient { get; set; }
        public INextOfKin NextOfKin { get; set; }
        public IMedicalAid MedicalAid { get; set; }
        public ISuburb Suburb { get; set; }
        public bool hasReferral { get; set; }
    }
}
