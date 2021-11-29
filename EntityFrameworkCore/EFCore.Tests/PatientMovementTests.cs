using EFCore.Domain;
using EFCore.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace EFCore.Tests
{
    public class PatientMovementTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;

        public PatientMovementTests(ITestOutputHelper output)
        {
            this.output = output;
        }

     

        

        [Fact]
        public void Data_Annotation_Valid()
        {
            // Arrange - Create a valid model
            var domainModel = new PatientMovement
            {
                AdmissionFileID = 101,
                CheckOutTime = DateTime.Now.AddMinutes(15),
                isCheckedOut = true,
                MoveDate = DateTime.Today,
                CheckInTime = null,
                Reason = Reason.Surgery
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
        [InlineData(nameof(PatientMovement.AdmissionFile))]
        public void Data_Annotation_Not_Required(string EFColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new PatientMovement();

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
