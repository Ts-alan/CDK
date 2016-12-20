using System;
using System.Collections.Generic;
using AutoMapper;
using CDK.BusinessLogic.Core.DTO.Client;
using CDK.BusinessLogic.Core.DTO.CMS;
using CDK.BusinessLogic.Core.Extenstions;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using Db = CDK.DataAccess.Models;

namespace CDK.BusinessLogic.Core
{
    internal static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Db.cdk.Developer, Developer>();
                cfg.CreateMap<Developer, Db.cdk.Developer>();

                cfg.CreateMap<Db.cdk.Development, Development>().ForMember(
                    vm => vm.DevelopmentAmenitiesIds,
                    m => m.MapFrom(
                        u => u.DevelopmentAmenities
                    .Select(x => x.Id)
                    .ToList()));

                cfg.CreateMap<Development, Db.cdk.Development>();

                cfg.CreateMap<Db.cdk.DevelopmentAddress, DevelopmentAddress>();
                cfg.CreateMap<DevelopmentAddress, Db.cdk.DevelopmentAddress>();

                cfg.CreateMap<Db.cdk.MetroArea, MetroArea>();
                cfg.CreateMap<MetroArea, Db.cdk.MetroArea>();

                cfg.CreateMap<Db.cdk.NeighborhoodArea, NeighborhoodArea>();
                cfg.CreateMap<NeighborhoodArea, Db.cdk.NeighborhoodArea>();

                cfg.CreateMap<Db.cdk.NeighborhoodGuide, NeighborhoodGuide>();
                cfg.CreateMap<NeighborhoodGuide, Db.cdk.NeighborhoodGuide>();

                cfg.CreateMap<Db.cdk.DevelopmentAmenities, DevelopmentAmenities>();
                cfg.CreateMap<DevelopmentAmenities, Db.cdk.DevelopmentAmenities>();

                cfg.CreateMap<Db.cdk.DevelopmentFloorPlan, DevelopmentFloorPlan>();
                cfg.CreateMap<DevelopmentFloorPlan, Db.cdk.DevelopmentFloorPlan>();

                cfg.CreateMap<Db.cdk.DevelopmentVideo, DevelopmentVideo>();
                cfg.CreateMap<DevelopmentVideo, Db.cdk.DevelopmentVideo>();

                cfg.CreateMap<Db.cdk.DevelopmentPhoto, DevelopmentPhoto>();
                cfg.CreateMap<DevelopmentPhoto, Db.cdk.DevelopmentPhoto>();

                cfg.CreateMap<Db.cdk.NeighborhoodGuideVideo, NeighborhoodGuideVideo>();
                cfg.CreateMap<NeighborhoodGuideVideo, Db.cdk.NeighborhoodGuideVideo>();

                cfg.CreateMap<Db.cdk.NeighborhoodGuidePhoto, NeighborhoodGuidePhoto>();
                cfg.CreateMap<NeighborhoodGuidePhoto, Db.cdk.NeighborhoodGuidePhoto>();

                cfg.CreateMap<Db.cdk.UserClaim, Claim>();
                cfg.CreateMap<Claim, Db.cdk.UserClaim>();

                cfg.CreateMap<Db.cdk.UserLogin, UserLoginInfo>();
                cfg.CreateMap<UserLoginInfo, Db.cdk.UserLogin>();

                cfg.CreateMap<Db.cdk.MetroArea, Area>()
                .ForMember(dest => dest.Group, opts => opts.MapFrom(src => src.State))
                //.ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                //.ForMember(dest => dest.ShortName, opts => opts.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.Value, opts => opts.MapFrom(src => src.MetroAreaUri))
                .ForMember(dest => dest.Center, opts => opts.MapFrom(src =>
                new GeoCoordinate(src.CenterPointGeo.Latitude, src.CenterPointGeo.Longitude)));

                cfg.CreateMap<Db.cdk.NeighborhoodArea, Neighborhood>()
                .ForMember(dest => dest.Group, opts => opts.MapFrom(src => src.MetroAreaId))
                //.ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                //.ForMember(dest => dest.ShortName, opts => opts.MapFrom(src => src.ShortName))
                .ForMember(dest => dest.Value, opts => opts.MapFrom(src => src.NeighborhoodAreaUri))
                .ForMember(dest => dest.Value, opts => opts.MapFrom(src => src.NeighborhoodAreaUri))
                .ForMember(dest => dest.Center, opts => opts.MapFrom(src =>
                new GeoCoordinate(src.CenterPointGeo.Latitude, src.CenterPointGeo.Longitude)));


