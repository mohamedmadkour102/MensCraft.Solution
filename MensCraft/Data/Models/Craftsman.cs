namespace MensCraft.Data.Models
{
	public class Craftsman : User
	{
		public int? CityId { get; set; }
		public City? City { get; set; }
		public int? OccupationId { get; set; }
		public Occupation? Occupation { get; set; }
	}
}
