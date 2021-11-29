using BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLogic
{
    public class DataProvider : IDataProvider
    {
        public Dictionary<string, string> ForDropdownList(
            DataTable table,
            string IDColumn,
            string descriptionColumn)
        {
            var itemList = new Dictionary<string, string>();
            foreach (DataRow row in table.Rows)
            {
                itemList.Add(row[IDColumn].ToString(), row[descriptionColumn].ToString());
            }
            return itemList;
        }

        public Dictionary<string, string> ForDropdownList(
            DataTable table,
            string IDColumn,
            string descriptionColumn1,
            string descriptionColumn2,
            string descriptionColumn3)
        {
            var itemList = new Dictionary<string, string>();
            foreach (DataRow row in table.Rows)
            {
                itemList.Add(
                    row[IDColumn].ToString(),
                    row[descriptionColumn1].ToString()
                    + " " + row[descriptionColumn2].ToString()
                    + " | " + row[descriptionColumn3].ToString());
            }
            return itemList;
        }

        public T GetClassFromTable<T>(DataTable table) where T : class, new()
        {
            // instantiates a single instance of the defined class
            T instance = new T();
            // gets all the properties in the defined class
            var properties = instance.GetType().GetProperties();
            // iterate through each row in the table
            foreach (DataRow row in table.Rows)
            {
                // class instance to represent a single row
                instance = new T();
                // iterate through each property in the defined class
                foreach (var prop in properties)
                {
                    // if the property name matches one of the column names
                    if (table.Columns.Contains(prop.Name))
                    {
                        // check if the type is an enum
                        if (prop.PropertyType.IsEnum)
                        {
                            // set the property value to the value defined in the column
                            prop.SetValue(instance, Enum.ToObject(prop.PropertyType, row[prop.Name]));
                        }
                        else
                        {
                            try
                            {
                                // set the property value to the value defined in the column
                                prop.SetValue(instance, Convert.ChangeType(row[prop.Name], prop.PropertyType));
                            }
                            catch (InvalidCastException)
                            {
                                //Get value
                                object value = row[prop.Name];

                                if (Convert.IsDBNull(value))
                                {

                                    // nullable property
                                    prop.SetValue(instance, null);
                                }
                                else
                                {
                                    prop.SetValue(instance, value);
                                }
                            }
                        }
                    }
                }
                // only one class instance is required
                return instance;
            }
            return null;
        }

        public List<T> GetClassListFromTable<T>(DataTable table) where T : class, new()
        {
            // instantiates a list of the defined class
            List<T> output = new List<T>();
            // instantiates a single instance of the defined class
            T instance = new T();
            // gets all the properties in the defined class
            var properties = instance.GetType().GetProperties();
            // iterate through each row in the table
            foreach (DataRow row in table.Rows)
            {
                // class instance to represent a single row
                instance = new T();
                // iterate through each property in the defined class
                foreach (var prop in properties)
                {
                    // if the property name matches one of the column names
                    if (table.Columns.Contains(prop.Name))
                    {
                        // check if the type is an enum
                        if (prop.PropertyType.IsEnum)
                        {
                            // set the property value to the value defined in the column
                            prop.SetValue(instance, Enum.ToObject(prop.PropertyType, row[prop.Name]));
                        }
                        else
                        {
                            try
                            {
                                // set the property value to the value defined in the column
                                prop.SetValue(instance, Convert.ChangeType(row[prop.Name], prop.PropertyType));
                            }
                            catch (InvalidCastException)
                            {
                                // get value
                                object value = row[prop.Name];

                                if(Convert.IsDBNull(value))
                                {
                                    // nullable property
                                    prop.SetValue(instance, null);
                                }
                                else
                                {
                                    prop.SetValue(instance, value);
                                }
                            }
                        }
                    }
                }
                // add class instance to the list
                output.Add(instance);
            }
            return output;
        }

        public List<string> GetColumnData(DataTable table, string columnName)
        {
            var list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                list.Add((string)row[columnName]);
            }
            return list;
        }
    }
}