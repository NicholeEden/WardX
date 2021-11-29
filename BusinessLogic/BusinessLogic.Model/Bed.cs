using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    public class Bed : IBed
    {
        public int BedID { get; set; }
        public string Description { get; set; }
        public bool isAvailable { get; set; }
    }
}
