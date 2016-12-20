namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyBusiness
    {
        public long PropertyId { get; set; }
        public string BusinessType { get; set; }
        public string BusinessSubType { get; set; }
        public string EstablishedDate { get; set; }
        public string Franchise { get; set; }
        public string Name { get; set; }
        public string OperatingSince { get; set; }
    
        public virtual Property Property { get; set; }
    }
}
