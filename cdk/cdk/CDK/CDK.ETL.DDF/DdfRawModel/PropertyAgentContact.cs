namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgentContact
    {
        public long PropertyAgentContactId { get; set; }
        public string ContactType { get; set; }
        public string AgentType { get; set; }
        public string TextValue { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public Nullable<long> PropertyAgentId { get; set; }
    
        public virtual PropertyAgent PropertyAgent { get; set; }
    }
}
