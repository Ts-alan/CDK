namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyUtilitiesAvailable
    {
        public long PropertyUtilitiesAvailableId { get; set; }
        public long PropertyId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    
        public virtual Property Property { get; set; }
    }
}
