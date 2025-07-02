using System;
namespace MvcProjectSeyehat.Models.ViewModels
{
	public class TravelPartViewModel
	{
        public string ParticipantName { get; set; }
        public string ParticipantMail { get; set; }

        public int TripId { get; set; }
        public string TripName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
    }
}

