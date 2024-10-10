﻿using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Repositories
{
	public interface ISessionRepository
	{
		Task<List<Session>> GetAllSessions();
		Task<List<Session>> GetSessionsByDate(DateTime date);
		Task CreateSessions(List<Session> sessions);
	}
}
