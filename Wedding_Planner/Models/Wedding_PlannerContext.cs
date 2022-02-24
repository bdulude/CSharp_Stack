using Microsoft.EntityFrameworkCore;

namespace Wedding_Planner.Models
{
    public class Wedding_PlannerContext : DbContext
    {
        public Wedding_PlannerContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings {get; set;}
        public DbSet<RSVP> RSVPs {get; set;}
    }
}