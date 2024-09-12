using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Models
{
	public class Booking
	{
        public int Id { get; set; }
        public required User User { get; set; }
        public Kart? Kart { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
