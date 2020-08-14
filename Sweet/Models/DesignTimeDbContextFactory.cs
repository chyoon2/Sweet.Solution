using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Sweet.Models
{
  public class SweetContextFactory : IDesignTimeDbContextFactory<SweetContext>
{

SweetContext IDesignTimeDbContextFactory<SweetContext>.CreateDbContext(string[] args)
  {
    IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

          var builder = new DbContextOptionsBuilder<SweetContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

    builder.UseMySql(connectionString);

      return new SweetContext(builder.Options);
    }
  }
}