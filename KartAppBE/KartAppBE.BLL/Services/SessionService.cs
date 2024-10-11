using KartAppBE.BLL.Interfaces.Repositories;
using KartAppBE.BLL.Interfaces.Services;
using KartAppBE.BLL.Models;
using KartAppBE.BLL.RequestModels;
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

		public async Task GenerateSessions(GenerateSessionsRequest request)
		{
			List<Session> sessions = [];

			foreach (var day in request.OpenDays)
			{
				DateTime currentDate = GetNextDate(day);
				DateTime currentTime = currentDate.Date.Add(request.OpeningTime);
				DateTime closingTime = currentDate.Date.Add(request.ClosingTime);

				while (currentTime < closingTime)
				{
					var endTime = currentTime.AddMinutes(request.IntervalInMinutes);

					if (endTime > closingTime)
					{
						break;
					}

					var session = new Session
					{
						StartTime = currentTime,
						EndTime = endTime,
					};

					currentTime = endTime;
					sessions.Add(session);
				}
			}

			await sessionRepository.CreateSessions(sessions);
		}

		private DateTime GetNextDate(string day)
		{
			var today = DateTime.Today;
			var dayOfWeek = Enum.Parse<DayOfWeek>(day, true);
			int daysUntilNextWeek = ((int)dayOfWeek - (int)today.DayOfWeek + 7) % 7;

			return today.AddDays(daysUntilNextWeek == 0 ? 7 : daysUntilNextWeek);
		}
	}
}
