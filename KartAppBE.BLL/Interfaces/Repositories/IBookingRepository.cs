using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Repositories
{
	public interface IBookingRepository
	{
		Task<List<Booking>> GetAllBookings();
		Task<Booking?> GetBookingById(int bookingId);
		Task CreateBooking(Booking booking);
		Task<BookingUser?> GetByBookingAndUserId(int bookingId, string userId);
		Task AddUserToBooking(BookingUser bookingUser);
	}
}
