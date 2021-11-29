using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface.Treatment
{
    public interface IViewPrescription
    {
        IList<ICardTableContent> PrescriptionTableContents { get; set; }
        IAlertModel Alert { get; set; }
    }
}
