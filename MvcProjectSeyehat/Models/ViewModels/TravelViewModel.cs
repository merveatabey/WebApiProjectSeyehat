using System;
namespace MvcProjectSeyehat.Models.ViewModels
{
	public class TravelViewModel
	{
		public int TripId { get; set; }
		public string TripName { get; set; }
		public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
		public string TripImg { get; set; }

    }
}

	