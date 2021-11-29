using Autofac.Extras.Moq;
using DataAccess.Domain;
using DataAccess.Domain.Interface;
using DataAccess.Interface;
using EFCore.Interface;
using Moq;
using System.Data;
using System.Data.SqlClient;
using Xunit;
using Xunit.Abstractions;

namespace DataAccess.Tests
{
    public class NextofKinTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper _output;

        public NextofKinTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Get_NextofKin()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // the stored procedure expected
                var sql = _StoredProcedureProvider.sp_SelectNextOfKin.ToString();
                // the parameter expected and its size
                int id = 101;
                var parameter = new SqlParameter[1];

                // create a mock of the IQueryManager to intercept the real method call
                mock.Mock<IQueryManager>()
                    .Setup(queryManager => queryManager.ExecuteQuery(sql, parameter))
                    .Returns(DummyData.CreateTable());

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<INextOfKin_DataAccess>()
                    .Setup(method => method.sp_SelectByPatient())
                    .Returns(sql);

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<INextOfKin_DataAccess>()
                    .Setup(method => method.GetPatientIDParameter(id))
                    .Returns(parameter);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<NextOfKin>();
                var prm = helper.GetPatientIDParameter(id);

                // create an instance of DatabaseAccess to test the method call
                var databaseAccess = mock.Create<DatabaseAccess>();

                // perform the method call
                var result = databaseAccess.Get_NextOfKin(id);

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
        public void Add_NextOfKin()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // the stored procedure expected
                var sql = _StoredProcedureProvider.sp_InsertNextOfKin.ToString();
                // the parameter expected and its size
                var input = new Mock<INextOfKin>();
                var parameter = new SqlParameter[10];

                // create a mock of the IQueryManager to intercept the real method call
                mock.Mock<IQueryManager>()
                    .Setup(queryManager => queryManager.ExecuteNonQuery(sql, parameter))
                    .Returns(1);

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<INextOfKin_DataAccess>()
                    .Setup(method => method.sp_Insert())
                    .Returns(sql);

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the real method call
                mock.Mock<INextOfKin_DataAccess>()
                    .Setup(method => method.GetInsertParameters(input.Object))
                    .Returns(parameter);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<NextOfKin>();
                var prm = helper.GetInsertParameters(input.Object);

                // create an instance of DatabaseAccess to test the method call
                var databaseAccess = mock.Create<DatabaseAccess>();

                // perform the method call
                var result = databaseAccess.Add_NextOfKin(input.Object);

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
    }
}
