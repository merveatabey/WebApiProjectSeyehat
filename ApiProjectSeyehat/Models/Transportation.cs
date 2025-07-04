using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProjectSeyehat.Models
{
	public class Transportation
	{
		[Key]
		public int TransportationId { get; set; }
		public string Type { get; set; }        //ulaşım türü
		public string From { get; set; }            //kalkış noktası
		public string To { get; set; }              //varış noktası
		public DateTime Date { get; set; }		//seyehat tarihi
		public decimal Price { get; set; }



	}
}

