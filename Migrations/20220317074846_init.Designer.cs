﻿// <auto-generated />
using System;
using Mac2sAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mac2sAPI.Migrations
{
    [DbContext(typeof(Mac2sAPIDbContext))]
    [Migration("20220317074846_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Mac2sAPI.Data.ActivityReport", b =>
                {
                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Grp")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.ToView("ActivityReport");
                });

            modelBuilder.Entity("Mac2sAPI.Data.GaugeParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Breakpoint1")
                        .HasColumnType("int");

                    b.Property<int>("Breakpoint2")
                        .HasColumnType("int");

                    b.Property<int>("EndAngle")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StartAngle")
                        .HasColumnType("int");

                    b.Property<int>("step")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GaugeParameter");
                });

            modelBuilder.Entity("Mac2sAPI.Data.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("FileContent")
                        .HasColumnType("longblob");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Mac2sAPI.Data.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float?>("Abs_Val_PL")
                        .HasColumnType("float");

                    b.Property<double?>("Abs_Val_S1_microm")
                        .HasColumnType("double");

                    b.Property<double?>("Abs_Val_S2_microm")
                        .HasColumnType("double");

                    b.Property<double?>("Abs_Val_S3_microm")
                        .HasColumnType("double");

                    b.Property<double?>("Abs_Val_S4_microm")
                        .HasColumnType("double");

                    b.Property<double?>("Abs_Val_S5_microm")
                        .HasColumnType("double");

                    b.Property<int?>("CycleTime_s")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Heure")
                        .HasColumnType("datetime(6)");

                    b.Property<float?>("Hi_Tol_S1")
                        .HasColumnType("float");

                    b.Property<float?>("Hi_Tol_S2")
                        .HasColumnType("float");

                    b.Property<float?>("Hi_Tol_S3")
                        .HasColumnType("float");

                    b.Property<float?>("Hi_Tol_S4")
                        .HasColumnType("float");

                    b.Property<float?>("Hi_Tol_S5")
                        .HasColumnType("float");

                    b.Property<float?>("Lo_Tol_S1")
                        .HasColumnType("float");

                    b.Property<float?>("Lo_Tol_S2")
                        .HasColumnType("float");

                    b.Property<float?>("Lo_Tol_S3")
                        .HasColumnType("float");

                    b.Property<float?>("Lo_Tol_S4")
                        .HasColumnType("float");

                    b.Property<float?>("Lo_Tol_S5")
                        .HasColumnType("float");

                    b.Property<int?>("NOK")
                        .HasColumnType("int");

                    b.Property<int?>("Nr_Cycle")
                        .HasColumnType("int");

                    b.Property<string>("Nr_Moule")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Part_Pr")
                        .HasColumnType("int");

                    b.Property<int?>("ProductionOrderId")
                        .HasColumnType("int");

                    b.Property<int>("RunTime_h")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductionOrderId");

                    b.HasIndex("StatusId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Mac2sAPI.Data.LogDuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float?>("Abs_Val_PL")
                        .HasColumnType("float");

                    b.Property<double?>("Abs_Val_S1_microm")
                        .HasColumnType("double");

                    b.Property<double?>("Abs_Val_S2_microm")
                        .HasColumnType("double");

                    b.Property<double?>("Abs_Val_S3_microm")
                        .HasColumnType("double");

                    b.Property<double?>("Abs_Val_S4_microm")
                        .HasColumnType("double");

                    b.Property<double?>("Abs_Val_S5_microm")
                        .HasColumnType("double");

                    b.Property<int?>("CycleTime_s")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_Heure")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Duration")
                        .HasColumnType("decimal(65,30)");

                    b.Property<float?>("Hi_Tol_S1")
                        .HasColumnType("float");

                    b.Property<float?>("Hi_Tol_S2")
                        .HasColumnType("float");

                    b.Property<float?>("Hi_Tol_S3")
                        .HasColumnType("float");

                    b.Property<float?>("Hi_Tol_S4")
                        .HasColumnType("float");

                    b.Property<float?>("Hi_Tol_S5")
                        .HasColumnType("float");

                    b.Property<float?>("Lo_Tol_S1")
                        .HasColumnType("float");

                    b.Property<float?>("Lo_Tol_S2")
                        .HasColumnType("float");

                    b.Property<float?>("Lo_Tol_S3")
                        .HasColumnType("float");

                    b.Property<float?>("Lo_Tol_S4")
                        .HasColumnType("float");

                    b.Property<float?>("Lo_Tol_S5")
                        .HasColumnType("float");

                    b.Property<int?>("NOK")
                        .HasColumnType("int");

                    b.Property<int?>("Nr_Cycle")
                        .HasColumnType("int");

                    b.Property<string>("Nr_Moule")
                        .HasColumnType("text");

                    b.Property<int?>("Part_Pr")
                        .HasColumnType("int");

                    b.Property<int?>("ProductionOrderId")
                        .HasColumnType("int");

                    b.Property<int>("RunTime_h")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductionOrderId");

                    b.HasIndex("StatusId");

                    b.ToView("LogDuration");
                });

            modelBuilder.Entity("Mac2sAPI.Data.Mold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NameIMM")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Nb_piece")
                        .HasColumnType("int");

                    b.Property<string>("Nr_Moule")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<float?>("Ref_S1")
                        .HasColumnType("float");

                    b.Property<float?>("Ref_S2")
                        .HasColumnType("float");

                    b.Property<float?>("Ref_S3")
                        .HasColumnType("float");

                    b.Property<float?>("Ref_S4")
                        .HasColumnType("float");

                    b.Property<float?>("Ref_S5")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Mold");
                });

            modelBuilder.Entity("Mac2sAPI.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int?>("MoldId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("MoldId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Mac2sAPI.Data.ProductionOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Color")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .HasColumnType("text");

                    b.Property<int>("ObjectifNumber")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductionOrder");
                });

            modelBuilder.Entity("Mac2sAPI.Data.ScheduleParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.ToTable("ScheduleParameter");
                });

            modelBuilder.Entity("Mac2sAPI.Data.SensorGlobal", b =>
                {
                    b.Property<DateTime>("Date_Heure")
                        .HasColumnType("datetime(6)");

                    b.Property<float?>("TH1")
                        .HasColumnType("float");

                    b.Property<float?>("TH2")
                        .HasColumnType("float");

                    b.Property<float?>("TH3")
                        .HasColumnType("float");

                    b.Property<float?>("TH4")
                        .HasColumnType("float");

                    b.Property<float?>("TH5")
                        .HasColumnType("float");

                    b.Property<float?>("TL1")
                        .HasColumnType("float");

                    b.Property<float?>("TL2")
                        .HasColumnType("float");

                    b.Property<float?>("TL3")
                        .HasColumnType("float");

                    b.Property<float?>("TL4")
                        .HasColumnType("float");

                    b.Property<float?>("TL5")
                        .HasColumnType("float");

                    b.Property<double?>("V1")
                        .HasColumnType("double");

                    b.Property<double?>("V2")
                        .HasColumnType("double");

                    b.Property<double?>("V3")
                        .HasColumnType("double");

                    b.Property<double?>("V4")
                        .HasColumnType("double");

                    b.Property<double?>("V5")
                        .HasColumnType("double");

                    b.Property<double?>("Vp")
                        .HasColumnType("double");

                    b.ToView("SensorGlobal");
                });

            modelBuilder.Entity("Mac2sAPI.Data.SensorPl", b =>
                {
                    b.Property<DateTime>("Date_Heure")
                        .HasColumnType("datetime(6)");

                    b.Property<double?>("Value")
                        .HasColumnType("double");

                    b.ToView("SensorPl");
                });

            modelBuilder.Entity("Mac2sAPI.Data.SensorUnique", b =>
                {
                    b.Property<DateTime>("Date_Heure")
                        .HasColumnType("datetime(6)");

                    b.Property<float?>("High")
                        .HasColumnType("float");

                    b.Property<float?>("Low")
                        .HasColumnType("float");

                    b.Property<string>("Nr_Moule")
                        .HasColumnType("text");

                    b.Property<double?>("Value")
                        .HasColumnType("double");

                    b.ToView("SensorUnique");
                });

            modelBuilder.Entity("Mac2sAPI.Data.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StatusGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusGroupId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Mac2sAPI.Data.StatusDuration", b =>
                {
                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToView("StatusDuration");
                });

            modelBuilder.Entity("Mac2sAPI.Data.StatusGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StatusGroup");
                });

            modelBuilder.Entity("Mac2sAPI.Data.StatusGroupDuration", b =>
                {
                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToView("StatusGroupDuration");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b5a136a0-dc53-4e4e-b5e0-68d10b70fe02",
                            ConcurrencyStamp = "a502296d-0571-4b9c-9b02-0025ca3b946c",
                            Name = "Monitor",
                            NormalizedName = "MONITEUR"
                        },
                        new
                        {
                            Id = "d9e1208e-5301-4fc9-8db0-f2562714a991",
                            ConcurrencyStamp = "8c75668b-0d53-4b75-a942-eae70f0917d8",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "43c38655-9aa0-48b4-aab1-7cd175500f09",
                            RoleId = "d9e1208e-5301-4fc9-8db0-f2562714a991"
                        },
                        new
                        {
                            UserId = "5bda2409-9516-4983-90a3-08363427e744",
                            RoleId = "b5a136a0-dc53-4e4e-b5e0-68d10b70fe02"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Mac2sAPI.Data.ApiUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("ApiUser");

                    b.HasData(
                        new
                        {
                            Id = "43c38655-9aa0-48b4-aab1-7cd175500f09",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5524cecf-7b4a-4265-93ef-a17aca07ce3b",
                            Email = "yicheng.yang@ermo-tech.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "YICHENG.YANG@ERMO-TECH.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEKFUMovUZjEwGWcoS+IaCPJ8idmm+ZNZJ0aE/+enox9P1oDuaK0zIpZJZ9duNwoSTQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "0d16b68b-7b7f-4ab2-9dab-6754638dc1dc",
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            FirstName = "System",
                            LastName = "Admin"
                        },
                        new
                        {
                            Id = "5bda2409-9516-4983-90a3-08363427e744",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d385e807-68cf-4bc5-ba1f-09a01f5f4dfe",
                            Email = "user@ermo-tech.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@ERMO-TECH.COM",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAEAACcQAAAAED5Tl7n167QDA74S6uijwymLsqFGioWE/83x5lxTbuh2DjsNWsZCdWlg3lSVtE/Iog==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ac8b25e3-e2d6-43bb-b556-1b7e4eb85cde",
                            TwoFactorEnabled = false,
                            UserName = "user",
                            FirstName = "System",
                            LastName = "User"
                        });
                });

            modelBuilder.Entity("Mac2sAPI.Data.Log", b =>
                {
                    b.HasOne("Mac2sAPI.Data.ProductionOrder", "ProductionOrder")
                        .WithMany("Logs")
                        .HasForeignKey("ProductionOrderId");

                    b.HasOne("Mac2sAPI.Data.Status", "Status")
                        .WithMany("Logs")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductionOrder");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Mac2sAPI.Data.LogDuration", b =>
                {
                    b.HasOne("Mac2sAPI.Data.ProductionOrder", "ProductionOrder")
                        .WithMany()
                        .HasForeignKey("ProductionOrderId");

                    b.HasOne("Mac2sAPI.Data.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductionOrder");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Mac2sAPI.Data.Product", b =>
                {
                    b.HasOne("Mac2sAPI.Data.Image", "Image")
                        .WithMany("Products")
                        .HasForeignKey("ImageId");

                    b.HasOne("Mac2sAPI.Data.Mold", "Mold")
                        .WithMany("Products")
                        .HasForeignKey("MoldId");

                    b.Navigation("Image");

                    b.Navigation("Mold");
                });

            modelBuilder.Entity("Mac2sAPI.Data.ProductionOrder", b =>
                {
                    b.HasOne("Mac2sAPI.Data.Product", "Product")
                        .WithMany("ProductionOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Mac2sAPI.Data.Status", b =>
                {
                    b.HasOne("Mac2sAPI.Data.StatusGroup", "StatusGroup")
                        .WithMany("Statuss")
                        .HasForeignKey("StatusGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusGroup");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mac2sAPI.Data.Image", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Mac2sAPI.Data.Mold", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Mac2sAPI.Data.Product", b =>
                {
                    b.Navigation("ProductionOrders");
                });

            modelBuilder.Entity("Mac2sAPI.Data.ProductionOrder", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Mac2sAPI.Data.Status", b =>
                {
                    b.Navigation("Logs");
                });

            modelBuilder.Entity("Mac2sAPI.Data.StatusGroup", b =>
                {
                    b.Navigation("Statuss");
                });
#pragma warning restore 612, 618
        }
    }
}