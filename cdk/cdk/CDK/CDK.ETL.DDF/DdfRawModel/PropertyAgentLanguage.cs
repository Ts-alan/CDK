namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgentLanguage
    {
        public long PropertyAgentLanguageId { get; set; }
        public long PropertyAgentId { get; set; }
        public string Language { get; set; }
    
        public virtual PropertyAgent PropertyAgent { get; set; }
    }
}
