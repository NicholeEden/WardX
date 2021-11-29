using System.Collections.Generic;
using WARDx.Data;
using WARDxAPI.Model.Interface.StaffScheduling;

namespace WARDxAPI.Model.StaffScheduling
{
    public class ScheduleTable : IScheduleTable
    {
        public List<TableContent> CardTableContents { get; set; }
    }
}
