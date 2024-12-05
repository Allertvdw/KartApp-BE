using KartAppBE.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Interfaces.Repositories
{
	public interface IKartRepository
	{
		Task<List<Kart>> GetAllKarts();
		Task<Kart> GetKartById(int kartId);
		Task CreateKart(Kart kart);
		Task<Kart> UpdateKart(Kart kart);
		Task DeleteKart(int kartId);
	}
}
