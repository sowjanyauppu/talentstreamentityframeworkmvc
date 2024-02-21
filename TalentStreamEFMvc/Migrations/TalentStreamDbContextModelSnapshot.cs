﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalentStreamEFMvc.Models;

#nullable disable

namespace TalentStreamEFMvc.Migrations
{
    [DbContext(typeof(TalentStreamDbContext))]
    partial class TalentStreamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TalentStreamEFMvc.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MaxExperience")
                        .HasColumnType("int");

                    b.Property<double>("MaxSalary")
                        .HasColumnType("double");

                    b.Property<int>("MinExperience")
                        .HasColumnType("int");

                    b.Property<double>("MinSalary")
                        .HasColumnType("double");

                    b.Property<int>("RecruiterId")
                        .HasColumnType("int");

                    b.Property<string>("RequiredSkills")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("JobId");

                    b.HasIndex("RecruiterId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("TalentStreamEFMvc.Models.Recruiter", b =>
                {
                    b.Property<int>("RecruiterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RecruiterId");

                    b.ToTable("Recruiters");
                });

            modelBuilder.Entity("TalentStreamEFMvc.Models.Job", b =>
                {
                    b.HasOne("TalentStreamEFMvc.Models.Recruiter", "Recruiter")
                        .WithMany("Jobs")
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recruiter");
                });

            modelBuilder.Entity("TalentStreamEFMvc.Models.Recruiter", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
