﻿// <auto-generated />
using System;
using HandyBusiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HandyBusiness.Migrations
{
    [DbContext(typeof(HylemDbContext))]
    [Migration("20200505005754_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HandyBusiness.Models.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dislikes")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfStaffs")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("businesses");
                });

            modelBuilder.Entity("HandyBusiness.Models.BusinessPhotos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BusinessId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("BusinessPhotos");
                });

            modelBuilder.Entity("HandyBusiness.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BusinessId")
                        .HasColumnType("int");

                    b.Property<double>("ChargesPerHour")
                        .HasColumnType("float");

                    b.Property<int>("OperatingMonth")
                        .HasColumnType("int");

                    b.Property<int>("OperatingYear")
                        .HasColumnType("int");

                    b.Property<string>("SectorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("sectors");
                });

            modelBuilder.Entity("HandyBusiness.Models.BusinessPhotos", b =>
                {
                    b.HasOne("HandyBusiness.Models.Business", null)
                        .WithMany("Photos")
                        .HasForeignKey("BusinessId");
                });

            modelBuilder.Entity("HandyBusiness.Models.Sector", b =>
                {
                    b.HasOne("HandyBusiness.Models.Business", null)
                        .WithMany("Sectors")
                        .HasForeignKey("BusinessId");
                });
#pragma warning restore 612, 618
        }
    }
}
