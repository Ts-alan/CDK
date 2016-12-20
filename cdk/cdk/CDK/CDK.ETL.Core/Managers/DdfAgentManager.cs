using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDK.ETL.DDF.Agent;
using CDK.ETL.DDF;
using System.Configuration;
using System.IO;
using CDK.DataAccess.Repositories;
using CDK.DataAccess.Models;
using CDK.ETL.DDF.DdfRawModel;
using CDK.DataAccess.Models.ddf;
using CDK.ETL.Core.Services;

namespace CDK.ETL.Core.Managers
{
    public class DdfAgentManager
    {

        AgentCRUDService agentCRUDService = null;

        public DdfAgentManager(RestSession session)
        {
            this.agentCRUDService = new AgentCRUDService(session);
        }

        public bool CreateUpdateAgent(List<RETS> retsAgentList)
        {
            int count = 0;
            foreach (RETS rets in retsAgentList)
            {
                foreach (var agentDetail in rets.RETSResponse.AgentDetails)
                {
                    try
                    {

                        PropertyAgent propertyAgent = getPropertyAgent(agentDetail);
                        agentCRUDService.CreateOrUpdate(propertyAgent);
                        count++;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Can't insert agent {0} due to <{1}>", agentDetail.ID, e.Message);
                    }
                }
            }
            Console.WriteLine(string.Format(">>> INSERTED/UPDATED ({0}) AGENTS", count));

            return true;

        }

        public  PropertyAgent getPropertyAgent(RETSResponseAgentDetails agent)
        {

            if (agent != null)
            {

                List<PropertyAgentDesignation> propertyAgentDesignation = getPropertyAgentDesignation(agent.AgentDetailsDesignations, agent.ID);
                List<PropertyAgentLanguage> propertyAgentLanguage = getPropertyAgentLanguage(agent.AgentDetailsLanguages, agent.ID);
                List<PropertyAgentPhone> propertyAgentPhone = getPropertyAgentPhone(agent.AgentDetailsPhones, agent.ID);
                List<PropertyAgentSpeciality> propertyAgentSpeciality = getPropertyAgentSpeciality(agent.AgentDetailsSpecialties, agent.ID);
                List<PropertyAgentWebsite> propertyAgentWebsite =getPropertyAgentWebsite(agent.AgentDetailsWebsites, agent.ID);
                PropertyAgentOffice propertyAgentOffice = getPropertyAgentOffice(agent.AgentDetailsOffice);

                PropertyAgent propertyAgent = new PropertyAgent()
                {
                    PropertyAgentId = agent.ID,
                    DdfAgentId = agent.ID.ToString(),
                    PropertyAgentDesignation = propertyAgentDesignation,
                    PropertyAgentLanguage = propertyAgentLanguage,
                    PropertyAgentPhone = propertyAgentPhone,
                    PropertyAgentSpeciality = propertyAgentSpeciality,
                    PropertyAgentWebsite = propertyAgentWebsite,
                    PropertyAgentOffice = propertyAgentOffice,
                    Name = agent.Name,
                    Position = agent.Position,
                    EducationCredentials = agent.EducationCredentials,
                    StreetAddress = agent.AgentDetailsAddress != null ? agent.AgentDetailsAddress.StreetAddress : null,
                    AddressLine1 = agent.AgentDetailsAddress != null ? agent.AgentDetailsAddress.AddressLine1 : null,
                    Addressline2 = agent.AgentDetailsAddress != null ? agent.AgentDetailsAddress.Addressline2 : null,
                    StreetNumber = agent.AgentDetailsAddress != null ? agent.AgentDetailsAddress.StreetNumber : null,
                    StreetName = agent.AgentDetailsAddress != null ? agent.AgentDetailsAddress.StreetName : null,
                    StreetSuffix = agent.AgentDetailsAddress != null ? agent.AgentDetailsAddress.StreetSuffix : null,
                    City = agent.AgentDetailsAddress != null ? agent.AgentDetailsAddress.City : null,
                    Province = agent.AgentDetailsAddress != null ? agent.AgentDetailsAddress.Province : null,
                    PostalCode = agent.AgentDetailsAddress != null ? agent.AgentDetailsAddress.PostalCode : null,
                    LastUpdate = DateTime.Now

                };

                if (agent.AgentDetailsOffice != null && agent.AgentDetailsOffice.ID != 0)
                    propertyAgent.PropertyAgentOfficeId = agent.AgentDetailsOffice.ID;

                return propertyAgent;

            }

            return null;

        }

