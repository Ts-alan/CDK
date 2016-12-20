using AutoMapper;
using CDK.Presentation.Web.CMS.Areas.CdkEntity.Models;
using DTO = CDK.BusinessLogic.Core.DTO.CMS;

namespace CDK.Presentation.Web.CMS.App_Start
{
    internal static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO.Developer, Developer>();
                cfg.CreateMap<Developer, DTO.Developer>();

                cfg.CreateMap<DTO.Development, Development>();
                cfg.CreateMap<Development, DTO.Development>();

                cfg.CreateMap<DTO.DevelopmentAddress, DevelopmentAddress>();
                cfg.CreateMap<DevelopmentAddress, DTO.DevelopmentAddress>();

                cfg.CreateMap<DTO.MetroArea, MetroArea>();
                cfg.CreateMap<MetroArea, DTO.MetroArea>();

                cfg.CreateMap<DTO.NeighborhoodArea, NeighborhoodArea>();
                cfg.CreateMap<NeighborhoodArea, DTO.NeighborhoodArea>();

                cfg.CreateMap<DTO.NeighborhoodGuide, NeighborhoodGuide>();
                cfg.CreateMap<NeighborhoodGuide, DTO.NeighborhoodGuide>();

                cfg.CreateMap<DTO.DevelopmentAmenities, DevelopmentAmenities>();
                cfg.CreateMap<DevelopmentAmenities, DTO.DevelopmentAmenities>();

                cfg.CreateMap<DTO.DevelopmentFloorPlan, DevelopmentFloorPlan>();
                cfg.CreateMap<DevelopmentFloorPlan, DTO.DevelopmentFloorPlan>();

                cfg.CreateMap<DTO.DevelopmentVideo, DevelopmentVideo>();
                cfg.CreateMap<DevelopmentVideo, DTO.DevelopmentVideo>();

                cfg.CreateMap<DTO.NeighborhoodGuideVideo, NeighborhoodGuideVideo>();
                cfg.CreateMap<NeighborhoodGuideVideo, DTO.NeighborhoodGuideVideo>();

                cfg.CreateMap<DTO.NeighborhoodGuidePhoto, NeighborhoodGuidePhoto>();
                cfg.CreateMap<NeighborhoodGuidePhoto, DTO.NeighborhoodGuidePhoto>();
                                       
                cfg.CreateMap<DTO.DevelopmentPhoto, DevelopmentPhoto>();
                cfg.CreateMap<DevelopmentPhoto, DTO.DevelopmentPhoto>();
            });

            return config.CreateMapper();
        }
    }
}