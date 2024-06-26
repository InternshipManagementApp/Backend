﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20230910165657_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Backend.Data.Model.Road", b =>
                {
                    b.Property<int>("RoadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoadId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Road", "internshipManagmentDatabase");
                });

            modelBuilder.Entity("Backend.Data.Model.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("XEnd")
                        .HasColumnType("INTEGER");

                    b.Property<int>("XStart")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YEnd")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YStart")
                        .HasColumnType("INTEGER");

                    b.HasKey("RoomId");

                    b.ToTable("Room", "internshipManagmentDatabase");
                });

            modelBuilder.Entity("Backend.Data.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("User", "internshipManagmentDatabase");
                });

            modelBuilder.Entity("Backend.Data.Model.Road", b =>
                {
                    b.HasOne("Backend.Data.Model.Room", "Room")
                        .WithMany("Roads")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Data.Model.User", "User")
                        .WithMany("Roads")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Data.Model.Room", b =>
                {
                    b.Navigation("Roads");
                });

            modelBuilder.Entity("Backend.Data.Model.User", b =>
                {
                    b.Navigation("Roads");
                });
#pragma warning restore 612, 618
        }
    }
}
