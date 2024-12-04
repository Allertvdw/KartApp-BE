using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Services
{
	public interface IReviewService
	{
		Task<List<Review>> GetAllReviews();
		Task CreateReview(Review review);
		Task DeleteReview(Review review);
	}
}
