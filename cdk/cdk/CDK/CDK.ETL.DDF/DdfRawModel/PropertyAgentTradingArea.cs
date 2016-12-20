namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgentTradingArea
    {
        public long PropertyAgentTradingAreaId { get; set; }
        public long PropertyAgentId { get; set; }
        public string TradingArea { get; set; }
    
        public virtual PropertyAgent PropertyAgent { get; set; }
    }
}
