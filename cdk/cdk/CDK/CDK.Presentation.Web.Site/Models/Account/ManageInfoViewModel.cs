using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CDK.Presentation.Web.Site.Account.Models
{

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public IEnumerable<UserLoginInfoViewModel> Logins
        {
            get; set;
        }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders
        {
            get; set;
        }
    }

}