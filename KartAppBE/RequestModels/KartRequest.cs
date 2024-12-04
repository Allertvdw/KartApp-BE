using KartAppBE.BLL.Enums;

namespace KartAppBE.RequestModels
{
	public class KartRequest
	{
		public int Number { get; set; }
		public KartStatus Status { get; set; }
	}
}
