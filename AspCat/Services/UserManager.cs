using AspCat.Data;
using AspCat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspCat.Services
{
    public class UserManager : UserManager<ApplicationUser>
    {
        private ApplicationDbContext _context;

        public UserManager(
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger,
            ApplicationDbContext context) :
            base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _context = context;
        }

        public async Task<string> GetNameAsync(ClaimsPrincipal principal)
        {
            ThrowIfDisposed();
            var user = await GetUserAsync(principal);
            return user.Name;
        }

        public async Task<IdentityResult> SetNameAsync(ApplicationUser user, string name)
        {
            ThrowIfDisposed();
            var dbUser = _context.Users.SingleOrDefault(u => u.Id == user.Id);
            dbUser.Name = name;
            var status = await _context.SaveChangesAsync();
            return (status > 0) ? IdentityResult.Success : IdentityResult.Failed();
        }
    }
}
