using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Models;
using KartAppBE.DAL.Data;
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
            return await dbContext.users.ToListAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await dbContext.users.SingleOrDefaultAsync(e => e.Email == email);
        }

        public async Task<User> RegisterUser(User user)
        {
            await dbContext.users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
