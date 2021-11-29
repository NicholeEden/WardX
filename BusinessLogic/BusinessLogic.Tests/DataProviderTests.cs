using System;
using System.Collections.Generic;
using System.Data;
using Xunit;

namespace BusinessLogic.Tests
{
    public class DataProviderTests
    {
        [Fact]
        public void DropdownList()
        {
            // create and populate table
            var table = CreateOrderTable();
            InsertOrders(table);

            // instantiate the 'DataProvider' class
            var provider = new DataProvider();

            // make the method call
            var result = provider.ForDropdownList(table, nameof(OrderTest.OrderId), nameof(OrderTest.OrderDate));

            // assert that a result was returned
            Assert.NotNull(result);
            // assert that the result is of the expected type
            Assert.IsType<Dictionary<string, string>>(result);
            // assert that the results returned are sufficient
            Assert.Equal(3, result.Count);
            // assert that the result has the expected value
            Assert.Equal(new DateTime(2013, 3, 12).ToString(), result["0002"]);
        }

        [Fact]
        public void ClassListFromTable()
        {
            // create and populate table
            var table = CreateOrderTable();
            InsertOrders(table);

            // instantiate the 'DataProvider' class
            var provider = new DataProvider();

            // make the method call
            var result = provider.GetClassListFromTable<OrderTest>(table);

            // assert that a result was returned
            Assert.NotNull(result);
            // assert that the result is of the expected type
            Assert.IsType<List<OrderTest>>(result);
            // assert that the results returned are sufficient
            Assert.Equal(3, result.Count);
            // assert that the result has the expected value
            Assert.Equal(3, result[2].OrderId);
        }

        [Fact]
        public void ClassFromTable()
        {
            // create and populate table
            var table = CreateOrderTable();
            InsertOrders(table);

            // instantiate the 'DataProvider' class
            var provider = new DataProvider();

            // make the method call
            var result = provider.GetClassFromTable<OrderTest>(table);

            // assert that a result was returned
            Assert.NotNull(result);
            // assert that the result is of the expected type
            Assert.IsType<OrderTest>(result);
            // assert that the result has the expected value
            Assert.Equal(1, result.OrderId);
        }

        #region Setup Tables
        private static DataTable CreateOrderTable()
        {
            DataTable orderTable = new DataTable("Order");

            // Define one column.
            DataColumn colId = new DataColumn("OrderId", typeof(String));
            orderTable.Columns.Add(colId);

            DataColumn colDate = new DataColumn("OrderDate", typeof(DateTime));
            orderTable.Columns.Add(colDate);

            // Set the OrderId column as the primary key.
            orderTable.PrimaryKey = new DataColumn[] { colId };

            return orderTable;
        }

        private static void InsertOrders(DataTable orderTable)
        {
            // Add one row once.
            DataRow row1 = orderTable.NewRow();
            row1["OrderId"] = "0001";
            row1["OrderDate"] = new DateTime(2013, 3, 1);
            orderTable.Rows.Add(row1);

            DataRow row2 = orderTable.NewRow();
            row2["OrderId"] = "0002";
            row2["OrderDate"] = new DateTime(2013, 3, 12);
            orderTable.Rows.Add(row2);

            DataRow row3 = orderTable.NewRow();
            row3["OrderId"] = "0003";
            row3["OrderDate"] = new DateTime(2013, 3, 20);
            orderTable.Rows.Add(row3);
        }
        #endregion
    }

    class OrderTest
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
