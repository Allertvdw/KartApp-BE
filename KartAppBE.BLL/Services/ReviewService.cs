using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Services
{
	public class ReviewService(IReviewRepository reviewRepository) : IReviewService
	{
		public async Task<List<Review>> GetAllReviews()
		{
			return await reviewRepository.GetAllReviews();
		}

		public async Task CreateReview(Review review)
		{
			await reviewRepository.CreateReview(review);
		}

		public async Task DeleteReview(Review review)
		{
			await reviewRepository.DeleteReview(review);
		}
	}
}
