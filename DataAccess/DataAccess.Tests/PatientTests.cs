using Autofac;
using Autofac.Extras.Moq;
using DataAccess.Domain;
using DataAccess.Domain.Interface;
using DataAccess.Interface;
using DataAccess.Manager;
using EFCore.Interface;
using Moq;
using System;
using System.Data;
using System.Data.SqlClient;
using Xunit;
using Xunit.Abstractions;

namespace DataAccess.Tests
{
    public class PatientTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper _output;

        public PatientTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Get_Patient_ID()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // the stored procedure expected
                var sql = _StoredProcedureProvider.sp_SelectPatientByID.ToString();
                // the parameter expected and its size
                int id = 101;
                var parameter = new SqlParameter[1];

                // create a mock of the IQueryManager to intercept the real method call
                mock.Mock<IQueryManager>()
                    .Setup(queryManager => queryManager.ExecuteQuery(sql, parameter))
                    .Returns(DummyData.CreateTable());

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<IPatient_DataAccess>()
                    .Setup(method => method.sp_SelectByPatient())
                    .Returns(sql);

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<IPatient_DataAccess>()
                    .Setup(method => method.GetIDParameter(id))
                    .Returns(parameter);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<Patient>();
                var prm = helper.GetIDParameter(id);

                // create an instance of DatabaseAccess to test the method call
                var databaseAccess = mock.Create<DatabaseAccess>();

                // perform the method call
                var result = databaseAccess.Get_Patient(id);

                // test details
                _output.WriteLine($"Please ensure that the methods in" +
                    $" { helper.GetType().FullName } and { databaseAccess.GetType().FullName }" +
                    $" are implemented correctly");
                // assert
                Assert.Equal(sql, helper.sp_SelectByPatient());
                Assert.Equal(parameter.Length, prm.Length);
                Assert.IsType<DataTable>(result);
            }
        }

        [Fact]
        public void Get_Patient_Name()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // the stored procedure expected
                var sql = _StoredProcedureProvider.sp_SelectPatientByName.ToString();
                // the parameter expected and its size
                string name = "sa";
                var parameter = new SqlParameter[1];

                // create a mock of the IQueryManager to intercept the real method call
                mock.Mock<IQueryManager>()
                    .Setup(queryManager => queryManager.ExecuteQuery(sql, parameter))
                    .Returns(DummyData.CreateTable());

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<IPatient_DataAccess>()
                    .Setup(method => method.sp_SelectByName())
                    .Returns(sql);

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<IPatient_DataAccess>()
                    .Setup(method => method.GetNameParameter(name))
                    .Returns(parameter);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<Patient>();
                var prm = helper.GetNameParameter(name);

                // create an instance of DatabaseAccess to test the method call
                var databaseAccess = mock.Create<DatabaseAccess>();

                // perform the method call
                var result = databaseAccess.Get_Patient(name);

                // test details
                _output.WriteLine($"Please ensure that the methods in" +
                    $" { helper.GetType().FullName } and { databaseAccess.GetType().FullName }" +
                    $" are implemented correctly");
                // assert
                Assert.Equal(sql, helper.sp_SelectByName());
                Assert.Equal(parameter.Length, prm.Length);
                Assert.IsType<DataTable>(result);
            }
        }

        [Fact]
        public void GetAll_Patient()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // the stored procedure expected
                var sql = _StoredProcedureProvider.sp_SelectPatient.ToString();

                // create a mock of the IQueryManager to intercept the real method call
                mock.Mock<IQueryManager>()
                    .Setup(queryManager => queryManager.ExecuteQuery(sql))
                    .Returns(DummyData.CreateTable());

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<IPatient_DataAccess>()
                    .Setup(method => method.sp_Select())
                    .Returns(sql);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<Patient>();

                // create an instance of DatabaseAccess to test the method call
                var databaseAccess = mock.Create<DatabaseAccess>();

                // perform the method call
                var result = databaseAccess.GetAll_Patient();

                // test details
                _output.WriteLine($"Please ensure that the methods in" +
                    $" { helper.GetType().FullName } and { databaseAccess.GetType().FullName }" +
                    $" are implemented correctly");
                // assert
                Assert.Equal(sql, helper.sp_Select());
                Assert.IsType<DataTable>(result);
            }
        }

        [Fact]
        public void Add_Patient()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // the stored procedure expected
                var sql = _StoredProcedureProvider.sp_InsertPatient.ToString();
                // the parameter expected and its size
                var input = new Mock<IPatient>();
                var parameter = new SqlParameter[11];

                // create a mock of the IQueryManager to intercept the real method call
                mock.Mock<IQueryManager>()
                    .Setup(queryManager => queryManager.ExecuteNonQuery(sql, parameter))
                    .Returns(1);

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<IPatient_DataAccess>()
                    .Setup(method => method.sp_Insert())
                    .Returns(sql);

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<IPatient_DataAccess>()
                    .Setup(method => method.GetInsertParameters(input.Object))
                    .Returns(parameter);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<Patient>();
                var prm = helper.GetInsertParameters(input.Object);

                // create an instance of DatabaseAccess to test the method call
                var databaseAccess = mock.Create<DatabaseAccess>();

                // perform the method call
                var result = databaseAccess.Add_Patient(input.Object);

                // test details
                _output.WriteLine($"Please ensure that the methods in" +
                    $" { helper.GetType().FullName } and { databaseAccess.GetType().FullName }" +
                    $" are implemented correctly");
                // assert
                Assert.Equal(sql, helper.sp_Insert());
                Assert.Equal(parameter.Length, prm.Length);
                Assert.IsType<int>(result);
            }
        }

        [Fact(Skip = "For local testing only")]
        public void Add_Patient2()
        {

            // provides the dependency injection container for the Data Access Layer
            var container = DataAccessConfig.Container();
            var scope = container.BeginLifetimeScope();
            var query = scope.Resolve<IQueryManager>();
            var sql = _StoredProcedureProvider.sp_InsertPatient.ToString();
            var parameter = new SqlParameter[]
                {
                    new SqlParameter(nameof(IPatient.PatientID), 0),
                    new SqlParameter(nameof(IPatient.FirstName), "John_*"),
                    new SqlParameter(nameof(IPatient.LastName), "Smith_*"),
                    new SqlParameter(nameof(IPatient.Gender), Gender.Male),
                    new SqlParameter(nameof(IPatient.IDNumber), "9007107005123"),
                    new SqlParameter(nameof(IPatient.DOB), Convert.ToDateTime("1990/07/10")),
                    new SqlParameter(nameof(IPatient.EmailAddress), "JSmith363@gmail.com"),
                    new SqlParameter(nameof(IPatient.MobileNumber), "0745017520"),
                    new SqlParameter(nameof(IPatient.AddressLine1), "50 Seaview Street"),
                    new SqlParameter(nameof(IPatient.SuburbID), 102)
                };
            var result = query.ExecuteNonQuery(sql, parameter, nameof(IPatient.PatientID));
            // assert
            Assert.Equal(101, result);
        }
    }
}
