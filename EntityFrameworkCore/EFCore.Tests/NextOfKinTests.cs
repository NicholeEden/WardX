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
    public class NextOfKinTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;

        public NextOfKinTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(nameof(INextOfKin.AddressLine1))]
        [InlineData(nameof(INextOfKin.EmailAddress))]
        [InlineData(nameof(INextOfKin.FirstName))]
        [InlineData(nameof(INextOfKin.LastName))]
        [InlineData(nameof(INextOfKin.MobileNumber))]
        [InlineData(nameof(INextOfKin.Relationship))]
        public void Data_Annotation_Required(string nullableColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new NextOfKin();

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
        [InlineData(nameof(INextOfKin.AddressLine1), 1024)]
        [InlineData(nameof(INextOfKin.EmailAddress), 1024)]
        [InlineData(nameof(INextOfKin.FirstName), 1024)]
        [InlineData(nameof(INextOfKin.LastName), 1024)]
        [InlineData(nameof(INextOfKin.MobileNumber), 10)]
        [InlineData(nameof(INextOfKin.Relationship), 128)]
        public void Data_Annotation_MaxLength(string column, int maxLength)
        {
            // Arrange
            string fluff = "";
            for (int i = 0; i <= maxLength; i++)
            {
                fluff += i.ToString();
            }

            // Create an invalid instance of the class
            var domainModel = new NextOfKin
            {
                AddressLine1 = fluff,
                EmailAddress = fluff,
                FirstName = fluff,
                LastName = fluff,
                MobileNumber = fluff,
                Relationship = fluff
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
            var domainModel = new NextOfKin
            {
                PatientID = 601,
                FirstName = "Kleon",
                LastName = "Alkibiades",
                Relationship = "Family member",
                EmailAddress = "webmail@internet.co.za",
                MobileNumber = "0123456789",
                AddressLine1 = "3 Short Road",
                SuburbID = 101
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
        [InlineData(nameof(NextOfKin.Patient))]
        [InlineData(nameof(NextOfKin.Suburb))]
        public void Data_Annotation_Not_Required(string EFColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new EmergencyContact();

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
