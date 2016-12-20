using AutoMapper;
using CDK.BusinessLogic.Core.ApplicationServices.Stores.Interfaces;
using CDK.DataAccess.Models.cdk;
using Microsoft.AspNet.Identity;
using Repository.Pattern.Ef6;
using Repository.Pattern.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace CDK.BusinessLogic.Core.ApplicationServices.Stores
{
    internal class UserStore : ICDKUserStore
    {
        protected readonly IUnitOfWorkAsync UnitOfWork;
        protected readonly Logger Logger;
        protected readonly IMapper Mapper;

        public UserStore(UnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.Logger = LogManager.GetCurrentClassLogger();
            this.Mapper = AutoMapperConfig.GetMapper();
        }

        public UserStore()
        {
        }

        public IQueryable<User> Users
        {
            get
            {
                return this.UnitOfWork.Repository<User>().Queryable();
            }
        }

        public Task AddClaimAsync(User user, Claim claim)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                if (claim == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                var dbModel = this.Mapper.Map<UserClaim>(claim);

                dbModel.UserId = user.Id;

                uow.Repository<UserClaim>().Insert(dbModel);

                uow.SaveChanges();

                return Task.FromResult<object>(null);
            });
        }

        public Task AddLoginAsync(User user, UserLoginInfo login)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                if (login == null)
                {
                    throw new ArgumentNullException(nameof(login));
                }

                var dbModel = this.Mapper.Map<UserLogin>(login);

                dbModel.UserId = user.Id;

                uow.Repository<UserLogin>().Insert(dbModel);

                uow.SaveChanges();

                return Task.FromResult<object>(null);
            });
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                if (string.IsNullOrEmpty(roleName))
                {
                    throw new ArgumentException("Argument cannot be null or empty: roleName.");
                }

                var role = uow.Repository<Role>().Query(x => x.Name == roleName).Select().FirstOrDefault();

                if (role != null)
                {
                    var dbModel = uow.Repository<User>().Find(user.Id);

                    dbModel.Roles.Add(role);

                    uow.Repository<User>().Update(dbModel);

                    uow.SaveChanges();
                }

                return Task.FromResult<object>(null);
            });
        }

        public Task CreateAsync(User user)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                uow.Repository<User>().Insert(user);

                uow.SaveChanges();

                return Task.FromResult<object>(null);
            });
        }

        public Task DeleteAsync(User user)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                var repo = uow.Repository<User>();
                var model = repo.Find(user.Id);

                repo.Delete(model);
                uow.SaveChanges();

                return Task.FromResult<object>(null);
            });
        }

        public void Dispose()
        {
            this.UnitOfWork.Dispose();
        }

        public Task<User> FindAsync(UserLoginInfo login)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (login == null)
                {
                    throw new ArgumentNullException(nameof(login));
                }

                var userLogin = uow.Repository<UserLogin>()
                .Query(x => x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey)
                .Include(x => x.User)
                .Select()
                .FirstOrDefault();

                if (userLogin != null)
                {
                    return Task.FromResult<User>(userLogin.User);
                }

                return Task.FromResult<User>(null);
            });
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (email == null)
                {
                    throw new ArgumentNullException(nameof(email));
                }

                var user = uow.Repository<User>()
                .Query(x => x.Email == email)
                .Select()
                .FirstOrDefault();

                if (user != null)
                {
                    return Task.FromResult<User>(user);
                }

                return Task.FromResult<User>(null);
            });
        }

        public Task<User> FindByIdAsync(long userId)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var user = uow.Repository<User>()
                .Find(userId);

                if (user != null)
                {
                    return Task.FromResult<User>(user);
                }

                return Task.FromResult<User>(null);
            });
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (userName == null)
                {
                    throw new ArgumentNullException(nameof(userName));
                }

                var user = uow.Repository<User>()
                .Query(x => x.UserName == userName)
                .Select()
                .FirstOrDefault();

                if (user != null)
                {
                    return Task.FromResult<User>(user);
                }

                return Task.FromResult<User>(null);
            });
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult<int>(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {                           
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult<bool>(user.LockoutEnabled);
        }

        public Task<IList<Claim>> GetClaimsAsync(User user)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                ClaimsIdentity identity = new ClaimsIdentity();

                uow.Repository<UserClaim>()
                .Query(x => x.UserId == user.Id)
                .Select()
                .ToList()
                .Select(y => new Claim(y.ClaimType, y.ClaimValue))
                .ToList()
                .ForEach(z => identity.AddClaim(z));

                return Task.FromResult<IList<Claim>>(identity.Claims.ToList());
            });
        }

        public Task<string> GetEmailAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult<string>(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult<bool>(user.EmailConfirmed);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            DateTimeOffset dateTimeOffset;

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (user.LockoutEndDateUtc.HasValue)
            {
                DateTime? lockoutEndDateUtc = user.LockoutEndDateUtc;
                dateTimeOffset = new DateTimeOffset(DateTime.SpecifyKind(lockoutEndDateUtc.Value, DateTimeKind.Utc));
            }
            else
            {
                dateTimeOffset = new DateTimeOffset();
            }
            return Task.FromResult<DateTimeOffset>(dateTimeOffset);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                var logins = uow.Repository<UserLogin>()
                .Query(x => x.UserId == user.Id)
                .Select()
                .ToList()
                .Select(z => new UserLoginInfo(z.LoginProvider, z.ProviderKey))
                .ToList();

                if (logins != null)
                {
                    return Task.FromResult<IList<UserLoginInfo>>(logins);
                }

                return Task.FromResult<IList<UserLoginInfo>>(null);
            });
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult<string>(user.PasswordHash);
        }

        public Task<string> GetPhoneNumberAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult<string>(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult<bool>(user.PhoneNumberConfirmed);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                List<string> roles = uow.Repository<User>()
                .Query(x => x.Id == user.Id)
                .Include(z => z.Roles)
                .Select()
                .First()
                .Roles
                .Select(r => r.Name)
                .ToList();

                if (roles != null)
                {
                    return Task.FromResult<IList<string>>(roles);
                }

                return Task.FromResult<IList<string>>(null);
            });
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult<string>(user.SecurityStamp);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                return Task.FromResult<bool>(user.PasswordHash != null);
            });
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.AccessFailedCount = user.AccessFailedCount + 1;
            return Task.FromResult<int>(user.AccessFailedCount);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                if (string.IsNullOrEmpty(roleName))
                {
                    throw new ArgumentNullException("", "role");
                }

                var model = uow.Repository<User>().Query(x => x.Id == user.Id && x.Roles.Any(z => z.Name == roleName)).Select().FirstOrDefault();

                return Task.FromResult<bool>(model != null);
            });
        }

        public Task RemoveClaimAsync(User user, Claim claim)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                if (claim == null)
                {
                    throw new ArgumentNullException(nameof(claim));
                }

                var repo = uow.Repository<UserClaim>();

                repo.Query(x => x.ClaimType == claim.Type && x.UserId == user.Id && x.ClaimType == claim.Type).Select().ToList().ForEach(z => repo.Delete(z.Id));

                uow.SaveChanges();
                return Task.FromResult<object>(null);
            });
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                if (login == null)
                {
                    throw new ArgumentNullException(nameof(login));
                }

                var repo = uow.Repository<UserLogin>();
                repo.Query(x => x.UserId == user.Id && x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey).Select().ToList().ForEach(z => repo.Delete(new
                {
                    z.LoginProvider,
                    z.ProviderKey,
                    z.UserId
                }));

                uow.SaveChanges();

                return Task.FromResult<Object>(null);
            });
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.AccessFailedCount = 0;
            return Task.FromResult<int>(0);
        }

        public Task SetEmailAsync(User user, string email)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Email = email;
            return Task.FromResult<int>(0);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.EmailConfirmed = confirmed;
            return Task.FromResult<int>(0);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            if(user == null)

            {
                throw new ArgumentNullException(nameof(user));
            }
            user.LockoutEnabled = enabled;
            return Task.FromResult<int>(0);
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            DateTime? nullable;

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (lockoutEnd == DateTimeOffset.MinValue)
            {
                nullable = null;
            }
            else
            {
                nullable = new DateTime?(lockoutEnd.UtcDateTime);
            }
            user.LockoutEndDateUtc = nullable;
            return Task.FromResult<int>(0);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.PasswordHash = passwordHash;
            return Task.FromResult<int>(0);
        }

        public Task SetPhoneNumberAsync(User user, string phoneNumber)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.PhoneNumber = phoneNumber;
            return Task.FromResult<int>(0);
        }

        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.PhoneNumberConfirmed = confirmed;
            return Task.FromResult<int>(0);
        }

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.SecurityStamp = stamp;
            return Task.FromResult<int>(0);
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.TwoFactorEnabled = enabled;
            return Task.FromResult<int>(0);
        }

        public Task UpdateAsync(User user)
        {
            return this.InvokeInUnitOfWorkScope(uow =>
            {
                var model = uow.Repository<User>().Find(user.Id);

                model.UserName = user.UserName;
                model.PasswordHash = user.PasswordHash;
                model.SecurityStamp = user.SecurityStamp;
                model.Id = user.Id;
                model.Email = user.Email;
                model.EmailConfirmed = user.EmailConfirmed;
                model.PhoneNumber = user.PhoneNumber;
                model.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                model.AccessFailedCount = user.AccessFailedCount;
                model.LockoutEnabled = user.LockoutEnabled;
                model.LockoutEndDateUtc = user.LockoutEndDateUtc;
                model.TwoFactorEnabled = user.TwoFactorEnabled;
                model.LastName = user.LastName;
                model.FirstName = user.FirstName;

                uow.Repository<User>().Update(model);

                uow.SaveChanges();

                return Task.FromResult(0);
            });
        }

        protected virtual TResult InvokeInUnitOfWorkScope<TResult>(Func<IUnitOfWorkAsync, TResult> func)
        {
            var result = default(TResult);

            this.TryInvokeServiceActionInUnitOfWorkScope(
                work =>
                {
                    result = func.Invoke(work);
                });

            return result;
        }

        protected virtual void InvokeInUnitOfWorkScope(Action<IUnitOfWorkAsync> action)
        {
            this.TryInvokeServiceActionInUnitOfWorkScope(action.Invoke);
        }

        private void TryInvokeServiceActionInUnitOfWorkScope(Action<IUnitOfWorkAsync> action)
        {
            this.TryInvokeServiceAction(
                () =>
                {
                    action.Invoke(this.UnitOfWork);
                });
        }

        private void TryInvokeServiceAction(Action action)
        {
            try
            {
                action.Invoke();
            }
            /*catch (InvalidOperationException exception)
            {
            }   */
            catch (DbEntityValidationException ex)
            {
                Logger.Error(ex, "User");
                throw ex;
            }
            catch (Exception exception)
            {
                Logger.Error(exception, "User");
                throw new InvalidOperationException("cannot invoke service action", exception);
            }
        }
    }
}