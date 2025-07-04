using System;
using System.ComponentModel.DataAnnotations;

namespace ApiProjectSeyehat.Models
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime CreatedTime { get; set; }
		public string Role { get; set; }        //admin, user

		// Bir kullanıcının katıldığı seyahatlerin listesi
        public ICollection<TripUser> TripUsers { get; set; }

    }
}

