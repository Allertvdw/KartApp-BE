using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.RequestModels
{
	public class GenerateSessionsRequest
	{
		public List<string> OpenDays { get; set; }
		public TimeSpan OpeningTime { get; set; }
		public TimeSpan ClosingTime { get; set; }
		public int IntervalInMinutes { get; set; }
	}
}
