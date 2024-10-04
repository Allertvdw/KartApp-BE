using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Models
{
	public class LapTime
	{
		public int Id { get; set; }
		public SessionKart? SessionKart { get; set; }
		public User? User { get; set; }
		public float LapTimeInSeconds { get; set; }
		public int LapNumber { get; set; }
	}
}
