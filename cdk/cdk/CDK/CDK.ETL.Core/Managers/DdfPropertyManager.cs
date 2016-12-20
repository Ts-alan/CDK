using System;
using System.Collections.Generic;
using CDK.ETL.DDF.DdfRawModel;
using CDK.ETL.DDF.Property;

namespace CDK.ETL.Core.Managers
{
    class DdfPropertyManager
    {

        public static PropertyBusiness getBusiness(RETSResponsePropertyDetailsBusiness business)
        {

            if (business != null)
            {

                PropertyBusiness propertyBusiness = new PropertyBusiness()
                {

                    BusinessType = business.BusinessType,
                    BusinessSubType = business.BusinessSubType,
                    EstablishedDate = business.EstablishedDate,
                    Franchise = business.Franchise,
                    Name = business.Name,
                    OperatingSince = business.OperatingSince,

                };

                return propertyBusiness;

            }

            return null;

        }

        public static List<PropertyOpenHouse> getOpenHouse(RETSResponsePropertyDetailsOpenHouse openHouses)
        {

            if (openHouses != null)
            {
                List<PropertyOpenHouse> propertyOpenHouses = new List<PropertyOpenHouse>();
                if (openHouses.Event != null)
                {
                    foreach (RETSResponsePropertyDetailsOpenHouseEvent openHouseEvent in openHouses.Event)
                    {
                        PropertyOpenHouse propertyOpenHouse = new PropertyOpenHouse()
                        {
                            StartDateTime = openHouseEvent.StartDateTime,
                            EndDateTime = openHouseEvent.EndDateTime,
                            Comments = openHouseEvent.Comments,
                        };
                        propertyOpenHouses.Add(propertyOpenHouse);
                    }
                }

                return propertyOpenHouses;

            }

            return null;

        }

        public static PropertyAlternateUrl getAlternateUrl(RETSResponsePropertyDetailsAlternateURL alternateUrl)
        {

            if (alternateUrl != null)
            {

                PropertyAlternateUrl propertyAlternateUrl = new PropertyAlternateUrl()
                {
                    BrochureLink = alternateUrl.BrochureLink,
                    MapLink = alternateUrl.MapLink,
                    PhotoLink = alternateUrl.PhotoLink,
                    SoundLink = alternateUrl.SoundLink,
                    VideoLink = alternateUrl.VideoLink
                };

                return propertyAlternateUrl;

            }

            return null;

        }

        public static List<PropertyUtilitiesAvailable> getUtilityAvailable(RETSResponsePropertyDetailsUtilitiesAvailable utilitiesAvailable)
        {

            if (utilitiesAvailable != null)
            {
                List<PropertyUtilitiesAvailable> utilitiesAvailableLst = new List<PropertyUtilitiesAvailable>();

                if (utilitiesAvailable.Utility != null)
                {
                    foreach (RETSResponsePropertyDetailsUtilitiesAvailableUtility utilityAvailable in utilitiesAvailable.Utility)
                    {
                        PropertyUtilitiesAvailable propertyUtilitiesAvailable = new PropertyUtilitiesAvailable()
                        {
                            Type = utilityAvailable.Type,
                            Description = utilityAvailable.Description,
                        };
                        utilitiesAvailableLst.Add(propertyUtilitiesAvailable);
                    }
                }

                return utilitiesAvailableLst;

            }

            return null;

        }

        public static List<PropertyParkingSpace> getParkingsSpace(RETSResponsePropertyDetailsParkingSpaces parkingSpaceParkingSpaces)
        {

            if (parkingSpaceParkingSpaces != null)
            {
                List<PropertyParkingSpace> parkingSpaces = new List<PropertyParkingSpace>();

                if (parkingSpaceParkingSpaces.Parking != null)
                {
                    foreach (RETSResponsePropertyDetailsParkingSpacesParking parkingSpaceParking in parkingSpaceParkingSpaces.Parking)
                    {
                        PropertyParkingSpace propertyParkingSpace = new PropertyParkingSpace()
                        {
                            Name = parkingSpaceParking.Name,
                            Spaces = parkingSpaceParking.Spaces,
                        };
                        parkingSpaces.Add(propertyParkingSpace);
                    }
                }

                return parkingSpaces;

            }

            return null;

        }

