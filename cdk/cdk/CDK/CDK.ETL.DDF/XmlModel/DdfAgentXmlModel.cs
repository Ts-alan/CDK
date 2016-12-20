using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CDK.ETL.DDF.Agent
{

     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    public partial class RETS
    {

        [XmlElementAttribute("COUNT")]
        public RETSCount COUNT{ get; set; }

        [XmlElementAttribute("DELIMITER")]
        public RETSDelimiter DELIMITER { get; set; }
         
        // Namespace is needed here. If regenerate manually put the Namespace
        [XmlElementAttribute("RETS-RESPONSE", Namespace = "urn:CREA.Search.Agent")]
        public RETSResponse RETSResponse { get; set; }
         
        [XmlAttributeAttribute()]
        public string ReplyCode { get; set; }

        [XmlIgnoreAttribute()]
        public bool ReplyCodeSpecified { get; set; }

        [XmlAttributeAttribute()]
        public string ReplyText { get; set; }

    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSCount
    {
         
        [XmlAttributeAttribute()]
        public short Records { get; set; }

        [XmlIgnoreAttribute()]
        public bool RecordsSpecified { get; set; }

        [XmlTextAttribute()]
        public string Value { get; set; }

    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSDelimiter
    {
         
        [XmlAttributeAttribute()]
        public string value { get; set; }

        [XmlIgnoreAttribute()]
        public bool valueSpecified { get; set; }

        [XmlTextAttribute()]
        public string Value { get; set; }

    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponse
    {
         
        public RETSResponsePagination Pagination { get; set; }

        [XmlElementAttribute("AgentDetails")]
        public RETSResponseAgentDetails[] AgentDetails { get; set; }

        [XmlElementAttribute("Agent")]
        public RETSResponseAgent[] Agent { get; set; }

    }

    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgent
    {
        [XmlAttributeAttribute()]
        public string ID { get; set; }

        [XmlAttributeAttribute()]
        public string LastUpdated { get; set; }
    }

    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponsePagination
    {
         
        public string TotalRecords { get; set; }

        public string Limit { get; set; }

        public string Offset { get; set; }

        public string TotalPages { get; set; }

        public string RecordsReturned { get; set; }

    }

    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetails
    {

        [XmlElementAttribute("Address")]
        public RETSResponseAgentDetailsAddress AgentDetailsAddress { get; set; }

        [XmlElementAttribute("Board")]
        public string Board { get; set; }

        [XmlElementAttribute("Designations", typeof(RETSResponseAgentDetailsDesignations))]
        public RETSResponseAgentDetailsDesignations AgentDetailsDesignations { get; set; }

        [XmlElementAttribute("EducationCredentials")]
        public string EducationCredentials { get; set; }

        [XmlElementAttribute("Languages")]
        public RETSResponseAgentDetailsLanguages AgentDetailsLanguages { get; set; }

        [XmlElementAttribute("Name")]
        public string Name { get; set; }

        [XmlElementAttribute("Office", typeof(RETSResponseAgentDetailsOffice))]
        public RETSResponseAgentDetailsOffice AgentDetailsOffice { get; set; }

        [XmlElementAttribute("Phones")]
        public RETSResponseAgentDetailsPhones AgentDetailsPhones { get; set; }

        [XmlElementAttribute("PhotoLastUpdated")]
        public string PhotoLastUpdated { get; set; }

        [XmlElementAttribute("Position")]
        public string Position { get; set; }

        [XmlElementAttribute("Specialties", typeof(RETSResponseAgentDetailsSpecialties))]
        public RETSResponseAgentDetailsSpecialties AgentDetailsSpecialties { get; set; }

        [XmlElementAttribute("Websites", typeof(RETSResponseAgentDetailsWebsites))]
        public RETSResponseAgentDetailsWebsites AgentDetailsWebsites { get; set; }

        [XmlAttributeAttribute()]
        public int ID { get; set; }

        [XmlIgnoreAttribute()]
        public bool IDSpecified { get; set; }

        [XmlAttributeAttribute()]
        public string LastUpdated { get; set; }

    }

    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsAddress
    {

        public string StreetAddress { get; set; }

        public string AddressLine1 { get; set; }

        public string Addressline2 { get; set; }

        public string StreetNumber { get; set; }

        public string StreetName { get; set; }

        public string StreetSuffix { get; set; }

        public string UnitNumber { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Neighbourhood { get; set; }

        public string CommunityName { get; set; }

    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsDesignations
    {
         
        [XmlElementAttribute("Designation")]
        public string[] Designation { get; set; }

    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsLanguages
    {
         
        [XmlElementAttribute("Language")]
        public string[] Language { get; set; }
    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsOffice
    {
         
        public string Name { get; set; }

        public RETSResponseAgentDetailsOfficeAddress Address { get; set; }

        [XmlArrayItemAttribute("Phone", IsNullable = false)]
        public RETSResponseAgentDetailsOfficePhone[] Phones { get; set; }

        [XmlArrayItemAttribute("Website", IsNullable = false)]
        public RETSResponseAgentDetailsOfficeWebsite[] Websites { get; set; }

        public string OrganizationType { get; set; }

        [XmlAttributeAttribute()]
        public int ID { get; set; }

        [XmlIgnoreAttribute()]
        public bool IDSpecified { get; set; }

    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsOfficeAddress
    {
         
        public string StreetAddress { get; set; }

        public string AddressLine1 { get; set; }

        public string Addressline2 { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsOfficePhone
    {
         
        [XmlAttributeAttribute()]
        public string ContactType { get; set; }

        [XmlAttributeAttribute()]
        public string PhoneType { get; set; }

        [XmlTextAttribute()]
        public string Value { get; set; }
    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsOfficeWebsite
    {
         
        [XmlAttributeAttribute()]
        public string ContactType { get; set; }

        [XmlAttributeAttribute()]
        public string WebsiteType { get; set; }

        [XmlTextAttribute(DataType = "anyURI")]
        public string Value { get; set; }
    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsPhones
    {
         
        [XmlElementAttribute("Phone")]
        public RETSResponseAgentDetailsPhonesPhone[] Phone { get; set; }

    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsPhonesPhone
    {
         
        [XmlAttributeAttribute()]
        public string ContactType { get; set; }

        [XmlAttributeAttribute()]
        public string PhoneType { get; set; }

        [XmlTextAttribute()]
        public string Value { get; set; }

    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsSpecialties
    {
         
        [XmlElementAttribute("Specialty")]
        public string[] Specialty { get; set; }
    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsWebsites
    {
         
        [XmlElementAttribute("Website")]
        public RETSResponseAgentDetailsWebsitesWebsite[] Website { get; set; }

    }
     
    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Agent")]
    public partial class RETSResponseAgentDetailsWebsitesWebsite
    {
         
        [XmlAttributeAttribute()]
        public string ContactType { get; set; }

        [XmlAttributeAttribute()]
        public string WebsiteType { get; set; }

        [XmlTextAttribute()]
        public string Value { get; set; }
    }
     
}