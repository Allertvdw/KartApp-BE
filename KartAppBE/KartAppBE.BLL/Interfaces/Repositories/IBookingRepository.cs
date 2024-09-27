using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Repositories
{
	public interface IBookingRepository
	{
		public Booking? Create(Booking booking);
	}
}
