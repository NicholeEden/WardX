using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Interface;
using WARDx.Data;

namespace WARDxAPI.Model.Interface.StaffScheduling
{
    public interface IGenerateTimesheet :  IClocking, IMonth
    {
        Dictionary<string, string> NurseOptions { get; set; }
        IList<ICardTableContent> CardTableContents { get; set; }
        Dictionary<string, string> MonthOptions { get; set; }
    }
}
