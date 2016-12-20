using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CDK.ETL.DDF
{
    public class RestSession
    {

        public CookieContainer cookieJar = new CookieContainer();
        public ICredentials requestCredentials = new NetworkCredential(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);

    }
}
