﻿using Autofac.Extras.Moq;
using DataAccess.Domain;
using DataAccess.Domain.Interface;
using DataAccess.Interface;
using EFCore.Interface;
using System.Data;
using Xunit;
using Xunit.Abstractions;

namespace DataAccess.Tests
{
    public class MedicalConditionTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper _output;

        public MedicalConditionTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void GetAll_MedicalCondition()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // the stored procedure expected
                var sql = _StoredProcedureProvider.sp_SelectMedicalCondition.ToString();

                // create a mock of the IQueryManager to intercept the real method call
                mock.Mock<IQueryManager>()
                    .Setup(queryManager => queryManager.ExecuteQuery(sql))
                    .Returns(DummyData.CreateTable());

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<IMedicalCondition_DataAccess>()
                    .Setup(method => method.sp_Select())
                    .Returns(sql);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<MedicalCondition>();

                // create an instance of DatabaseAccess to test the method call
                var databaseAccess = mock.Create<DatabaseAccess>();

                // perform the method call
                var result = databaseAccess.GetAll_MedicalCondition();

                // test details
                _output.WriteLine($"Please ensure that the methods in" +
                    $" { helper.GetType().FullName } and { databaseAccess.GetType().FullName }" +
                    $" are implemented correctly");
                // assert
                Assert.Equal(sql, helper.sp_Select());
                Assert.IsType<DataTable>(result);
            }
        }
    }
}
