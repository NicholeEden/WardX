using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EFCore.Tests
{
    public class DoctorTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;
        // provides an instance of EFCore DatabaseContext
        private readonly TestDatabaseContext context;

        public DoctorTests(ITestOutputHelper output)
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
        public void Doctor_Has_Data_Seeded()
        {
            // Arrange [declare expected values]
            int expected = 3;

            // Act [calculate actual values]
            int actual = context.Doctor.Count();

            // Assert [compare actual value with expected value]
            output.WriteLine($"There should be at least { expected } row(s) of data in the { nameof(context.Doctor) } table");
            Assert.True(actual >= expected);
        }

        [Theory]
        [InlineData(nameof(Doctor.AdmissionFiles))]
        [InlineData(nameof(Doctor.DoctorInspection))]
        [InlineData(nameof(Doctor.DoctorType))]
        [InlineData(nameof(Doctor.IsStaffMember))]
        [InlineData(nameof(Doctor.Prescriptions))]
        [InlineData(nameof(Doctor.Specialization))]
        public void Data_Annotation_Not_Required(string EFColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new Doctor();

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
