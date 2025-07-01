using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjectSeyehat.Models
{
	public class TripDestination
	{
		//bir seyehatte ziyaret edilecek yerler
		[Key]
		public int Id { get; set; }
		[ForeignKey("Trip")]
		public int TripId { get; set; }
        [ForeignKey("Destination")]
        public int DestId { get; set; }
		public int VisitOrder { get; set; }

	}
}

