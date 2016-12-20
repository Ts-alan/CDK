using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace CDK.ETL.DDF.ExternalTools.MultipartParser
{

    public class MultiPartParser
    {
        /*
        *
        * 
        * Based on this data structure:
        * --creaboundary
        * Content-Type: image/jpeg
        * Content-ID:16744377
        * Object-ID:1
        * Content-Description: null
        * 
        * Bytes-JPEG FF D8 FF E0 00
        * 10 4A 46 49 46 
        * 00 01 01 01 00 
        * 60 00 60 00 00 FFDBBytes-JPEG
        * --creaboundary
        * Content-Type: image/jpeg
        * ...
        * --creaboundary--
        * 
        * 
        * Ref: 
        * https://bitbucket.org/lorenzopolidori/http-form-parser/src/a48defaac3b2c8a4b89152bffb8a2eb33ad57e53/HttpMultipartParser.cs (lorenzo)
        * http://multipartparser.codeplex.com/SourceControl/latest#MultipartParser.cs
        * 
        * 
        */

        public List<MultiPartSection> Parse(Stream stream, Encoding encoding)
        {

            this.Success = false;

            // Read the stream into a byte array
            byte[] data = ToByteArray(stream);

            // Copy to a string for header parsing
            string content = encoding.GetString(data);

            int BinaryDataStartIndex = 0;
            int BinaryDataEndIndex = 0;

            //  delimiter
            string delimiterSection = "--creaboundary";
            string delimiterContentDescription = "Content-Description:";
            byte[] delimiterSectionBytes = encoding.GetBytes("\r\n" + delimiterSection);
            byte[] delimiterContentDescriptionBytes = encoding.GetBytes("\r\n" + delimiterContentDescription);

            //new try with byte lead seek

            //Initalize the Indexes
            int BoundaryStartIndex = IndexOf(data, delimiterSectionBytes, 0) + 18; // 18 is the length of "\r\n--creaboundary\r\n"
            int BoundaryEndIndex = IndexOf(data, delimiterSectionBytes, BoundaryStartIndex);

            int ContentDescriptionStartIndex = 0;
            List<MultiPartSection> mpSection = new List<MultiPartSection>();

            while (BoundaryStartIndex > -1 && BoundaryEndIndex > -1)
            {
                //copy byte data to string se we can exact data headers (Content-Type,Content-Description,etc)
                int sectionDataLen = BoundaryEndIndex - BoundaryStartIndex;
                byte[] sectionData = new byte[sectionDataLen];
                Array.Copy(data, BoundaryStartIndex, sectionData, 0, sectionDataLen);
                string sectionDataString = encoding.GetString(sectionData);

                Regex re = new Regex(@"(?<=Content\-Type:)(.*?)(?=\r\n)");
                Match ContentTypeMatch = re.Match(sectionDataString);

                re = new Regex(@"(?<=Content\-ID:)(.*?)(?=\r\n)");
                Match ContentIDMatch = re.Match(sectionDataString);

                re = new Regex(@"(?<=Object\-ID:)(.*?)(?=\r\n)");
                Match ObjectIDMatch = re.Match(sectionDataString);

                re = new Regex(@"(?<=Content\-Description:)(.*?)(?=\r\n)");
                Match contentDescriptionMatch = re.Match(sectionDataString);

                string ContentType = ContentTypeMatch.Value.Trim();
                string ContentID = ContentIDMatch.Value.Trim();
                string ObjectID = ObjectIDMatch.Value.Trim();
                string contentDescription = contentDescriptionMatch.Value.Trim();

                //extract binary
                ContentDescriptionStartIndex = IndexOf(data, delimiterContentDescriptionBytes, BoundaryStartIndex);
                BinaryDataStartIndex = IndexOf(data, encoding.GetBytes("\r\n\r\n"), ContentDescriptionStartIndex) + 4; // 4 is length of "\r\n\r\n"                
                if (BinaryDataStartIndex > -1)
                {
                    BinaryDataEndIndex = IndexOf(data, delimiterSectionBytes, BinaryDataStartIndex);
                    if (BinaryDataEndIndex > -1)
                    {
                        int BinaryDataLen = BinaryDataEndIndex - BinaryDataStartIndex;

                        // Extract the file contents from the byte array
                        byte[] BinaryData = new byte[BinaryDataLen];

                        Buffer.BlockCopy(data, BinaryDataStartIndex, BinaryData, 0, BinaryDataLen);

                        mpSection.Add(new MultiPartSection(ContentType, ContentID, ObjectID, contentDescription, new MemoryStream(BinaryData)));
                    }
                }

                //set the indexes for next section
                BoundaryStartIndex = BoundaryEndIndex + 18;
                BoundaryEndIndex = IndexOf(data, encoding.GetBytes("\r\n" + delimiterSection), BoundaryEndIndex + 1);

            }

            return mpSection;

        }

        private int IndexOf(byte[] searchWithin, byte[] serachFor, int startIndex)
        {
            int index = 0;
            int startPos = Array.IndexOf(searchWithin, serachFor[0], startIndex);

            if (startPos != -1)
            {
                while ((startPos + index) < searchWithin.Length)
                {
                    if (searchWithin[startPos + index] == serachFor[index])
                    {
                        index++;
                        if (index == serachFor.Length)
                        {
                            return startPos;
                        }
                    }
                    else
                    {
                        startPos = Array.IndexOf<byte>(searchWithin, serachFor[0], startPos + index);
                        if (startPos == -1)
                        {
                            return -1;
                        }
                        index = 0;
                    }
                }
            }

            return -1;
        }
        private byte[] ToByteArray(Stream stream) {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
        public bool Success
        {
            get;
            private set;
        }
    }
}

