using System.IO;

namespace CDK.ETL.DDF.ExternalTools.MultipartParser
{
    public class MultiPartSection
    {
        public string ContentType;
        public string ContentID;
        public string ObjectID;
        public string ContentDescription;
        public MemoryStream MultiPartMemoryStream;

        public MultiPartSection(string ContentType, string ContentID, string ObjectID, string ContentDescription, MemoryStream MultipartMemoryStream)
        {
            this.ContentType = ContentType;
            this.ContentID = ContentID;
            this.ObjectID = ObjectID;
            this.ContentDescription = ContentDescription;
            this.MultiPartMemoryStream = MultipartMemoryStream;
        }
    }
}
