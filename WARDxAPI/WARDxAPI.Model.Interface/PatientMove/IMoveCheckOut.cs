using EFCore.Interface;
using System.Collections.Generic;

namespace WARDxAPI.Model.Interface
{
    //IMoveCheckOut represents the checkout
    public interface IMoveCheckOut:IPatientMovement
    {
       //Populates the CheckOut View input elements
        List<ISelectOption> PatientNamesList  { get; set; }
        //Populate the CheckOutView table
        IList<ICardTableContent> CheckOuttableContents { get; set; }

        int PatientID { get; set; }

        int SurgeryCounter { get; set; }
        int SmokeBreakCounter { get; set; }
        int XRaysCounter { get; set; }
        int BloodTestsCounter { get; set; }

    }
}