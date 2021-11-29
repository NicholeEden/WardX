namespace WARDxAPI.Model.Interface
{
    /// <summary>
    /// This interface defines the data that will be displayed in the card table.
    /// </summary>
    public interface ICardTableContent
    {
        /// <summary>
        /// Defines the id value to be used in the route parameter
        /// </summary>
        int Key { get; set; }

        /// <summary>
        /// Defines the value of the first column
        /// </summary>
        string Value1 { get; set; }

        /// <summary>
        /// Defines the value of the second column
        /// </summary>
        string Value2 { get; set; }

        /// <summary>
        /// Defines the value of the third column
        /// </summary>
        string Value3 { get; set; }

        /// <summary>
        /// Defines the value of the fourth column
        /// </summary>
        string Value4 { get; set; }

        /// <summary>
        /// Defines the value of the fifth column
        /// </summary>
        string Value5 { get; set; }

        /// <summary>
        /// Defines the value of the sixth column
        /// </summary>
        string Value6 { get; set; }

        /// <summary>
        /// Defines the value of the seventh column
        /// </summary>
        string Value7 { get; set; }

        /// <summary>
        /// Defines the value of the eighth column
        /// </summary>
        string Value8 { get; set; }
    }
}