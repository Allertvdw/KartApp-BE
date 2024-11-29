using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Services
{
	public class BookingService(IBookingRepository bookingRepository) : IBookingService
	{
		public async Task<List<Booking>> GetAllBookings()
		{
			return await bookingRepository.GetAllBookings();
		}

		public async Task<Booking?> GetBookingById(int bookingId)
		{
			return await bookingRepository.GetBookingById(bookingId);
		}

		public async Task CreateBooking(Booking booking)
		{
			await bookingRepository.CreateBooking(booking);
		}

		public async Task AddUserToBooking(BookingUser bookingUser)
		{
			await bookingRepository.AddUserToBooking(bookingUser);
		}
	}
}
