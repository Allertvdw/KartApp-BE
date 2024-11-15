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
    public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        public async Task<List<User>> GetAllUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> RegisterUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
