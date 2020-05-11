using Garage_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2.Data
{
    public class Garage_2Context : DbContext
    {
        public Garage_2Context(DbContextOptions<Garage_2Context> options)
            : base(options)
        {
        }
        public DbSet<ParkedVehicle> ParkedVehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkedVehicle>()
                .Property(b => b.TimeOfArrival)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ParkedVehicle>()
                .HasIndex(b => b.RegNr)
                .IsUnique();

            modelBuilder.Entity<ParkedVehicle>()
                .HasData(
                  new ParkedVehicle { Id = 1, RegNr = "ABC123", Color = "Blue", Brand = "Volkswagen", Model = "Sedan", vehicleType=VehicleType.Car, NrOfWheels=4 },
                  new ParkedVehicle { Id = 2, RegNr = "EFG456", Color = "White", Brand = "Boeing", Model = "747", vehicleType = VehicleType.Airplane, NrOfWheels = 8 },
                  new ParkedVehicle { Id = 3, RegNr = "JKL789", Color = "Gold", Brand = "Honda", Model = "Goldwing", vehicleType = VehicleType.Motorcycle, NrOfWheels = 2 },
                  new ParkedVehicle { Id = 4, RegNr = "GHJ730", Color = "Yellow", Brand = "Coronet", Model = "32C", vehicleType = VehicleType.Boat, NrOfWheels = 0 },
                  new ParkedVehicle { Id = 5, RegNr = "IOP466", Color = "Red", Brand = "Volvo", Model = "Single-Decker", vehicleType = VehicleType.Bus, NrOfWheels = 12 }
                 );
        }
    }
}
