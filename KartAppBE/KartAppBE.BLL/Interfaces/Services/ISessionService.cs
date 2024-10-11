using KartAppBE.BLL.Models;
using KartAppBE.BLL.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Services
{
	public interface ISessionService
	{
		Task<List<Session>> GetAllSessions();
		Task<Session> GetSessionById(int sessionId);
		Task<List<Session>> GetSessionsByDate(DateTime date);
		Task CreateSessions(List<Session> sessions);
		Task GenerateSessions(GenerateSessionsRequest request);
	}
}
