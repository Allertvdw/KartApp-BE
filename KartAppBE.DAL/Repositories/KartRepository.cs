using KartAppBE.BLL.Enums;
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
			return await dbContext.karts.ToListAsync();
		}

		public async Task<Kart?> GetKartById(int kartId)
		{
			return await dbContext.karts.FirstOrDefaultAsync(k => k.Id == kartId);
		}

		public async Task<Kart?> GetFirstAvailableKart()
		{
			return await dbContext.karts.FirstOrDefaultAsync(k => k.Status == KartStatus.Available);
		}

		public async Task CreateKart(Kart kart)
		{
			await dbContext.karts.AddAsync(kart);
			await dbContext.SaveChangesAsync();
		}

		public async Task<Kart> UpdateKart(Kart kart)
		{
			Kart? existingKart = await dbContext.karts.FindAsync(kart.Id) ??
				throw new ArgumentNullException(nameof(kart.Id));

			existingKart.Number = kart.Number;
			existingKart.Status = kart.Status;

			await dbContext.SaveChangesAsync();
			return existingKart;
		}

		public async Task DeleteKart(int kartId)
		{
			Kart? kart = await dbContext.karts.FindAsync(kartId);
			dbContext.karts.Remove(kart);
			await dbContext.SaveChangesAsync();
		}
	}
}
