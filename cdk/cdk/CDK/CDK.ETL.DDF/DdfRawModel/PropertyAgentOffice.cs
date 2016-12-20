namespace CDK.ETL.DDF.DdfRawModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PropertyAgentOffice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PropertyAgentOffice()
        {
            this.PropertyAgent = new HashSet<PropertyAgent>();
            this.PropertyAgentOfficePhone = new HashSet<PropertyAgentOfficePhone>();
            this.PropertyAgentOfficeWebsite = new HashSet<PropertyAgentOfficeWebsite>();
        }
    
        public long PropertyAgentOfficeId { get; set; }
        public string DdfPropertyAgentOfficeId { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Franchisor { get; set; }
        public string LogoLastUpdated { get; set; }
        public string OrganizationType { get; set; }
        public string Designation { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public string Addressline2 { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetSuffix { get; set; }
        public string Province { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgent> PropertyAgent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgentOfficePhone> PropertyAgentOfficePhone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropertyAgentOfficeWebsite> PropertyAgentOfficeWebsite { get; set; }
    }
}
