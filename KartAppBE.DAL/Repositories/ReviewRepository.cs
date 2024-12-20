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
			return await dbContext.reviews.ToListAsync();
		}

		public async Task CreateReview(Review review)
		{
			await dbContext.reviews.AddAsync(review);
			await dbContext.SaveChangesAsync();
		}

		public async Task DeleteReview(int id)
		{
			Review? review = await dbContext.reviews.FindAsync(id);
			dbContext.reviews.Remove(review);
			await dbContext.SaveChangesAsync();
		}
	}
}
