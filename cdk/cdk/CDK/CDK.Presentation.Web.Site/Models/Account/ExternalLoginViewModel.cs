using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CDK.Presentation.Web.Site.Account.Models
{

    public class ExternalLoginViewModel
    {
        public string Name
        {
            get; set;
        }

        public string Url
        {
            get; set;
        }

        public string State
        {
            get; set;
        }
    }

}