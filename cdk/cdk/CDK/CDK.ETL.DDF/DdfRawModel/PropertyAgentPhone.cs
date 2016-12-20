namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgentPhone
    {
        public long PropertyAgentPhoneId { get; set; }
        public long PropertyAgentId { get; set; }
        public string ContactType { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual PropertyAgent PropertyAgent { get; set; }
    }
}
