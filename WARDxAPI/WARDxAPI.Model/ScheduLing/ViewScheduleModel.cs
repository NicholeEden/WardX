using WARDxAPI.Model.Interface;
using WARDxAPI.Model.Interface.StaffScheduling;
using WARDxAPI.Model.StaffScheduling;

namespace WARDxAPI.Model
{
    public class ViewScheduleModel : IViewScheduleModel
    {
        public ViewScheduleModel(
            IScheduleTable viewSchedule,
            IAlertModel AlertModel)
        {
            ScheduleTable = viewSchedule;
            alertModel = AlertModel;
        }
        public IScheduleTable ScheduleTable { get; set; }
        public IAlertModel alertModel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeID { get; set; }
        public bool isWardManager { get; set; }
        public bool isHeadNurse { get; set; }
        public string MonthName { get; set; }
        public string Description { get; set; }

    }
}
