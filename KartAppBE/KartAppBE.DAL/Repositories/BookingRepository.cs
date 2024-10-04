using KartAppBE.BLL.Models;
using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.DAL.Repositories
{
	public class BookingRepository(ApplicationDbContext dbContext) : IBookingRepository
	{
		public async Task<Booking> Create(Booking booking, User user)
		{
			booking.User = user;
			await dbContext.Bookings.AddAsync(booking);
			await dbContext.SaveChangesAsync();

			return booking;
		}
	}
}
