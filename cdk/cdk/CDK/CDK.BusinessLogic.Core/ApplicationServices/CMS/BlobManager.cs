using CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;
using System.IO;

namespace CDK.BusinessLogic.Core.ApplicationServices.CMS
{
    internal class BlobManager : IBlobManager
    {
        public void Upload(string containerName, byte[] uploadBytes, string targetFileName)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["CDKStorageConnectionString"]);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);

            var blockBlob = container.GetBlockBlobReference(targetFileName);

            blockBlob.UploadFromByteArray(uploadBytes, 0, uploadBytes.Length);
        }

        public void Delete(string containerName, string targetFileName)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["CDKStorageConnectionString"]);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);

            var blockBlob = container.GetBlockBlobReference(targetFileName);

            blockBlob.Delete();
        }

        public void Rename(string containerName, string oldFilename, string newFilename)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["CDKStorageConnectionString"]);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);

            var oldBlob = container.GetBlockBlobReference(oldFilename);
            var newBlob = container.GetBlockBlobReference(newFilename);

            using (var stream = new MemoryStream())
            {
                oldBlob.DownloadToStream(stream);
                stream.Seek(0, SeekOrigin.Begin);
                newBlob.UploadFromStream(stream);

                oldBlob.Delete();
            }
        }
    }
}