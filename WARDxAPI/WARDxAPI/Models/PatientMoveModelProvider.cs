using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WARDxAPI.Interface;
using WARDxAPI.Model.Interface;

namespace WARDxAPI.Models
{
    public class PatientMoveModelProvider : IPatientMoveModelProvider
    {
        public PatientMoveModelProvider(ICheckOutModel CheckOutModel,ICheckInModel CheckInModel, IMovementsModel MovementsModel, IFollowUpModel FollowUpModel, INotificationsModel NotificationsModel)
            
        {
            checkOutModel = CheckOutModel;
            checkInModel = CheckInModel;
            movementsModel = MovementsModel;
            followUpModel = FollowUpModel;
            notificationsModel = NotificationsModel;
        }

        public ICheckOutModel checkOutModel { get; }

        public ICheckInModel checkInModel { get; }

        public IMovementsModel movementsModel { get; }

        public IFollowUpModel followUpModel { get; }

        public INotificationsModel notificationsModel { get; }
    }
}
