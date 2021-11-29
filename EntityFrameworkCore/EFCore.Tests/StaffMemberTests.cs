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
    public class StaffMemberTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;
        // provides an instance of EFCore DatabaseContext
        private readonly TestDatabaseContext context;

        public StaffMemberTests(ITestOutputHelper output)
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
        [InlineData(nameof(IStaffMember.AddressLine1))]
        [InlineData(nameof(IStaffMember.EmailAddress))]
        [InlineData(nameof(IStaffMember.EmployeeID))]
        [InlineData(nameof(IStaffMember.FirstName))]
        [InlineData(nameof(IStaffMember.LastName))]
        [InlineData(nameof(IStaffMember.MobileNumber))]
        [InlineData(nameof(IStaffMember.WorkNumber))]
        public void Data_Annotation_Required(string nullableColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new StaffMember();

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
        [InlineData(nameof(IStaffMember.AddressLine1), 1024)]
        [InlineData(nameof(IStaffMember.EmailAddress), 1024)]
        [InlineData(nameof(IStaffMember.EmployeeID), 13)]
        [InlineData(nameof(IStaffMember.FirstName), 1024)]
        [InlineData(nameof(IStaffMember.LastName), 1024)]
        [InlineData(nameof(IStaffMember.MobileNumber), 10)]
        [InlineData(nameof(IStaffMember.WorkNumber), 10)]
        public void Data_Annotation_MaxLength(string column, int maxLength)
        {
            // Arrange
            string fluff = "";
            for (int i = 0; i <= maxLength; i++)
            {
                fluff += i.ToString();
            }

            // Create an invalid instance of the class
            var domainModel = new StaffMember
            {
                AddressLine1 = fluff,
                EmailAddress = fluff,
                EmployeeID = fluff,
                FirstName = fluff,
                LastName =fluff,
                MobileNumber = fluff,
                WorkNumber = fluff
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
            var domainModel = context.StaffMember.ToList();

            foreach (var model in domainModel)
            {
                List<ValidationResult> results = new List<ValidationResult>();
                // Act
                var isValid = Validator.TryValidateObject(
                                instance: model,
                                validationContext: new ValidationContext(model),
                                validationResults: results,
                                true);

                // Assert - Valid data should not return any errors

                // we expect 'TryValidateObject()' to return true because we provided a valid model
                foreach (var item in results)
                {
                    output.WriteLine(item.ErrorMessage);
                }
                output.WriteLine($"Please review the requirements for { model.GetType().FullName }");
                Assert.True(isValid);
            }
        }

        [Theory]
        [InlineData(nameof(StaffMember.Doctor))]
        [InlineData(nameof(StaffMember.Nurse))]
        [InlineData(nameof(StaffMember.Receptionist))]
        [InlineData(nameof(StaffMember.Suburb))]
        [InlineData(nameof(StaffMember.User))]
        public void Data_Annotation_Not_Required(string EFColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new StaffMember();

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
