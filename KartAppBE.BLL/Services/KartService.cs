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
	public class KartService(IKartRepository kartRepository) : IKartService
	{
		public async Task<List<Kart>> GetAllKarts()
		{
			return await kartRepository.GetAllKarts();
		}

		public async Task CreateKart(Kart kart)
		{
			await kartRepository.CreateKart(kart);
		}

		public async Task DeleteKart(int id)
		{
			await kartRepository.DeleteKart(id);
		}
	}
}
