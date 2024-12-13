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
			return await dbContext.sessions.ToListAsync();
		}

		public async Task<Session?> GetSessionById(int sessionId)
		{
			return await dbContext.sessions.FirstOrDefaultAsync(s => s.Id == sessionId);
		}

		public async Task<List<Session>> GetSessionsByDate(DateTime date)
		{
			return await dbContext.sessions
				.Where(s => s.StartTime.Date == date.Date)
				.ToListAsync();
		}

		public async Task CreateSessions(List<Session> sessions)
		{
			await dbContext.sessions.AddRangeAsync(sessions);
			await dbContext.SaveChangesAsync();
		}
	}
}
