using EFCore.Domain;
using EFCore.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EFCore.Tests
{
    public class NurseTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper output;

        public NurseTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(nameof(Nurse.isStaffMember))]
        [InlineData(nameof(Nurse.NurseBar))]
        [InlineData(nameof(Nurse.NurseInspection))]
        [InlineData(nameof(Nurse.NurseType))]
        [InlineData(nameof(Nurse.Specialization))]
        public void Data_Annotation_Not_Required(string EFColumn)
        {
            // Arrange - Create a null instance
            var domainModel = new Nurse();

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
