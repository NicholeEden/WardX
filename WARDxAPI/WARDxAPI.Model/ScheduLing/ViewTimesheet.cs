using EFCore.Interface;
using System;
using System.Collections.Generic;
using WARDx.Data;
using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.StaffScheduling;

namespace WARDxAPI.Model.StaffScheduling
{
    public class ViewTimesheet : IViewTimesheet
    {
        public List<TableContent> CardTableContents { get; set; }
    }
}
