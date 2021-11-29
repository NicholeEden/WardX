using System.Collections.Generic;
using System.Data;

namespace BusinessLogic.Interface
{
    public interface IDataProvider
    {
        /// <summary>
        /// example:
        /// <example>
        /// <code>
        ///     ForDropdownList(databaseAccess.GetUsers(), nameof(IUser.UserID), nameof(IUser.UserName));
        /// </code>
        /// </example>
        ///     results in Dictionary key [UserID] and display value [UserName] to use on a dropdown input element.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="IDColumn"></param>
        /// <param name="descriptionColumn"></param>
        /// <returns></returns>
        Dictionary<string, string> ForDropdownList(
            DataTable table,
            string IDColumn,
            string descriptionColumn);

        /// <summary>
        /// example:
        /// <example>
        /// <code>
        ///     ForDropdownList(databaseAccess.GetUsers(), nameof(IUser.UserID), nameof(IUser.Firsname), nameof(IUser.LastName));
        /// </code>
        /// </example>
        ///     results in Dictionary key [UserID] and display value [UserName] to use on a dropdown input element.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="IDColumn"></param>
        /// <param name="descriptionColumn1"></param>
        /// <param name="descriptionColumn2"></param>
        /// <param name="descriptionColumn3"></param>
        /// <returns></returns>
        Dictionary<string, string> ForDropdownList(
            DataTable table,
            string IDColumn,
            string descriptionColumn1,
            string descriptionColumn2,
            string descriptionColumn3);

        /// <summary>
        /// example:
        /// <example>
        /// <code>
        ///     GetClassListFromTable&lt;User>(databaseAccess.GetUsers())
        /// </code>
        /// </example>
        ///     results in a list of User classes [List&lt;User>]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        List<T> GetClassListFromTable<T>(DataTable table) where T : class, new();

        /// <summary>
        /// example:
        /// <example>
        /// <code>
        ///     GetClassFromTable&lt;User>(databaseAccess.GetUser())
        /// </code>
        /// </example>
        ///     results in a single User class [User]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        T GetClassFromTable<T>(DataTable table) where T : class, new();

        /// <summary>
        /// example:
        /// <example>
        /// <code>
        ///     GetColumnData(databaseAccess.GetUsers(), nameof(IUser.UserName));
        /// </code>
        /// </example>
        ///     results in a list of values the specified column has from all rows in the table [List&lt;string>]
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        List<string> GetColumnData(DataTable table, string columnName);
    }
}
