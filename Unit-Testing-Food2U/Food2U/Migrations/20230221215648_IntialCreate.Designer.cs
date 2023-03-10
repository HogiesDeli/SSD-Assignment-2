// <auto-generated />
using Food2U.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Food2U.Migrations
{
    [DbContext(typeof(Food2UDbContext))]
    [Migration("20230221215648_IntialCreate")]
    partial class IntialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Food2U.Models.DeliveryPerson", b =>
                {
                    b.Property<int>("driverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Vehichle")
                        .HasColumnType("TEXT");

                    b.HasKey("driverID");

                    b.ToTable("DeliverPerson");
                });

            modelBuilder.Entity("Food2U.Models.Items", b =>
                {
                    b.Property<int>("itemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("itemID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Food2U.Models.LocalRestaurants", b =>
                {
                    b.Property<int>("restaurantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Menu")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("restaurantID");

                    b.ToTable("LocalRestaurants");
                });

            modelBuilder.Entity("Food2U.Models.Order", b =>
                {
                    b.Property<int>("orderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("orderID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Food2U.Models.Shoppers", b =>
                {
                    b.Property<int>("shopperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("shopperID");

                    b.ToTable("Shoppers");
                });
#pragma warning restore 612, 618
        }
    }
}
