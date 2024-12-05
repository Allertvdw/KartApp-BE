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
	public class KartRepository(ApplicationDbContext dbContext) : IKartRepository
	{
		public async Task<List<Kart>> GetAllKarts()
		{
			return await dbContext.Karts.ToListAsync();
		}

		public async Task CreateKart(Kart kart)
		{
			await dbContext.Karts.AddAsync(kart);
			await dbContext.SaveChangesAsync();
		}

		public async Task DeleteKart(int id)
		{
			Kart? kart = await dbContext.Karts.FindAsync(id);
			dbContext.Karts.Remove(kart);
			await dbContext.SaveChangesAsync();
		}
	}
}
