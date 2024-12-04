using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Models;
using KartAppBE.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.DAL.Repositories
{
	public class ReviewRepository(ApplicationDbContext dbContext) : IReviewRepository
	{
		public async Task<List<Review>> GetAllReviews()
		{
			return await dbContext.Reviews.ToListAsync();
		}

		public async Task CreateReview(Review review)
		{
			await dbContext.Reviews.AddAsync(review);
			await dbContext.SaveChangesAsync();
		}

		public async Task DeleteReview(Review review)
		{
			dbContext.Reviews.Remove(review);
			await dbContext.SaveChangesAsync();
		}
	}
}
