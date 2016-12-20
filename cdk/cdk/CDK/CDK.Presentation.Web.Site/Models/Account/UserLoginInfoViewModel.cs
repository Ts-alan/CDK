using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CDK.Presentation.Web.Site.Account.Models
{

    public class UserLoginInfoViewModel
    {
        public string LoginProvider
        {
            get; set;
        }

        public string ProviderKey
        {
            get; set;
        }
    }

}