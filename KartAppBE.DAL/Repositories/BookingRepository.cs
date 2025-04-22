using KartAppBE.BLL.Models;
using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KartAppBE.DAL.Repositories
{
	public class BookingRepository(ApplicationDbContext dbContext) : IBookingRepository
	{
		public async Task<List<Booking>> GetAllBookings()
		{
			return await dbContext.Bookings.Include(b => b.Session).ToListAsync();
		}

		public async Task<Booking?> GetBookingById(int bookingId)
		{
			return await dbContext.Bookings
				.Include(b => b.Session)
				.FirstOrDefaultAsync(b => b.Id == bookingId);
		}

		public async Task CreateBooking(Booking booking)
		{
			await dbContext.Bookings.AddAsync(booking);
			await dbContext.SaveChangesAsync();
		}

		public async Task<BookingUser?> GetByBookingAndUserId(int bookingId, string userId)
		{
			return await dbContext.BookingUsers
				.FirstOrDefaultAsync(bu => bu.Booking.Id == bookingId && bu.User.Id == userId);
		}

		public async Task AddUserToBooking(BookingUser bookingUser)
		{
			await dbContext.BookingUsers.AddAsync(bookingUser);
			await dbContext.SaveChangesAsync();
		}
	}
}
