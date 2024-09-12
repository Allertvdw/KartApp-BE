using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Models
{
	public class Kart
	{
        public int Id { get; set; }
		public required string Model { get; set; }
		public bool IsAvailable { get; set; } // enum?
    }
}
