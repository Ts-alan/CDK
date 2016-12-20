using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class DevelopmentAmenities : BaseModel
    {
        [Display(Name = "Name")]
        [Required]
        [MaxLength(255)]
        public string Name
        {
            get; set;
        }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description
        {
            get; set;
        }

        [Display(Name = "Logo")]
        [DataType(DataType.ImageUrl)]
        [MaxLength(255)]
        public string IconUri
        {
            get; set;
        }
    }
}