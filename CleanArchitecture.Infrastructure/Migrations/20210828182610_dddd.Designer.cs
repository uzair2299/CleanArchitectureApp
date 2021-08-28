﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(AutoSolutionContext))]
    [Migration("20210828182610_dddd")]
    partial class dddd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AppControllerActions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ControllerId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ControllerId");

                    b.ToTable("AppControllerActions");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AppControllers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ControllerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AppControllers");
                });

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

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoLookUpType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LookUpTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AutoLookUpType");
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

                    b.Property<bool>("IsPopular")
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

                    b.Property<bool>("IsPopular")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SpecificationParameter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecificationTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("SpecificationTypeId");

                    b.ToTable("AutoSpecifications");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoSpecificationSub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("SpecificationSubParameter")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AutoSpecificationSubs");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AutoBodyTypeId")
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

                    b.Property<int>("CrubWeight")
                        .HasColumnType("int");

                    b.Property<decimal?>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("EndProductionYear")
                        .HasColumnType("datetime2");

                    b.Property<int>("EngineCapacity")
                        .HasColumnType("int");

                    b.Property<int>("ExteriorHeight")
                        .HasColumnType("int");

                    b.Property<int>("ExteriorLength")
                        .HasColumnType("int");

                    b.Property<int>("ExteriorWidth")
                        .HasColumnType("int");

                    b.Property<int>("FuelTankCapacity")
                        .HasColumnType("int");

                    b.Property<int>("GrossVehicleWeigth")
                        .HasColumnType("int");

                    b.Property<int>("GroundClearance")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InteriorHeight")
                        .HasColumnType("int");

                    b.Property<int>("InteriorLength")
                        .HasColumnType("int");

                    b.Property<int>("InteriorWidth")
                        .HasColumnType("int");

                    b.Property<int>("MinimumGroundClearance")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("OverhangFront")
                        .HasColumnType("int");

                    b.Property<int>("OverhangRear")
                        .HasColumnType("int");

                    b.Property<decimal?>("PreviousPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RunningGroundClearance")
                        .HasColumnType("int");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartProductionYear")
                        .HasColumnType("datetime2");

                    b.Property<int>("TreadFront")
                        .HasColumnType("int");

                    b.Property<int>("TreadRear")
                        .HasColumnType("int");

                    b.Property<int>("Wheelbase")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutoBodyTypeId");

                    b.HasIndex("AutoEngineTypeId");

                    b.HasIndex("AutoModelId");

                    b.ToTable("AutoVersion");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersionDimension", b =>
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

                    b.Property<int>("ExteriorHeight")
                        .HasColumnType("int");

                    b.Property<int>("ExteriorLength")
                        .HasColumnType("int");

                    b.Property<int>("ExteriorWidth")
                        .HasColumnType("int");

                    b.Property<int>("InteriorHeight")
                        .HasColumnType("int");

                    b.Property<int>("InteriorLength")
                        .HasColumnType("int");

                    b.Property<int>("InteriorWidth")
                        .HasColumnType("int");

                    b.Property<int>("MinimumGroundClearance")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("OverhangFront")
                        .HasColumnType("int");

                    b.Property<int>("OverhangRear")
                        .HasColumnType("int");

                    b.Property<int>("TreadFront")
                        .HasColumnType("int");

                    b.Property<int>("TreadRear")
                        .HasColumnType("int");

                    b.Property<int>("Wheelbase")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutoVersionId");

                    b.ToTable("AutoVersionDimensions");
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

                    b.Property<bool>("IsPopular")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersionSpecification", b =>
                {
                    b.Property<int>("AutoVersionId")
                        .HasColumnType("int");

                    b.Property<int>("AutoSpecificationId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("AutoVersionId", "AutoSpecificationId");

                    b.HasIndex("AutoSpecificationId");

                    b.ToTable("AutoVersionSpecifications");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersionWeightCapacity", b =>
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

                    b.Property<int>("CrubWeight")
                        .HasColumnType("int");

                    b.Property<int>("FuelTankCapacity")
                        .HasColumnType("int");

                    b.Property<int>("GrossVehicleWeigth")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutoVersionId");

                    b.ToTable("AutoVersionWeightCapacities");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProvinceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.RolePermissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryMobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryMobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondaryPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.UserRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AppControllerActions", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.AppControllers", "AppControllers")
                        .WithMany("AppControllerActions")
                        .HasForeignKey("ControllerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppControllers");
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

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoSpecification", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.AutoSpecification", "ParentNode")
                        .WithMany("SpecificationSubParameter")
                        .HasForeignKey("ParentId");

                    b.HasOne("CleanArchitecture.Domain.Entities.AutoLookUpType", "SpecificationType")
                        .WithMany("AutoSpecifications")
                        .HasForeignKey("SpecificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentNode");

                    b.Navigation("SpecificationType");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersion", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.AutoBodyType", "AutoBodyType")
                        .WithMany()
                        .HasForeignKey("AutoBodyTypeId");

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

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersionDimension", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.AutoVersion", "AutoVersion")
                        .WithMany("AutoVersionDimensions")
                        .HasForeignKey("AutoVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoVersion");
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

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersionSpecification", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.AutoSpecification", "AutoSpecification")
                        .WithMany("AutoVersionSpecifications")
                        .HasForeignKey("AutoSpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.Domain.Entities.AutoVersion", "AutoVersion")
                        .WithMany("AutoVersionSpecifications")
                        .HasForeignKey("AutoVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoSpecification");

                    b.Navigation("AutoVersion");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersionWeightCapacity", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.AutoVersion", "AutoVersion")
                        .WithMany("AutoVersionWeightCapacities")
                        .HasForeignKey("AutoVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoVersion");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.RolePermissions", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.Domain.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.UserRoles", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AppControllers", b =>
                {
                    b.Navigation("AppControllerActions");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoEngineType", b =>
                {
                    b.Navigation("AutoVersions");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoLookUpType", b =>
                {
                    b.Navigation("AutoSpecifications");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoManufacturer", b =>
                {
                    b.Navigation("AutoModels");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoModel", b =>
                {
                    b.Navigation("AutoVersions");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoSpecification", b =>
                {
                    b.Navigation("AutoVersionSpecifications");

                    b.Navigation("SpecificationSubParameter");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.AutoVersion", b =>
                {
                    b.Navigation("AutoVersionDimensions");

                    b.Navigation("AutoVersionSpecifications");

                    b.Navigation("AutoVersionWeightCapacities");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
