namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgentDesignation
    {
        public long PropertyAgentDesignationId { get; set; }
        public long PropertyAgentId { get; set; }
        public string Designation { get; set; }
    
        public virtual PropertyAgent PropertyAgent { get; set; }
    }
}