                cfg.CreateMap<Db.cdk.NeighborhoodArea, GeoPolygon>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.Coordinates, opts => opts.MapFrom(src => src.CoordinatesGeo.GetGeoCoordinatesFromPolygon()))
               .ForMember(dest => dest.Center, opts => opts.MapFrom(src =>
               new GeoCoordinate(src.CenterPointGeo.Latitude, src.CenterPointGeo.Longitude)));

                cfg.CreateMap<Db.cdk.MetroArea, GeoPolygon>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.Coordinates, opts => opts.MapFrom(src => src.CoordinatesGeo.GetGeoCoordinatesFromPolygon()))
               .ForMember(dest => dest.Center, opts => opts.MapFrom(src =>
               new GeoCoordinate(src.CenterPointGeo.Latitude, src.CenterPointGeo.Longitude)));

                cfg.CreateMap<Db.IPhotoModel, DTO.Client.Photo>()
                .ForMember(dest => dest.SmallUri, opts => opts.MapFrom(src => Image.FixUrlImage("unit-photos", src.SmallUri)))
                .ForMember(dest => dest.LargeUri, opts => opts.MapFrom(src => Image.FixUrlImage("unit-photos", src.LargeUri)));

                cfg.CreateMap<CDK.DataAccess.Models.cdk.NeighborhoodGuide, DTO.DetailObject.NeighborhoodGuide>();


                cfg.CreateMap<Db.ddf.Unit, DTO.Client.UnitMarker>()
                .ForMember(dest => dest.Type, opts => opts.MapFrom(src => DTO.Client.MarkerEntityEnum.Unit))
                .ForMember(dest => dest.Url, opts => opts.MapFrom(src => src.UnitUri));

                cfg.CreateMap<Db.ddf.Unit, DTO.DetailObject.Unit>()
                    .ForMember(dest => dest.Bath, opts => opts.MapFrom(src => src.BathroomTotal))
                    .ForMember(dest => dest.Bed, opts => opts.MapFrom(src => src.BedroomsTotal))
                    .ForMember(dest => dest.Parking,
                        opts => opts.MapFrom(src => src.ParkingSpaceTotal == null ? "No" : "Yes"))
                    .ForMember(dest => dest.TransactionType, opts => opts.MapFrom(src => src.TransactionType))
                    .ForMember(dest => dest.Photo,
                        opts => opts.MapFrom(src => src.UnitPhotos.OrderBy(x => x.DdfSequenceId).ToList()))
                    .ForMember(dest => dest.UrlForPage, opts => opts.MapFrom(src => src.UnitUri))
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id));

                cfg.CreateMap<Db.ddf.Unit, DTO.Client.UnitForGallery>()
                    .ForMember(dest => dest.Bath, opts => opts.MapFrom(src => src.BathroomTotal))
                    .ForMember(dest => dest.Bed, opts => opts.MapFrom(src => src.BedroomsTotal))
                    .ForMember(dest => dest.Photo,
                        opts => opts.MapFrom(src => src.UnitPhotos.OrderBy(x => x.DdfSequenceId).FirstOrDefault()))
                    .ForMember(dest => dest.UrlForPage, opts => opts.MapFrom(src => src.UnitUri))
                    .ForMember(dest => dest.StreetAddress,
                        opts => opts.MapFrom(src => src.Building.BuildingAddress.StreetAddress))
                    .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.Building.BuildingAddress.City));


                cfg.CreateMap
                    <Tuple<CDK.DataAccess.Models.ddf.Building, CDK.DataAccess.Models.cdk.NeighborhoodArea>,
                        CDK.BusinessLogic.Core.DTO.DetailObject.Building>()
                        .ForMember(dest => dest.StreetAddress, opts => opts.MapFrom(src => src.Item1.BuildingAddress.StreetAddress))
                        .ForMember(dest => dest.PostalCode, opts => opts.MapFrom(src => src.Item1.BuildingAddress.PostalCode))
                        .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.Item1.BuildingAddress.City))
                        .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Item1.BuildingAddress.Country))
                        .ForMember(dest => dest.UrlForPage, opts => opts.MapFrom(src => src.Item1.BuildingUri))
                        .ForMember(dest => dest.ConstructedDate, opts => opts.MapFrom(src => src.Item1.ConstructedDate))
                        .ForMember(dest => dest.Amenities, opts => opts.MapFrom(src => src.Item1.Amenities.Select(a => a.Name)))
                        .ForMember(dest => dest.SeoDescription, opts => opts.MapFrom(src => src.Item1.SeoDescription))
                        .ForMember(dest => dest.Latitude, opts => opts.MapFrom(src => src.Item1.BuildingAddress.Lat))
                        .ForMember(dest => dest.Longitude, opts => opts.MapFrom(src => src.Item1.BuildingAddress.Lon))
                        .ForMember(dest => dest.Longitude, opts => opts.MapFrom(src => src.Item1.BuildingAddress.Lon))
                        .ForMember(dest => dest.Type, opts => opts.MapFrom(src => "Building"))
                        .ForMember(dest => dest.Neighborhood, opts => opts.MapFrom(src => src.Item2.Name))
                        .ForMember(dest => dest.Units, opts => opts.MapFrom(src => src.Item1.Units))
                        .ForMember(dest => dest.NeighborhoodGuide, opts => opts.MapFrom(src => src.Item2.NeighborhoodGuides))
                        .ForMember(dest => dest.Photo, opts => opts.MapFrom(src => src.Item1.Units.Select(a => a.UnitPhotos.OrderBy(b => b.DdfSequenceId).First())))
                        .ForMember(dest => dest.SeoTitle, opts => opts.MapFrom(src => src.Item1.SeoTitle))
                        .ForMember(dest => dest.SeoKeywords, opts => opts.MapFrom(src => src.Item1.SeoKeywords))
                        .ForMember(dest => dest.SeoMetaDescription, opts => opts.MapFrom(src => src.Item1.SeoMetaDescription))
                        ;
                cfg.CreateMap
                   <Tuple<CDK.DataAccess.Models.ddf.Unit, CDK.DataAccess.Models.cdk.NeighborhoodArea>,
                      CDK.BusinessLogic.Core.DTO.DetailObject.Unit>()
                       .ForMember(dest => dest.StreetAddress, opts => opts.MapFrom(src => src.Item1.Building.BuildingAddress.StreetAddress))
                       .ForMember(dest => dest.PostalCode, opts => opts.MapFrom(src => src.Item1.Building.BuildingAddress.PostalCode))
                       .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.Item1.Building.BuildingAddress.City))
                       .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.Item1.Building.BuildingAddress.Country))
                       .ForMember(dest => dest.Price, opts => opts.MapFrom(src => src.Item1.Price ?? src.Item1.Lease))
                       .ForMember(dest => dest.LeasePerTime, opts => opts.MapFrom(src => src.Item1.LeasePerTime))
                       .ForMember(dest => dest.TransactionType, opts => opts.MapFrom(src => src.Item1.TransactionType))
                       .ForMember(dest => dest.DaysOnMarket, opts => opts.MapFrom(src => (DateTime.Now - src.Item1.LastUpdate).Days))
                       .ForMember(dest => dest.ConstructedDate, opts => opts.MapFrom(src => src.Item1.Building.ConstructedDate))
                       .ForMember(dest => dest.MaintenanceFee, opts => opts.MapFrom(src => src.Item1.MaintenanceFee))
                       .ForMember(dest => dest.Bed, opts => opts.MapFrom(src => src.Item1.BedroomsTotal))
                       .ForMember(dest => dest.Bath, opts => opts.MapFrom(src => src.Item1.BathroomTotal))
                       .ForMember(dest => dest.Parking, opts => opts.MapFrom(src => src.Item1.ParkingSpaceTotal == null ? "No" : "Yes"))
                       .ForMember(dest => dest.Amenities, opts => opts.MapFrom(src => src.Item1.Features.Select(a => a.Name)))
                       .ForMember(dest => dest.SeoDescription, opts => opts.MapFrom(src => src.Item1.PublicRemarks))
                       .ForMember(dest => dest.Photo, opts => opts.MapFrom(src => src.Item1.UnitPhotos.OrderBy(x => x.DdfSequenceId).ToList()))
                       .ForMember(dest => dest.Latitude, opts => opts.MapFrom(src => src.Item1.Building.BuildingAddress.Lat))
                       .ForMember(dest => dest.Longitude, opts => opts.MapFrom(src => src.Item1.Building.BuildingAddress.Lon))
                       .ForMember(dest => dest.Type, opts => opts.MapFrom(src => "Unit"))
                       .ForMember(dest => dest.UrlForPage, opts => opts.MapFrom(src => src.Item1.UnitUri))
                       .ForMember(dest => dest.Neighborhood, opts => opts.MapFrom(src => src.Item2.Name))
                       .ForMember(dest => dest.NeighborhoodGuide, opts => opts.MapFrom(src => src.Item2.NeighborhoodGuides))
                       .ForMember(dest => dest.SeoTitle, opts => opts.MapFrom(src => src.Item1.SeoTitle))
                       .ForMember(dest => dest.SeoKeywords, opts => opts.MapFrom(src => src.Item1.SeoKeywords))
                       .ForMember(dest => dest.SeoMetaDescription, opts => opts.MapFrom(src => src.Item1.SeoMetaDescription))
                       ;
                cfg.CreateMap<Tuple<CDK.DataAccess.Models.ddf.Building, IList<CDK.DataAccess.Models.ddf.Unit>>,
                    CDK.BusinessLogic.Core.DTO.DetailObject.Building>()
                    .ForMember(dest => dest.StreetAddress, opts => opts.MapFrom(src => src.Item1.BuildingAddress.StreetAddress))
                    .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.Item1.BuildingAddress.City))
                    .ForMember(dest => dest.Units, opts => opts.MapFrom(src => src.Item2))
                    .ForMember(dest => dest.Photo, opts => opts.MapFrom(src => src.Item2.SelectMany(a => a.UnitPhotos).OrderBy(a => a.DdfSequenceId).Take(1)))
                    .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Item1.Id))
                    ;
            });


            return config.CreateMapper();
        }
    }
}