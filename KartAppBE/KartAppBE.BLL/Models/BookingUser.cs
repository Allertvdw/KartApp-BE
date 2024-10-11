using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Models
{
	public class BookingUser
	{
		public int Id { get; set; }
		public Booking? Booking { get; set; }
		public User? User { get; set; }
		public Kart? Kart { get; set; }
	}
}