        public static RETSResponsePropertyDetailsAddress getAdresses(RETSResponsePropertyDetailsAddress address)
        {
            if (address == null)
            {
                return address = new RETSResponsePropertyDetailsAddress();
            }

            return address;
        }

        public static PropertyBuilding getBuilding(RETSResponsePropertyDetailsBuilding building)
        {
            if (building != null)
            {

                List<PropertyBuildingRoom> buildingRooms = DdfPropertyManager.getBuildingRooms(building.Rooms);

                PropertyBuilding PropertyBuilding = new PropertyBuilding()
                {
                    PropertyBuildingRoom = buildingRooms,
                    BathroomTotal = building.BathroomTotal,
                    BedroomsAboveGround = building.BedroomsAboveGround,
                    BedroomsBelowGround = building.BedroomsBelowGround,
                    BedroomsTotal = building.BedroomsTotal,
                    Age = building.Age,
                    Amenities = building.Amenities,
                    Amperage = building.Amperage,
                    Anchor = building.Anchor,
                    Appliances = building.Appliances,
                    ArchitecturalStyle = building.ArchitecturalStyle,
                    BasementDevelopment = building.BasementDevelopment,
                    BasementFeatures = building.BasementFeatures,
                    BasementType = building.BasementType,
                    BomaRating = building.BomaRating,
                    CeilingHeight = building.CeilingHeight,
                    CeilingType = building.CeilingType,
                    ClearCeilingHeight = building.ClearCeilingHeight,
                    ConstructedDate = building.ConstructedDate,
                    ConstructionMaterial = building.ConstructionMaterial,
                    ConstructionStatus = building.ConstructionStatus,
                    ConstructionStyleAttachment = building.ConstructionStyleAttachment,
                    ConstructionStyleOther = building.ConstructionStyleOther,
                    ConstructionStyleSplitLevel = building.ConstructionStyleSplitLevel,
                    CoolingType = building.CoolingType,
                    EnerguideRating = building.EnerguideRating,
                    ExteriorFinish = building.ExteriorFinish,
                    FireProtection = building.FireProtection,
                    FireplaceFuel = building.FireplaceFuel,
                    FireplacePresent = building.FireplacePresent,
                    FireplaceTotal = building.FireplaceTotal,
                    FireplaceType = building.FireplaceType,
                    Fixture = building.Fixture,
                    FlooringType = building.FlooringType,
                    FoundationType = building.FoundationType,
                    HalfBathTotal = building.HalfBathTotal,
                    HeatingFuel = building.HeatingFuel,
                    HeatingType = building.HeatingType,
                    LeedsCategory = building.LeedsCategory,
                    LeedsRating = building.LeedsRating,
                    RenovatedDate = building.RenovatedDate,
                    RoofMaterial = building.RoofMaterial,
                    RoofStyle = building.RoofStyle,
                    StoriesTotal = building.StoriesTotal,
                    SizeExterior = building.SizeExterior,
                    SizeInterior = building.SizeInterior,
                    SizeInteriorFinished = building.SizeInteriorFinished,
                    StoreFront = building.StoreFront,
                    TotalFinishedArea = building.TotalFinishedArea,
                    Type = building.Type,
                    Uffi = building.Uffi,
                    UnitType = building.UnitType,
                    UtilityPower = building.UtilityPower,
                    UtilityWater = building.UtilityWater,
                    VacancyRate = building.VacancyRate,
                    LastUpdate = DateTime.Now

                };

                return PropertyBuilding;

            }

            return new PropertyBuilding() { LastUpdate = DateTime.Now };

        }

