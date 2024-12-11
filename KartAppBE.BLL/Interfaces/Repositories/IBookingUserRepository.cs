using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Repositories
{
	public interface IBookingUserRepository
	{
		Task<BookingUser?> GetByBookingAndUser(Booking booking, User user);
		Task CreateBookingUser(BookingUser bookingUser);
	}
}
