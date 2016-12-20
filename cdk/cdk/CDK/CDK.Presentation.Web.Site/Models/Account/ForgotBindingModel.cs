using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.Site.Account.Models
{
    public class ForgotBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email
        {
            get; set;
        }
    }
}
