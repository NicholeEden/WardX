using WARDxAPI.Model.Interface;

namespace WARDxAPI.Interface
{
    public interface ITreatmentModelProvider
    {
        //Defines the Treatment process for Patient Treatment
        ITreatmentModel TreatmentModel { get; }

        //Defines the Vitals process for Patient Treatment
        IVitalsModel VitalsModel { get; }

        //Defines the Dispense process for Patient Treatment
        IDispenseModel DispenseModel { get; }

        //Defines the Request Doctor process for Patient Treatment
        IRequestDoctorModel RequestModel { get; }

        //Defines the Prescription process for Patient Treatment
        IAddPrescription PrescriptionModel { get; }
    }
}
