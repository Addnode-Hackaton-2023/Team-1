﻿// <auto-generated />
using System;
using Allwin_Planning.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace Allwin_Planning.Migrations
{
    [DbContext(typeof(AllwinContext))]
    [Migration("20230830172844_StopLogAddWeight")]
    partial class StopLogAddWeight
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Allwin_Planning.Core.Entities.Area", b =>
                {
                    b.Property<Guid>("Gid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Gid");

                    b.ToTable("Area", (string)null);
                });

            modelBuilder.Entity("Allwin_Planning.Core.Entities.Delivery", b =>
                {
                    b.Property<Guid>("Gid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Point>("Shape")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.Property<int>("StopTime")
                        .HasColumnType("int");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Gid");

                    b.ToTable("Delivery", (string)null);
                });

            modelBuilder.Entity("Allwin_Planning.Core.Entities.DeliveryDay", b =>
                {
                    b.Property<Guid>("Gid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeliveryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Weekday")
                        .HasColumnType("int");

                    b.HasKey("Gid");

                    b.ToTable("DeliveryDay", (string)null);
                });

            modelBuilder.Entity("Allwin_Planning.Core.Entities.Depot", b =>
                {
                    b.Property<Guid>("Gid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepotName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Point>("Shape")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.HasKey("Gid");

                    b.ToTable("Depot", (string)null);
                });

            modelBuilder.Entity("Allwin_Planning.Core.Entities.Pickup", b =>
                {
                    b.Property<Guid>("Gid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Active")
                        .HasColumnType("smallint");

                    b.Property<int>("AvarageStoptime")
                        .HasColumnType("int");

                    b.Property<int>("AvarageVolume")
                        .HasColumnType("int");

                    b.Property<int>("ClosingHour")
                        .HasColumnType("int");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OpeningHour")
                        .HasColumnType("int");

                    b.Property<string>("PickupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Point>("Shape")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Gid");

                    b.ToTable("Pickup", (string)null);
                });

            modelBuilder.Entity("Allwin_Planning.Core.Entities.StopLog", b =>
                {
                    b.Property<Guid>("Gid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StopId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StopType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Gid");

                    b.ToTable("StopLog", (string)null);
                });

            modelBuilder.Entity("Allwin_Planning.Core.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Gid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("DepotId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Gid");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("Allwin_Planning.Core.Entities.Delivery", b =>
                {
                    b.HasOne("Allwin_Planning.Core.Entities.Vehicle", null)
                        .WithMany("Deliveries")
                        .HasForeignKey("Gid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Allwin_Planning.Core.Entities.Pickup", b =>
                {
                    b.HasOne("Allwin_Planning.Core.Entities.Vehicle", null)
                        .WithMany("Pickups")
                        .HasForeignKey("Gid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Allwin_Planning.Core.Entities.Vehicle", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("Pickups");
                });
#pragma warning restore 612, 618
        }
    }
}
