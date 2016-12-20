using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class NeighborhoodArea : BaseModel, ISeoModel
    {
        [Display(Name = "Metro Area")]
        public long? MetroAreaId
        {
            get; set;
        }

        public MetroArea MetroArea
        {
            get;set;
        }

        [Display(Name = "Name")]
        [Required]
        [MaxLength(255)]
        public string Name
        {
            get; set;
        }

        [Display(Name = "Short name")]
        [Required]
        [MaxLength(255)]
        public string ShortName
        {
            get; set;
        }

        [Display(Name = "Description")]
        public string Description
        {
            get; set;
        }

        [Display(Name = "Center Point Lat.")]
        [MaxLength(255)]
        public string CenterPointLat
        {
            get; set;
        }

        [Display(Name = "Center Point Lon.")]
        [MaxLength(255)]
        public string CenterPointLon
        {
            get; set;
        }

        [Display(Name = "Coordinates as text")]
        [MaxLength(255)]
        public string CoordinatesAsText
        {
            get; set;
        }

        [Display(Name = "Uri")]
        [MaxLength(255)]
        public string NeighborhoodAreaUri
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