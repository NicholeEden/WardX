using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;


namespace WARDxAPI.Model.Interface.PatientMove
{
    ///IMoveFollow represents the Patient Movements Follow Up View for sending Emails
    public interface IMoveFollow:IPatientMovement
    {
       List<ISelectOption> PatientEmailList { get; set; }
        int PatientID { get; set; }
    
        string Body { get; set; }
        string Subject { get; set; }

        string fromEmail { get; set; }

       
        string toEmail { get; set; }
    }
}
