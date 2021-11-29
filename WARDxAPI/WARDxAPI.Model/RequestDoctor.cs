using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model
{
    public class RequestDoctor : IRequestDoctorModel
    {
        public RequestDoctor(ISearchDoctor searchDoctor, ISendRequest sendRequest, IAlertModel alert)
        {
            SearchDoctor = searchDoctor;
            SendRequest = sendRequest;
            alertModel = alert;
        }
        public ISearchDoctor SearchDoctor {get;set;}
        public ISendRequest SendRequest {get;set;}
        public IAlertModel alertModel { get ; set ; }
    }
}
