using KartAppBE.BLL.Enums;
using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.BLL.RequestModels;
using KartAppBE.BLL.Services;
using KartAppBE.RequestModels;
using KartAppBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KartAppBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController(IBookingService bookingService, ISessionService sessionService,
		IUserService userService, IBookingUserService bookingUserService) : ControllerBase
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

			BookingView bookingView = new()
			{
				Id = booking.Id,
				Date = booking.Session.StartTime.Date,
				StartTime = booking.Session.StartTime,
				EndTime = booking.Session.EndTime,
				PeopleCount = booking.PeopleCount,
				Email = booking.Email,
				PhoneNumber = booking.PhoneNumber,
				CreatedAt = booking.CreatedAt,
			};

			return Ok(bookingView);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBooking(BookingRequest request)
		{
			var session = await sessionService.GetSessionById(request.SessionId);

			Booking booking = new()
			{
				Session = session,
				PeopleCount = request.PeopleCount,
				Email = request.Email,
				PhoneNumber = request.PhoneNumber,
				CreatedAt = DateTime.UtcNow,
			};

			await bookingService.CreateBooking(booking);
			return Ok(booking);
		}

		[HttpPost("register-and-link-booking")]
		public async Task<IActionResult> RegisterAndLinkBooking([FromBody] LinkBookingRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var emailEntered = await userService.GetByEmail(request.Email);
			if (emailEntered != null)
			{
				ModelState.AddModelError("Email", "Email already exists.");
				return BadRequest(ModelState);
			}

			string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

			User user = new()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				PasswordHash = passwordHash,
				PhoneNumber = request.PhoneNumber,
				Role = Role.Client,
			};

			bool result = await bookingUserService.RegisterAndLinkBooking(user, request.BookingId);
			if (result)
			{
				return Ok("User registered and linked to booking.");
			}

			return BadRequest("Failed to link user to booking.");
		}
	}
}
