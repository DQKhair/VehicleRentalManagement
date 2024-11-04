﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectQLThueXe.Infrastructure.DBContext;

#nullable disable

namespace ProjectQLThueXe.Infrastructure.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20241031071204_UpdateTableCarStatus")]
    partial class UpdateTableCarStatus
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.Car", b =>
                {
                    b.Property<Guid>("Car_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CarStatus_ID")
                        .HasColumnType("int");

                    b.Property<int?>("CarType_ID")
                        .HasColumnType("int");

                    b.Property<Guid?>("KCT_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("Car_ID");

                    b.HasIndex("CarStatus_ID");

                    b.HasIndex("CarType_ID");

                    b.HasIndex("KCT_ID");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.CarStatus", b =>
                {
                    b.Property<int>("CarStatus_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarStatus_ID"));

                    b.Property<string>("CarStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CarStatus_ID");

                    b.ToTable("CarStatus", (string)null);
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.CarType", b =>
                {
                    b.Property<int>("CarType_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarType_ID"));

                    b.Property<string>("CarTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CarType_ID");

                    b.ToTable("CarType", (string)null);
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.KCT", b =>
                {
                    b.Property<Guid>("KCT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KCT_CCCD")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("KCT_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KCT_Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("KCT_address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("KCT_ID");

                    b.ToTable("KCT", (string)null);
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.KT", b =>
                {
                    b.Property<Guid>("KT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KT_Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("KT_CCCD")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("KT_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KT_Phone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("KT_ID");

                    b.ToTable("KT", (string)null);
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.ReceiptDetail", b =>
                {
                    b.Property<Guid>("ReceiptDetail_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Car_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Car_Price")
                        .HasColumnType("float");

                    b.Property<string>("Car_model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("Receipt_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalDay")
                        .HasColumnType("int");

                    b.HasKey("ReceiptDetail_ID");

                    b.HasIndex("Car_ID");

                    b.HasIndex("Receipt_ID");

                    b.ToTable("ReceiptDetail", (string)null);
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.ReceiptStatus", b =>
                {
                    b.Property<int>("ReceiptStatus_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptStatus_ID"));

                    b.Property<string>("ReceiptstatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ReceiptStatus_ID");

                    b.ToTable("ReceiptStatus", (string)null);
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.Receipts", b =>
                {
                    b.Property<Guid>("Receipt_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("KT_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ReceiptStatus_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReceiptTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("totalMoney")
                        .HasColumnType("float");

                    b.HasKey("Receipt_ID");

                    b.HasIndex("KT_ID");

                    b.HasIndex("ReceiptStatus_ID");

                    b.ToTable("Receipts", (string)null);
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.Car", b =>
                {
                    b.HasOne("ProjectQLThueXe.Domain.Entities.CarStatus", "CarStatus")
                        .WithMany("Cars")
                        .HasForeignKey("CarStatus_ID")
                        .HasConstraintName("FK_Car_CarStatus");

                    b.HasOne("ProjectQLThueXe.Domain.Entities.CarType", "CarType")
                        .WithMany("Cars")
                        .HasForeignKey("CarType_ID")
                        .HasConstraintName("FK_Car_CarType");

                    b.HasOne("ProjectQLThueXe.Domain.Entities.KCT", "KCT")
                        .WithMany("Cars")
                        .HasForeignKey("KCT_ID")
                        .HasConstraintName("FK_Car_KCT");

                    b.Navigation("CarStatus");

                    b.Navigation("CarType");

                    b.Navigation("KCT");
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.ReceiptDetail", b =>
                {
                    b.HasOne("ProjectQLThueXe.Domain.Entities.Car", "Car")
                        .WithMany("ReceiptDetails")
                        .HasForeignKey("Car_ID")
                        .HasConstraintName("FK_ReceiptDetail_Car");

                    b.HasOne("ProjectQLThueXe.Domain.Entities.Receipts", "Receipts")
                        .WithMany("ReceiptDetails")
                        .HasForeignKey("Receipt_ID")
                        .HasConstraintName("FK_ReceiptDetail_Receipts");

                    b.Navigation("Car");

                    b.Navigation("Receipts");
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.Receipts", b =>
                {
                    b.HasOne("ProjectQLThueXe.Domain.Entities.KT", "KT")
                        .WithMany("Receipts")
                        .HasForeignKey("KT_ID")
                        .HasConstraintName("FK_Receipts_KT");

                    b.HasOne("ProjectQLThueXe.Domain.Entities.ReceiptStatus", "ReceiptStatus")
                        .WithMany("Receipts")
                        .HasForeignKey("ReceiptStatus_ID")
                        .HasConstraintName("FK_Receipt_ReceiptStatus");

                    b.Navigation("KT");

                    b.Navigation("ReceiptStatus");
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.Car", b =>
                {
                    b.Navigation("ReceiptDetails");
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.CarStatus", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.CarType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.KCT", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.KT", b =>
                {
                    b.Navigation("Receipts");
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.ReceiptStatus", b =>
                {
                    b.Navigation("Receipts");
                });

            modelBuilder.Entity("ProjectQLThueXe.Domain.Entities.Receipts", b =>
                {
                    b.Navigation("ReceiptDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
