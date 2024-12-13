using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Services
{
	public interface IBookingService
	{
		Task<List<Booking>> GetAllBookings();
		Task<Booking?> GetBookingById(int bookingId);
		Task CreateBooking(Booking booking);
	}
}
