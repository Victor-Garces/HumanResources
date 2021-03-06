﻿// <auto-generated />
using System;
using HumanResources.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HumanResources.Migrations
{
    [DbContext(typeof(HumanResourceContext))]
    [Migration("20180923025111_PositionTable")]
    partial class PositionTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HumanResources.SqlServer.Models.Competition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("Description", "Status")
                        .IsUnique();

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("HumanResources.SqlServer.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Status")
                        .IsUnique();

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("HumanResources.SqlServer.Models.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<double>("MaximumSalary");

                    b.Property<double>("MinimumSalary");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RiskLevel");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("HumanResources.SqlServer.Models.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("EndDateTime");

                    b.Property<string>("Institution")
                        .IsRequired();

                    b.Property<int>("Level");

                    b.Property<DateTime>("StartDateTime");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
