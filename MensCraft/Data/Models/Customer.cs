namespace MensCraft.Data.Models
{
	public class Customer : User
	{
		public int? LocationId { get; set; }
		public City? Location { get; set; }
		public int? ApartmentId { get; set; }
		public Apartment? Apartment { get; set; }
	}
}
