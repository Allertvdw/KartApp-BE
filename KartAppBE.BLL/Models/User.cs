using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Models
{
	public class User
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
