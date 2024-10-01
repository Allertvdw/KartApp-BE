﻿using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Services
{
	public class UserService(IUserRepository userRepository) : IUserService
	{
		public async Task<User?> GetByEmail(string email)
		{
			return await userRepository.GetByEmail(email);
		}
	}
}