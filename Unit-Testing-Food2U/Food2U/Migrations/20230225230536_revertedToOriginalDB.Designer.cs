﻿// <auto-generated />
using Food2U.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Food2U.Migrations
{
    [DbContext(typeof(Food2UDbContext))]
    [Migration("20230225230536_revertedToOriginalDB")]
    partial class revertedToOriginalDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Food2U.Models.DeliveryPerson", b =>
                {
                    b.Property<int>("deliverypersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Vehicle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("deliverypersonID");

                    b.ToTable("DeliveryPerson");
                });

            modelBuilder.Entity("Food2U.Models.Items", b =>
                {
                    b.Property<int>("itemsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("localrestaurantsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("itemsID");

                    b.HasIndex("localrestaurantsID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Food2U.Models.LocalRestaurants", b =>
                {
                    b.Property<int>("localrestaurantsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Menu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("localrestaurantsID");

                    b.ToTable("LocalRestaurants");
                });

            modelBuilder.Entity("Food2U.Models.Shoppers", b =>
                {
                    b.Property<int>("shoppersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("shoppersID");

                    b.ToTable("Shoppers");
                });

            modelBuilder.Entity("Food2U.Models.Items", b =>
                {
                    b.HasOne("Food2U.Models.LocalRestaurants", "LocalRestaurants")
                        .WithMany()
                        .HasForeignKey("localrestaurantsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalRestaurants");
                });
#pragma warning restore 612, 618
        }
    }
}