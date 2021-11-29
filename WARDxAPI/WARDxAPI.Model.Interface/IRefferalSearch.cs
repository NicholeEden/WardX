using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface
{
    public interface IRefferalSearch
    {
        IDictionary PatientList { get; set; }

        IList<ICardTableContent> tableContents { get; set; }
    }
}
