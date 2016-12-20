using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.Site.Account.Models
{

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string UserName
        {
            get; set;
        }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get; set;
        }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword
        {
            get; set;
        }
        
        [Range(typeof(bool), "true", "true", ErrorMessage = "You should confirm that you agree with terms")]
        public bool? IsAgree { get; set; }
    }

}