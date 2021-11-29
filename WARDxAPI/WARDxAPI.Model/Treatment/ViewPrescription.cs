using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Treatment
{
    public class ViewPrescription : IViewPrescription
    {
        
        public IAlertModel Alert { get ; set ; }
        public IList<ICardTableContent> PrescriptionTableContents { get ; set ; }
    }
}