        public static List<PropertyAgent> getAgent(RETSResponsePropertyDetailsAgentDetails[] agent)
        {

            if (agent != null)
            {

                List<PropertyAgent> propertyAgents = new List<PropertyAgent>();

                foreach (RETSResponsePropertyDetailsAgentDetails tmpAgent in agent)
                {

                    List<PropertyAgentDesignation> propertyAgentDesignation = DdfPropertyManager.getAgentDesignation(tmpAgent.Designations);
                    List<PropertyAgentLanguage> propertyAgentLanguage = DdfPropertyManager.getAgentLanguage(tmpAgent.Languages);
                    List<PropertyAgentPhone> propertyAgentPhone = DdfPropertyManager.getAgentPhone(tmpAgent.Phones);
                    List<PropertyAgentSpeciality> propertyAgentSpeciality = DdfPropertyManager.getAgentSpeciality(tmpAgent.Specialties);
                    List<PropertyAgentTradingArea> propertyAgentTradingArea = DdfPropertyManager.getAgentTradingArea(tmpAgent.TradingAreas);
                    List<PropertyAgentWebsite> propertyAgentWebsite = DdfPropertyManager.getAgentWebsite(tmpAgent.Websites);
                    PropertyAgentOffice propertyAgentOffice = DdfPropertyManager.getPropertyAgentOfficeOffice(tmpAgent.Office);

                    PropertyAgent propertyAgent = new PropertyAgent()
                    {
                        PropertyAgentId = long.Parse(tmpAgent.ID),
                        DdfAgentId = tmpAgent.ID,
                        PropertyAgentDesignation = propertyAgentDesignation,
                        PropertyAgentLanguage = propertyAgentLanguage,
                        PropertyAgentPhone = propertyAgentPhone,
                        PropertyAgentSpeciality = propertyAgentSpeciality,
                        PropertyAgentWebsite = propertyAgentWebsite,
                        PropertyAgentTradingArea = propertyAgentTradingArea,
                        PropertyAgentOffice = propertyAgentOffice,
                        Name = tmpAgent.Name,
                        Position = tmpAgent.Position,
                        EducationCredentials = tmpAgent.EducationCredentials,
                        StreetAddress = tmpAgent.Address != null ? tmpAgent.Address.StreetAddress : null,
                        AddressLine1 = tmpAgent.Address != null ? tmpAgent.Address.AddressLine1 : null,
                        Addressline2 = tmpAgent.Address != null ? tmpAgent.Address.Addressline2 : null,
                        StreetNumber = tmpAgent.Address != null ? tmpAgent.Address.StreetNumber : null,
                        StreetName = tmpAgent.Address != null ? tmpAgent.Address.StreetName : null,
                        StreetSuffix = tmpAgent.Address != null ? tmpAgent.Address.StreetSuffix : null,
                        City = tmpAgent.Address != null ? tmpAgent.Address.City : null,
                        Province = tmpAgent.Address != null ? tmpAgent.Address.Province : null,
                        PostalCode = tmpAgent.Address != null ? tmpAgent.Address.PostalCode : null,
                        LastUpdate = DateTime.Now

                    };

                    propertyAgents.Add(propertyAgent);

                }

                return propertyAgents;

            }

            return null;

        }

        public static List<PropertyAgentPhone> getAgentPhone(RETSResponsePropertyDetailsAgentDetailsPhone agentPhone)
        {
            if (agentPhone != null)
            {
                List<PropertyAgentPhone> phones = new List<PropertyAgentPhone>();

                if (agentPhone.Phone != null)
                {
                    foreach (RETSResponsePropertyDetailsAgentDetailsPhonePhone phone in agentPhone.Phone)
                    {
                        PropertyAgentPhone propertyAgentPhone = new PropertyAgentPhone()
                        {
                            ContactType = phone.ContactType,
                            PhoneType = phone.PhoneType,
                            PhoneNumber = phone.Value
                        };
                        phones.Add(propertyAgentPhone);
                    }
                }

                return phones;

            }
            return null;
        }

        public static List<PropertyAgentLanguage> getAgentLanguage(RETSResponsePropertyDetailsAgentDetailsLanguage agentLanguage)
        {
            if (agentLanguage != null)
            {
                List<PropertyAgentLanguage> languages = new List<PropertyAgentLanguage>();

                if (agentLanguage.Language != null)
                {
                    foreach (string language in agentLanguage.Language)
                    {
                        PropertyAgentLanguage propertyAgentLanguage = new PropertyAgentLanguage()
                        {
                            Language = language
                        };
                        languages.Add(propertyAgentLanguage);
                    }
                }

                return languages;

            }
            return null;
        }

