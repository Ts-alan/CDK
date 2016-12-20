using AutoMapper;
using CDK.Presentation.Web.Site.Models.Search;
using DTO = CDK.BusinessLogic.Core.DTO.Client;

namespace CDK.Presentation.Web.CMS.App_Start
{
    internal static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {                                                                                                  
                cfg.CreateMap<DTO.Area, AreaViewModel>();
                cfg.CreateMap<AreaViewModel, DTO.Area>();

                cfg.CreateMap<DTO.Neighborhood, NeighborhoodViewModel>();
                cfg.CreateMap<NeighborhoodViewModel, DTO.Neighborhood>();


                cfg.CreateMap<DTO.GeoCoordinate, GeoCoordinateViewModel>();
                cfg.CreateMap<GeoCoordinateViewModel, DTO.GeoCoordinate>();

                cfg.CreateMap<DTO.GeoPolygon, GeoPolygonViewModel>();
                cfg.CreateMap<GeoPolygonViewModel, DTO.GeoPolygon>();


                cfg.CreateMap<DTO.SortByUnitTypeEnum, SortByUnitTypeEnum>();
                cfg.CreateMap<SortByUnitTypeEnum, DTO.SortByUnitTypeEnum>();

                cfg.CreateMap<DTO.SearchCriteria, SearchFilterBindingModel>();
                cfg.CreateMap<SearchFilterBindingModel, DTO.SearchCriteria>();

                cfg.CreateMap<DTO.MarkerEntityEnum, MarkerTypeEnum>();
                cfg.CreateMap<MarkerTypeEnum, DTO.MarkerEntityEnum>();
;

                cfg.CreateMap<DTO.Photo, PhotoViewModel>();
                cfg.CreateMap<PhotoViewModel, DTO.Photo>();

                cfg.CreateMap<DTO.UnitMarker, UnitMarkerViewModel>();
                cfg.CreateMap<UnitMarkerViewModel, DTO.UnitMarker>();

                cfg.CreateMap<DTO.GeoMarker, GeoMarkerViewModel>();
                cfg.CreateMap<GeoMarkerViewModel, DTO.GeoMarker>();

                cfg.CreateMap<DTO.TransactionTypeEnum, TransactionTypeEnum>();
                cfg.CreateMap<TransactionTypeEnum, DTO.TransactionTypeEnum>();
            });

            return config.CreateMapper();
        }
    }
}