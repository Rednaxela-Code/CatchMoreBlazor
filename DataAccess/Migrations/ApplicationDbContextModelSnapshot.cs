﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Catch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Catches");
                });

            modelBuilder.Entity("Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("SessionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateOnly(2024, 3, 2),
                            Latitude = 12.0,
                            Longitude = 22.0,
                            SessionName = "Test Session 1"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateOnly(2023, 8, 23),
                            Latitude = 21.0,
                            Longitude = 2.0,
                            SessionName = "Test Session 2"
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateOnly(2023, 6, 12),
                            Latitude = 5.0,
                            Longitude = 54.0,
                            SessionName = "Test Session 3"
                        });
                });

            modelBuilder.Entity("Models.Catch", b =>
                {
                    b.HasOne("Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId");

                    b.Navigation("Session");
                });
#pragma warning restore 612, 618
        }
    }
}
