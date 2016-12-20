using CDK.DataAccess.Models.ddf;
using CDK.ETL.DDF.DdfRawModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.Core.Extenstions
{
    static class UnitExtensions
    {

        public static void Map(this Unit unit, Property model)
        {

            decimal decimalValue;
            int intValue;
            var nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            unit.DdfUnitId = model.DdfPropertyId;

            if (int.TryParse(model.PropertyBuilding.HalfBathTotal, out intValue)) unit.HalfBathTotal = intValue; else unit.HalfBathTotal = null;

            if (int.TryParse(model.PropertyBuilding.BathroomTotal, out intValue)) unit.BathroomTotal = intValue; else unit.BathroomTotal = null;

            if (int.TryParse(model.PropertyBuilding.BedroomsAboveGround, out intValue)) unit.BedroomsAboveGround = intValue; else unit.BedroomsAboveGround = null;

            if (int.TryParse(model.PropertyBuilding.BedroomsBelowGround, out intValue)) unit.BedroomsBelowGround = intValue; else unit.BedroomsBelowGround = null;

            if (int.TryParse(model.PropertyBuilding.BedroomsTotal, out intValue)) unit.BedroomsTotal = intValue; else unit.BedroomsTotal = null;

            unit.CeilingHeight = model.PropertyBuilding.CeilingHeight;
            unit.SizeInterior = model.PropertyBuilding.SizeInterior;
            unit.SizeInteriorFinished = model.PropertyBuilding.SizeInteriorFinished;
            unit.TotalFinishedArea = model.PropertyBuilding.TotalFinishedArea;

            if (decimal.TryParse(model.Lease, NumberStyles.AllowDecimalPoint, nfi, out decimalValue)) unit.Lease = decimalValue; else unit.Lease = null;

            unit.LeasePerTime = model.LeasePerTime;
            unit.LeasePerUnit = model.LeasePerUnit;
            unit.LeaseTermRemaining = model.LeaseTermRemaining;

            if (int.TryParse(model.LeaseTermRemainingFreq, out intValue)) unit.LeaseTermRemainingFreq = intValue; else unit.LeaseTermRemainingFreq = null;

            if (decimal.TryParse(model.MaintenanceFee, NumberStyles.AllowDecimalPoint, nfi, out decimalValue)) unit.MaintenanceFee = decimalValue; else unit.MaintenanceFee = null;

            unit.MaintenanceFeePaymentUnit = model.MaintenanceFeePaymentUnit;

            if (int.TryParse(model.ParkingSpaceTotal, out intValue)) unit.ParkingSpaceTotal = intValue; else unit.ParkingSpaceTotal = null;

            unit.Plan = model.Plan;

            if (decimal.TryParse(model.Price, NumberStyles.AllowDecimalPoint, nfi, out decimalValue)) unit.Price = decimalValue; else unit.Price = null;

            unit.PricePerTime = model.PricePerTime;
            unit.PricePerUnit = model.PricePerUnit;
            unit.PropertyType = model.PropertyType;
            unit.OwnershipType = model.OwnershipType;
            unit.TransactionType = model.TransactionType;
            unit.PublicRemarks = model.PublicRemarks;
            unit.AdditionalInformationIndicator = model.AdditionalInformationIndicator;
            unit.MoreInformationLink = model.MoreInformationLink;
            unit.ListingId = model.ListingId;
            unit.SeoCaption = "";
            unit.SeoDescription = "";
            unit.SeoKeywords = "";
            unit.SeoSlug = "";
            unit.SeoMetaDescription = "";
            unit.SeoTitle = "";
            unit.SeoURI = "";
            unit.LastExternalUpdate = model.LastDdfUpdate;
            unit.LastUpdate = DateTime.Now;
            if (unit.Created==null || unit.Created.Year == 1)
                unit.Created = DateTime.Now;
            if (unit.CreatedBy == null)
                unit.CreatedBy = "ETL";
            unit.LastUpdateBy = "ETL";

        }
    }
}
