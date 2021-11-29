using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace WARDxAPI.Model.Interface.Treatment
{
    public interface ISearchDoctor
    {

        string SearchWord { get; set; }
        List<IDoctor> SearchResults { get; set; }
    }
}
