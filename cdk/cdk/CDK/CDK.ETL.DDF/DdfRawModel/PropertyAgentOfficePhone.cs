namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgentOfficePhone
    {
        public long PropertyAgentOfficePhoneId { get; set; }
        public long PropertyAgentOfficeId { get; set; }
        public string ContactType { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual PropertyAgentOffice PropertyAgentOffice { get; set; }
    }
}
