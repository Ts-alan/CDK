using CDK.DataAccess.Models.cdk;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CDK.BusinessLogic.Core.ApplicationServices.Client.Interfaces
{
    public interface ICDKUserManager
    {
        IClaimsIdentityFactory<User, long> ClaimsIdentityFactory
        {
            get;
            set;
        }
        TimeSpan DefaultAccountLockoutTimeSpan
        {
            get;
            set;
        }
        IIdentityMessageService EmailService
        {
            get;
            set;
        }
        int MaxFailedAccessAttemptsBeforeLockout
        {
            get;
            set;
        }
        IPasswordHasher PasswordHasher
        {
            get;
            set;
        }
        IIdentityValidator<string> PasswordValidator
        {
            get;
            set;
        }
        IIdentityMessageService SmsService
        {
            get;
            set;
        }
        bool SupportsQueryableUsers
        {
            get;
        }
        bool SupportsUserClaim
        {
            get;
        }
        bool SupportsUserEmail
        {
            get;
        }
        bool SupportsUserLockout
        {
            get;
        }
        bool SupportsUserLogin
        {
            get;
        }
        bool SupportsUserPassword
        {
            get;
        }
        bool SupportsUserPhoneNumber
        {
            get;
        }
        bool SupportsUserRole
        {
            get;
        }
        bool SupportsUserSecurityStamp
        {
            get;
        }
        bool SupportsUserTwoFactor
        {
            get;
        }
        IDictionary<string, IUserTokenProvider<User, long>> TwoFactorProviders
        {
            get;
        }
        bool UserLockoutEnabledByDefault
        {
            get;
            set;
        }
        IQueryable<User> Users
        {
            get;
        }
        IUserTokenProvider<User, long> UserTokenProvider
        {
            get;
            set;
        }
        IIdentityValidator<User> UserValidator
        {
            get;
            set;
        }

        Task<IdentityResult> AccessFailedAsync(long userId);
        Task<IdentityResult> AddClaimAsync(long userId, Claim claim);
        Task<IdentityResult> AddLoginAsync(long userId, UserLoginInfo login);
        Task<IdentityResult> AddPasswordAsync(long userId, string password);
        Task<IdentityResult> AddToRoleAsync(long userId, string role);
        Task<IdentityResult> AddToRolesAsync(long userId, params string[] roles);
        Task<IdentityResult> ChangePasswordAsync(long userId, string currentPassword, string newPassword);
        Task<IdentityResult> ChangePhoneNumberAsync(long userId, string phoneNumber, string token);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IdentityResult> ConfirmEmailAsync(long userId, string token);
        Task<IdentityResult> CreateAsync(User user);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);
        Task<IdentityResult> DeleteAsync(User user);
        void Dispose();
        Task<User> FindAsync(UserLoginInfo login);
        Task<User> FindAsync(string userName, string password);
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByIdAsync(long userId);
        Task<User> FindByNameAsync(string userName);
        Task<string> GenerateChangePhoneNumberTokenAsync(long userId, string phoneNumber);
        Task<string> GenerateEmailConfirmationTokenAsync(long userId);
        Task<string> GeneratePasswordResetTokenAsync(long userId);
        Task<string> GenerateTwoFactorTokenAsync(long userId, string twoFactorProvider);
        Task<string> GenerateUserTokenAsync(string purpose, long userId);
        Task<int> GetAccessFailedCountAsync(long userId);
        Task<IList<Claim>> GetClaimsAsync(long userId);
        Task<string> GetEmailAsync(long userId);
        Task<bool> GetLockoutEnabledAsync(long userId);
        Task<DateTimeOffset> GetLockoutEndDateAsync(long userId);
        Task<IList<UserLoginInfo>> GetLoginsAsync(long userId);
        Task<string> GetPhoneNumberAsync(long userId);
        Task<IList<string>> GetRolesAsync(long userId);
        Task<string> GetSecurityStampAsync(long userId);
        Task<bool> GetTwoFactorEnabledAsync(long userId);
        Task<IList<string>> GetValidTwoFactorProvidersAsync(long userId);
        Task<bool> HasPasswordAsync(long userId);
        Task<bool> IsEmailConfirmedAsync(long userId);
        Task<bool> IsInRoleAsync(long userId, string role);
        Task<bool> IsLockedOutAsync(long userId);
        Task<bool> IsPhoneNumberConfirmedAsync(long userId);
        Task<IdentityResult> NotifyTwoFactorTokenAsync(long userId, string twoFactorProvider, string token);
        void RegisterTwoFactorProvider(string twoFactorProvider, IUserTokenProvider<User, long> provider);
        Task<IdentityResult> RemoveClaimAsync(long userId, Claim claim);
        Task<IdentityResult> RemoveFromRoleAsync(long userId, string role);
        Task<IdentityResult> RemoveFromRolesAsync(long userId, params string[] roles);
        Task<IdentityResult> RemoveLoginAsync(long userId, UserLoginInfo login);
        Task<IdentityResult> RemovePasswordAsync(long userId);
        Task<IdentityResult> ResetAccessFailedCountAsync(long userId);
        Task<IdentityResult> ResetPasswordAsync(long userId, string token, string newPassword);
        Task SendEmailAsync(long userId, string subject, string body);
        Task SendSmsAsync(long userId, string message);
        Task<IdentityResult> SetEmailAsync(long userId, string email);
        Task<IdentityResult> SetLockoutEnabledAsync(long userId, bool enabled);
        Task<IdentityResult> SetLockoutEndDateAsync(long userId, DateTimeOffset lockoutEnd);
        Task<IdentityResult> SetPhoneNumberAsync(long userId, string phoneNumber);
        Task<IdentityResult> SetTwoFactorEnabledAsync(long userId, bool enabled);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IdentityResult> UpdateSecurityStampAsync(long userId);
        Task<bool> VerifyChangePhoneNumberTokenAsync(long userId, string token, string phoneNumber);
        Task<bool> VerifyTwoFactorTokenAsync(long userId, string twoFactorProvider, string token);
        Task<bool> VerifyUserTokenAsync(long userId, string purpose, string token);
    }
}
