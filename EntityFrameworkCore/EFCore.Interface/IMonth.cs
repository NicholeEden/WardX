namespace EFCore.Interface
{
    public interface IMonth
    {
        int MonthID { get; set; }

        string MonthName { get; set; }

        int StartDate { get; set; }

        int EndDate { get; set; }
    }
}
