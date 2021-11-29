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
    public class ReferralTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;

        public ReferralTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(nameof(IReferral.Reason))]
        public void Data_Annotation_Required(string nullableColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new Referral();

            // Act
            var domainResult = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(
                            instance: domainModel,
                            validationContext: new ValidationContext(domainModel),
                            validationResults: domainResult,
                            true);

            // Assert - Check if Required attribute is used

            // we expect 'TryValidateObject()' to return false because we provided an invalid model
            Assert.False(isValid);

            output.WriteLine($"Please ensure that { nullableColumn } has the [Required] attribute");
            // we expect the validation result to return an error message from the specified property
            Assert.Contains(domainResult, result => result.MemberNames.Contains(nullableColumn));
        }

        [Theory]
        [InlineData(nameof(IReferral.Reason), 1024)]
        public void Data_Annotation_MaxLength(string column, int maxLength)
        {
            // Arrange
            string fluff = "";
            for (int i = 0; i <= maxLength; i++)
            {
                fluff += i.ToString();
            }

            // Create an invalid instance of the class
            var domainModel = new Referral
            {
                Reason = fluff
            };

            // Act
            var domainResult = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(
                            instance: domainModel,
                            validationContext: new ValidationContext(domainModel),
                            validationResults: domainResult,
                            true);

            // Assert - Check if MaxLength attribute is used

            // we expect 'TryValidateObject()' to return false because we provided an invalid model
            Assert.False(isValid);

            output.WriteLine($"Please ensure that the [MaxLength] attribute of { column } has the value of { maxLength }");
            // we expect the validation result to return an error message from the specified property
            Assert.Contains(domainResult, result => result.MemberNames.Contains(column));
            Assert.Contains(domainResult, result => result.ErrorMessage.Contains(maxLength.ToString()));
        }

        [Fact]
        public void Data_Annotation_Valid()
        {
            // Arrange - Create a valid model
            var domainModel = new Referral
            {
                AdmissionDate = DateTime.Today,
                DiagnosisID = 101,
                PatientID = 601,
                Reason = "Recommend removing a part or an entire lymph node for microscopic examination to determine lymphoma and types of cells involved.",
                ReferringDoctorID = 101,
                SpecialistID = 102
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
        [InlineData(nameof(Referral.Diagnosis))]
        [InlineData(nameof(Referral.Patient))]
        [InlineData(nameof(Referral.Doctor))]
        public void Data_Annotation_Not_Required(string EFColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new Referral();

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
