﻿// <auto-generated />
using System;
using GAP.Insurance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GAP.Insurance.Migrations
{
    [DbContext(typeof(InsuranceContext))]
    [Migration("20190204012145_ThirdMigration")]
    partial class ThirdMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GAP.Insurance.Entities.Assignment", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("PolicyId");

                    b.HasKey("UserId", "PolicyId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("GAP.Insurance.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("GAP.Insurance.Entities.CoverageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Coverage");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("CoverageTypes");
                });

            modelBuilder.Entity("GAP.Insurance.Entities.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoverageTypeId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Period");

                    b.Property<double>("Price");

                    b.Property<int>("RiskTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CoverageTypeId");

                    b.HasIndex("RiskTypeId");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("GAP.Insurance.Entities.RiskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("RiskTypes");
                });

            modelBuilder.Entity("GAP.Insurance.Entities.Policy", b =>
                {
                    b.HasOne("GAP.Insurance.Entities.CoverageType", "CoverageType")
                        .WithMany()
                        .HasForeignKey("CoverageTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GAP.Insurance.Entities.RiskType", "RiskType")
                        .WithMany()
                        .HasForeignKey("RiskTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
