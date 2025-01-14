using KartAppBE.BLL.Enums;
using System.ComponentModel.DataAnnotations;

namespace KartAppBE.RequestModels
{
	public class KartRequest
	{
		[Required(ErrorMessage = "Number is required.")]
		[Range(1, 999, ErrorMessage = "Number should be between 1 and 999.")]
		public int Number { get; set; }
		public KartStatus Status { get; set; }
	}
}
