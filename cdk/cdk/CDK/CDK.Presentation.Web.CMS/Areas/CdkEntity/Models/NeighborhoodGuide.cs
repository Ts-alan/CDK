using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CDK.Presentation.Web.CMS.Areas.CdkEntity.Models
{
    public class NeighborhoodGuide : BaseModel, IVideoContainerModel, IPhotoContainerModel, ISeoModel
    {
        [Display(Name = "Neighborhood Area")]
        public long? NeighborhoodAreaId
        {
            get; set;
        }

        public NeighborhoodArea NeighborhoodArea
        {
            get; set;
        }

        [Display(Name = "Name")]
        [MaxLength(255)]
        [Required]
        public string Name
        {
            get; set;
        }

        [Display(Name = "Tag Line")]
        [MaxLength(255)]
        [Required]
        public string TagLine
        {
            get; set;
        }

        [Display(Name = "What to expect")]
        [DataType(DataType.MultilineText)]
        public string WhatToExpect
        {
            get; set;
        }

        [Display(Name = "Demographics")]
        [DataType(DataType.MultilineText)]
        public string Demographics
        {
            get; set;
        }

        [Display(Name = "Lifestyle")]
        [DataType(DataType.MultilineText)]
        public string Lifestyle
        {
            get; set;
        }

        [Display(Name = "What you'll Love")]
        [DataType(DataType.MultilineText)]
        public string WhatYoullLove
        {
            get; set;
        }

        [Display(Name = "Source")]
        [DataType(DataType.MultilineText)]
        public string Source
        {
            get; set;
        }

        public List<NeighborhoodGuideVideo> NeighborhoodGuideVideos
        {
            get; set;
        }

        public List<NeighborhoodGuidePhoto> NeighborhoodGuidePhotos
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

        //For UI
        public string VideosJSON
        {
            get; set;
        }

        [AllowHtml]
        public string PhotoJSON
        {
            get;set;
        }

        
        public string PhotoStorageUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["blobUrl"];
            }
        }                                                                              

        public string VideoListJSON()
        {
            return JsonConvert.SerializeObject((this.NeighborhoodGuideVideos ?? Enumerable.Empty<NeighborhoodGuideVideo>()).OrderBy(x => x.SequenceNumber));
        }

        public string PhotoListJSON()
        {
            return JsonConvert.SerializeObject((this.NeighborhoodGuidePhotos ?? Enumerable.Empty<NeighborhoodGuidePhoto>()).OrderBy(x => x.SequenceNumber));
        }
    }
}
