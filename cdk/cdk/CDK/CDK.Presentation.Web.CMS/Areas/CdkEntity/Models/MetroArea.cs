using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class MetroArea : BaseModel, ISeoModel
    {    
        [Display(Name = "Name")]
        [Required]
        [MaxLength(255)]
        public string Name
        {
            get; set;
        }

        [Display(Name = "Short Name")]
        [Required]
        [MaxLength(255)]
        public string ShortName
        {
            get; set;
        }

        [Display(Name = "State")]
        [Required]
        [MaxLength(255)]
        public string State
        {
            get; set;
        }

        [Display(Name = "Country")]
        [Required]
        [MaxLength(255)]
        public string Country
        {
            get; set;
        }

        [Display(Name = "Description")]
        [Required]  
        [DataType(DataType.MultilineText)]
        public string Description
        {
            get; set;
        }

        [Display(Name = "Center Point Lat.")]
        [Required]
        [MaxLength(255)]
        public string CenterPointLat
        {
            get; set;
        }

        [Display(Name = "Center Point Lon.")]
        [Required]
        [MaxLength(255)]
        public string CenterPointLon
        {
            get; set;
        }

        [Display(Name = "Coordinates as Text")]
        [Required]
        [MaxLength(255)]
        public string CoordinatesAsText
        {
            get; set;
        }

        [Display(Name = "Uri")]  
        [DataType(DataType.ImageUrl)]
        public string MetroAreaUri
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