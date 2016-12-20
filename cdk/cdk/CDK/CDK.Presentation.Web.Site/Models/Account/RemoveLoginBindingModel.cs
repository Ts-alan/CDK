using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.Site.Account.Models
{

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider
        {
            get; set;
        }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey
        {
            get; set;
        }
    }

}