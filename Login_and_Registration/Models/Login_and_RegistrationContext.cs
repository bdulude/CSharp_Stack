using Microsoft.EntityFrameworkCore;

namespace Login_and_Registration.Models
{
    public class Login_and_RegistrationContext : DbContext
    {
        public Login_and_RegistrationContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}