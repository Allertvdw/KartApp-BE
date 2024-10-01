using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KartAppBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController(IUserService userService) : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<User?>> GetByEmail(string email)
		{
			User? user = await userService.GetByEmail(email);

			if (user == null)
			{
				return NotFound($"User with email '{email}' not found.");
			}
			
			return Ok(user);
		}
	}
}
