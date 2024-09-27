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
		public Booking? Create(Booking booking)
		{
			dbContext.Bookings.Add(booking);

			return dbContext.SaveChanges() > 0 ? booking : null;
		}
	}
}
