using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjectSeyehat.Models
{
	public class Activity
	{
		[Key]
		public int ActivityId { get; set; }
		[ForeignKey("Trip")]
		public int TripId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public string Location { get; set; }
		public decimal Price { get; set; }

	}
}

