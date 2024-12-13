using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Models;
using KartAppBE.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.DAL.Repositories
{
	public class BookingUserRepository(ApplicationDbContext dbContext) : IBookingUserRepository
	{
		public async Task<List<BookingUser>> GetBookingUserBySessionId(int sessionId)
		{
			return await dbContext.bookingusers
				.Include(bu => bu.User)
				.Include(bu => bu.Kart)
				.Include(bu => bu.Booking)
				.ThenInclude(b => b.Session)
				.Where(bu => bu.Booking.Session.Id == sessionId)
				.ToListAsync();
		}

		public async Task<BookingUser?> GetByBookingAndUser(Booking booking, User user)
		{
			return await dbContext.bookingusers
				.Include(bu => bu.Booking)
				.Include(bu => bu.User)
				.FirstOrDefaultAsync(bu => bu.Booking.Id == booking.Id && bu.User.Id == user.Id);
		}

		public async Task CreateBookingUser(BookingUser bookingUser)
		{
			await dbContext.bookingusers.AddAsync(bookingUser);
			await dbContext.SaveChangesAsync();
		}
	}
}
