using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using CDK.ETL.DDF.ExternalTools.MultipartParser;

namespace CDK.ETL.DDF
{
    public class DdfCoreManager
    {

        private HttpWebRequest httpWebRequest;
        private CredentialCache requestCredentialCache = new CredentialCache();
        private string RetsUrl = ConfigurationManager.AppSettings["url"];
        private RestSession session;

        public DdfCoreManager()
        {
            session = new RestSession();
        }

        public DdfCoreManager(RestSession session)
        {
            this.session = session;
        }

        public RestSession LoginTransaction()
        {

            try
            {

                string service = RetsUrl + "/Login.svc/Login";

                CookieContainer loginCookie = new CookieContainer();

                httpWebRequest = (HttpWebRequest)WebRequest.Create(service);
                httpWebRequest.CookieContainer = loginCookie; //STORE THE REQUEST COOKIE
                httpWebRequest.Credentials = session.requestCredentials;

                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    Stream stream = httpResponse.GetResponseStream();
                    // READ THE RESPONSE STREAM USING XMLTEXTREADER
                    XmlTextReader reader = new XmlTextReader(stream);

                    while (reader.Read())
                    {
                        if (reader.Name == "RETS")
                        {
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "ReplyCode" & reader.Value == "0")
                                    {
                                        Console.WriteLine(">>> VALID LOGIN REQUEST : {0}: {1}", reader.Name, reader.Value);
                                        loginCookie.Add(httpResponse.Cookies);
                                        session.cookieJar = loginCookie;
                                        //STORE THE COOKIES RECEIVED FOR FUTURE RETRIEVAL
                                        //FOR STATELESS APPLICATION PROCESSING, STORE THE COOKIES RECEIVED IN THE SESSION STATE FOR FUTURE RETRIEVAL BY THIS SESSION.
                                        return session;
                                    }
                                    else
                                    {
                                        Console.WriteLine("{0}: {1}", reader.Name, reader.Value);
                                    }
                                }
                            }
                        }
                        else if (reader.NodeType != XmlNodeType.XmlDeclaration & reader.HasValue)
                        {
                            Console.WriteLine("RETS-RESPONSE:");
                            Console.WriteLine("{0}", reader.Value);
                            return null;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE LOGGIN IN : {0}", e.Message);
            }

            return null;

        }

