﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstate.Data;

#nullable disable

namespace RealEstate.Data.Migrations
{
    [DbContext(typeof(RealEstateDbContext))]
    [Migration("20240406172326_InitialRealEstateDb")]
    partial class InitialRealEstateDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RealEstate.Domain.Catalog.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("RealEstate.Domain.Catalog.ItemAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemAttribute", (string)null);
                });

            modelBuilder.Entity("RealEstate.Domain.Catalog.ItemAttributeMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemAttributeValueId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemAttributeValueId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemAttributeMapping", (string)null);
                });

            modelBuilder.Entity("RealEstate.Domain.Catalog.ItemAttributeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemAttributeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemAttributeId");

                    b.ToTable("ItemAttributeValue", (string)null);
                });

            modelBuilder.Entity("RealEstate.Domain.Catalog.ItemImage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemImage", (string)null);
                });

            modelBuilder.Entity("RealEstate.Domain.Catalog.ItemAttributeMapping", b =>
                {
                    b.HasOne("RealEstate.Domain.Catalog.ItemAttributeValue", "ItemAttributeValue")
                        .WithMany()
                        .HasForeignKey("ItemAttributeValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.Catalog.Item", "Item")
                        .WithMany("Attributes")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("ItemAttributeValue");
                });

            modelBuilder.Entity("RealEstate.Domain.Catalog.ItemAttributeValue", b =>
                {
                    b.HasOne("RealEstate.Domain.Catalog.ItemAttribute", "ItemAttribute")
                        .WithMany("AttributeValues")
                        .HasForeignKey("ItemAttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemAttribute");
                });

            modelBuilder.Entity("RealEstate.Domain.Catalog.ItemImage", b =>
                {
                    b.HasOne("RealEstate.Domain.Catalog.Item", "Item")
                        .WithMany("Images")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("RealEstate.Domain.Catalog.Item", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("RealEstate.Domain.Catalog.ItemAttribute", b =>
                {
                    b.Navigation("AttributeValues");
                });
#pragma warning restore 612, 618
        }
    }
}
