﻿using KartAppBE.BLL.Interfaces.Repositories;
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
    public class UserRepository(UserManager<User> userManager, ApplicationDbContext dbContext) : IUserRepository
    {
        public async Task<List<User>> GetAllUsers()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task RegisterUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
