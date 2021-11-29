using EFCore.Interface;
using System.Collections.Generic;

namespace WARDxAPI.Model.Interface
{
    //IMoveCheckOut represents the checkout
    public interface IMoveCheckIn:IPatientMovement
    {
       //Populates the CheckOut View input elements
        List<ISelectOption> PatientNamesList  { get; set; }
        //Populate the CheckOutView table
        IList<ICardTableContent> CheckOuttableContents { get; set; }
        int PatientID { get; set; }

        int CheckedInCounter { get; set; }
        int CheckedOutCounter{ get; set; }
        

    }
}