using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BusinessLogic.Tests
{
    public class AdmissionFileDataProvider_Test
    {
        [Fact(Skip = "dev test only")]
        public void GetAll_AdmissionFile()
        {
            
            Logic _logic = new Logic(new DataProvider());

            var AdmissionFile = _logic.GetAdmissionFiles();

            Assert.NotNull(AdmissionFile);
        }
    }
}
