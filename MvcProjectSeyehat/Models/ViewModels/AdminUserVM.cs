using System;
namespace MvcProjectSeyehat.Models
{
	public class AdminUserVM
	{
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Role { get; set; }
    }
}

