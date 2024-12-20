using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KartAppBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KartController(IKartService kartService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllKarts()
		{
			var karts = await kartService.GetAllKarts();
			return Ok(karts);
		}

		[HttpGet("{kartId}")]
		public async Task<IActionResult> GetKartById(int kartId)
		{
			var kart = await kartService.GetKartById(kartId);
			return Ok(kart);
		}

		[HttpPost]
		public async Task<IActionResult> CreateKart(KartRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Kart kart = new()
			{
				Number = request.Number,
				Status = request.Status,
			};

			await kartService.CreateKart(kart);
			return Ok(kart);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateKart([FromBody] Kart kart)
		{
			var updatedKart = await kartService.UpdateKart(kart);
			return Ok(updatedKart);
		}

		[HttpDelete("{kartId}")]
		public async Task<IActionResult> DeleteKart(int kartId)
		{
			await kartService.DeleteKart(kartId);
			return Ok();
		}
	}
}
