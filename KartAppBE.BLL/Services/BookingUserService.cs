using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.BLL.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Services
{
	public class BookingUserService(IBookingUserRepository bookingUserRepository, IBookingRepository bookingRepository,
		IUserRepository userRepository, IKartRepository kartRepository) : IBookingUserService
	{
		public async Task<List<BookingUser>> GetBookingUserBySessionId(int sessionId)
		{
			return await bookingUserRepository.GetBookingUserBySessionId(sessionId);
		}

		public async Task<bool> RegisterAndLinkBooking(User user, int bookingId)
		{
			var createdUser = await userRepository.RegisterUser(user) ??
				throw new Exception("Failed to create user.");

			var booking = await bookingRepository.GetBookingById(bookingId) ??
				throw new Exception("Booking not found.");

			var kart = await kartRepository.GetFirstAvailableKart() ??
				throw new Exception("No available kart found.");

			var existingLink = await bookingUserRepository.GetByBookingAndUser(booking, createdUser);
			if (existingLink != null)
			{
				throw new Exception("User is already linked to the booking.");
			}

			var bookingUser = new BookingUser
			{
				Booking = booking,
				User = createdUser,
				Kart = kart,
			};

			await bookingUserRepository.CreateBookingUser(bookingUser);
			return true;
		}
	}
}
