using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model;
using EFCore.Interface;
using WARDx.Data;

namespace WARDxAPI.Model.Interface.StaffScheduling
{
    /// <summary>
    /// Defines the schedule table
    /// </summary>
    public interface IScheduleTable
    {
        List<TableContent> CardTableContents { get; set; }
    }
}
