using EFCore.Interface;
using System;
using System.Collections.Generic;

namespace WARDxAPI.Model.Interface
{
    //IMoveReport represents the Patient Movements report View
    public interface IMoveReport : IPatientMovement
    {
       //Populates the Movementd View input elements
        List<ISelectOption> PatientNamesList  { get; set; }
        //Populate the Movement table
        IList<ICardTableContent> CheckOuttableContents { get; set; }
        int PatientID { get; set; }
        DateTime startDate { get; set; }
        DateTime endDate  { get; set; }

        string DateInput { get; set; }


    }
}