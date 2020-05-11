﻿// <auto-generated />
using System;
using Garage_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage_2.Migrations
{
    [DbContext(typeof(Garage_2Context))]
    partial class Garage_2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("RegNr")
                        .IsRequired()
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.Property<DateTime>("TimeOfArrival")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 5, 11, 15, 51, 54, 445, DateTimeKind.Local).AddTicks(4328));

                    b.Property<int>("vehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegNr")
                        .IsUnique();

                    b.ToTable("ParkedVehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Volkswagen",
                            Color = "Blue",
                            Model = "Sedan",
                            NrOfWheels = 4,
                            RegNr = "ABC123",
                            TimeOfArrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            vehicleType = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
