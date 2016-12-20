namespace CDK.DataAccess.Models.cdk
{
    // MetroArea

    public class MetroArea : BaseModel, ISeoModel
    {
        public long? MetroAreaExtId
        {
            get; set;
        } // MetroAreaExtId

        public string MetroAreaExtVersion
        {
            get; set;
        } // MetroAreaExtVersion (length: 255)

        public string Name
        {
            get; set;
        } // Name (length: 255)

        public string ShortName
        {
            get; set;
        } // ShortName (length: 255)

        public string State
        {
            get; set;
        } // State (length: 255)

        public string Country
        {
            get; set;
        } // Country (length: 255)

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

        public string MetroCoordinatesAsText
        {
            get; set;
        } // CoordinatesAsText

        public string MetroAreaUri
        {
            get; set;
        } // MetroAreaUri (length: 255)

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

        public string MType
        {
            get; set;
        }

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<NeighborhoodArea> NeighborhoodAreas
        {
            get; set;
        } // NeighborhoodArea.NeighborhoodArea_MetroArea

        public MetroArea()
        {
            NeighborhoodAreas = new System.Collections.Generic.HashSet<NeighborhoodArea>();
        }
    }
}