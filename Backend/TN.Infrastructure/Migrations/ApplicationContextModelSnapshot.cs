﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TN.Infrastructure;

namespace TN.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim","adm");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim","adm");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin","adm");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole","adm");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken","adm");
                });

            modelBuilder.Entity("TN.Domain.Model.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role","adm");
                });

            modelBuilder.Entity("TN.Domain.Model.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Avatar");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("CreatedUserId");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsLock");

                    b.Property<bool>("IsReLogin");

                    b.Property<bool>("IsSuperAdmin");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Note");

                    b.Property<string>("NoteLock")
                        .HasMaxLength(1000);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RoleParents");

                    b.Property<string>("RoleSchool");

                    b.Property<string>("RoleTransportCompany");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UpdatedUserId");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User","adm");
                });

            modelBuilder.Entity("TN.Domain.Model.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomObject");

                    b.Property<double>("Note");

                    b.Property<string>("Object")
                        .HasMaxLength(50);

                    b.Property<int>("ObjectId");

                    b.Property<string>("ObjectType")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<string>("SystemUser");

                    b.Property<int>("SystemUserId");

                    b.Property<long>("Timestamp");

                    b.Property<int>("Type");

                    b.Property<string>("ValueAfter");

                    b.Property<string>("ValueBefore");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDate", "Type", "ObjectType", "Action", "SystemUser");

                    b.ToTable("Log","adm");
                });

            modelBuilder.Entity("TN.Domain.Model.Manager.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CashierId");

                    b.Property<string>("CashierName");

                    b.Property<DateTime>("CreateDate");

                    b.Property<float>("Money");

                    b.Property<string>("Note");

                    b.Property<bool>("Paid");

                    b.Property<int>("TableId");

                    b.Property<string>("WaiterName");

                    b.Property<int>("WaitersId");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("TN.Domain.Model.Manager.BillDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillId");

                    b.Property<int>("DishId");

                    b.Property<string>("DishName");

                    b.Property<string>("Note");

                    b.Property<float>("Price");

                    b.Property<int>("Quanity");

                    b.Property<bool>("Status");

                    b.Property<string>("UseName");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("dateTime");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("BillDetail");
                });

            modelBuilder.Entity("TN.Domain.Model.Manager.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("TN.Domain.Model.Manager.DishPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("DishId");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<float>("Price");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.ToTable("DishPrice");
                });

            modelBuilder.Entity("TN.Domain.Model.Manager.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("TN.Domain.Model.RoleAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .HasMaxLength(500);

                    b.Property<string>("ControllerId")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int>("Order");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ControllerId");

                    b.ToTable("RoleAction","adm");
                });

            modelBuilder.Entity("TN.Domain.Model.RoleArea", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.Property<int>("Order");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("RoleArea","adm");
                });

            modelBuilder.Entity("TN.Domain.Model.RoleController", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100);

                    b.Property<string>("AreaId");

                    b.Property<int>("GroupId");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<int>("Order");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("GroupId");

                    b.ToTable("RoleController","adm");
                });

            modelBuilder.Entity("TN.Domain.Model.RoleDetail", b =>
                {
                    b.Property<int>("ActionId");

                    b.Property<int>("RoleId");

                    b.HasKey("ActionId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleDetail","adm");
                });

            modelBuilder.Entity("TN.Domain.Model.RoleGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.Property<int>("Order");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("RoleGroup","adm");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("TN.Domain.Model.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("TN.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("TN.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("TN.Domain.Model.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TN.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("TN.Domain.Model.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TN.Domain.Model.Manager.Bill", b =>
                {
                    b.HasOne("TN.Domain.Model.Manager.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TN.Domain.Model.Manager.BillDetail", b =>
                {
                    b.HasOne("TN.Domain.Model.Manager.Bill", "Bill")
                        .WithMany()
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TN.Domain.Model.Manager.DishPrice", b =>
                {
                    b.HasOne("TN.Domain.Model.Manager.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TN.Domain.Model.RoleAction", b =>
                {
                    b.HasOne("TN.Domain.Model.RoleController", "RoleController")
                        .WithMany()
                        .HasForeignKey("ControllerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TN.Domain.Model.RoleController", b =>
                {
                    b.HasOne("TN.Domain.Model.RoleArea", "RoleArea")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TN.Domain.Model.RoleGroup", "RoleGroups")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TN.Domain.Model.RoleDetail", b =>
                {
                    b.HasOne("TN.Domain.Model.RoleAction", "RoleAction")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TN.Domain.Model.ApplicationRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
