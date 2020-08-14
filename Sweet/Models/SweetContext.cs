using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Sweet.Models
{
  public class SweetContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Treat> Treat { get; set; }
    public DbSet<Flavor> Flavor { get; set; }
    public DbSet<FlavorTreat> FlavorTreat { get; set; }
    public SweetContext(DbContextOptions options) : base(options) { }
  }
}