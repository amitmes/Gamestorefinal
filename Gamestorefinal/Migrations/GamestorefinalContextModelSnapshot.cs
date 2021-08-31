﻿// <auto-generated />
using System;
using Gamestorefinal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gamestorefinal.Migrations
{
    [DbContext(typeof(GamestorefinalContext))]
    partial class GamestorefinalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryGames", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("CategoryGames");
                });

            modelBuilder.Entity("GamesStore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("GamesStore.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("GamesStore.Models.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Countofsell")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Onstock")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<DateTime>("Releasedate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Systemrequiremnts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WishlistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WishlistId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GamesStore.Models.Locations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Cor_x")
                        .HasColumnType("real");

                    b.Property<float>("Cor_y")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("GamesStore.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderClientId")
                        .HasColumnType("int");

                    b.Property<int?>("OrdereSupplierId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("OrderClientId");

                    b.HasIndex("OrdereSupplierId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("GamesStore.Models.OrderClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apartmentnumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Buildingnumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Creditcard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Totalprice")
                        .HasColumnType("real");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("OrderClient");
                });

            modelBuilder.Entity("GamesStore.Models.OrdereSupplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<float>("Totalprice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("OrdereSupplier");
                });

            modelBuilder.Entity("GamesStore.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("GamesStore.Models.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("GamesSupplier", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "SuppliersId");

                    b.HasIndex("SuppliersId");

                    b.ToTable("GamesSupplier");
                });

            modelBuilder.Entity("CategoryGames", b =>
                {
                    b.HasOne("GamesStore.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesStore.Models.Games", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesStore.Models.Games", b =>
                {
                    b.HasOne("GamesStore.Models.Wishlist", null)
                        .WithMany("Gameslist")
                        .HasForeignKey("WishlistId");
                });

            modelBuilder.Entity("GamesStore.Models.Order", b =>
                {
                    b.HasOne("GamesStore.Models.Games", "Game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("GamesStore.Models.OrderClient", null)
                        .WithMany("Games")
                        .HasForeignKey("OrderClientId");

                    b.HasOne("GamesStore.Models.OrdereSupplier", null)
                        .WithMany("GamesforOrder")
                        .HasForeignKey("OrdereSupplierId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GamesStore.Models.OrderClient", b =>
                {
                    b.HasOne("GamesStore.Models.Client", "Client")
                        .WithMany("OrderClient")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("GamesStore.Models.OrdereSupplier", b =>
                {
                    b.HasOne("GamesStore.Models.Supplier", "Supplier")
                        .WithMany("OrdereSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("GamesStore.Models.Wishlist", b =>
                {
                    b.HasOne("GamesStore.Models.Client", "Client")
                        .WithOne("WishList")
                        .HasForeignKey("GamesStore.Models.Wishlist", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("GamesSupplier", b =>
                {
                    b.HasOne("GamesStore.Models.Games", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesStore.Models.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesStore.Models.Client", b =>
                {
                    b.Navigation("OrderClient");

                    b.Navigation("WishList");
                });

            modelBuilder.Entity("GamesStore.Models.OrderClient", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GamesStore.Models.OrdereSupplier", b =>
                {
                    b.Navigation("GamesforOrder");
                });

            modelBuilder.Entity("GamesStore.Models.Supplier", b =>
                {
                    b.Navigation("OrdereSuppliers");
                });

            modelBuilder.Entity("GamesStore.Models.Wishlist", b =>
                {
                    b.Navigation("Gameslist");
                });
#pragma warning restore 612, 618
        }
    }
}
