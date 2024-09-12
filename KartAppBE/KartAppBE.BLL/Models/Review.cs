﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Models
{
	public class Review
	{
		public int Id { get; set; }
		public required User User { get; set; }
		public int Rating { get; set; }
		public string? Text { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
