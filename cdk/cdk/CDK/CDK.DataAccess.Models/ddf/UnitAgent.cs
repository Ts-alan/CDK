using Repository.Pattern.Ef6;

namespace CDK.DataAccess.Models.ddf
{
    public class UnitAgent : Entity
    {
        public long Id
        {
            get; set;
        }

        public long? UnitAgentOfficeId
        {
            get; set;
        }

        public string DdfAgentId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Position
        {
            get; set;
        }

        public System.DateTime LastUpdate
        {
            get; set;
        }

        public string EducationCredentials
        {
            get; set;
        }

        public System.DateTime? PhotoLastUpdated
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

        public string Addressline2
        {
            get; set;
        }

        public string StreetNumber
        {
            get; set;
        }

        public string StreetName
        {
            get; set;
        }

        public string StreetSuffix
        {
            get; set;
        }

        public string City
        {
            get; set;
        }

        public string Province
        {
            get; set;
        }

        public string PostalCode
        {
            get; set;
        }

        public string ThumbnailPhotoUri
        {
            get; set;
        }

        public string LargePhotoUri
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<ABoard> ABoards
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<ALanguage> ALanguages
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<IndividualDesignation> IndividualDesignations
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Specialtie> Specialties
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<Unit> Units
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgentContact> UnitAgentContacts
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgentDesignation> UnitAgentDesignations
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgentLanguage> UnitAgentLanguages
        {
            get; set;
        }

        public virtual UnitAgentOffice UnitAgentOffice
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgentPhone> UnitAgentPhones
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgentSpeciality> UnitAgentSpecialities
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgentTradingArea> UnitAgentTradingAreas
        {
            get; set;
        }

        public virtual System.Collections.Generic.ICollection<UnitAgentWebsite> UnitAgentWebsites
        {
            get; set;
        }

        public UnitAgent()
        {
            UnitAgentContacts = new System.Collections.Generic.HashSet<UnitAgentContact>();
            UnitAgentDesignations = new System.Collections.Generic.HashSet<UnitAgentDesignation>();
            UnitAgentLanguages = new System.Collections.Generic.HashSet<UnitAgentLanguage>(); 
            UnitAgentPhones = new System.Collections.Generic.HashSet<UnitAgentPhone>();
            UnitAgentSpecialities = new System.Collections.Generic.HashSet<UnitAgentSpeciality>();
            UnitAgentTradingAreas = new System.Collections.Generic.HashSet<UnitAgentTradingArea>();
            UnitAgentWebsites = new System.Collections.Generic.HashSet<UnitAgentWebsite>();
            ABoards = new System.Collections.Generic.HashSet<ABoard>();
            ALanguages = new System.Collections.Generic.HashSet<ALanguage>();
            IndividualDesignations = new System.Collections.Generic.HashSet<IndividualDesignation>();
            Specialties = new System.Collections.Generic.HashSet<Specialtie>();
            Units = new System.Collections.Generic.HashSet<Unit>();
        }
    }
}