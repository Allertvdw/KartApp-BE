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
		[HttpGet]
		public async Task<IActionResult> GetAllBookings()
		{
			var bookings = await bookingService.GetAllBookings();
			return Ok(bookings);
		}

		[HttpGet]
		public async Task<IActionResult> GetBookingById(int bookingId)
		{
			var booking = await bookingService.GetBookingById(bookingId);
			return Ok(booking);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBooking(Booking booking)
		{
			await bookingService.CreateBooking(booking);
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> AddUserToBooking(BookingUser bookingUser)
		{
			await bookingService.AddUserToBooking(bookingUser);
			return Ok();
		}
	}
}
