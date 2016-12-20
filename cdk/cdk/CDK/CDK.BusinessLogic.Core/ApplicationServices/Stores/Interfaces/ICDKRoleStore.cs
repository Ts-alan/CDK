using CDK.DataAccess.Models.cdk;
using Microsoft.AspNet.Identity;

namespace CDK.BusinessLogic.Core.ApplicationServices.Stores.Interfaces
{
    internal interface ICDKRoleStore : IQueryableRoleStore<Role, long>
    {
    }
}