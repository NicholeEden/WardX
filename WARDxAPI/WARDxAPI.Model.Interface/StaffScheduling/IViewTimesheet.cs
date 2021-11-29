using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model;
using EFCore.Interface;
using WARDx.Data;

namespace WARDxAPI.Model.Interface.StaffScheduling
{
    public interface IViewTimesheet
    {
        List<TableContent> CardTableContents { get; set; }

    }
}
