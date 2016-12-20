using System;
using System.ComponentModel.DataAnnotations;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class BaseModel
    {
        [Display(Name = "Id")]
        public long? Id
        {
            get; set;
        }

        [Display(Name = "Updated")]
        public DateTime LastUpdate
        {
            get; set;
        }

        [Display(Name = "Created")]
        public DateTime Created
        {
            get; set;
        }

        [Display(Name = "Created by")]
        public string CreatedBy
        {
            get; set;
        }

        [Display(Name = "Updated by")]
        public string LastUpdateBy
        {
            get; set;
        }
    }
}