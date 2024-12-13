using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Services
{
	public interface IBookingUserService
	{
		Task<List<BookingUser>> GetBookingUserBySessionId(int sessionId);
		Task<bool> RegisterAndLinkBooking(User user, int bookingId);
	}
}
