using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Services
{
	public class UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher) : IUserService
	{
		public async Task<List<User>> GetAllUsers()
		{
			return await userRepository.GetAllUsers();
		}

		public async Task<User?> GetByEmail(string email)
		{
			return await userRepository.GetByEmail(email);
		}

		public async Task RegisterUser(User user)
		{
			user.PasswordHash = passwordHasher.HashPassword(user, user.PasswordHash);
			await userRepository.RegisterUser(user);
		}
	}
}
