namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyPhoto
    {
        public long PropertyPhotoId { get; set; }
        public long PropertyId { get; set; }
        public string DdfPropertyId { get; set; }
        public string DdfSequenceId { get; set; }
        public string FolderPath { get; set; }
        public string PhotoType { get; set; }
        public string PhotoName { get; set; }
        public string PhotoOriginalSize { get; set; }
        public System.DateTime LastDdfUpdate { get; set; }
        public System.DateTime LastUpdate { get; set; }
    
        public virtual Property Property { get; set; }
    }
}
