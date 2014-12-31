using app.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Infrastructure.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(RegisterViewModel userModel);
        Task<ApplicationUser> FindUser(string userName, string password);
        Task<ApplicationUser> FindUserByName(string userName);
    }
}
