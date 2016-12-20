using System.Collections.Generic;
using System.Web.Mvc;

namespace CDK.Presentation.Web.CMS
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string area = null, string action = null, string cssClass = null)
        {
            if (string.IsNullOrEmpty(cssClass))
                cssClass = "active";

            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];
            var currentArea = (string)html.ViewContext.RouteData.DataTokens["area"];

            if (string.IsNullOrEmpty(controller))
            {
                controller = currentController;
            }

            if (string.IsNullOrEmpty(action))
            {
                action = currentAction;
            }

            if (string.IsNullOrEmpty(area))
            {
                area = currentArea;
            }

            return controller == currentController && action == currentAction && area == currentArea ?
                cssClass : string.Empty;
        }

        public static string PageClass(this HtmlHelper html)
        {
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }


        public static IEnumerable<SelectListItem> CountryStateList(this HtmlHelper html)
        {
            return new List<SelectListItem>()
              {
                  new SelectListItem() { Text = "Alberta", Value = "AB"},
                  new SelectListItem() { Text = "British Columbia", Value = "BC"},
                  new SelectListItem() { Text = "Manitoba", Value = "MB"},
                  new SelectListItem() { Text = "New Brunswick", Value = "NB"},
                  new SelectListItem() { Text = "Newfoundland and Labrador", Value = "NL"},
                  new SelectListItem() { Text = "Northwest Territories", Value = "NT"},
                  new SelectListItem() { Text = "Nova Scotia", Value = "NS"},
                  new SelectListItem() { Text = "Nunavut", Value = "NU"},
                  new SelectListItem() { Text = "Ontario", Value = "ON"},
                  new SelectListItem() { Text = "Prince Edward Island", Value = "PE"},
                  new SelectListItem() { Text = "Quebec", Value = "QC"},
                  new SelectListItem() { Text = "Saskatchewan", Value = "SK"},
                  new SelectListItem() { Text = "Yukon", Value = "YT"}
              };
        }
    }
}