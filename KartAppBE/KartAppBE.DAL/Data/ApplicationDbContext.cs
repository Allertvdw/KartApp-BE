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
		: IdentityDbContext<User>(options)
	{
		public DbSet<Booking> Bookings { get; set; }

		public DbSet<Kart> Karts { get; set; }

		public DbSet<Review> Reviews { get; set; }

		public DbSet<Session> Sessions { get; set; }

		public DbSet<SessionKart> SessionKarts { get; set; }

		public DbSet<LapTime> Laptimes { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			var admin = new IdentityRole("admin");
			admin.NormalizedName = "admin";

			var client = new IdentityRole("client");
			client.NormalizedName = "client";

			builder.Entity<IdentityRole>().HasData(admin, client);
		}
	}
}