        public static List<PropertyAgentTradingArea> getAgentTradingArea(RETSResponsePropertyDetailsAgentDetailsTradingArea agentTradingArea)
        {
            if (agentTradingArea != null)
            {
                List<PropertyAgentTradingArea> tradingAreas = new List<PropertyAgentTradingArea>();

                if (agentTradingArea.TradingArea != null)
                {
                    foreach (string tradingArea in agentTradingArea.TradingArea)
                    {
                        PropertyAgentTradingArea propertyAgentTradingArea = new PropertyAgentTradingArea()
                        {
                            TradingArea = tradingArea
                        };
                        tradingAreas.Add(propertyAgentTradingArea);
                    }
                }

                return tradingAreas;

            }
            return null;
        }

        public static List<PropertyAgentDesignation> getAgentDesignation(RETSResponsePropertyDetailsAgentDetailsDesignation agentDesignation)
        {
            if (agentDesignation != null)
            {
                List<PropertyAgentDesignation> designations = new List<PropertyAgentDesignation>();

                foreach (string designation in agentDesignation.Designation)
                {
                    PropertyAgentDesignation propertyAgentDesignation = new PropertyAgentDesignation()
                    {
                        Designation = designation
                    };
                    designations.Add(propertyAgentDesignation);
                }
                return designations;

            }
            return null;
        }

        public static List<PropertyAgentSpeciality> getAgentSpeciality(RETSResponsePropertyDetailsAgentDetailsSpecialtiy agentSpeciality)
        {
            if (agentSpeciality != null)
            {
                List<PropertyAgentSpeciality> specialities = new List<PropertyAgentSpeciality>();

                if (agentSpeciality.Specialty != null)
                {
                    foreach (string speciality in agentSpeciality.Specialty)
                    {
                        PropertyAgentSpeciality propertyAgentSpeciality = new PropertyAgentSpeciality()
                        {
                            Specialtie = speciality
                        };
                        specialities.Add(propertyAgentSpeciality);
                    }
                }

                return specialities;

            }
            return null;
        }

        public static List<PropertyAgentWebsite> getAgentWebsite(RETSResponsePropertyDetailsAgentDetailsWebsites agentWebsite)
        {
            if (agentWebsite != null)
            {
                List<PropertyAgentWebsite> websites = new List<PropertyAgentWebsite>();

                if (agentWebsite.Website != null)
                {
                    foreach (RETSResponsePropertyDetailsAgentDetailsWebsitesWebsite website in agentWebsite.Website)
                    {
                        PropertyAgentWebsite propertyAgentWebsite = new PropertyAgentWebsite()
                        {
                            ContactType = website.ContactType,
                            WebsiteType = website.WebsiteType,
                            WebsiteUrl = website.Value
                        };
                        websites.Add(propertyAgentWebsite);
                    }
                }

                return websites;

            }
            return null;
        }

        public static PropertyAgentOffice getPropertyAgentOfficeOffice(RETSResponsePropertyDetailsAgentDetailsOffice office)
        {

            if (office != null)
            {

                List<PropertyAgentOfficePhone> propertyAgentOfficePhone = DdfPropertyManager.getOfficePhone(office.Phones);
                List<PropertyAgentOfficeWebsite> propertyAgentOfficeWebsite = DdfPropertyManager.getOfficeWebsite(office.Websites);

                PropertyAgentOffice propertyAgentOffice = new PropertyAgentOffice()
                {
                    PropertyAgentOfficeId = long.Parse(office.ID),
                    PropertyAgentOfficePhone = propertyAgentOfficePhone,
                    PropertyAgentOfficeWebsite = propertyAgentOfficeWebsite,
                    DdfPropertyAgentOfficeId = office.ID,
                    Name = office.Name,
                    StreetAddress = office.Address != null ? office.Address.StreetAddress : null,
                    AddressLine1 = office.Address != null ? office.Address.AddressLine1 : null,
                    City = office.Address != null ? office.Address.City : null,
                    PostalCode = office.Address != null ? office.Address.PostalCode : null,
                    Country = office.Address != null ? office.Address.Country : null,
                    Franchisor = office.Franchisor,
                    LogoLastUpdated = office.LogoLastUpdated,
                    OrganizationType = office.OrganizationType,
                    Designation = office.Designation,
                    LastUpdate = DateTime.Now
                };

                return propertyAgentOffice;

            }

            return null;

        }

