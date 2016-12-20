namespace CDK.DataAccess.Models.cdk
{
    // NeighborhoodGuide

    public class NeighborhoodGuide : BaseModel, ISeoModel
    {
        public long? NeighborhoodAreaId
        {
            get; set;
        } // NeighborhoodAreaId

        public string Name
        {
            get; set;
        }

        public string TagLine
        {
            get; set;
        } // TagLine (length: 255)

        public string WhatToExpect
        {
            get; set;
        } // WhatToExpect

        public string Demographics
        {
            get; set;
        } // Demographics

        public string Lifestyle
        {
            get; set;
        } // Lifestyle

        public string WhatYoullLove
        {
            get; set;
        } // WhatYoullLove

        public string Source
        {
            get; set;
        } // Source

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

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<NeighborhoodGuidePhoto> NeighborhoodGuidePhotos
        {
            get; set;
        } // NeighborhoodGuidePhoto.FK__Neighborh__Neigh__314D4EA8

        public virtual System.Collections.Generic.ICollection<NeighborhoodGuideVideo> NeighborhoodGuideVideos
        {
            get; set;
        } // NeighborhoodGuideVideo.FK__Neighborh__Neigh__324172E1

        // Foreign keys
        public virtual NeighborhoodArea NeighborhoodArea
        {
            get; set;
        } // FK__Neighborh__Neigh__30592A6F

        public NeighborhoodGuide()
        {
            NeighborhoodGuidePhotos = new System.Collections.Generic.HashSet<NeighborhoodGuidePhoto>();
            NeighborhoodGuideVideos = new System.Collections.Generic.HashSet<NeighborhoodGuideVideo>();
        }
    }
}