        public  List<PropertyAgentPhone> getPropertyAgentPhone(RETSResponseAgentDetailsPhones agentPhone, long propertyAgentId)
        {

            List<PropertyAgentPhone> phones = new List<PropertyAgentPhone>();

            if (agentPhone != null)
            {
               
                if (agentPhone.Phone != null)
                {
                    foreach (RETSResponseAgentDetailsPhonesPhone phone in agentPhone.Phone)
                    {
                        PropertyAgentPhone propertyAgentPhone = new PropertyAgentPhone()
                        {
                            PropertyAgentId = propertyAgentId,
                            ContactType = phone.ContactType,
                            PhoneType = phone.PhoneType,
                            PhoneNumber = phone.Value
                        };
                        phones.Add(propertyAgentPhone);
                    }
                }
            }

            return phones;

        }

        public  List<PropertyAgentLanguage> getPropertyAgentLanguage(RETSResponseAgentDetailsLanguages agentLanguage, long propertyAgentId)
        {

            List<PropertyAgentLanguage> languages = new List<PropertyAgentLanguage>();

            if (agentLanguage != null)
            {

                if (agentLanguage.Language != null)
                {
                    foreach (string language in agentLanguage.Language)
                    {
                        PropertyAgentLanguage propertyAgentLanguage = new PropertyAgentLanguage()
                        {
                            PropertyAgentId = propertyAgentId,
                            Language = language
                        };
                        languages.Add(propertyAgentLanguage);
                    }
                }
            }

            return languages;

        }

        public  List<PropertyAgentDesignation> getPropertyAgentDesignation(RETSResponseAgentDetailsDesignations agentDesignation, long propertyAgentId)
        {

            List<PropertyAgentDesignation> designations = new List<PropertyAgentDesignation>();

            if (agentDesignation != null)
            {
               
                foreach (string designation in agentDesignation.Designation)
                {
                    PropertyAgentDesignation propertyAgentDesignation = new PropertyAgentDesignation()
                    {
                        PropertyAgentId = propertyAgentId,
                        Designation = designation
                    };
                    designations.Add(propertyAgentDesignation);
                }
            }

            return designations;
        }

        public  List<PropertyAgentSpeciality> getPropertyAgentSpeciality(RETSResponseAgentDetailsSpecialties agentSpeciality, long propertyAgentId)
        {

            List<PropertyAgentSpeciality> specialities = new List<PropertyAgentSpeciality>();

            if (agentSpeciality != null)
            {
                
                if (agentSpeciality.Specialty != null)
                {
                    foreach (string speciality in agentSpeciality.Specialty)
                    {
                        PropertyAgentSpeciality propertyAgentSpeciality = new PropertyAgentSpeciality()
                        {
                            PropertyAgentId = propertyAgentId,
                            Specialtie = speciality
                        };
                        specialities.Add(propertyAgentSpeciality);
                    }
                }
            }
            return specialities;

        }

        public  List<PropertyAgentWebsite> getPropertyAgentWebsite(RETSResponseAgentDetailsWebsites agentWebsite, long propertyAgentId)
        {

            List<PropertyAgentWebsite> websites = new List<PropertyAgentWebsite>();

            if (agentWebsite != null)
            {

                if (agentWebsite.Website != null)
                {
                    foreach (RETSResponseAgentDetailsWebsitesWebsite website in agentWebsite.Website)
                    {
                        PropertyAgentWebsite propertyAgentWebsite = new PropertyAgentWebsite()
                        {
                            PropertyAgentId = propertyAgentId,
                            ContactType = website.ContactType,
                            WebsiteType = website.WebsiteType,
                            WebsiteUrl = website.Value
                        };
                        websites.Add(propertyAgentWebsite);
                    }
                }
            }
            return websites;
        }

        public  PropertyAgentOffice getPropertyAgentOffice(RETSResponseAgentDetailsOffice office)
        {

            if (office != null)
            {

                PropertyAgentOffice propertyAgentOffice = new PropertyAgentOffice()
                {

                    DdfPropertyAgentOfficeId = office.ID.ToString(),
                    LastUpdate = DateTime.Now

                };

                return propertyAgentOffice;

            }

            return null;

        }
    }
}