        public static List<PropertyAgentOfficePhone> getOfficePhone(RETSResponsePropertyDetailsAgentDetailsOfficePhone officePhone)
        {
            if (officePhone != null)
            {
                List<PropertyAgentOfficePhone> phones = new List<PropertyAgentOfficePhone>();

                if (officePhone.Phone != null)
                {
                    foreach (RETSResponsePropertyDetailsAgentDetailsOfficePhonePhone phone in officePhone.Phone)
                    {
                        PropertyAgentOfficePhone propertyAgentOfficePhone = new PropertyAgentOfficePhone()
                        {
                            ContactType = phone.ContactType,
                            PhoneType = phone.PhoneType,
                            PhoneNumber = phone.Value
                        };
                        phones.Add(propertyAgentOfficePhone);
                    }
                }

                return phones;

            }
            return null;
        }

        public static List<PropertyAgentOfficeWebsite> getOfficeWebsite(RETSResponsePropertyDetailsAgentDetailsOfficeWebsites officeWebsite)
        {
            if (officeWebsite != null)
            {
                List<PropertyAgentOfficeWebsite> websites = new List<PropertyAgentOfficeWebsite>();

                if (officeWebsite.Website != null)
                {
                    foreach (RETSResponsePropertyDetailsAgentDetailsOfficeWebsitesWebsite website in officeWebsite.Website)
                    {
                        PropertyAgentOfficeWebsite propertyAgentOfficeWebsite = new PropertyAgentOfficeWebsite()
                        {
                            ContactType = website.ContactType,
                            WebsiteType = website.WebsiteType,
                            WebsiteUrl = website.Value
                        };
                        websites.Add(propertyAgentOfficeWebsite);
                    }
                }

                return websites;

            }
            return null;
        }

