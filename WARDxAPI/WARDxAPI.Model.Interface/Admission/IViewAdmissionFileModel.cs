using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface.Admission
{
    public interface IViewAdmissionFileModel
    {
        IList<ICardTableContent> CardTableContents { get; set; }
    }
}
