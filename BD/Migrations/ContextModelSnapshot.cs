﻿// <auto-generated />
using System;
using BD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BD.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BD.Produkt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Produkts");
                });

            modelBuilder.Entity("BD.ProduktWSklepie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CenaWSklepie")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.Property<int>("SklepID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProduktId");

                    b.HasIndex("SklepID");

                    b.ToTable("ShopProducts");
                });

            modelBuilder.Entity("BD.Sklep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("BD.SzczegolyZamowienia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<int>("ProduktId")
                        .HasColumnType("int");

                    b.Property<int?>("ZamowieniaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProduktId");

                    b.HasIndex("ZamowieniaId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BD.Zamowienia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DataUtworzenia")
                        .HasColumnType("int");

                    b.Property<int>("SklepIDId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SklepIDId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BD.ProduktWSklepie", b =>
                {
                    b.HasOne("BD.Produkt", "Produkt")
                        .WithMany("ProduktWSklepie")
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BD.Sklep", "Sklep")
                        .WithMany("ProduktWSklepie")
                        .HasForeignKey("SklepID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produkt");

                    b.Navigation("Sklep");
                });

            modelBuilder.Entity("BD.SzczegolyZamowienia", b =>
                {
                    b.HasOne("BD.Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("ProduktId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BD.Zamowienia", null)
                        .WithMany("SzczegolyZamowienia")
                        .HasForeignKey("ZamowieniaId");

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("BD.Zamowienia", b =>
                {
                    b.HasOne("BD.Sklep", "SklepID")
                        .WithMany()
                        .HasForeignKey("SklepIDId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SklepID");
                });

            modelBuilder.Entity("BD.Produkt", b =>
                {
                    b.Navigation("ProduktWSklepie");
                });

            modelBuilder.Entity("BD.Sklep", b =>
                {
                    b.Navigation("ProduktWSklepie");
                });

            modelBuilder.Entity("BD.Zamowienia", b =>
                {
                    b.Navigation("SzczegolyZamowienia");
                });
#pragma warning restore 612, 618
        }
    }
}
