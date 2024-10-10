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
        public Session? Session { get; set; }
        public int PeopleCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
