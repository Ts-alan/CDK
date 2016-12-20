using CDK.DataAccess.Models.ddf;

namespace CDK.DataAccess.Models.cdk
{
    // NeighborhoodArea

    public class NeighborhoodArea : BaseModel, ISeoModel
    {
        public long? MetroAreaId
        {
            get; set;
        } // MetroAreaId

        public long? NeighborhoodAreaExtId
        {
            get; set;
        } // NeighborhoodAreaExtId

        public string NeighborhoodAreaExtVersion
        {
            get; set;
        } // NeighborhoodAreaExtVersion (length: 255)

        public long? ParentId
        {
            get; set;
        } // ParentId

        public string Name
        {
            get; set;
        } // Name (length: 255)

        public string ShortName
        {
            get; set;
        } // ShortName (length: 255)

        public string Description
        {
            get; set;
        } // Description

        public System.Data.Entity.Spatial.DbGeography CenterPointGeo
        {
            get; set;
        } // CenterPointGeo

        public string CenterPointLat
        {
            get; set;
        } // CenterPointLat (length: 255)

        public string CenterPointLon
        {
            get; set;
        } // CenterPointLon (length: 255)

        public System.Data.Entity.Spatial.DbGeography CoordinatesGeo
        {
            get; set;
        } // CoordinatesGeo

        public string CoordinatesAsText
        {
            get; set;
        } // CoordinatesAsText

        public string NeighborhoodAreaUri
        {
            get; set;
        } // NeighborhoodAreaUri (length: 255)

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

        public string NType
        {
            get; set;
        }

        public int LType
        {
            get; set;
        }

        public bool HasChild
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<NeighborhoodGuide> NeighborhoodGuides
        {
            get; set;
        } // NeighborhoodGuide.FK__Neighborh__Neigh__30592A6F

        // Foreign keys
        public virtual MetroArea MetroArea
        {
            get; set;
        } // NeighborhoodArea_MetroArea

        //public virtual NeighborhoodArea Parent
        //{
        //    get; set;
        //}

        public System.Collections.Generic.ICollection<DevelopmentAddress> DevelopmentAddress
        {
            get;
            set;
        }

        public NeighborhoodArea()
        {
            NeighborhoodGuides = new System.Collections.Generic.HashSet<NeighborhoodGuide>();
            DevelopmentAddress = new System.Collections.Generic.HashSet<DevelopmentAddress>();
        }
    }
}