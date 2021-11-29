using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;

namespace WARDxAPI.Model
{
    public class RefferalSearch : IRefferalSearch
    {
        public IDictionary PatientList { get; set; }
        public IList<ICardTableContent> tableContents { get; set; }
    }
}
