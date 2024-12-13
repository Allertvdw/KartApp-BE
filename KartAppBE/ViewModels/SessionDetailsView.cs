namespace KartAppBE.ViewModels
{
	public class SessionDetailsView
	{
		public DateTime SessionDate { get; set; }
		public DateTime SessionStartTime { get; set; }
		public DateTime SessionEndTime { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public int KartNumber { get; set; }
		public int BookingId { get; set; }
	}
}
