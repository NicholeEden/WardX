using EFCore.Domain;
using EFCore.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;
namespace EFCore.Tests
{
    public class TreatmentTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;

        public TreatmentTests(ITestOutputHelper output)
        {
            this.output = output;
            
        }
        [Theory]
        [InlineData(nameof(ITreatment.ObservationNotes))]
        public void Data_Annotation_Required(string nullableColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new Treatment();

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
        [InlineData(nameof(ITreatment.ObservationNotes), 1024)]
        public void Data_Annotation_MaxLength(string column, int maxLength)
        {
            // Arrange
            string fluff = "";
            for (int i = 0; i <= maxLength; i++)
            {
                fluff += i.ToString();
            }

            // Create an invalid instance of the class
            var domainModel = new Treatment
            {
                ObservationNotes = fluff
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

    }

}
