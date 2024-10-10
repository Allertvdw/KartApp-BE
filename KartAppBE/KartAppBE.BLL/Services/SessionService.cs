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
	public class SessionService(ISessionRepository sessionRepository) : ISessionService
	{
		public async Task<List<Session>> GetAllSessions()
		{
			return await sessionRepository.GetAllSessions();
		}

		public async Task<List<Session>> GetSessionsByDate(DateTime date)
		{
			return await sessionRepository.GetSessionsByDate(date);
		}

		public async Task CreateSessions(List<Session> sessions)
		{
			await sessionRepository.CreateSessions(sessions);
		}
	}
}
