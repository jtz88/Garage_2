using Garage_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Garage_2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Garage_2Context>>()))
            {
                
                if (context.ParkedVehicle.Any())
                {
                    return;  
                }

                context.ParkedVehicle.AddRange(
                    new ParkedVehicle
                    {
                        RegNr = "ABC123",
                        NrOfWheels = 4,
                        Color = "Blue",
                        Brand = "Audi",
                        Model = "Coupe",
                        TimeOfArrival = DateTime.Parse("2020-4-10")
                    },

                    new ParkedVehicle
                    {
                        RegNr = "GHJ987",
                        NrOfWheels = 18,
                        Color = "Red",
                        Brand = "Volvo",
                        Model = "Bus",
                        TimeOfArrival = DateTime.Parse("2020-3-27")
                    },

                    new ParkedVehicle
                    {
                        RegNr = "ZAS456",
                        NrOfWheels = 2,
                        Color = "Gold",
                        Brand = "Honda",
                        Model = "Motorcycle",
                        TimeOfArrival = DateTime.Parse("2020-5-3")
                    },

                    new ParkedVehicle
                    {
                        RegNr = "JKL437",
                        NrOfWheels = 4,
                        Color = "Black",
                        Brand = "BMW",
                        Model = "Sedan",
                        TimeOfArrival = DateTime.Parse("2020-4-30")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
