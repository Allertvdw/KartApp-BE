using KartAppBE.BLL.Models;
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
		Task<List<Session>> GetSessionsByDate(DateTime date);
		Task CreateSessions(List<Session> sessions);
	}
}
