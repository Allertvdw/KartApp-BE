using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Models;
using KartAppBE.DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.DAL.Repositories
{
    public class UserRepository(UserManager<User> userManager) : IUserRepository
    {
        public async Task<User?> GetByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }
    }
}
