using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WARDx.Data;
using WARDxAPI.Model.Interface.Treatment;

namespace WARDxAPI.Model.Treatment
{
    public class SendRequest : ISendRequest
    {
        public string CCEmailAddress { get; set; }
        public List<SelectOption> DoctorEmailList { get; set; }

        public int DoctorID { get; set; }
        [Required,
           MinLength(5, ErrorMessage = "The header is too short."),
           Display(Name = "Subject")]
        public string Subject { get; set; }

        [Required,
            MaxLength(1024, ErrorMessage = "The email content has exceeded the size."),
            Display(Name = "Body")]
        public string Body { get; set; }

        [Required,
            DataType(DataType.EmailAddress)]
        public string ToEmail { get; set; }

    }
}
