using System.Collections.Generic;

namespace CDK.BusinessLogic.Core.DTO.CMS
{
    public class NeighborhoodGuide : BaseModel, ISeoModel, IPhotoContainer
    {
        public long? NeighborhoodAreaId
        {
            get; set;
        }

        public NeighborhoodArea NeighborhoodArea
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string TagLine
        {
            get; set;
        }

        public string WhatToExpect
        {
            get; set;
        }

        public string Demographics
        {
            get; set;
        }

        public string Lifestyle
        {
            get; set;
        }

        public string WhatYoullLove
        {
            get; set;
        }

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
    }
}