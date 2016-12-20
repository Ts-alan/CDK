using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.Extenstions
{
    internal static class Image
    {
        internal static string FixUrlImage(string type,string url)
        {
            string stringConfig = ConfigurationManager.AppSettings["blobUrl"];
            string result = stringConfig + type+"/" + url;
            return result;
        }
    }
}