        public bool LogoutTransaction()
        {
            string service = RetsUrl + "/Logout.svc/Logout";

            httpWebRequest = (HttpWebRequest)WebRequest.Create(service);
            httpWebRequest.CookieContainer = session.cookieJar; //GRAB THE COOKIE
            httpWebRequest.Credentials = session.requestCredentials; //PASS CREDENTIALS

            try
            {
                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    Stream stream = httpResponse.GetResponseStream();
                    
                    // READ THE RESPONSE STREAM USING XMLTEXTREADER
                    XmlTextReader reader = new XmlTextReader(stream);

                    while (reader.Read())
                    {
                        if (reader.Name == "RETS")
                        {
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "ReplyCode" & reader.Value == "0")
                                    {
                                        Console.WriteLine(">>> VALID LOGOUT REQUEST : {0}: {1}",reader.Name, reader.Value);
                                        return true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("{0}: {1}", reader.Name, reader.Value);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE LOGGIN OFF : {0}", e.Message);
            }

            return false;

        }

        public MemoryStream GetObject(string strResource, string strID, string strType)
        {

            string requestArguments = "?Resource=" + strResource + "&ID=" + strID + "&Type=" + strType;
            string searchService = RetsUrl + "/Object.svc/GetObject" + requestArguments;

            httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
            httpWebRequest.CookieContainer = session.cookieJar; //GRAB THE COOKIE
            httpWebRequest.Credentials = session.requestCredentials; //PASS CREDENTIALS

            try
            {
                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {

                    //var contentType = ContentType.Parse(httpResponse.ContentType);

                    // READ THE RESPONSE STREAM USING XMLTEXTREADER
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {

                        Stream stream = httpResponse.GetResponseStream(); // READ THE RESPONSE STREAM USING STREAMREADER

                        if (stream != null)
                        {

                            MemoryStream ms = new MemoryStream();
                            stream.CopyTo(ms);

                            Console.WriteLine("Received photo -> resource:" + strResource + ", type: " + strType);

                            return ms;

                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING OBJECT : {0}", e.Message);
            }

            return null;

        }

        public List<MultiPartSection> GetObjectMultipart(string strResource, string strID, string strType)
        {

            string requestArguments = "?Resource=" + strResource + "&ID=" + strID + "&Type=" + strType;
            string searchService = RetsUrl + "/Object.svc/GetObject" + requestArguments;

            httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
            httpWebRequest.CookieContainer = session.cookieJar; //GRAB THE COOKIE
            httpWebRequest.Credentials = session.requestCredentials; //PASS CREDENTIALS

            try
            {
                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {

                    //var contentType = ContentType.Parse(httpResponse.ContentType);

                    // READ THE RESPONSE STREAM USING XMLTEXTREADER
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {

                        Stream stream = httpResponse.GetResponseStream(); // READ THE RESPONSE STREAM USING STREAMREADER
                        MemoryStream copiedStream = new MemoryStream();
                        stream.CopyTo(copiedStream);
                        copiedStream.Position = 0;

                        if (stream != null)
                        {

                            
                            MultiPartParser mpParser = new MultiPartParser();
                            List<MultiPartSection> sections =  mpParser.Parse(copiedStream, Encoding.UTF8);

                            return sections;

                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING OBJECT : {0}", e.Message);
            }

            return null;

        }

        public List<CDK.ETL.DDF.Property.RETSMetadataLookupType> GetMetadataLookupType(string type, string subType)
        {

            string Query = type + ":" + subType;
            string Format = "STANDARD-XML";
            string Type = "METADATA-LOOKUP_TYPE";

            string requestArguments = "?Type=" + Type + "&Format" + Format + "&ID=" + Query;
            string searchService = RetsUrl + "/Metadata.svc/GetMetadata" + requestArguments;

            List<CDK.ETL.DDF.Property.RETSMetadataLookupType> lookupTypes = new List<CDK.ETL.DDF.Property.RETSMetadataLookupType>();

            try
            {

                httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
                httpWebRequest.CookieContainer = session.cookieJar; //GRAB THE COOKIE
                httpWebRequest.Credentials = session.requestCredentials; //PASS CREDENTIALS

                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {

                    Stream stream = httpResponse.GetResponseStream();

                    XmlTextReader xmlReader = new XmlTextReader(stream);
                    XmlSerializer mySerializer = new XmlSerializer(typeof(CDK.ETL.DDF.Property.RETS));
                    CDK.ETL.DDF.Property.RETS rets = (CDK.ETL.DDF.Property.RETS)mySerializer.Deserialize(xmlReader);

                    if (rets.METADATA != null && rets.METADATA.MetaDataLookupType != null)
                    {

                        return lookupTypes = rets.METADATA.MetaDataLookupType.LookupType.ToList();

                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return lookupTypes;

        }

        public List<CDK.ETL.DDF.Agent.RETS> GetAgentsFromDdf(DateTime? lastUpdate)
        {

            try
            {

                List<CDK.ETL.DDF.Agent.RETS> retsElementsList = new List<CDK.ETL.DDF.Agent.RETS>();

                int retsTotalPage = 0;
                int retsOffset = 1;
                int retsRecordsReturned = 0;
                int retsTotalRecords = 0;

                int retsCount = 1;
                int retsLimit = 100;

                string searchType = "Agent";
                string retsClass = "Agent";
                string retsQueryType = "DMQL2";
                string retsQuery = "";
                string retsCulture = "en-CA";
                string retsFormat = "STANDARD-XML";

                //if there is a last update passed as arguement then request only from that date
                retsQuery = "(ID=*)";
                if (lastUpdate!=null)
                {
                    retsQuery = "(LastUpdated=" + lastUpdate.Value.ToString("yyyy-MM-ddThh:mm:ssZ") + ")";
                }
                
                do
                {

                    string requestArguments = "?Format=" + retsFormat + "&SearchType=" + searchType + "&Class=" + retsClass + "&QueryType=" + retsQueryType + "&Query=" + retsQuery + "&Count=" + retsCount + "&Limit=" + retsLimit + "&Offset=" + retsOffset + "&Culture=" + retsCulture;

                    string searchService = RetsUrl + "/Search.svc/Search" + requestArguments;

                    httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
                    httpWebRequest.CookieContainer = session.cookieJar; //GRAB THE COOKIE
                    httpWebRequest.Credentials = session.requestCredentials; //PASS CREDENTIALS

                    using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                    {

                        Stream stream = httpResponse.GetResponseStream();

                        XmlTextReader xmlReader = new XmlTextReader(stream);

                        XmlSerializer mySerializer = new XmlSerializer(typeof(CDK.ETL.DDF.Agent.RETS));
                        CDK.ETL.DDF.Agent.RETS rets = (CDK.ETL.DDF.Agent.RETS)mySerializer.Deserialize(xmlReader);

                        if (rets.RETSResponse != null && rets.RETSResponse.AgentDetails != null)
                        {

                            int.TryParse(rets.RETSResponse.Pagination.TotalPages, out retsTotalPage);
                            int.TryParse(rets.RETSResponse.Pagination.Offset, out retsOffset);
                            int.TryParse(rets.RETSResponse.Pagination.RecordsReturned, out retsRecordsReturned);
                            int.TryParse(rets.RETSResponse.Pagination.TotalRecords, out retsTotalRecords);

                        }

                        retsElementsList.Add(rets);
                    }

                    retsOffset++;

                } while (retsOffset <= retsTotalPage);
                return retsElementsList;
            }
            catch (XmlException e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING AGENT FROM DDF : {0}", e.Message);
                throw new Exception(e.Message, e);
            }

        }

        public List<CDK.ETL.DDF.Office.RETS> GetOfficesFromDdf(DateTime? lastUpdate)
        {

            try
            {

                List<CDK.ETL.DDF.Office.RETS> retsElementsList = new List<CDK.ETL.DDF.Office.RETS>();

                int retsTotalPage = 0;
                int retsOffset = 1;
                int retsRecordsReturned = 0;
                int retsTotalRecords = 0;

                int retsCount = 1;
                int retsLimit = 100;

                string searchType = "Office";
                string retsClass = "Office";
                string retsQueryType = "DMQL2";
                string retsQuery = "";
                string retsCulture = "en-CA";
                string retsFormat = "STANDARD-XML";

                //if there is a last update passed as arguement then request only from that date
                retsQuery = "(ID=*)";
                if (lastUpdate != null)
                {
                    retsQuery = "(LastUpdated=" + lastUpdate.Value.ToString("yyyy-MM-ddThh:mm:ssZ") + ")";
                }

                do
                {

                    string requestArguments = "?Format=" + retsFormat + "&SearchType=" + searchType + "&Class=" + retsClass + "&QueryType=" + retsQueryType + "&Query=" + retsQuery + "&Count=" + retsCount + "&Limit=" + retsLimit + "&Offset=" + retsOffset + "&Culture=" + retsCulture;

                    string searchService = RetsUrl + "/Search.svc/Search" + requestArguments;

                    httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
                    httpWebRequest.CookieContainer = session.cookieJar; //GRAB THE COOKIE
                    httpWebRequest.Credentials = session.requestCredentials; //PASS CREDENTIALS

                    using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                    {

                        Stream stream = httpResponse.GetResponseStream();

                        XmlTextReader xmlReader = new XmlTextReader(stream);

                        XmlSerializer mySerializer = new XmlSerializer(typeof(CDK.ETL.DDF.Office.RETS));
                        CDK.ETL.DDF.Office.RETS rets = (CDK.ETL.DDF.Office.RETS)mySerializer.Deserialize(xmlReader);

                        if (rets.RETSResponse != null && rets.RETSResponse.OfficeDetails != null)
                        {

                            int.TryParse(rets.RETSResponse.Pagination.TotalPages, out retsTotalPage);
                            int.TryParse(rets.RETSResponse.Pagination.Offset, out retsOffset);
                            int.TryParse(rets.RETSResponse.Pagination.RecordsReturned, out retsRecordsReturned);
                            int.TryParse(rets.RETSResponse.Pagination.TotalRecords, out retsTotalRecords);

                        }

                        retsElementsList.Add(rets);
                    }
                    
                    retsOffset++;

                } while (retsOffset <= retsTotalPage);

                return retsElementsList;

            }
            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING OFFICE FROM DDF : {0}", e.Message);
                throw new Exception(e.Message, e);
            }
        }

        public Dictionary<string, string> GetPropertyMasterList()
        {

            Dictionary<string, string> masterList = new Dictionary<string, string>();

            try
            {

                List<CDK.ETL.DDF.Property.RETS> retsList = GetPropertiesFromDdf(null);
                foreach (var rets in retsList)
                {
                    if (rets.RETSResponse != null && rets.RETSResponse.Property != null)
                    {
                        foreach (CDK.ETL.DDF.Property.RETSResponseProperty singleProperty in rets.RETSResponse.Property)
                        {
                            masterList.Add(singleProperty.ID, singleProperty.LastUpdated);
                        }
                    }
                }

                return masterList;

            }

            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING PROPERTY MASTER LIST FROM DDF : {0}", e.Message);
                throw new Exception(e.Message, e);
            }

        }

        public Dictionary<string, string> GetOfficeMasterList()
        {

            Dictionary<string, string> masterList = new Dictionary<string, string>();

            try
            {

                List<CDK.ETL.DDF.Office.RETS> retsList = GetOfficesFromDdf(null);
                foreach (var rets in retsList)
                {
                    if (rets.RETSResponse != null && rets.RETSResponse.Office != null)
                    {
                        foreach (CDK.ETL.DDF.Office.RETSResponseOffice singleProperty in rets.RETSResponse.Office)
                        {
                            masterList.Add(singleProperty.ID, singleProperty.LastUpdated);
                        }
                    }
                }

                return masterList;

            }

            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING OFFICE MASTER LIST FROM DDF : {0}", e.Message);
                throw new Exception(e.Message, e);
            }

        }

        public Dictionary<string, string> GetAgentMasterList()
        {

            Dictionary<string, string> masterList = new Dictionary<string, string>();

            try
            {

                List<CDK.ETL.DDF.Agent.RETS> retsList = GetAgentsFromDdf(null);
                foreach (var rets in retsList)
                {
                    if (rets.RETSResponse != null && rets.RETSResponse.Agent != null)
                    {
                        foreach (CDK.ETL.DDF.Agent.RETSResponseAgent singleProperty in rets.RETSResponse.Agent)
                        {
                            masterList.Add(singleProperty.ID, singleProperty.LastUpdated);
                        }
                    }
                }

                return masterList;

            }

            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING AGENT MASTER LIST FROM DDF : {0}", e.Message);
                throw new Exception(e.Message, e);
            }

        }

        public List<CDK.ETL.DDF.Property.RETS> GetPropertiesFromDdf(DateTime? lastUpdate)
        {

            try
            {

                List<CDK.ETL.DDF.Property.RETS> retsElementsList = new List<CDK.ETL.DDF.Property.RETS>();

                int retsTotalPage = 0;
                int retsOffset = 1;
                int retsRecordsReturned = 0;
                int retsTotalRecords = 0;

                int retsCount = 1;
                int retsLimit = 100;

                string searchType = "Property";
                string retsClass = "Property";
                string retsQueryType = "DMQL2";
                string retsQuery = "";
                string retsCulture = "en-CA";
                string retsFormat = "STANDARD-XML";

                //if there is a last update passed as arguement then request only from that date
                retsQuery = "(ID=*)";
                if (lastUpdate != null)
                {
                    retsQuery = "(LastUpdated=" + lastUpdate.Value.ToString("yyyy-MM-ddThh:mm:ssZ") + ")";
                }

                do
                {

                    string requestArguments = "?Format=" + retsFormat + "&SearchType=" + searchType + "&Class=" + retsClass + "&QueryType=" + retsQueryType + "&Query=" + retsQuery + "&Count=" + retsCount + "&Limit=" + retsLimit + "&Offset=" + retsOffset + "&Culture=" + retsCulture;

                    string searchService = RetsUrl + "/Search.svc/Search" + requestArguments;

                    httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
                    httpWebRequest.CookieContainer = session.cookieJar; //GRAB THE COOKIE
                    httpWebRequest.Credentials = session.requestCredentials; //PASS CREDENTIALS

                    using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                    {

                        Stream stream = httpResponse.GetResponseStream();

                        XmlTextReader xmlReader = new XmlTextReader(stream);

                        XmlSerializer mySerializer = new XmlSerializer(typeof(CDK.ETL.DDF.Property.RETS));
                        CDK.ETL.DDF.Property.RETS rets = (CDK.ETL.DDF.Property.RETS)mySerializer.Deserialize(xmlReader);

                        if (rets.RETSResponse != null && rets.RETSResponse.PropertyDetails != null)
                        {

                            int.TryParse(rets.RETSResponse.Pagination.TotalPages, out retsTotalPage);
                            int.TryParse(rets.RETSResponse.Pagination.Offset, out retsOffset);
                            int.TryParse(rets.RETSResponse.Pagination.RecordsReturned, out retsRecordsReturned);
                            int.TryParse(rets.RETSResponse.Pagination.TotalRecords, out retsTotalRecords);

                        }

                        retsElementsList.Add(rets);
                    }

                    retsOffset++;

                } while (retsOffset <= retsTotalPage);
                return retsElementsList;
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING PROPERTIES FROM DDF : {0}", e.Message);
                throw new Exception(e.Message, e);
            }
        }

        public List<CDK.ETL.DDF.Property.RETS> GetRequestedProperties(string SearchType, string Class, string QueryType, string Query, int Count, string Limit, int Offset, string Culture, string Format)
        {

            try
            {

                string requestArguments = "?Format=" + Format + "&SearchType=" + SearchType + "&Class=" + Class + "&QueryType=" + QueryType + "&Query=" + Query + "&Count=" + Count + "&Limit=" + Limit + "&Offset=" + Offset + "&Culture=" + Culture;
                string searchService = RetsUrl + "/Search.svc/Search" + requestArguments;

                httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
                httpWebRequest.CookieContainer = session.cookieJar; //GRAB THE COOKIE
                httpWebRequest.Credentials = session.requestCredentials; //PASS CREDENTIALS

                List<CDK.ETL.DDF.Property.RETS> retsList = new List<CDK.ETL.DDF.Property.RETS>();

                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {

                    Stream stream = httpResponse.GetResponseStream();

                    XmlTextReader xmlReader = new XmlTextReader(stream);
                    XmlSerializer mySerializer = new XmlSerializer(typeof(CDK.ETL.DDF.Property.RETS));
                    CDK.ETL.DDF.Property.RETS rets = (CDK.ETL.DDF.Property.RETS)mySerializer.Deserialize(xmlReader);

                    retsList.Add(rets);
                    return retsList;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING LIST OF REQUESTED PROPERTIES FROM DDF : {0}", e.Message);
                throw new Exception(e.Message, e);
            }
        }

        public List<CDK.ETL.DDF.Office.RETS> GetRequestedOffice(string SearchType, string Class, string QueryType, string Query, int Count, string Limit, int Offset, string Culture, string Format)
        {

            try
            {

                string requestArguments = "?Format=" + Format + "&SearchType=" + SearchType + "&Class=" + Class + "&QueryType=" + QueryType + "&Query=" + Query + "&Count=" + Count + "&Limit=" + Limit + "&Offset=" + Offset + "&Culture=" + Culture;
                string searchService = RetsUrl + "/Search.svc/Search" + requestArguments;

                httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
                httpWebRequest.CookieContainer = session.cookieJar; //GRAB THE COOKIE
                httpWebRequest.Credentials = session.requestCredentials; //PASS CREDENTIALS

                List<CDK.ETL.DDF.Office.RETS> retsList = new List<CDK.ETL.DDF.Office.RETS>();

                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {

                    Stream stream = httpResponse.GetResponseStream();

                    XmlTextReader xmlReader = new XmlTextReader(stream);
                    XmlSerializer mySerializer = new XmlSerializer(typeof(CDK.ETL.DDF.Office.RETS));
                    CDK.ETL.DDF.Office.RETS rets = (CDK.ETL.DDF.Office.RETS)mySerializer.Deserialize(xmlReader);

                    retsList.Add(rets);
                    return retsList;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING LIST OF REQUESTED OFFICES FROM DDF : {0}", e.Message);
                throw new Exception(e.Message, e);
            }

        }

        public List<CDK.ETL.DDF.Agent.RETS> GetRequestedAgent(string SearchType, string Class, string QueryType, string Query, int Count, string Limit, int Offset, string Culture, string Format)
        {

            try
            {

                string requestArguments = "?Format=" + Format + "&SearchType=" + SearchType + "&Class=" + Class + "&QueryType=" + QueryType + "&Query=" + Query + "&Count=" + Count + "&Limit=" + Limit + "&Offset=" + Offset + "&Culture=" + Culture;
                string searchService = RetsUrl + "/Search.svc/Search" + requestArguments;

                httpWebRequest = (HttpWebRequest)WebRequest.Create(searchService);
                httpWebRequest.CookieContainer = session.cookieJar; //GRAB THE COOKIE
                httpWebRequest.Credentials = session.requestCredentials; //PASS CREDENTIALS

                List<CDK.ETL.DDF.Agent.RETS> retsList = new List<CDK.ETL.DDF.Agent.RETS>();

                using (HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {

                    Stream stream = httpResponse.GetResponseStream();

                    XmlTextReader xmlReader = new XmlTextReader(stream);
                    XmlSerializer mySerializer = new XmlSerializer(typeof(CDK.ETL.DDF.Agent.RETS));
                    CDK.ETL.DDF.Agent.RETS rets = (CDK.ETL.DDF.Agent.RETS)mySerializer.Deserialize(xmlReader);

                    retsList.Add(rets);
                    return retsList;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(">>> ERROR WHILE GETTING LIST OF REQUESTED AGENTS FROM DDF : {0}", e.Message);
                throw new Exception(e.Message, e);
            }
        }
    }
}
