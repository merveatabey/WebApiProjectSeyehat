using System;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectSeyehat.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<Trip> Trips { get; set; }
		public DbSet<TripDestination> TripDestinations { get; set; }
		public DbSet<Transportation> Transportations { get; set; }
		public DbSet<Destination> Destinations { get; set; }
		public DbSet<Accomodation> Accomodations { get; set; }
		public DbSet<Activity> Activities { get; set; }
        public DbSet<TripUser> TripUsers { get; set; }  // TripUser tablosu


    }
}

