using System.Collections.Generic;
using WARDx.Data;

namespace WARDxAPI.Model.Interface.Treatment
{
    public interface ISendRequest
    {
        //Returns a list of Doctor email address
        List<SelectOption> DoctorEmailList { get; set; }
        // stores the selected doctor
        string ToEmail { get; set; }
        int DoctorID { get; set; }
        string CCEmailAddress { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
    }
}
