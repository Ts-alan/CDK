using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class DevelopmentVideo : BaseModel, ISeoModel
    {
        public long DevelopmentId
        {
            get; set;
        }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(255)]
        public string Name
        {
            get; set;
        }

        public string Type
        {
            get; set;
        }

        [Display(Name = "Uri")]
        [Required]
        public string Uri
        {
            get; set;
        }

        [Display(Name = "Description")]    
        public string Description
        {
            get; set;
        }

        [Display(Name = "Sequence Number")]   
        public int SequenceNumber
        {
            get; set;
        }

        [Display(Name = "Alt Text")]
        [MaxLength(255)]
        public string AltText
        {
            get; set;
        }


        public bool IsDeleted
        {
            get; set;
        }

        public string SeoCaption
        {
            get; set;
        }

        public string SeoDescription
        {
            get; set;
        }

        public string SeoKeywords
        {
            get; set;
        }

        public string SeoSlug
        {
            get; set;
        }

        public string SeoTitle
        {
            get; set;
        }

        public string SeoMetaDescription
        {
            get; set;
        }

        public string SeoURI
        {
            get; set;
        }
    }
}
