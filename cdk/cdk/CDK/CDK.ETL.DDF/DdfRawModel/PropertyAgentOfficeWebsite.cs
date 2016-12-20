namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgentOfficeWebsite
    {
        public long PropertyAgentOfficeWebsiteId { get; set; }
        public long PropertyAgentOfficeId { get; set; }
        public string ContactType { get; set; }
        public string WebsiteType { get; set; }
        public string WebsiteUrl { get; set; }
    
        public virtual PropertyAgentOffice PropertyAgentOffice { get; set; }
    }
}
