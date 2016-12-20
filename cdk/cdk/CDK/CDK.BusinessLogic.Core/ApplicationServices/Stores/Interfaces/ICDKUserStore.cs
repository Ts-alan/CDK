using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CDK.DataAccess.Models.cdk;
using Microsoft.AspNet.Identity;

namespace CDK.BusinessLogic.Core.ApplicationServices.Stores.Interfaces
{
    public interface ICDKUserStore:
        IUserLoginStore<User, long>,
        IUserClaimStore<User, long>,
        IUserRoleStore<User, long>,
        IUserPasswordStore<User, long>,
        IUserSecurityStampStore<User, long>,
        IQueryableUserStore<User, long>,
        IUserEmailStore<User, long>,
        IUserPhoneNumberStore<User, long>,
        IUserTwoFactorStore<User, long>,
        IUserLockoutStore<User, long>,
        IUserStore<User, long> 
    {   
    }
}