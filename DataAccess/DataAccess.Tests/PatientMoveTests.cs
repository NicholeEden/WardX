using Autofac;
using Autofac.Extras.Moq;
using DataAccess.Domain;
using DataAccess.Domain.Interface;
using DataAccess.Interface;
using DataAccess.Interface.Integration;
using EFCore.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DataAccess.Tests
{
    public class PatientMoveTests
    {
        // provides user defined test output
        private readonly ITestOutputHelper _output;
        public PatientMoveTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        #region Add_PatientCheckOut Test
        [Fact]
        public void Add_PatientCheckOut()
        {
            using (var mock = AutoMock.GetLoose())
            {

                // Declare the stored procedure expected
                var sql = _StoredProcedureProvider.sp_InsertPatientMovement.ToString();

                // the parameter expected
                var input = new Mock<IPatientMovement>();

                // the parameter array with initialized size
                var parameter = new SqlParameter[3];

                // create a mock of the IQueryManager to intercept the query manager method call
                mock.Mock<IQueryManager>()
                    .Setup(querymanager
                    => querymanager.ExecuteNonQuery(sql, parameter)).Returns(1);


                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method call
                mock.Mock<IPatientMovement_DataAccess>()
                   .Setup(pMove
                   => pMove.sp_Insert()).Returns(sql);



                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method call
                mock.Mock<IPatientMovement_DataAccess>()
                  .Setup(pMove
                  => pMove.GetInsertParameters(input.Object)).Returns(parameter);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<PatientMovement>();


                // perform helper class the parameter method call
                var sp = helper.sp_Insert();


                var param = helper.GetInsertParameters(input.Object);

                // create an instance of DatabaseAccess to test the method call
                var db = mock.Create<DatabaseAccess>();

                // perform the DatabaseAccess method call
                var result = db.Add_PatientCheckOut(input.Object);

                //Make sure the sp_Insert() is called
                mock.Mock<IPatientMovement_DataAccess>()
                    .Verify(p => p.sp_Insert());

                // test details
                _output.WriteLine($"Please ensure that the sp_Insert() returns a {sql}");
                // assert
                Assert.Equal(sql, sp);
                //Check parameter length
                Assert.Equal(parameter.Length, param.Length);
                Assert.IsType<int>(result);
            }
        }
        #endregion

        #region Update_PatientCheckOut Test
        [Fact]
        public void Update_PatientCheckOut()
        {
            using (var mock = AutoMock.GetLoose())
            {

                // Declare the stored procedure expected
                var sql = _StoredProcedureProvider.sp_UpdatePatientMovement.ToString();

                // the parameter expected
                var input = new Mock<IPatientMovement>();

                // the parameter array with initialized size
                var parameter = new SqlParameter[3];

                // create a mock of the IQueryManager to intercept the query manager method call
                mock.Mock<IQueryManager>()
                    .Setup(querymanager
                    => querymanager.ExecuteNonQuery(sql, parameter)).Returns(1);


                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method call
                mock.Mock<IPatientMovement_DataAccess>()
                   .Setup(pMove
                   => pMove.sp_Update()).Returns(sql);



                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method call
                mock.Mock<IPatientMovement_DataAccess>()
                  .Setup(pMove
                  => pMove.GetUpdateParameters(input.Object)).Returns(parameter);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<PatientMovement>();


                // perform helper class the parameter method call
                var sp = helper.sp_Update();


                var param = helper.GetUpdateParameters(input.Object);

                // create an instance of DatabaseAccess to test the method call
                var db = mock.Create<DatabaseAccess>();

                // perform the DatabaseAccess method call
                var result = db.Update_PatientCheckOut(input.Object);

                //Make sure the sp_Insert() is called
                mock.Mock<IPatientMovement_DataAccess>()
                    .Verify(p => p.sp_Update());

                // test details
                _output.WriteLine($"Please ensure that the sp_Update() returns a {sql}");
                // assert
                Assert.Equal(sql, sp);
                //Check parameter length
                Assert.Equal(parameter.Length, param.Length);
                Assert.IsType<int>(result);
            }
        }
        #endregion

        #region GetAll_PatientMovement Test
        [Fact]
        public void GetAll_PatientMovement()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // declare the stored procedure expected
                var sql = _StoredProcedureProvider.sp_SelectPatientMovement.ToString();
                // create a mock of the IQueryManager method used by the integration method you are testing
                mock.Mock<IQueryManager>()
                     .Setup(queryManager => queryManager.ExecuteQuery(sql))
                     .Returns(DummyData.CreateTable());
                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method used
                mock.Mock<IPatientMovement_DataAccess>()
                        .Setup(method => method.sp_Select())
                        .Returns(sql);
                // create an instace of the 'DataAccess.Domain' helper class
                var helper = mock.Create<PatientMovement>();

                // create an instance of DatabaseAccess class
                var databaseAccess = mock.Create<DatabaseAccess>();

                // call the integration method you are testing in DatabaseAccess
                var result = databaseAccess.GetAll_PatientMovement();

                // verify correct stored procedure method was called
                mock.Mock<IPatientMovement_DataAccess>()
                .Verify(method => method.sp_Select());

                // add test description details
                _output.WriteLine($"Please ensure that the methods in" +
                 $" { helper.GetType().FullName} and { databaseAccess.GetType().FullName }" +
                 $" are implemented correctly");
                // add your assert
                Assert.Equal(sql, helper.sp_Select());
                Assert.IsType<DataTable>(result);

            }
        }


        #endregion
        #region GetPatientMovementByCheckOutStatus
        [Fact]
        public void GetPatientMovementByCheckOutStatus()
        {
            using (var mock = AutoMock.GetLoose())
            {

                // Declare the stored procedure expected
                var sql = _StoredProcedureProvider.sp_SelectPatientMovementByStatus.ToString();

                // the parameter expected
                var input = new Mock<IPatientMovement>();

                // the parameter array with initialized size
                var parameter = new SqlParameter[1];

                // create a mock of the IQueryManager to intercept the query manager method call
                mock.Mock<IQueryManager>()
                    .Setup(querymanager
                    => querymanager.ExecuteQuery(sql, parameter))
                    .Returns(DummyData.CreateTable());


                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method call
                mock.Mock<IPatientMovement_DataAccess>()
                   .Setup(pMove
                   => pMove.sp_SelectByStatus()).Returns(sql);



                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method call
                mock.Mock<IPatientMovement_DataAccess>()
                  .Setup(pMove
                  => pMove.GetSelectByStatusParameter(input.Object.isCheckedOut)).Returns(parameter);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<PatientMovement>();


                // perform helper class the parameter method call
                var sp = helper.sp_SelectByStatus();


                var param = helper.GetSelectByStatusParameter(input.Object.isCheckedOut);

                // create an instance of DatabaseAccess to test the method call
                var db = mock.Create<DatabaseAccess>();

                // perform the DatabaseAccess method call
                var result = db.GetPatientMovementByCheckOutStatus(input.Object.isCheckedOut);

                //Make sure the sp_Insert() is called
                mock.Mock<IPatientMovement_DataAccess>()
                    .Verify(p => p.sp_SelectByStatus());

                // test details
                _output.WriteLine($"Please ensure that the sp_SelectByStatus() returns a {sql}");
                // assert
                Assert.Equal(sql, sp);
                //Check parameter length
                Assert.Equal(parameter.Length, param.Length);
                Assert.IsType<DataTable>(result);
            }
        }
        #endregion Test
        #region GetPatientMovementByDateRange Test
        [Fact]
        public void GetPatientMovementByDateRange()
        {
            using (var mock = AutoMock.GetLoose())
            {

                // Declare the stored procedure expected
                var sql = _StoredProcedureProvider.sp_SelectPatientMoveByDateRange.ToString();

                // the parameter expected
                var input = new Mock<IPatient>();
                DateTime startDate = DateTime.Now;
                DateTime endDate = DateTime.Now;

                // the parameter array with initialized size
                var parameter = new SqlParameter[3];

                // create a mock of the IQueryManager to intercept the query manager method call
                mock.Mock<IQueryManager>()
                    .Setup(querymanager
                    => querymanager.ExecuteQuery(sql, parameter))
                    .Returns(DummyData.CreateTable());


                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method call
                mock.Mock<IPatientMovement_DataAccess>()
                   .Setup(pMove
                   => pMove.sp_SelectByDateRange()).Returns(sql);



                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method call
                mock.Mock<IPatientMovement_DataAccess>()
                  .Setup(pMove
                  => pMove.GetSelectByDateRangeParameters(input.Object,startDate, endDate)).Returns(parameter);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<PatientMovement>();


                // perform helper class the parameter method call
                var sp = helper.sp_SelectByDateRange();


                var param = helper.GetSelectByDateRangeParameters(input.Object, startDate, endDate);

                // create an instance of DatabaseAccess to test the method call
                var db = mock.Create<DatabaseAccess>();

                // perform the DatabaseAccess method call
                var result = db.GetPatientMovementByDateRange(input.Object, startDate, endDate);

                //Make sure the sp_Insert() is called
                mock.Mock<IPatientMovement_DataAccess>()
                    .Verify(p => p.sp_SelectByDateRange());
               
                // test details
                _output.WriteLine($"Please ensure that the sp_SelectByDateRange() returns a {sql}");
                // assert
                Assert.Equal(sql, sp);
                //Check parameter length
                Assert.Equal(parameter.Length, param.Length);
                Assert.IsType<DataTable>(result);
              
            }
        }
        #endregion
        #region GetPatientMovementByReason
        [Fact]
        public void GetPatientMovementByReason()
        {
            using (var mock = AutoMock.GetLoose())
            {

                // Declare the stored procedure expected
                var sql = _StoredProcedureProvider.sp_SelectPatientMovementByReason.ToString();

                // the parameter expected
                var input = 1;
               
                // the parameter array with initialized size
                var parameter = new SqlParameter[1];

                // create a mock of the IQueryManager to intercept the query manager method call
                mock.Mock<IQueryManager>()
                .Setup(queryManager => queryManager.ExecuteQuery(sql, parameter))
                .Returns(DummyData.CreateTable());

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method call
                mock.Mock<IPatientMovement_DataAccess>()
                   .Setup(pMove
                   => pMove.sp_SelectByReason()).Returns(sql);

                // create a mock of the 'DataAccess.Domain.Interface' to intercept the helper class method call
                mock.Mock<IPatientMovement_DataAccess>()
                  .Setup(pMove
                  => pMove.GetSelectByReasonParameter(input)).Returns(parameter);

                // create implementation of the 'DataAccess.Domain' helper class
                var helper = mock.Create<PatientMovement>();


                // perform helper class the parameter method call
                var sp = helper.sp_SelectByReason();


                var param = helper.GetSelectByReasonParameter(input);

                // create an instance of DatabaseAccess to test the method call
                var db = mock.Create<DatabaseAccess>();

                // perform the DatabaseAccess method call
                var result = db.GetPatientMovementByReason(input);

                //Make sure the sp_Insert() is called
                mock.Mock<IPatientMovement_DataAccess>()
                    .Verify(p => p.sp_SelectByReason());

                // test details
                _output.WriteLine($"Please ensure that the sp_SelectByReason() returns a {sql}");
                // assert
                Assert.Equal(sql, sp);
                //Check parameter length
                Assert.Equal(parameter.Length, param.Length);
                Assert.IsType<DataTable>(result);
            }
        }
        #endregion

    


    }

    public class move : IPatientMovement
    {
        public int PatientMovementID { get ; set ; }
        public int AdmissionFileID { get; set; }
       
        public DateTime MoveDate { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public bool isCheckedOut { get; set; }
        public Reason Reason { get; set; }
        }
}
