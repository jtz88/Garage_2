﻿using Garage_2.Models;
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
        //        .HasData(
        //          new ParkedVehicle { Id = 1,     },
        //         );
        //}
    }
}
