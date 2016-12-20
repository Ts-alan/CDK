using AutoMapper;
using CDK.BusinessLogic.Core.DTO.CMS;
using LinqKit;
using System.Linq;
using Db = CDK.DataAccess.Models.cdk;

namespace CDK.BusinessLogic.Core.Extenstions.MergeExtensions
{
    internal static class DevelopmentModelExtensions
    {
        public static void Merge(this Db.Development dev, Development model)
        {
            dev.DeveloperId = model.DeveloperId;
            dev.Name = model.Name;
            dev.PrimaryContactName = model.PrimaryContactName;
            dev.PrimaryContactEmail = model.PrimaryContactEmail;
            dev.PrimaryContactPhone = model.PrimaryContactPhone;
            dev.SecondaryContactName = model.SecondaryContactName;
            dev.SecondaryContactEmail = model.SecondaryContactEmail;
            dev.SecondaryContactPhone = model.SecondaryContactPhone;
            dev.ProjectWebsiteUrl = model.ProjectWebsiteUrl;
            dev.ProjectFacebookUrl = model.ProjectFacebookUrl;
            dev.ProjectTwiterUrl = model.ProjectTwiterUrl;
            dev.ProjectGooglePlusUrl = model.ProjectGooglePlusUrl;
            dev.SalesCenterPhoneNumber = model.SalesCenterPhoneNumber;
            dev.SalesCenterAddress = model.SalesCenterAddress;
            dev.SalesCenterPhone = model.SalesCenterPhone;
            dev.SalesCenterOpenHours = model.SalesCenterOpenHours;
            dev.ConstructuedYear = model.ConstructuedYear;
            dev.ForSale = model.ForSale;
            dev.ForRent = model.ForRent;
            dev.BuildingType = model.BuildingType;
            dev.Community = model.Community;
            dev.PriceAveragePerSqrFeet = model.PriceAveragePerSqrFeet;
            dev.TotalNumberOfUnits = model.TotalNumberOfUnits;
            dev.TotalNumberOfStories = model.TotalNumberOfStories;
            dev.SalesCompany = model.SalesCompany;
            dev.MarketingCompany = model.MarketingCompany;
            dev.Architects = model.Architects;
            dev.InteriorDesigner = model.InteriorDesigner;
            dev.ProjectSummary = model.ProjectSummary;
            dev.ShortProjectSummary = model.ShortProjectSummary;
            dev.ProjectAmenities = model.ProjectAmenities;
            dev.CurrentIncentives = model.CurrentIncentives;
            dev.LogoUri = model.LogoUri;

            dev.MergeSeo(model);

            dev.DevelopmentAddress.NeighborhoodAreaId = model.DevelopmentAddress.NeighborhoodAreaId;
            dev.DevelopmentAddress.StreetAddress = model.DevelopmentAddress.StreetAddress;
            dev.DevelopmentAddress.City = model.DevelopmentAddress.City;
            dev.DevelopmentAddress.CountryState = model.DevelopmentAddress.CountryState;
            dev.DevelopmentAddress.PostalCode = model.DevelopmentAddress.PostalCode;
            dev.DevelopmentAddress.Country = model.DevelopmentAddress.Country;
            dev.DevelopmentAddress.Lon = model.DevelopmentAddress.Lon;
            dev.DevelopmentAddress.Lat = model.DevelopmentAddress.Lat;
            dev.DevelopmentAddress.StreetType = model.DevelopmentAddress.StreetType;
            dev.DevelopmentAddress.AdditionalStreetInfo = model.DevelopmentAddress.AdditionalStreetInfo;
            dev.DevelopmentAddress.CommunityName = model.DevelopmentAddress.CommunityName;
        }

        public static void MergeVideosForExistingRecord(this Db.Development dbModel, Development model, IMapper mapper)
        {
            //remove deleted videos
            dbModel.DevelopmentVideos.Where(x => !model.DevelopmentVideos.Any(y => y.Id == x.Id)).ToList().ForEach(z => z.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Deleted);

            //add new videos
            model.DevelopmentVideos.Where(x => !x.Id.HasValue).ForEach(z =>
            {
                var newVideo = mapper.Map<Db.DevelopmentVideo>(z);
                newVideo.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Added;
                dbModel.DevelopmentVideos.Add(newVideo);
            });

            //merge videos
            model.DevelopmentVideos.Where(x => x.Id.HasValue).ForEach(z =>
            {
                var original = dbModel.DevelopmentVideos.FirstOrDefault(x => x.Id == z.Id.Value);

                if (original != null)
                {
                    original.ObjectState = Repository.Pattern.Infrastructure.ObjectState.Modified;
                    original.SequenceNumber = z.SequenceNumber;
                    original.Name = z.Name;
                    original.Type = z.Type;
                    original.Uri = z.Uri;
                    original.Description = z.Description;
                    original.AltText = z.AltText;


                    original.MergeSeo(z);
                }
            });
        }
    }
}