using KartAppBE.BLL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.DAL.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
		: IdentityDbContext<User>(options)
	{
	}
}
