namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgentWebsite
    {
        public long PropertyAgentWebsiteId { get; set; }
        public long PropertyAgentId { get; set; }
        public string ContactType { get; set; }
        public string WebsiteType { get; set; }
        public string WebsiteUrl { get; set; }
    
        public virtual PropertyAgent PropertyAgent { get; set; }
    }
}
