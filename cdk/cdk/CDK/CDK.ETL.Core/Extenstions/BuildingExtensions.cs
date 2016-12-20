using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class BuildingExtensions
    {

        public static void Map(this Building building, Property model)
        {

            if (model.PropertyBuilding != null)
            {

                building.ConstructedDate = model.PropertyBuilding.ConstructedDate;
                building.EnerguideRating = model.PropertyBuilding.EnerguideRating;
                building.FireplacePresent = model.PropertyBuilding.FireplacePresent;
                building.FireplaceTotal = model.PropertyBuilding.FireplaceTotal;
                building.LeedsCategory = model.PropertyBuilding.LeedsCategory;
                building.LeedsRating = model.PropertyBuilding.LeedsRating;
                building.RenovatedDate = model.PropertyBuilding.RenovatedDate;
                building.StoriesTotal = model.PropertyBuilding.StoriesTotal;
                building.SizeExterior = model.PropertyBuilding.SizeExterior;

            }
            
            building.Age = model.PropertyBuilding.Age;
            building.Board = model.Board;
            building.Anchor = model.PropertyBuilding.Anchor;
            building.BomaRating = model.PropertyBuilding.BomaRating;
            building.ManagementCompany = model.ManagementCompany;
            building.Type = model.PropertyBuilding.Type;
            building.Structure = model.Structure;
            building.MunicipalId = model.MunicipalId;
            building.Uffi = model.PropertyBuilding.Uffi;
            building.UnitType = model.PropertyBuilding.UnitType;
            building.VacancyRate = model.PropertyBuilding.VacancyRate;
            building.ZoningType = model.ZoningType;
            building.ZoningDescription = model.ZoningDescription;
            building.TotalBuildings = model.TotalBuildings;
            building.WaterFrontName = model.WaterFrontName;
            building.LocationDescription = model.LocationDescription;
            building.SeoCaption = "";
            building.SeoDescription = "";
            building.SeoKeywords = "";
            building.SeoSlug = "";
            building.SeoMetaDescription = "";
            building.SeoTitle = "";
            building.SeoURI = "";
            building.LastExternalUpdate = model.LastDdfUpdate;
            building.LastUpdate = DateTime.Now;
            if (building.Created == null || building.Created.Year == 1)
                building.Created = DateTime.Now;
            if (building.CreatedBy == null)
                building.CreatedBy = "ETL";
            building.LastUpdateBy = "ETL";

        }
    }
}
