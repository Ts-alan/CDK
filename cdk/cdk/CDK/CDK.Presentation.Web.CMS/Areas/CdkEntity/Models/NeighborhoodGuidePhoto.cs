using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class NeighborhoodGuidePhoto : BasePhotoModel, ISeoModel
    {
        public long NeighborhoodGuideId
        {
            get; set;
        }
                    
        [Display(Name = "Sequence Number")]
        [Range(0, int.MaxValue)]
        public int SequenceNumber
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
