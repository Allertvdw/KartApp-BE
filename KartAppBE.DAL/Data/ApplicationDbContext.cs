using KartAppBE.BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.DAL.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
		: DbContext(options)
	{
		public DbSet<User> users { get; set; }

		public DbSet<Booking> bookings { get; set; }

		public DbSet<BookingUser> bookingusers { get; set; }

		public DbSet<Kart> karts { get; set; }

		public DbSet<Review> reviews { get; set; }

		public DbSet<Session> sessions { get; set; }

		public DbSet<LapTime> laptimes { get; set; }
	}
}
