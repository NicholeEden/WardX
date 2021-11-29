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
    //public class PatientVisitorTests
    //{
    //    // provides user defined test output
    //    private readonly ITestOutputHelper output;

    //    public PatientVisitorTests(ITestOutputHelper output)
    //    {
    //        this.output = output;
    //    }

    //    [Theory]
    //    [InlineData(nameof(IPatientVisitor.FirstName))]
    //    [InlineData(nameof(IPatientVisitor.LastName))]
    //    public void Data_Annotation_Required(string nullableColumn)
    //    {
    //        // Arrange - Create a null instance
    //        var domainModel = new PatientVisitor();

    //        // Act
    //        var domainResult = new List<ValidationResult>();
    //        var isValid = Validator.TryValidateObject(
    //                        instance: domainModel,
    //                        validationContext: new ValidationContext(domainModel),
    //                        validationResults: domainResult,
    //                        true);

    //        // Assert - Check if Required attribute is used

    //        // we expect 'TryValidateObject()' to return false because we provided an invalid model
    //        Assert.False(isValid);

    //        output.WriteLine($"Please ensure that { nullableColumn } has the [Required] attribute");
    //        // we expect the validation result to return an error message from the specified property
    //        Assert.Contains(domainResult, result => result.MemberNames.Contains(nullableColumn));
    //    }

    //    [Theory]
    //    [InlineData(nameof(IPatientVisitor.FirstName), 1024)]
    //    [InlineData(nameof(IPatientVisitor.LastName), 1024)]
    //    public void Data_Annotation_MaxLength(string column, int maxLength)
    //    {
    //        // Arrange
    //        string fluff = "";
    //        for (int i = 0; i <= maxLength; i++)
    //        {
    //            fluff += i.ToString();
    //        }

    //        // Create an invalid instance of the class
    //        var domainModel = new PatientVisitor
    //        {
    //            FirstName = fluff,
    //            LastName = fluff
    //        };

    //        // Act
    //        var domainResult = new List<ValidationResult>();
    //        var isValid = Validator.TryValidateObject(
    //                        instance: domainModel,
    //                        validationContext: new ValidationContext(domainModel),
    //                        validationResults: domainResult,
    //                        true);

    //        // Assert - Check if MaxLength attribute is used

    //        // we expect 'TryValidateObject()' to return false because we provided an invalid model
    //        Assert.False(isValid);

    //        output.WriteLine($"Please ensure that the [MaxLength] attribute of { column } has the value of { maxLength }");
    //        // we expect the validation result to return an error message from the specified property
    //        Assert.Contains(domainResult, result => result.MemberNames.Contains(column));
    //        Assert.Contains(domainResult, result => result.ErrorMessage.Contains(maxLength.ToString()));
    //    }

    //    [Fact]
    //    public void Data_Annotation_Valid()
    //    {
    //        // Arrange - Create a valid model
    //        var domainModel = new PatientVisitor
    //        {
    //            FirstName = "Kleon",
    //            LastName = "Alkibiades",
    //            AdmissionFileID = 101,
    //            TimeIn = DateTime.Now,
    //            TimeOut = null,
    //            isCheckedIn = true,
    //            VisitDate = DateTime.Today
    //        };

    //        // Act
    //        var isValid = Validator.TryValidateObject(
    //                        instance: domainModel,
    //                        validationContext: new ValidationContext(domainModel),
    //                        validationResults: null,
    //                        true);

    //        // Assert - Valid data should not return any errors

    //        // we expect 'TryValidateObject()' to return true because we provided a valid model
    //        output.WriteLine($"Please review the requirements for { domainModel.GetType().FullName }");
    //        Assert.True(isValid);
    //    }

    //    [Theory]
    //    [InlineData(nameof(PatientVisitor.AdmissionFile))]
    //    public void Data_Annotation_Not_Required(string EFColumn)
    //    {
    //        // Arrange - Create a null instance
    //        var domainModel = new PatientVisitor();

    //        // Act
    //        var domainResult = new List<ValidationResult>();
    //        var isValid = Validator.TryValidateObject(
    //                        instance: domainModel,
    //                        validationContext: new ValidationContext(domainModel),
    //                        validationResults: domainResult,
    //                        true);

    //        // Assert - Check if Required attribute is used

    //        output.WriteLine($"{ EFColumn } property do not require any attributes");
    //        // we do not expect the validation result to return an error message from the specified property
    //        Assert.DoesNotContain(domainResult,
    //            result => result.MemberNames.Contains(EFColumn));
    //    }
    //}
}
