using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KartAppBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController(IBookingService bookingService) : ControllerBase
	{
		[HttpPost]
		public async Task<ActionResult<Booking>> CreateBooking([FromForm] Booking booking)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			string? email = User.FindFirstValue(ClaimTypes.Email);

			if (string.IsNullOrEmpty(email))
			{
				return Unauthorized("User email not found.");
			}

			Booking newBooking = await bookingService.Create(booking, email);

			return Ok(newBooking);
		}
	}
}
