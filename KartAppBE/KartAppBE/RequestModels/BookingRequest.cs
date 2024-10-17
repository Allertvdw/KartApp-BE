namespace KartAppBE.RequestModels
{
	public class BookingRequest
	{
		public int SessionId { get; set; }
		public int PeopleCount { get; set; }
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
	}
}
