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
	public class BookingService(IBookingRepository bookingRepository, IUserRepository userRepository) : IBookingService
	{
		public async Task<Booking> Create(Booking booking, string email)
		{
			User? user = await userRepository.GetByEmail(email);

			return await bookingRepository.Create(booking, user);
		}
	}
}
