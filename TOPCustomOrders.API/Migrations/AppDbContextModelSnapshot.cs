﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TOPCustomOrders.API.Data;

#nullable disable

namespace TOPCustomOrders.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TOPCustomOrders.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fa549bb2-8fb4-404b-ae85-6f3695578dd0"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("4c6964a9-31b9-40f6-9b39-678b2b08f6b2"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("4a3549ea-34f5-44e3-87c1-e8447bcd198e"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("TOPCustomOrders.API.Models.Domain.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FileDescription")
                        .HasColumnType("text");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileSizeInBytes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("TOPCustomOrders.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a628b292-c0d8-478a-a6cf-aa1b1df1bb5b"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "https://picsum.photos/seed/picsum/200/300"
                        },
                        new
                        {
                            Id = new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                            Code = "NTL",
                            Name = "Northland"
                        },
                        new
                        {
                            Id = new Guid("14ceba71-4b51-4777-9b17-46602cf66153"),
                            Code = "BOP",
                            Name = "Bay Of Plenty"
                        },
                        new
                        {
                            Id = new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                            Code = "WGN",
                            Name = "Wellington",
                            RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },
                        new
                        {
                            Id = new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                            Code = "NSN",
                            Name = "Nelson",
                            RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        },
                        new
                        {
                            Id = new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                            Code = "STL",
                            Name = "Southland"
                        });
                });

            modelBuilder.Entity("TOPCustomOrders.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uuid");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uuid");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("TOPCustomOrders.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("TOPCustomOrders.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TOPCustomOrders.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
