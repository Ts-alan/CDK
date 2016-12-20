using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace CDK.Presentation.Web.Site.Models.Search.Binders
{
    public class SearchFilterModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext,
                              ModelBindingContext bindingContext)
        {
            var model = new SearchFilterBindingModel();

            var state = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.State));

            if (state != null)
            {
                model.State = (string)state.RawValue;
            }

            var area = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.Area)) ?? bindingContext.ValueProvider.GetValue("city");

            if (area != null)
            {
                model.Area = (string)area.RawValue;
            }

            var mNeighborhood = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.MNeighborhood));
            if (mNeighborhood != null)
            {
                model.MNeighborhood = (string)mNeighborhood.RawValue;
            }


            var sNeighborhood = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.SNeighborhood));
            if (sNeighborhood != null)
            {
                model.SNeighborhood = (string)sNeighborhood.RawValue;
            }

            var nNeighborhood = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.NNeighborhood));
            if (nNeighborhood != null)
            {
                model.NNeighborhood = (string)nNeighborhood.RawValue;
            }


            var minPrice = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.MinPrice));
            if (minPrice != null)
            {
                decimal parseMinPrice;

                if (decimal.TryParse((string)minPrice.RawValue, out parseMinPrice))
                {
                    model.MinPrice = parseMinPrice;
                }
            }


            var maxPrice = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.MaxPrice));
            if (maxPrice != null)
            {
                decimal parseMaxPrice;

                if (decimal.TryParse((string)maxPrice.RawValue, out parseMaxPrice))
                {
                    model.MaxPrice = parseMaxPrice;
                }
            }

            var beds = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.Beds));
            if (beds != null && beds.RawValue is List<string>)
            {
                model.Beds = (List<string>)beds.RawValue;
            }


           
            var page = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.Page));
            if (page != null)
            {
                int parsePage;

                if (int.TryParse((string)page.RawValue, out parsePage))
                {
                    model.Page = parsePage;
                }
            }

            var transactionType = 
                bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.TransactionType))
                ?? bindingContext.ValueProvider.GetValue("transaction");
            if (transactionType != null)
            {
                int parseTransactionType;

                if (int.TryParse((string)transactionType.RawValue, out parseTransactionType))
                {
                    model.TransactionType = (CDK.Presentation.Web.Site.Models.Search.TransactionTypeEnum)parseTransactionType;
                }
            }

            var take = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.Take));
            if (take != null)
            {
                int parseTake;

                if (int.TryParse((string)take.RawValue, out parseTake))
                {
                    model.Take = parseTake;
                }
            }

            var skip = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.Skip));
            if (skip != null)
            {
                int parseSkip;

                if (int.TryParse((string)skip.RawValue, out parseSkip))
                {
                    model.Skip = parseSkip;
                }
            }

            var zoom = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.Zoom));
            if (zoom != null)
            {
                int parseZoom;

                if (int.TryParse((string)zoom.RawValue, out parseZoom))
                {
                    model.Zoom = parseZoom;
                }
            }
            var sortByUnit = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.SortBy));
            if (sortByUnit != null)
            {
                int parseSortByUnit;

                if (int.TryParse((string)sortByUnit.RawValue, out parseSortByUnit))
                {
                    if (Enum.IsDefined(typeof(SortByUnitTypeEnum), parseSortByUnit))
                    {
                        model.SortBy = (SortByUnitTypeEnum) parseSortByUnit;
                    }
                }
            }

            var coordinates = bindingContext.ValueProvider.GetValue(nameof(SearchFilterBindingModel.Coordinates));

            if (coordinates != null)
            {
                try
                {
                    model.Coordinates = (coordinates.RawValue as List<string>).Select(x =>
                    {
                        double[] doubles = Array.ConvertAll(x.Replace("[", "").Replace("]", "").Split(','), new Converter<string, double>(Double.Parse));

                        return new GeoCoordinateViewModel
                        {
                            Latitude = doubles[0],
                            Longitude = doubles[1]
                        };
                    }).ToList();
                }
                catch { }
            }


            bindingContext.Model = model;

            return true;
        }
    }
}
