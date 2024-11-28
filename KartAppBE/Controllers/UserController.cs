using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.RequestModels;
using KartAppBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KartAppBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController(IUserService userService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllUsers()
		{
			var users = await userService.GetAllUsers();

			var userViewList = users.Select(u => new UserView
			{
				Id = u.Id,
				FirstName = u.FirstName,
				LastName = u.LastName,
				Email = u.Email,
				PhoneNumber = u.PhoneNumber,
				CreatedAt = u.CreatedAt
			}).ToList();

			return Ok(userViewList);
		}

		[HttpGet("{email}")]
		public async Task<ActionResult<User?>> GetByEmail(string email)
		{
			User? user = await userService.GetByEmail(email);

			if (user == null)
			{
				return NotFound($"User with email '{email}' not found.");
			}
			
			return Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> RegisterUser(UserRequest request)
		{
			User user = new()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				PasswordHash = request.Password,
				PhoneNumber = request.PhoneNumber,
			};

			await userService.RegisterUser(user);
			return Ok(user);
		}
	}
}
