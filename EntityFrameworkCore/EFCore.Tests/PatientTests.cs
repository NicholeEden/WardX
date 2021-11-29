using EFCore.Domain;
using EFCore.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EFCore.Tests
{
    public class PatientTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;
        // provides an instance of EFCore DatabaseContext
        private readonly TestDatabaseContext context;

        public PatientTests(ITestOutputHelper output)
        {
            this.output = output;

            // configure EFCore DatabaseContext to be created in the memory
            var options = new DbContextOptionsBuilder<TestDatabaseContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            // apply the configurations to EFCore DatabaseContext
            context = new TestDatabaseContext(options);
            // creates the database if it does not exist
            context.Database.EnsureCreated();
        }

        [Theory]
        [InlineData(nameof(IPatient.AddressLine1))]
        [InlineData(nameof(IPatient.EmailAddress))]
        [InlineData(nameof(IPatient.FirstName))]
        [InlineData(nameof(IPatient.IDNumber))]
        [InlineData(nameof(IPatient.LastName))]
        [InlineData(nameof(IPatient.MobileNumber))]
        public void Data_Annotation_Required(string nullableColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new Patient();

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
        [InlineData(nameof(IPatient.AddressLine1), 1024)]
        [InlineData(nameof(IPatient.AddressLine2), 1024)]
        [InlineData(nameof(IPatient.EmailAddress), 1024)]
        [InlineData(nameof(IPatient.FirstName), 128)]
        [InlineData(nameof(IPatient.IDNumber), 13)]
        [InlineData(nameof(IPatient.LastName), 128)]
        [InlineData(nameof(IPatient.MobileNumber), 10)]
        public void Data_Annotation_MaxLength(string column, int maxLength)
        {
            // Arrange
            string fluff = "";
            for (int i = 0; i <= maxLength; i++)
            {
                fluff += i.ToString();
            }

            // Create an invalid instance of the class
            var domainModel = new Patient
            {
                AddressLine1 = fluff,
                AddressLine2 = fluff,
                EmailAddress = fluff,
                FirstName = fluff,
                IDNumber = fluff,
                LastName = fluff,
                MobileNumber = fluff,
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
            var domainModel = new Patient
            {
                PatientID = 101,
                FirstName = "John",
                LastName = "Smith",
                Gender = Gender.Male,
                IDNumber = "9007107005123",
                DOB = Convert.ToDateTime("1990/07/10"),
                EmailAddress = "JSmith363@gmail.com",
                MobileNumber = "0745017520",
                AddressLine1 = "50 Seaview Street",
                SuburbID = 102
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
        [InlineData(nameof(Patient.AdmissionFiles))]
        [InlineData(nameof(Patient.DoctorInspection))]
        [InlineData(nameof(Patient.MedicalHistory))]
        [InlineData(nameof(Patient.NurseInspection))]
        [InlineData(nameof(Patient.Suburb))]
        public void Data_Annotation_Not_Required(string EFColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new Patient();

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