        public static Property getPropertyGrap(RETSResponsePropertyDetails PropertyDetail)
        {

            if (PropertyDetail != null)
            {

                PropertyDetail.Address = DdfPropertyManager.getAdresses(PropertyDetail.Address);

                List<PropertyAgent> propertyAgent = DdfPropertyManager.getAgent(PropertyDetail.AgentDetails);
                PropertyBuilding propertyBuilding = DdfPropertyManager.getBuilding(PropertyDetail.Building);
                PropertyLand propertyLand = DdfPropertyManager.getLand(PropertyDetail.Land);
                List<PropertyPhoto> propertyPhotos = DdfPropertyManager.getPropertyPhotos(PropertyDetail.Photo, PropertyDetail.ID, PropertyDetail.Address);
                List<PropertyParkingSpace> parkingSpaceParking = DdfPropertyManager.getParkingsSpace(PropertyDetail.ParkingSpaces);
                PropertyBusiness propertyBusiness = DdfPropertyManager.getBusiness(PropertyDetail.Business);
                PropertyAlternateUrl propertyAlternateUrl = DdfPropertyManager.getAlternateUrl(PropertyDetail.AlternateURL);
                List<PropertyOpenHouse> propertyOpenHouse = DdfPropertyManager.getOpenHouse(PropertyDetail.OpenHouse);
                List<PropertyUtilitiesAvailable> propertyUtilitiesAvailable = DdfPropertyManager.getUtilityAvailable(PropertyDetail.UtilitiesAvailable);

                Property Property = new Property()
                {

                    PropertyPhoto = propertyPhotos,
                    PropertyLand = propertyLand,
                    PropertyBuilding = propertyBuilding,
                    PropertyAgent = propertyAgent,
                    PropertyBusiness = propertyBusiness,
                    PropertyAlternateUrl = propertyAlternateUrl,
                    PropertyOpenHouse = propertyOpenHouse,
                    PropertyUtilitiesAvailable = propertyUtilitiesAvailable,
                    PropertyParkingSpace = parkingSpaceParking,
                    StreetAddress = PropertyDetail.Address != null ? PropertyDetail.Address.StreetAddress : null,
                    AddressLine1 = PropertyDetail.Address != null ? PropertyDetail.Address.AddressLine1 : null,
                    AddressLine2 = PropertyDetail.Address != null ? PropertyDetail.Address.Addressline2 : null,
                    StreetNumber = PropertyDetail.Address != null ? PropertyDetail.Address.StreetNumber : null,
                    StreetName = PropertyDetail.Address != null ? PropertyDetail.Address.StreetName : null,
                    StreetSuffix = PropertyDetail.Address != null ? PropertyDetail.Address.StreetSuffix : null,
                    City = PropertyDetail.Address != null ? PropertyDetail.Address.City : null,
                    CountryState = PropertyDetail.Address != null ? PropertyDetail.Address.Province : null,
                    PostalCode = PropertyDetail.Address != null ? PropertyDetail.Address.PostalCode : null,
                    Country = PropertyDetail.Address != null ? PropertyDetail.Address.Country : null,
                    AmmenitiesNearBy = PropertyDetail.AmmenitiesNearBy,
                    CommunicationType = PropertyDetail.CommunicationType,
                    CommunityFeatures = PropertyDetail.CommunityFeatures,
                    Crop = PropertyDetail.Crop,
                    DocumentType = PropertyDetail.DocumentType,
                    EquipmentType = PropertyDetail.EquipmentType,
                    Easement = PropertyDetail.Easement,
                    FarmType = PropertyDetail.FarmType,
                    Features = PropertyDetail.Features,
                    IrrigationType = PropertyDetail.IrrigationType,
                    Lease = PropertyDetail.Lease,
                    LeasePerTime = PropertyDetail.LeasePerTime,
                    LeasePerUnit = PropertyDetail.LeasePerUnit,
                    LeaseTermRemaining = PropertyDetail.LeaseTermRemaining,
                    LeaseTermRemainingFreq = PropertyDetail.LeaseTermRemainingFreq,
                    LeaseType = PropertyDetail.LeaseType,
                    LiveStockType = PropertyDetail.LiveStockType,
                    LoadingType = PropertyDetail.LoadingType,
                    LocationDescription = PropertyDetail.LocationDescription,
                    Machinery = PropertyDetail.Machinery,
                    MaintenanceFee = PropertyDetail.MaintenanceFee,
                    MaintenanceFeePaymentUnit = PropertyDetail.MaintenanceFeePaymentUnit,
                    MaintenanceFeeType = PropertyDetail.MaintenanceFeeType,
                    ManagementCompany = PropertyDetail.ManagementCompany,
                    MunicipalId = PropertyDetail.MunicipalId,
                    OwnershipType = PropertyDetail.OwnershipType,
                    ParkingSpaceTotal = PropertyDetail.ParkingSpaceTotal,
                    Plan = PropertyDetail.Plan,
                    PoolType = PropertyDetail.PoolType,
                    PoolFeatures = PropertyDetail.PoolFeatures,
                    Price = PropertyDetail.Price,
                    PricePerTime = PropertyDetail.PricePerTime,
                    PricePerUnit = PropertyDetail.PricePerUnit,
                    PropertyType = PropertyDetail.PropertyType,
                    PublicRemarks = PropertyDetail.PublicRemarks,
                    RentalEquipmentType = PropertyDetail.RentalEquipmentType,
                    RightType = PropertyDetail.RightType,
                    RoadType = PropertyDetail.RoadType,
                    StorageType = PropertyDetail.StorageType,
                    Structure = PropertyDetail.Structure,
                    SignType = PropertyDetail.SignType,
                    TransactionType = PropertyDetail.TransactionType,
                    TotalBuildings = PropertyDetail.TotalBuildings,
                    ViewType = PropertyDetail.ViewType,
                    WaterFrontType = PropertyDetail.WaterFrontType,
                    WaterFrontName = PropertyDetail.WaterFrontName,
                    AdditionalInformationIndicator = PropertyDetail.AdditionalInformationIndicator,
                    ZoningDescription = PropertyDetail.ZoningDescription,
                    ZoningType = PropertyDetail.ZoningType,
                    MoreInformationLink = PropertyDetail.MoreInformationLink,
                    AnalyticsClick = PropertyDetail.AnalyticsClick,
                    AnalyticsView = PropertyDetail.AnalyticsView,
                    Board = PropertyDetail.Board,
                    DdfPropertyId = PropertyDetail.ID,
                    ListingId = PropertyDetail.ListingID,
                    LastDdfUpdate = string.IsNullOrEmpty(PropertyDetail.LastUpdated) ? DateTime.ParseExact(PropertyDetail.LastUpdated, "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture) : DateTime.Now,
                    LastUpdate = DateTime.Now

                };

                return Property;

            }

            return null;

        }

        public static PropertyLand getLand(RETSResponsePropertyDetailsLand land)
        {
            if (land != null)
            {

                PropertyLand PropertyLand = new PropertyLand()
                {

                    SizeTotal = land.SizeTotal,
                    SizeTotalText = land.SizeTotalText,
                    SizeFrontage = land.SizeFrontage,
                    AccessType = land.AccessType,
                    Acreage = land.Acreage,
                    Amenities = land.Amenities,
                    ClearedTotal = land.ClearedTotal,
                    CurrentUse = land.CurrentUse,
                    Divisible = land.Divisible,
                    FenceTotal = land.FenceTotal,
                    FenceType = land.FenceType,
                    FrontsOn = land.FrontsOn,
                    LandDisposition = land.LandDisposition,
                    LandscapeFeatures = land.LandscapeFeatures,
                    PastureTotal = land.PastureTotal,
                    Sewer = land.Sewer,
                    SizeDepth = land.SizeDepth,
                    SizeIrregular = land.SizeIrregular,
                    SoilEvaluation = land.SoilEvaluation,
                    SoilType = land.SoilType,
                    SurfaceWater = land.SurfaceWater,
                    TiledTotal = land.TiledTotal,
                    TopographyType = land.TopographyType,
                    LastUpdate = DateTime.Now
                };

                return PropertyLand;

            }

            return new PropertyLand() { LastUpdate = DateTime.Now };

        }

        public static List<PropertyBuildingRoom> getBuildingRooms(RETSResponsePropertyDetailsBuildingRooms buildingRooms)
        {
            if (buildingRooms != null)
            {

                List<PropertyBuildingRoom> PropertyBuildingRooms = new List<PropertyBuildingRoom>();

                if (buildingRooms.Room != null)
                {
                    foreach (RETSResponsePropertyDetailsBuildingRoomsRoom room in buildingRooms.Room)
                    {
                        PropertyBuildingRoom PropertyBuildingRoom = new PropertyBuildingRoom()
                        {
                            Dimension = room.Dimension,
                            Length = room.Length,
                            Level = room.Level,
                            Type = room.Type,
                            Width = room.Width,
                            Description = room.Description,
                            LastUpdate = DateTime.Now
                        };
                        PropertyBuildingRooms.Add(PropertyBuildingRoom);
                    }
                }

                return PropertyBuildingRooms;

            }

            return null;

        }

        public static List<PropertyPhoto> getPropertyPhotos(RETSRETSRESPONSEPropertyDetailsPhoto photos, String ddfPropertyId, RETSResponsePropertyDetailsAddress address)
        {
            if (photos != null)
            {


                List<PropertyPhoto> PropertyPhotos = new List<PropertyPhoto>();

                string cityName = "Unknown";

                if (address!=null) { cityName = address.City; }
                
                if (photos.PropertyPhoto != null)
                {
                    foreach (RETSResponsePropertyDetailsPhotoPropertyPhoto photo in photos.PropertyPhoto)
                    {
                        PropertyPhoto PropertyPhoto = new PropertyPhoto()
                        {
                            DdfSequenceId = photo.SequenceId,
                            DdfPropertyId = ddfPropertyId,
                            LastDdfUpdate = string.IsNullOrEmpty(photo.LastUpdated) ? DateTime.ParseExact(photo.LastUpdated, "yyyy-MM-ddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture) : DateTime.Now,
                            LastUpdate = DateTime.Now
                        };
                        PropertyPhotos.Add(PropertyPhoto);
                    }
                }

                return PropertyPhotos;

            }

            return null;

        }

    }
}
