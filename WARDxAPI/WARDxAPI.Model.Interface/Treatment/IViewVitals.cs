using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Interface;
using WARDx.Data;

namespace WARDxAPI.Model.Interface.Treatment
{
    public interface IViewVitals
    {
        IVitalSign VitalSign { get; set; }
        List<TableContent> VitalsTableContents { get; set; }
    }
}
