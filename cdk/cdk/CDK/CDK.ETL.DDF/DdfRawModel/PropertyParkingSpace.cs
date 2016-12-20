namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyParkingSpace
    {
        public long PropertyParkingSpaceId { get; set; }
        public long PropertyId { get; set; }
        public string Name { get; set; }
        public string Spaces { get; set; }
    
        public virtual Property Property { get; set; }
    }
}
