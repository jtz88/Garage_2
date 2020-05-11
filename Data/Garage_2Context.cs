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
                .HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<ParkedVehicle>()
                .HasIndex(b => b.RegNr)
                .IsUnique();

            modelBuilder.Entity<ParkedVehicle>()
                .HasData(
                  new ParkedVehicle { Id = 1, RegNr="US_LM126", VehicleType=VehicleType.Airplane, NrOfWheels=4 },
                  new ParkedVehicle { Id = 1, RegNr="BVG17", VehicleType=VehicleType.Boat, NrOfWheels=0,Color="White" },
                  new ParkedVehicle { Id = 2, RegNr="BUS123", VehicleType=VehicleType.Bus, NrOfWheels=6 },
                  new ParkedVehicle { Id = 3, RegNr="ABC123", VehicleType=VehicleType.Car, NrOfWheels=4 },
                  new ParkedVehicle { Id = 4, RegNr="ADZ967", VehicleType=VehicleType.Motorcycle, NrOfWheels=2,Model= "Yamaha YZF1000R 4VD", Color="Black"},
                 );
        }
    }
}
