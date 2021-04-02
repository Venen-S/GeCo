﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Models.Entities.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Key")
                        .HasColumnType("text")
                        .HasColumnName("key");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.ToTable("choice");
                });

            modelBuilder.Entity("Models.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConvertedOrder")
                        .HasColumnType("text")
                        .HasColumnName("converted_order");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<long>("OrderNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("order_number");

                    b.Property<string>("SourceOrder")
                        .HasColumnType("text")
                        .HasColumnName("source_order");

                    b.Property<string>("SystemType")
                        .HasColumnType("text")
                        .HasColumnName("system_type");

                    b.HasKey("Id");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Models.Entities.Processing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("process");
                });

            modelBuilder.Entity("Models.Entities.Processing", b =>
                {
                    b.HasOne("Models.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}