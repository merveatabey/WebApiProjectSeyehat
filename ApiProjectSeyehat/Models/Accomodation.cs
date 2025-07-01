using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjectSeyehat.Models
{
	public class Accomodation
	{
		[Key]
		public int AccomodationId { get; set; }

		[ForeignKey("Trip")]
		public int TripId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public DateTime CheckInDate { get; set; }
		public DateTime CheckOutDate { get; set; }
		public decimal Price { get; set; }

	}
}

