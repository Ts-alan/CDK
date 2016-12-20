using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public interface ISeoModel
    {
        [Display(Name = "Seo Caption")]
        [MaxLength(255)]
        string SeoCaption
        {
            get;set;
        }

        [Display(Name = "Seo Description")]   
        [DataType(DataType.MultilineText)]
        string SeoDescription
        {
            get; set;
        }

        [Display(Name = "Seo Keywords")]
        [MaxLength(255)]
        string SeoKeywords
        {
            get; set;
        }

        [Display(Name = "Seo Slug")]
        [DataType(DataType.MultilineText)]
        string SeoSlug
        {
            get; set;
        }
  
        [Display(Name = "Seo Title")]
        [MaxLength(255)]
        string SeoTitle
        {
            get; set;
        }

        [Display(Name = "Seo Meta Description")]
        [DataType(DataType.MultilineText)]
        string SeoMetaDescription
        {
            get; set;
        }

        [Display(Name = "Seo URI")]  
        string SeoURI
        {
            get; set;
        }
    }
}
