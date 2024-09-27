using Microsoft.AspNetCore.Mvc;

namespace KartAppBE.Controllers
{
	public class BookingController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
