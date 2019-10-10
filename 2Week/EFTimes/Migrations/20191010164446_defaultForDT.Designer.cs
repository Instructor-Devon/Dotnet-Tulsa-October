﻿// <auto-generated />
using System;
using DBTimes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBTimes.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20191010164446_defaultForDT")]
    partial class defaultForDT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DBTimes.Models.Ninja", b =>
                {
                    b.Property<int>("NinjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ninja_id");

                    b.Property<string>("Bio");

                    b.Property<string>("Color");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("SecretCode");

                    b.HasKey("NinjaId");

                    b.ToTable("ninjas");
                });
#pragma warning restore 612, 618
        }
    }
}
