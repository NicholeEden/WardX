using System.ComponentModel.DataAnnotations;
using WARDxAPI.Model.Interface;

namespace WARDxAPI.Model.Shared
{
    public class LoginModel : ILoginModel
    {
        [Required, MaxLength(13)]
        public string EmployeeID { get; set; }

        [Required, MaxLength(1024), DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
