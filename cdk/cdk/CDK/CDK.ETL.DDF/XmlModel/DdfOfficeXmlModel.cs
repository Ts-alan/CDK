using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CDK.ETL.DDF.Office
{

    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    public partial class RETS
    {

        public RETSCount COUNT { get; set; }

        public RETSDelimiter DELIMITER { get; set; }

        // Namespace is needed here. If regenerate manually put the Namespace
        [XmlElementAttribute("RETS-RESPONSE", Namespace = "urn:CREA.Search.Office")]
        public RETSResponse RETSResponse { get; set; }

        [XmlAttributeAttribute()]
        public sbyte ReplyCode { get; set; }

        [XmlIgnoreAttribute()]
        public bool ReplyCodeSpecified { get; set; }

        [XmlAttributeAttribute()]
        public string ReplyText { get; set; }

    }

    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
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
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
    public partial class RETSDelimiter
    {

        [XmlAttributeAttribute()]
        public sbyte value { get; set; }

        [XmlIgnoreAttribute()]
        public bool valueSpecified { get; set; }

        [XmlTextAttribute()]
        public string Value { get; set; }
    }

    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
    public partial class RETSResponse
    {

        public RETSResponsePagination Pagination { get; set; }

        [XmlElementAttribute("OfficeDetails")]
        public RETSResponseOfficeDetails[] OfficeDetails { get; set; }

        [XmlElementAttribute("Office")]
        public RETSResponseOffice[] Office { get; set; }

    }

    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
    public partial class RETSResponseOffice
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
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
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
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
    public partial class RETSResponseOfficeDetails
    {
        
        public string Name { get; set; }

        public sbyte Board { get; set; }

        public string LogoLastUpdated { get; set; }

        public RETSResponseOfficeDetailsAddress Address { get; set; }

        [XmlElementAttribute("Phones")]
        public RETSResponseOfficeDetailsPhone Phones { get; set; }

        [XmlElementAttribute("Websites")]
        public RETSResponseOfficeDetailsWebsite Websites { get; set; }

        public string OrganizationType { get; set; }

        public string Designation { get; set; }

        public string Franchisor { get; set; }

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
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
    public partial class RETSResponseOfficeDetailsAddress
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
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
    public partial class RETSResponseOfficeDetailsPhone
    {
        [XmlElementAttribute("Phone")]
        public RETSResponseOfficeDetailsPhonePhone[] Phone { get; set; }

    }

    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
    public partial class RETSResponseOfficeDetailsPhonePhone
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
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
    public partial class RETSResponseOfficeDetailsWebsite
    {
        [XmlElementAttribute("website")]
        public RETSResponseOfficeDetailsWebsiteWebsite[] Website { get; set; }

    }

    [GeneratedCodeAttribute("Xml", "4.0.30319.34283")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:CREA.Search.Office")]
    public partial class RETSResponseOfficeDetailsWebsiteWebsite
    {
        
        [XmlAttributeAttribute()]
        public string ContactType { get; set; }

        [XmlAttributeAttribute()]
        public string WebsiteType { get; set; }

        [XmlTextAttribute()]
        public string Value { get; set; }
    }
}