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

		[HttpPost]
		public async Task<IActionResult> CreateKart(KartRequest request)
		{
			Kart kart = new()
			{
				Number = request.Number,
				Status = request.Status,
			};

			await kartService.CreateKart(kart);
			return Ok(kart);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteKart(int id)
		{
			await kartService.DeleteKart(id);
			return Ok();
		}
	}
}
