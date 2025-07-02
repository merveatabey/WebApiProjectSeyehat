using System;
namespace MvcProjectSeyehat.Models.ViewModels
{
	public class DashboardViewModel
	{
		public List<AdminUserVM> adminUsers { get; set; }
		public List<TravelViewModel> travelViews { get; set; }
		public List<TravelPartViewModel> travelPartViews { get; set; }
	}
}

