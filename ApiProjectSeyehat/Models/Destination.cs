using System;
using System.ComponentModel.DataAnnotations;

namespace ApiProjectSeyehat.Models
{
	public class Destination
	{
		[Key]
		public int DestId { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public double Latitude { get; set; }        //harita için enlem
		public double Longitude { get; set; }		//boylam
	}
}

