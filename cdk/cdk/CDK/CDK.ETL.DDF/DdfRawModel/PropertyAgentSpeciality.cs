namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgentSpeciality
    {
        public long PropertyAgentSpecialityId { get; set; }
        public long PropertyAgentId { get; set; }
        public string Specialtie { get; set; }
    
        public virtual PropertyAgent PropertyAgent { get; set; }
    }
}
