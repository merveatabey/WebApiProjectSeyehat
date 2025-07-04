using System;
namespace MvcProjectSeyehat.Models.ViewModels
{
	public class CompositeViewModel
	{
        public StatsViewModel Stats { get; set; }
        public List<TravelViewModel> Travels { get; set; }
        //hangi seyahatte hangi aktiviteler var seyehatlere aktivite bilgi de ekle detay sayfasına
        //buraya da aktivie modeli ekle

    }
}

    