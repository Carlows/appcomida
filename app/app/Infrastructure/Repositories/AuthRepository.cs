using app.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace app.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;

        private UserManager<ApplicationUser> _userManager;

        public AuthRepository(ApplicationDbContext context)
        {
            _db = context;
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_db));
        }

        public async Task<IdentityResult> RegisterUser(RegisterViewModel userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _db.Dispose();
            _userManager.Dispose();
        }
    }
}