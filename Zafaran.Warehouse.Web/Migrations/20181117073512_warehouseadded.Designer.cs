﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zafaran.WareHouse.Infrastructure;

namespace Zafaran.Warehouse.Web.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181117073512_warehouseadded")]
    partial class warehouseadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts.CheckoutedLineItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommodityId");

                    b.Property<Guid?>("CommodityRequestCheckoutId");

                    b.Property<int>("FinalPurchaseCount");

                    b.Property<Guid?>("FormRequestLineItemId");

                    b.Property<int>("RequiredAmount");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.HasIndex("CommodityRequestCheckoutId");

                    b.ToTable("CheckoutedLineItem");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts.CommodityRequestCheckout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("RequestFormId");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.HasIndex("RequestFormId");

                    b.ToTable("CommodityRequestCheckouts");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms.CommodityRequestForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("ResturantId");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("CommodityRequestForms");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms.CommodityRequestFormLineItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("CommodityId");

                    b.Property<Guid>("FormId");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.HasIndex("FormId");

                    b.ToTable("CommodityRequestFormLineItem");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Aggregates.InventoryEntryForms.EntryForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("InventoryId");

                    b.HasKey("Id");

                    b.ToTable("EntryForms");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Aggregates.InventoryEntryForms.EntryFormLineItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("CommodityId");

                    b.Property<Guid?>("EntryFormId");

                    b.HasKey("Id");

                    b.HasIndex("EntryFormId");

                    b.ToTable("EntryFormLineItem");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.CommidityWarehouseInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("CommodityId");

                    b.Property<int>("WareHouseId");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.HasIndex("WareHouseId");

                    b.ToTable("CommidityWarehouseInventories");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Commodity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Title");

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Commodities");

                    b.HasData(
                        new { Id = 1, Code = "123312312", CreatedOn = new DateTime(2018, 11, 17, 11, 5, 11, 530, DateTimeKind.Local), Title = "گوشت قرمز گوسفندی", UnitId = 1 },
                        new { Id = 2, Code = "123312312", CreatedOn = new DateTime(2018, 11, 17, 11, 5, 11, 530, DateTimeKind.Local), Title = "برنج", UnitId = 4 },
                        new { Id = 3, Code = "123312312", CreatedOn = new DateTime(2018, 11, 17, 11, 5, 11, 530, DateTimeKind.Local), Title = "رب گوجه", UnitId = 1 }
                    );
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Resturant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Resturants");

                    b.HasData(
                        new { Id = 1, CreatedOn = new DateTime(2018, 11, 17, 11, 5, 11, 526, DateTimeKind.Local), Title = "شعبه بلوار امین" },
                        new { Id = 2, CreatedOn = new DateTime(2018, 11, 17, 11, 5, 11, 528, DateTimeKind.Local), Title = "شعبه امام" }
                    );
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new { Id = 2, CreatedOn = new DateTime(2018, 11, 17, 11, 5, 11, 529, DateTimeKind.Local), Title = "کیلو" },
                        new { Id = 1, CreatedOn = new DateTime(2018, 11, 17, 11, 5, 11, 529, DateTimeKind.Local), Title = "مثقال" },
                        new { Id = 4, CreatedOn = new DateTime(2018, 11, 17, 11, 5, 11, 529, DateTimeKind.Local), Title = "گرم" },
                        new { Id = 3, CreatedOn = new DateTime(2018, 11, 17, 11, 5, 11, 529, DateTimeKind.Local), Title = "تن" }
                    );
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.WareHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("WareHouses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts.CheckoutedLineItem", b =>
                {
                    b.HasOne("Zafaran.WareHouse.Core.Entities.Commodity", "Commodity")
                        .WithMany()
                        .HasForeignKey("CommodityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts.CommodityRequestCheckout")
                        .WithMany("LineItems")
                        .HasForeignKey("CommodityRequestCheckoutId");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestCheckouts.CommodityRequestCheckout", b =>
                {
                    b.HasOne("Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms.CommodityRequestForm", "RequestForm")
                        .WithMany()
                        .HasForeignKey("RequestFormId");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms.CommodityRequestFormLineItem", b =>
                {
                    b.HasOne("Zafaran.WareHouse.Core.Entities.Commodity", "Commodity")
                        .WithMany()
                        .HasForeignKey("CommodityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Zafaran.WareHouse.Core.Entities.Aggregates.CommodityRequestForms.CommodityRequestForm")
                        .WithMany("LineItems")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Aggregates.InventoryEntryForms.EntryFormLineItem", b =>
                {
                    b.HasOne("Zafaran.WareHouse.Core.Entities.Aggregates.InventoryEntryForms.EntryForm")
                        .WithMany("LineItems")
                        .HasForeignKey("EntryFormId");
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.CommidityWarehouseInventory", b =>
                {
                    b.HasOne("Zafaran.WareHouse.Core.Entities.Commodity", "Commodity")
                        .WithMany("Inventories")
                        .HasForeignKey("CommodityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Zafaran.WareHouse.Core.Entities.WareHouse", "WareHouse")
                        .WithMany("Inventories")
                        .HasForeignKey("WareHouseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Zafaran.WareHouse.Core.Entities.Commodity", b =>
                {
                    b.HasOne("Zafaran.WareHouse.Core.Entities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
