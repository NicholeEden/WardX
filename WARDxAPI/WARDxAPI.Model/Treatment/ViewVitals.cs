using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using WARDx.Data;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Treatment
{
    public class ViewVitals : IViewVitals
    {
        public IVitalSign VitalSign{get ; set; }
        public List<TableContent> VitalsTableContents { get ; set ; }
    }
}
