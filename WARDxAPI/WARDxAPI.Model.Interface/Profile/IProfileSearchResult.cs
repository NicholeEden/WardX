using EFCore.Interface;

namespace WARDxAPI.Model.Interface.Profile
{
    /// <summary>
    /// Defines the properties used in the Profile/Search/resultPartial view
    /// </summary>
    public interface IProfileSearchResult
    {
        IPatient Patient { get; set; }
        INextOfKin NextOfKin { get; set; }
        IMedicalAid MedicalAid { get; set; }
        ISuburb Suburb { get; set; }
        bool hasReferral { get; set; }
    }
}
