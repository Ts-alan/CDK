using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CDK.Presentation.Web.Site.Account.Models
{

    public class UserInfoViewModel
    {
        public string Email
        {
            get; set;
        }

        public bool HasRegistered
        {
            get; set;
        }

        public string LoginProvider
        {
            get; set;
        }

        public DateTime CreatedDate
        {
            get; set;
        }

        public string PhoneNumber
        {
            get;
            internal set;
        }

        public string FirstName
        {
            get;
            internal set;
        }

        public string LastName
        {
            get;
            internal set;
        }
    }

}