using EFCore.Interface;
using System.Collections.Generic;
using WARDx.Data;

namespace WARDxAPI.Model.Interface.Treatment
{
    public interface IRecordVitals : IVitalSign
    {
        List<SelectOption> BloodGroupList { get; set; }
    }

}
