using EFCore.Interface;
using System;
using System.Collections.Generic;

namespace WARDxAPI.Model.Interface
{
    //IMoveReport represents the Patient Movements report View
    public interface IMoveNotification : IPatientMovement
  
 {
        
        DateTime latetime { get; set; }
        

        


    }
}