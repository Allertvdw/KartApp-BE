using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KartAppBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController(IBookingService bookingService, ISessionRepository sessionRepository) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllBookings()
		{
			var bookings = await bookingService.GetAllBookings();
			return Ok(bookings);
		}

		[HttpGet("{bookingId}")]
		public async Task<IActionResult> GetBookingById(int bookingId)
		{
			var booking = await bookingService.GetBookingById(bookingId);
			return Ok(booking);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBooking(BookingRequest request)
		{
			var session = await sessionRepository.GetSessionById(request.SessionId);

			Booking booking = new()
			{
				Session = session,
				PeopleCount = request.PeopleCount,
				Email = request.Email,
				PhoneNumber = request.PhoneNumber,
			};

			await bookingService.CreateBooking(booking);
			return Ok(booking);
		}

		[HttpPost("add-user")]
		public async Task<IActionResult> AddUserToBooking(BookingUser bookingUser)
		{
			await bookingService.AddUserToBooking(bookingUser);
			return Ok();
		}
	}
}
