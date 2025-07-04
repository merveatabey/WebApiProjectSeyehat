using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjectSeyehat.Models
{
	public class Trip
	{
		[Key]
		public int TripId { get; set; }
        [ForeignKey("Transportation")]
        public int TransportationId { get; set; }
        public string TripName { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate{ get; set; }
		public string Notes { get; set; }			//seyahatle ilgili notlar
		public DateTime CreatedDate { get; set; }
		public string TripImg { get; set; }

        // Bir seyahate katılan kullanıcıların listesi
        public ICollection<TripUser> TripUsers { get; set; }


    }
}

