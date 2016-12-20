using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.Site.Account.Models
{
    public class UserInfoBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get; set;
        }


        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber
        {
            get; set;
        }

        [Display(Name = "First Name")]
        public string FirstName
        {
            get; set;
        }

        [Display(Name = "Last Name")]
        public string LastName
        {
            get; set;
        }
    }
}
