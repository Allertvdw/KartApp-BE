using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartAppBE.BLL.Models
{
    public class Session
    {
        public int Id { get; set; }
        public Booking? Booking { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
