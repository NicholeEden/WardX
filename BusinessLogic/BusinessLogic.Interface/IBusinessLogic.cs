namespace BusinessLogic.Interface
{
    /// <summary>
    /// Defines the logical process for retrieving and sending data
    /// </summary>
    public interface IBusinessLogic :
        IStaffProcessor,
        IDropdownProcessor,
        IPatientProcessor,
        IAdmissionProcessor,
        ISchedulingProcessor,
        IMoveProcessor,
        IEmailSender,
        ITreatmentProcessor
    {

    }
}
