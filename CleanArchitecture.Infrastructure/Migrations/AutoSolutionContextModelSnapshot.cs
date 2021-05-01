﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(AutoSolutionContext))]
    partial class AutoSolutionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoBodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BodyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AutoBodyType");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoEngineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AutoEngineType");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoManufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AutoManufacturerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AutoManufacturers");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AutoManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AutoManufacturerId");

                    b.ToTable("AutoModels");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AutoBodyTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("AutoEngineTypeId")
                        .HasColumnType("int");

                    b.Property<int>("AutoModelId")
                        .HasColumnType("int");

                    b.Property<string>("AutoVersionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("EndProductionYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PreviousPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("StartProductionYear")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AutoBodyTypeId");

                    b.HasIndex("AutoEngineTypeId");

                    b.HasIndex("AutoModelId");

                    b.ToTable("AutoVersion");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersionPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AutoVersionId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("EndPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AutoVersionId");

                    b.ToTable("AutoVersionPrice");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoModel", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.AutoManufacturer", "AutoManufacturer")
                        .WithMany("AutoModels")
                        .HasForeignKey("AutoManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoManufacturer");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersion", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.AutoBodyType", "AutoBodyType")
                        .WithMany()
                        .HasForeignKey("AutoBodyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.Domain.Entities.AutoEngineType", "AutoEngineType")
                        .WithMany("AutoVersions")
                        .HasForeignKey("AutoEngineTypeId");

                    b.HasOne("CleanArchitecture.Domain.Entities.AutoModel", "AutoModel")
                        .WithMany("AutoVersions")
                        .HasForeignKey("AutoModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoBodyType");

                    b.Navigation("AutoEngineType");

                    b.Navigation("AutoModel");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersionPrice", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.AutoVersion", "AutoVersion")
                        .WithMany()
                        .HasForeignKey("AutoVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoVersion");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoEngineType", b =>
                {
                    b.Navigation("AutoVersions");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoManufacturer", b =>
                {
                    b.Navigation("AutoModels");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoModel", b =>
                {
                    b.Navigation("AutoVersions");
                });
#pragma warning restore 612, 618
        }
    }
}
