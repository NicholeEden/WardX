using EFCore.Domain;
using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EFCore.Tests
{
    public class MedicalAidTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;

        public MedicalAidTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(nameof(IMedicalAid.DependantCode))]
        [InlineData(nameof(IMedicalAid.MemberNumber))]
        [InlineData(nameof(IMedicalAid.PrincipalFirstName))]
        [InlineData(nameof(IMedicalAid.PrincipalLastName))]
        public void Data_Annotation_Required(string nullableColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new MedicalAid();

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
        [InlineData(nameof(IMedicalAid.DependantCode), 128)]
        [InlineData(nameof(IMedicalAid.MemberNumber), 128)]
        [InlineData(nameof(IMedicalAid.PrincipalFirstName), 1024)]
        [InlineData(nameof(IMedicalAid.PrincipalLastName), 1024)]
        public void Data_Annotation_MaxLength(string column, int maxLength)
        {
            // Arrange
            string fluff = "";
            for (int i = 0; i <= maxLength; i++)
            {
                fluff += i.ToString();
            }

            // Create an invalid instance of the class
            var domainModel = new MedicalAid
            {
                DependantCode = fluff,
                MemberNumber = fluff,
                PrincipalFirstName = fluff,
                PrincipalLastName = fluff
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
            var domainModel = new MedicalAid
            {
                MedicalAidPlanID = MedicalAidPlans.Executive,
                MedicalAidSchemeID = MedicalAidSchemes.Discovery,
                DependantCode = "123456",
                MemberNumber = "645321",
                PatientID = 601,
                PrincipalFirstName = "Kleon",
                PrincipalLastName = "Alkibiades"
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
        [InlineData(nameof(MedicalAid.MedicalAidPlan))]
        [InlineData(nameof(MedicalAid.MedicalAidScheme))]
        [InlineData(nameof(MedicalAid.Patient))]
        public void Data_Annotation_Not_Required(string EFColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new MedicalAid();

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
