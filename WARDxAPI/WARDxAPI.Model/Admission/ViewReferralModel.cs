using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Admission;
using WARDxAPI.Model.Shared;

namespace WARDxAPI.Model.Admission
{
    public class ViewReferralModel : IViewReferralModel
    {
        public IList<ICardTableContent> CardTableContents { get; set; }

    }
}
