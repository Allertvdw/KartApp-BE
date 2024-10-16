using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Models;
using KartAppBE.BLL.RequestModels;
using KartAppBE.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.DAL.Repositories
{
	public class SessionRepository(ApplicationDbContext dbContext) : ISessionRepository
	{
		public async Task<List<Session>> GetAllSessions()
		{
			return await dbContext.Sessions.ToListAsync();
		}

		public async Task<Session?> GetSessionById(int sessionId)
		{
			return await dbContext.Sessions.FirstOrDefaultAsync(s => s.Id == sessionId);
		}

		public async Task<List<Session>> GetSessionsByDate(DateTime date)
		{
			return await dbContext.Sessions
				.Where(s => s.StartTime.Date == date.Date)
				.ToListAsync();
		}

		public async Task CreateSessions(List<Session> sessions)
		{
			await dbContext.Sessions.AddRangeAsync(sessions);
			await dbContext.SaveChangesAsync();
		}
	}
}
