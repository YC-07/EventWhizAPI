﻿// <auto-generated />
using System;
using EventWhiz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventWhiz.Migrations
{
    [DbContext(typeof(EventWhizDBContext))]
    partial class EventWhizDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventWhiz.Models.Domain.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("LocationId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventWhiz.Models.Domain.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Small"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Large"
                        });
                });

            modelBuilder.Entity("EventWhiz.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("EventWhiz.Models.Domain.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b54fc53b-1628-4902-9820-3c471a7da4d1"),
                            Code = "LOC001",
                            LocationImgURL = "https://www.google.com",
                            Name = "Location 1"
                        },
                        new
                        {
                            Id = new Guid("6407c114-6fe6-42be-a77c-29344ed4e26a"),
                            Code = "LOC002",
                            LocationImgURL = "https://www.google.com",
                            Name = "Location 2"
                        },
                        new
                        {
                            Id = new Guid("e4ba1491-6dff-4068-9ac0-9d8c5f6d2c0a"),
                            Code = "LOC003",
                            LocationImgURL = "https://www.google.com",
                            Name = "Location 3"
                        },
                        new
                        {
                            Id = new Guid("8ff18763-6785-4413-ae5e-c217e6406288"),
                            Code = "LOC004",
                            LocationImgURL = "https://www.google.com",
                            Name = "Location 4"
                        },
                        new
                        {
                            Id = new Guid("52208aca-98b8-4c05-ac26-c8915255f9cf"),
                            Code = "LOC005",
                            LocationImgURL = "https://www.google.com",
                            Name = "Location 5"
                        });
                });

            modelBuilder.Entity("EventWhiz.Models.Domain.Event", b =>
                {
                    b.HasOne("EventWhiz.Models.Domain.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventWhiz.Models.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventType");

                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}
