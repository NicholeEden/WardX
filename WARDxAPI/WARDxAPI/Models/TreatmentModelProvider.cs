using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WARDxAPI.Interface;
using WARDxAPI.Model.Interface;


namespace WARDxAPI.Models
{
    public class TreatmentModelProvider: ITreatmentModelProvider
    {
        public TreatmentModelProvider(IAddPrescription prescriptionModel,
            IDispenseModel dispenseModel,
            IRequestDoctorModel requestDoctorModel,
            ITreatmentModel treatmentModel,
            IVitalsModel vitalsModel)
        {
            PrescriptionModel = prescriptionModel;
            DispenseModel = dispenseModel;
            RequestModel = requestDoctorModel;
            TreatmentModel = treatmentModel;
            VitalsModel = vitalsModel;
        }

        public IAddPrescription PrescriptionModel { get; set; }

        public IDispenseModel DispenseModel { get; set; }

        public IRequestDoctorModel RequestModel { get; set; }

        public ITreatmentModel TreatmentModel { get; set; }

        public IVitalsModel VitalsModel { get; set; }
    }
}
