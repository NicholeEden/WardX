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
    public class BloodGroupTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;
        // provides an instance of EFCore DatabaseContext
        private readonly TestDatabaseContext context;

        public BloodGroupTests(ITestOutputHelper output)
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

        [Fact]
        public void BloodGroup_Has_Data_Seeded()
        {
            // Arrange [declare expected values]
            int expected = 8;

            // Act [calculate actual values]
            int actual = context.BloodGroup.Count();

            // Assert [compare actual value with expected value]
            output.WriteLine($"There should be at least { expected } row(s) of data in the { nameof(context.BloodGroup) } table");
            Assert.True(actual >= expected);
        }

        [Theory]
        [InlineData(nameof(IBloodGroup.BloodGroupName))]
        [InlineData(nameof(IBloodGroup.Description))]
        public void Data_Annotation_Required(string nullableColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new BloodGroup();

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
        [InlineData(nameof(IBloodGroup.BloodGroupName), 1024)]
        [InlineData(nameof(IBloodGroup.Description), 1024)]
        public void Data_Annotation_MaxLength(string column, int maxLength)
        {
            // Arrange
            string fluff = "";
            for (int i = 0; i <= maxLength; i++)
            {
                fluff += i.ToString();
            }

            // Create an invalid instance of the class
            var domainModel = new BloodGroup
            {
                BloodGroupName = fluff,
                Description = fluff
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
            var domainModel = context.BloodGroup.ToList();

            foreach (var model in domainModel)
            {
                // Act
                var isValid = Validator.TryValidateObject(
                                instance: model,
                                validationContext: new ValidationContext(model),
                                validationResults: null,
                                true);

                // Assert - Valid data should not return any errors

                // we expect 'TryValidateObject()' to return true because we provided a valid model
                output.WriteLine($"Please review the requirements for { model.GetType().FullName }");
                Assert.True(isValid);
            }
        }
    }
}
