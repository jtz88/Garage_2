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


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ParkedVehicle>()
        //        .Property(b => b.TimeOfArrival)
        //        .HasDefaultValue(DateTime.Now);

        //    modelBuilder.Entity<ParkedVehicle>()
        //        .HasIndex(b => b.RegNr)
        //        .IsUnique();


        //    modelBuilder.Entity<ParkedVehicle>()
        //        .HasData(
        //          new ParkedVehicle { Id = 1, RegNr = "ABC123", VehicleType = VehicleType.Car, NrOfWheels = 4 }
        //         );

        //}
    }
}
