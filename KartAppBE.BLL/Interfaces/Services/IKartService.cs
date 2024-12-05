﻿using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Services
{
	public interface IKartService
	{
		Task<List<Kart>> GetAllKarts();
		Task CreateKart(Kart kart);
		Task DeleteKart(int id);
	}
}
