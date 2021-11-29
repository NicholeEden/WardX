using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class BloodGroup : IBloodGroup
    {
        public int BloodGroupID { get; set; }
        public string BloodGroupName { get; set; }
        public string Description { get; set; }
    }
}
