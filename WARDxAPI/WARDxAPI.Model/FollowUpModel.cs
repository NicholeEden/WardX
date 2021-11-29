using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.PatientMove;

namespace WARDxAPI.Model
{
    public class FollowUpModel : IFollowUpModel
    {
        public FollowUpModel(IMoveFollow _moveFollow, IAlertModel _alertModel)
        {
            moveFollow = _moveFollow;
            alertModel = _alertModel;
        }
        public IMoveFollow moveFollow { get; set; }
        public IAlertModel alertModel { get; set; }
    }
}
