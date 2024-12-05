using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KartAppBE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController(IReviewService reviewService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllReviews()
		{
			var reviews = await reviewService.GetAllReviews();
			return Ok(reviews);
		}

		[HttpPost]
		public async Task<IActionResult> CreateReview(ReviewRequest request)
		{
			Review review = new()
			{
				Rating = request.Rating,
				Text = request.Text,
			};

			await reviewService.CreateReview(review);
			return Ok(review);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteReview(int id)
		{
			await reviewService.DeleteReview(id);
			return Ok();
		}
	}
}
