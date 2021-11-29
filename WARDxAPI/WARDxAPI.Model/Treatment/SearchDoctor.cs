using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Treatment
{
    public class SearchDoctor : ISearchDoctor
    {
        public string SearchWord { get ; set ; }
        public List<IDoctor> SearchResults { get ; set ; }
    }
}
