using System;
using System.Collections.Generic;
using CDK.ETL.DDF.Office;
using CDK.DataAccess.Models;
using CDK.DataAccess.Repositories;
using System.Linq;
using System.IO;
using System.Configuration;
using CDK.ETL.DDF.DdfRawModel;
using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF;
using CDK.ETL.Core.Services;

namespace CDK.ETL.Core.Managers
{
    public class DdfOfficeManager
    {

        OfficeCRUDService officeCRUDService = null;

        public DdfOfficeManager(RestSession session)
        {
            this.officeCRUDService = new OfficeCRUDService(session);
        }

        public  bool CreateUpdateAgentOffice(List<RETS> retsOfficeList)
        {

            using (var contextDdf = new CDKDbContext())
            {
                int count=0;
                foreach (CDK.ETL.DDF.Office.RETS rets in retsOfficeList)
                {
                    foreach (var officeDetail in rets.RETSResponse.OfficeDetails)
                    {
                        try
                        {

                            PropertyAgentOffice propertyOfficeAgent = getPropertyAgentOffice(officeDetail);
                            officeCRUDService.CreateOrUpdate(propertyOfficeAgent);
                            count++;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Can't insert office {0} due to <{1}>", officeDetail.ID, e.Message);
                        }
                    }
                }
                Console.WriteLine(string.Format(">>> INSERTED/UPDATED ({0}) OFFICE", count));
            }

            return true;

        }

        public  PropertyAgentOffice getPropertyAgentOffice(RETSResponseOfficeDetails office)
        {

            if (office != null)
            {

                List<PropertyAgentOfficePhone> propertyAgentOfficePhone = getPropertyAgentOfficePhone(office.Phones, office.ID);
                List<PropertyAgentOfficeWebsite> propertyAgentOfficeWebsite = getPropertyAgentOfficeWebsite(office.Websites, office.ID);

                PropertyAgentOffice propertyAgentOffice = new PropertyAgentOffice()
                {

                    PropertyAgentOfficeId = office.ID,
                    PropertyAgentOfficePhone = propertyAgentOfficePhone,
                    PropertyAgentOfficeWebsite = propertyAgentOfficeWebsite,
                    DdfPropertyAgentOfficeId = office.ID.ToString(),
                    Name = office.Name,
                    StreetAddress = office.Address != null ? office.Address.StreetAddress : null,
                    AddressLine1 = office.Address != null ? office.Address.AddressLine1 : null,
                    Addressline2 = office.Address != null ? office.Address.Addressline2 : null,
                    StreetNumber = office.Address != null ? office.Address.StreetNumber : null,
                    StreetName = office.Address != null ? office.Address.StreetName : null,
                    StreetSuffix = office.Address != null ? office.Address.StreetSuffix : null,
                    City = office.Address != null ? office.Address.City : null,
                    Province = office.Address != null ? office.Address.Province : null,
                    PostalCode = office.Address != null ? office.Address.PostalCode : null,
                    Franchisor = office.Franchisor,
                    LogoLastUpdated = office.LogoLastUpdated,
                    OrganizationType = office.OrganizationType,
                    Designation = office.Designation,
                    LastUpdate = DateTime.Now,

                };

                return propertyAgentOffice;

            }

            return null;

        }

        public  List<PropertyAgentOfficePhone> getPropertyAgentOfficePhone(RETSResponseOfficeDetailsPhone officePhone, long officeId)
        {
            if (officePhone != null)
            {
                List<PropertyAgentOfficePhone> phones = new List<PropertyAgentOfficePhone>();

                if (officePhone.Phone != null)
                {
                    foreach (RETSResponseOfficeDetailsPhonePhone phone in officePhone.Phone)
                    {
                        PropertyAgentOfficePhone propertyAgentOfficePhone = new PropertyAgentOfficePhone()
                        {
                            PropertyAgentOfficeId = officeId,
                            ContactType = phone.ContactType,
                            PhoneType = phone.PhoneType,
                            PhoneNumber = phone.Value
                        };
                        phones.Add(propertyAgentOfficePhone);
                    }
                }

                return phones;

            }
            return new List<PropertyAgentOfficePhone>();
        }

        public  List<PropertyAgentOfficeWebsite> getPropertyAgentOfficeWebsite(RETSResponseOfficeDetailsWebsite officeWebsite, long officeId)
        {
            if (officeWebsite != null)
            {
                List<PropertyAgentOfficeWebsite> websites = new List<PropertyAgentOfficeWebsite>();

                if (officeWebsite.Website != null)
                {
                    foreach (RETSResponseOfficeDetailsWebsiteWebsite website in officeWebsite.Website)
                    {
                        PropertyAgentOfficeWebsite propertyAgentOfficeWebsite = new PropertyAgentOfficeWebsite()
                        {
                            PropertyAgentOfficeId = officeId,
                            ContactType = website.ContactType,
                            WebsiteType = website.WebsiteType,
                            WebsiteUrl = website.Value
                        };
                        websites.Add(propertyAgentOfficeWebsite);
                    }
                }

                return websites;

            }
            return new List<PropertyAgentOfficeWebsite>();
        }
    }
}
