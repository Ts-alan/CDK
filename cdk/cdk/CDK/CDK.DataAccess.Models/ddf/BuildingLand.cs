using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class BuildingLand : Entity
    {
        public long Id
        {
            get; set;
        }

        public long? BuildingId
        {
            get; set;
        }

        public string SizeTotal
        {
            get; set;
        }

        public string SizeTotalText
        {
            get; set;
        }

        public string SizeFrontage
        {
            get; set;
        }

        public string AccessType
        {
            get; set;
        }

        public string Acreage
        {
            get; set;
        }

        public string Amenities
        {
            get; set;
        }

        public string ClearedTotal
        {
            get; set;
        }

        public string CurrentUse
        {
            get; set;
        }

        public string Divisible
        {
            get; set;
        }

        public string FenceTotal
        {
            get; set;
        }

        public string FenceType
        {
            get; set;
        }

        public string FrontsOn
        {
            get; set;
        }

        public string LandDisposition
        {
            get; set;
        }

        public string LandscapeFeatures
        {
            get; set;
        }

        public string PastureTotal
        {
            get; set;
        }

        public string Sewer
        {
            get; set;
        }

        public string SizeDepth
        {
            get; set;
        }

        public string SizeIrregular
        {
            get; set;
        }

        public string SoilEvaluation
        {
            get; set;
        }

        public string SoilType
        {
            get; set;
        }

        public string SurfaceWater
        {
            get; set;
        }

        public string TiledTotal
        {
            get; set;
        }

        public string TopographyType
        {
            get; set;
        }

        public System.DateTime? LastUpdate
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<AccessType> AccessTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<AmenitiesNearby> AmenitiesNearbies
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<CurrentUse> CurrentUses
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<FenceType> FenceTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<LandDispositionType> LandDispositionTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<LandscapeFeature> LandscapeFeatures_LandscapeFeatureId
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Sewer> Sewers
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<SoilType> SoilTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<SurfaceWater> SurfaceWaters
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<TopographyType> TopographyTypes
        {
            get; set;
        }

        public virtual Building Building
        {
            get; set;
        }

        public BuildingLand()
        {
            AccessTypes = new System.Collections.Generic.HashSet<AccessType>();
            AmenitiesNearbies = new System.Collections.Generic.HashSet<AmenitiesNearby>();
            CurrentUses = new System.Collections.Generic.HashSet<CurrentUse>();
            FenceTypes = new System.Collections.Generic.HashSet<FenceType>();
            LandDispositionTypes = new System.Collections.Generic.HashSet<LandDispositionType>();
            LandscapeFeatures_LandscapeFeatureId = new System.Collections.Generic.HashSet<LandscapeFeature>();
            Sewers = new System.Collections.Generic.HashSet<Sewer>();
            SoilTypes = new System.Collections.Generic.HashSet<SoilType>();
            SurfaceWaters = new System.Collections.Generic.HashSet<SurfaceWater>();
            TopographyTypes = new System.Collections.Generic.HashSet<TopographyType>();
        }
    }
}