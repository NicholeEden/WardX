using System;
using System.Data;

namespace DataAccess.Tests
{
    internal static class DummyData
    {
        #region Setup Tables
        internal static DataTable CreateTable()
        {
            DataTable orderTable = new DataTable("Order");

            // Define one column.
            DataColumn colId = new DataColumn("OrderId", typeof(String));
            orderTable.Columns.Add(colId);

            DataColumn colDate = new DataColumn("OrderDate", typeof(DateTime));
            orderTable.Columns.Add(colDate);

            // Set the OrderId column as the primary key.
            orderTable.PrimaryKey = new DataColumn[] { colId };

            // Add data
            InsertOrders(orderTable);
            
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
}