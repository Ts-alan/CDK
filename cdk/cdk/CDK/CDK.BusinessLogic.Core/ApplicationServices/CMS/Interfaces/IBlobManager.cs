namespace CDK.BusinessLogic.Core.ApplicationServices.CMS.Interfaces
{
    internal interface IBlobManager
    {
        void Upload(string containerName, byte[] uploadBytes, string targetFileName);

        void Rename(string containerName, string oldFilename, string newFilename);

        void Delete(string containerName, string targetFileName);
    }
}