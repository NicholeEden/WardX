using EFCore.Domain;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EFCore.Tests
{
    public class VitalSignTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;

        public VitalSignTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Data_Annotation_Valid()
        {
            // Arrange - Create a valid model
            var domainModel = new VitalSign
            {
                BloodGroupID = 601,
                DateRecorded = DateTime.Today,
                Hypoglycemia = "482.15",
                BodyTemperature = "975.16",
                PulseRate = "120",
                BloodPressure = "468.1649",
                Weight = "80",
                BMI = "5142.212"
            };

            // Act
            var isValid = Validator.TryValidateObject(
                            instance: domainModel,
                            validationContext: new ValidationContext(domainModel),
                            validationResults: null,
                            true);

            // Assert - Valid data should not return any errors

            // we expect 'TryValidateObject()' to return true because we provided a valid model
            output.WriteLine($"Please review the requirements for { domainModel.GetType().FullName }");
            Assert.True(isValid);
        }

        [Theory]
        [InlineData(nameof(VitalSign.BloodGroup))]
        public void Data_Annotation_Not_Required(string EFColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new VitalSign();

            // Act
            var domainResult = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(
                            instance: domainModel,
                            validationContext: new ValidationContext(domainModel),
                            validationResults: domainResult,
                            true);

            // Assert - Check if Required attribute is used

            output.WriteLine($"{ EFColumn } property do not require any attributes");
            // we do not expect the validation result to return an error message from the specified property
            Assert.DoesNotContain(domainResult,
                result => result.MemberNames.Contains(EFColumn));
        }

    }
}
