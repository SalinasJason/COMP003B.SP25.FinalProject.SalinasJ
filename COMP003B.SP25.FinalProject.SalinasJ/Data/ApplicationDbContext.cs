using COMP003B.SP25.FinalProject.SalinasJ.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.SP25.FinalProject.SalinasJ.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<SpecialGuest> SpecialGuests { get; set; }
    }
}
