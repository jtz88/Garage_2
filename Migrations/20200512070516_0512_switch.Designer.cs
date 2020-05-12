﻿// <auto-generated />
using System;
using Garage_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage_2.Migrations
{
    [DbContext(typeof(Garage_2Context))]
    [Migration("20200512070516_0512_switch")]
    partial class _0512_switch
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Garage_2.Models.ParkedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<int>("NrOfWheels")
                        .HasColumnType("int");

                    b.Property<int>("PosParkingSpace")
                        .HasColumnType("int");

                    b.Property<string>("RegNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<DateTime>("TimeOfArrival")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegNr")
                        .IsUnique();

                    b.ToTable("ParkedVehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NrOfWheels = 4,
                            PosParkingSpace = 0,
                            RegNr = "US_LM126",
                            TimeOfArrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleType = 0
                        },
                        new
                        {
                            Id = 2,
                            Color = "White",
                            NrOfWheels = 0,
                            PosParkingSpace = 0,
                            RegNr = "BVG17",
                            TimeOfArrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleType = 1
                        },
                        new
                        {
                            Id = 3,
                            NrOfWheels = 6,
                            PosParkingSpace = 0,
                            RegNr = "BUS123",
                            TimeOfArrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleType = 2
                        },
                        new
                        {
                            Id = 4,
                            NrOfWheels = 4,
                            PosParkingSpace = 0,
                            RegNr = "ABC123",
                            TimeOfArrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleType = 3
                        },
                        new
                        {
                            Id = 5,
                            Color = "Black",
                            Model = "Yamaha YZF1000R 4VD",
                            NrOfWheels = 2,
                            PosParkingSpace = 0,
                            RegNr = "ADZ967",
                            TimeOfArrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleType = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}