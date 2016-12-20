namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAlternateUrl
    {
        public long PropertyId { get; set; }
        public string BrochureLink { get; set; }
        public string MapLink { get; set; }
        public string PhotoLink { get; set; }
        public string SoundLink { get; set; }
        public string VideoLink { get; set; }
    
        public virtual Property Property { get; set; }
    }
}
