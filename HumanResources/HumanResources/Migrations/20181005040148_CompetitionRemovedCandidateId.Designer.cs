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
    [Migration("20181005040148_CompetitionRemovedCandidateId")]
    partial class CompetitionRemovedCandidateId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HumanResources.SqlServer.Models.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<double>("AspiratedSalary");

                    b.Property<string>("Department")
                        .IsRequired();

                    b.Property<string>("Identification")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("PositionId");

                    b.Property<string>("RecommendBy");

                    b.Property<Guid>("WorkExperienceId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("WorkExperienceId");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("HumanResources.SqlServer.Models.Competition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("CandidateId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.HasIndex("Description", "Status")
                        .IsUnique();

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("HumanResources.SqlServer.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<DateTime>("AdmissionDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Department")
                        .IsRequired();

                    b.Property<string>("Identification")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<double>("MonthlySalary");

                    b.Property<string>("Name");

                    b.Property<Guid>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
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

                    b.Property<Guid>("CandidateId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("EndDateTime");

                    b.Property<string>("Institution")
                        .IsRequired();

                    b.Property<int>("Level");

                    b.Property<DateTime>("StartDateTime");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("HumanResources.SqlServer.Models.WorkExperience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Company")
                        .IsRequired();

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("OccupiedPosition")
                        .IsRequired();

                    b.Property<double>("Salary");

                    b.HasKey("Id");

                    b.ToTable("WorkExperiences");
                });

            modelBuilder.Entity("HumanResources.SqlServer.Models.Candidate", b =>
                {
                    b.HasOne("HumanResources.SqlServer.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HumanResources.SqlServer.Models.WorkExperience", "WorkExperience")
                        .WithMany()
                        .HasForeignKey("WorkExperienceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HumanResources.SqlServer.Models.Competition", b =>
                {
                    b.HasOne("HumanResources.SqlServer.Models.Candidate")
                        .WithMany("Competitions")
                        .HasForeignKey("CandidateId");
                });

            modelBuilder.Entity("HumanResources.SqlServer.Models.Employee", b =>
                {
                    b.HasOne("HumanResources.SqlServer.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HumanResources.SqlServer.Models.Training", b =>
                {
                    b.HasOne("HumanResources.SqlServer.Models.Candidate", "Candidate")
                        .WithMany("Trainings")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}