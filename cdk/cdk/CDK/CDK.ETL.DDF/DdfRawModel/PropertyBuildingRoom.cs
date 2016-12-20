namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyBuildingRoom
    {
        public long PropertyBuildingRoomId { get; set; }
        public long PropertyId { get; set; }
        public string Type { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Level { get; set; }
        public string Dimension { get; set; }
        public string Description { get; set; }
        public System.DateTime LastUpdate { get; set; }
    
        public virtual PropertyBuilding PropertyBuilding { get; set; }
    }
}
