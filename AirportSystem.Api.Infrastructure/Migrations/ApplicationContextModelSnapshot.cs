﻿// <auto-generated />
using System;
using AirportSystem.Api.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AirportSystem.Api.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AirportSystem.Api.Domain.Entities.AirTicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeparturePoint")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DestinationPoint")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("PassengerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ServiceIssuanceDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.ToTable("AirTickets");
                });

            modelBuilder.Entity("AirportSystem.Api.Domain.Entities.DocumentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PassengerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId")
                        .IsUnique();

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("AirportSystem.Api.Domain.Entities.PassengerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("AirportSystem.Api.Domain.Entities.AirTicketEntity", b =>
                {
                    b.HasOne("AirportSystem.Api.Domain.Entities.PassengerEntity", "Passenger")
                        .WithMany("AirTickets")
                        .HasForeignKey("PassengerId");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AirportSystem.Api.Domain.Entities.DocumentEntity", b =>
                {
                    b.HasOne("AirportSystem.Api.Domain.Entities.PassengerEntity", "Passenger")
                        .WithOne("Document")
                        .HasForeignKey("AirportSystem.Api.Domain.Entities.DocumentEntity", "PassengerId");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AirportSystem.Api.Domain.Entities.PassengerEntity", b =>
                {
                    b.Navigation("AirTickets");

                    b.Navigation("Document");
                });
#pragma warning restore 612, 618
        }
    }
}
