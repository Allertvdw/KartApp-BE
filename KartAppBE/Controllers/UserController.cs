using KartAppBE.BLL.Enums;
using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.RequestModels;
using KartAppBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KartAppBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController(IConfiguration config, IUserService userService) : ControllerBase
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

		[HttpPost("register")]
		public async Task<ActionResult<User>> Register(UserRequest request)
		{
			var emailEntered = await userService.GetByEmail(request.Email);
			if (emailEntered != null)
			{
				return BadRequest("Email already exists.");
			}

			string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

			User user = new()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				PasswordHash = passwordHash,
				PhoneNumber = request.PhoneNumber,
				Role = Role.Client
			};

			await userService.RegisterUser(user);
			return Ok(user);
		}

		[HttpPost("login")]
		public async Task<ActionResult<User>> Login(LoginRequest request)
		{
			User? user = await userService.GetByEmail(request.Email);
			if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
			{
				return Unauthorized("Invalid email or password.");
			}
			string token = CreateToken(user);
			return Ok(token);
		}

		private string CreateToken(User user)
		{
			List<Claim> claims =
			[
				new Claim(ClaimTypes.NameIdentifier, user.Id),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, user.Role.ToString())
			];

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Jwt:Key").Value!));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.UtcNow.AddHours(1),
				signingCredentials: credentials
			);

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);
			return jwt;
		}
	}
}
