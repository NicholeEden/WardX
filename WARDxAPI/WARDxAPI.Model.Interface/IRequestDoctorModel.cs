using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Interface
{
    public interface IRequestDoctorModel
    {
        //Defines the view the search for doctor in Patient Treatment
        ISearchDoctor SearchDoctor { get; set; }

        //Defines the view to send a request
        ISendRequest SendRequest { get; set; }

        IAlertModel alertModel { get; set; }
    }
}
