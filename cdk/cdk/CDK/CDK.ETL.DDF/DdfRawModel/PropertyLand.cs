namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyLand
    {
        public long PropertyId { get; set; }
        public string SizeTotal { get; set; }
        public string SizeTotalText { get; set; }
        public string SizeFrontage { get; set; }
        public string AccessType { get; set; }
        public string Acreage { get; set; }
        public string Amenities { get; set; }
        public string ClearedTotal { get; set; }
        public string CurrentUse { get; set; }
        public string Divisible { get; set; }
        public string FenceTotal { get; set; }
        public string FenceType { get; set; }
        public string FrontsOn { get; set; }
        public string LandDisposition { get; set; }
        public string LandscapeFeatures { get; set; }
        public string PastureTotal { get; set; }
        public string Sewer { get; set; }
        public string SizeDepth { get; set; }
        public string SizeIrregular { get; set; }
        public string SoilEvaluation { get; set; }
        public string SoilType { get; set; }
        public string SurfaceWater { get; set; }
        public string TiledTotal { get; set; }
        public string TopographyType { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    
        public virtual Property Property { get; set; }
    }
}
