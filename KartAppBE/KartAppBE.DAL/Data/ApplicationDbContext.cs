using KartAppBE.BLL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
		public DbSet<User> Users { get; set; }

		public DbSet<Booking> Bookings { get; set; }

		public DbSet<BookingUser> BookingUsers { get; set; }

		public DbSet<Kart> Karts { get; set; }

		public DbSet<Review> Reviews { get; set; }

		public DbSet<Session> Sessions { get; set; }

		public DbSet<LapTime> Laptimes { get; set; }
	}
}
