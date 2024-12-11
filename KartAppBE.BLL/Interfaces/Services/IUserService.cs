using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Services
{
	public interface IUserService
	{
		Task<List<User>> GetAllUsers();
		Task<User?> GetByEmail(string email);
		Task<User> RegisterUser(User user);
	}
}
