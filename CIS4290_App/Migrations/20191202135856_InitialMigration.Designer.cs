﻿// <auto-generated />
using System;
using CIS4290_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CIS4290_App.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20191202135856_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CIS4290_App.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e310a6cb-6677-4aa6-93c7-2763956f7a97"),
                            Age = 26,
                            Name = "Mark Miens",
                            Position = "Software Developer"
                        },
                        new
                        {
                            Id = new Guid("398d10fe-4b8d-4606-8e9c-bd2c78d4e001"),
                            Age = 29,
                            Name = "Anna Simmons",
                            Position = "Software Developer"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
