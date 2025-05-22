using KartAppBE.BLL.Models;
using KartAppBE.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace KartAppBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController(IConfiguration config) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllMessages()
		{
			var messages = new List<Contact>();

			try
			{
				using var connection = new MySqlConnection(config.GetConnectionString("DefaultConnection"));
				await connection.OpenAsync();

				var query = "SELECT Id, Name, Email, Message FROM contact";
				using var command = new MySqlCommand(query, connection);
				using var reader = await command.ExecuteReaderAsync();

				while (await reader.ReadAsync())
				{
					messages.Add(new Contact
					{
						Name = reader.GetString("Name"),
						Email = reader.GetString("Email"),
						Message = reader.GetString("Message")
					});
				}

				return Ok(messages);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
			}
		}

		[HttpPost]
		public async Task<IActionResult> SubmitContactForm([FromBody] ContactRequest request)
		{
			try
			{
				using var connection = new MySqlConnection(config.GetConnectionString("DefaultConnection"));
				await connection.OpenAsync();

				var query = "INSERT INTO contact (Id, Name, Email, Message) VALUES (@Id, @Name, @Email, @Message)";
				using var command = new MySqlCommand(query, connection);
				command.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString());
				command.Parameters.AddWithValue("@Name", request.Name);
				command.Parameters.AddWithValue("@Email", request.Email);
				command.Parameters.AddWithValue("@Message", request.Message);

				if ((request.Message ?? "").Contains('<', StringComparison.OrdinalIgnoreCase))
					return BadRequest("Potentially dangerous input detected.");

				await command.ExecuteNonQueryAsync();

				return Ok(new { message = "Contact form submitted successfully." });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
			}
		}

		private readonly string basePath = Path.Combine(Directory.GetCurrentDirectory(), "Folder");

		private static readonly HashSet<string> AllowedFiles =
		[
			"example.txt",
		];

		[HttpGet("download")]
		public IActionResult DownloadFile([FromQuery] string filename)
		{
			if (!AllowedFiles.Contains(filename))
			{
				return BadRequest("File is unavailable for download.");
			}

			var basePath = Path.GetFullPath("Folder");
			var sanitizedFileName = Path.GetFileName(filename);
			var fullPath = Path.GetFullPath(Path.Combine(basePath, sanitizedFileName));

			if (!System.IO.File.Exists(fullPath))
			{
				return NotFound("File not found.");
			}

			var bytes = System.IO.File.ReadAllBytes(fullPath);
			return File(bytes, "application/octet-stream", Path.GetFileName(filename));
		}
	}
}
