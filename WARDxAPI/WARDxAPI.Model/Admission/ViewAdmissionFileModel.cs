using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Admission;

namespace WARDxAPI.Model.Admission
{
    public class ViewAdmissionFileModel : IViewAdmissionFileModel
    {
        public IList<ICardTableContent> CardTableContents { get; set; }
    }
}
