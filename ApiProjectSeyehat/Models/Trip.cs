using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjectSeyehat.Models
{
	public class Trip
	{
		[Key]
		public int TripId { get; set; }
		[ForeignKey("User")]
		public int UserId { get; set; }
		public string TripName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate{ get; set; }
		public string Notes { get; set; }			//seyahatle ilgili notlar
		public DateTime CreatedDate { get; set; }



	}
}

