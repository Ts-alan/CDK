namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyOpenHouse
    {
        public long PropertyOpenHouseId { get; set; }
        public long PropertyId { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string Comments { get; set; }
    
        public virtual Property Property { get; set; }
    }
}
