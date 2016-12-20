using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitAgentOffice : Entity
    {
        public long Id
        {
            get; set;
        }

        public string DdfUnitAgentOfficeId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string StreetAddress
        {
            get; set;
        }

        public string AddressLine1
        {
            get; set;
        }

        public string City
        {
            get; set;
        }

        public string PostalCode
        {
            get; set;
        }

        public string Country
        {
            get; set;
        }

        public string Franchisor
        {
            get; set;
        }

        public string LogoLastUpdated
        {
            get; set;
        }

        public string LogoUri
        {
            get; set;
        }

        public string OrganizationType
        {
            get; set;
        }

        public string Designation
        {
            get; set;
        }

        public System.DateTime LastUpdate
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Franchisor> Franchisors
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<OrganizationDesignation> OrganizationDesignations
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<OrganizationType> OrganizationTypes
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgentOfficePhone> UnitAgentOfficePhones
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgentOfficeWebsite> UnitAgentOfficeWebsites
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgent> UnitAgents
        {
            get; set;
        }

        public UnitAgentOffice()
        {
            UnitAgentOfficePhones = new System.Collections.Generic.HashSet<UnitAgentOfficePhone>();
            UnitAgentOfficeWebsites = new System.Collections.Generic.HashSet<UnitAgentOfficeWebsite>();
            Franchisors = new System.Collections.Generic.HashSet<Franchisor>();
            OrganizationDesignations = new System.Collections.Generic.HashSet<OrganizationDesignation>();
            OrganizationTypes = new System.Collections.Generic.HashSet<OrganizationType>();
            UnitAgents = new System.Collections.Generic.HashSet<UnitAgent>();
        }
    }
}