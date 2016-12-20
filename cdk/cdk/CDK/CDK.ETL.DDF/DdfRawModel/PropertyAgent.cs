namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PropertyAgent()
        {
            this.PropertyAgentContact = new HashSet<PropertyAgentContact>();
            this.PropertyAgentDesignation = new HashSet<PropertyAgentDesignation>();
            this.PropertyAgentLanguage = new HashSet<PropertyAgentLanguage>();
            this.PropertyAgentPhone = new HashSet<PropertyAgentPhone>();
            this.PropertyAgentSpeciality = new HashSet<PropertyAgentSpeciality>();
            this.PropertyAgentTradingArea = new HashSet<PropertyAgentTradingArea>();
            this.PropertyAgentWebsite = new HashSet<PropertyAgentWebsite>();
            this.Property = new HashSet<Property>();
        }
    
        public long PropertyAgentId { get; set; }
        public Nullable<long> PropertyAgentOfficeId { get; set; }
        public string DdfAgentId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public string EducationCredentials { get; set; }
        public Nullable<System.DateTime> PhotoLastUpdated { get; set; }
        public string StreetAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string Addressline2 { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetSuffix { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgentContact> PropertyAgentContact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgentDesignation> PropertyAgentDesignation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgentLanguage> PropertyAgentLanguage { get; set; }
        public virtual PropertyAgentOffice PropertyAgentOffice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgentPhone> PropertyAgentPhone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgentSpeciality> PropertyAgentSpeciality { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgentTradingArea> PropertyAgentTradingArea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgentWebsite> PropertyAgentWebsite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Property> Property { get; set; }
    }
}
