using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ColourAPI.Models
{
  public static class PrepDB
  {
    public static void PrepPopulation(IApplicationBuilder app)
    {
      using(var serviceScope = app.ApplicationServices.CreateScope())
      {
        SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());
      }
    }

    public static void SeedData(ColourContext context)
    {
      System.Console.WriteLine("Applying migrations....");

      context.Database.Migrate();

      if (!context.ColourItems.Any())
      {
        System.Console.WriteLine("No data available, adding data");
        context.ColourItems.AddRange(
          new Colour { Name = "Red" },
          new Colour { Name = "Black" },
          new Colour { Name = "Yellow" },
          new Colour { Name = "Blue" }
        );
      }
      else
      {
        System.Console.WriteLine("Data exists, skipping seeding of default data");
      }

      context.SaveChanges();
    }

  }
}