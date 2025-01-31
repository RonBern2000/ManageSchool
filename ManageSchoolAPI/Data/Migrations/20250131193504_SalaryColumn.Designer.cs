﻿// <auto-generated />
using ManageSchoolAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManageSchoolAPI.Data.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20250131193504_SalaryColumn")]
    partial class SalaryColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManageSchoolAPI.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmployeeType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("ManagerUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ManagerUserId");

                    b.ToTable("Employee");

                    b.HasDiscriminator<string>("EmployeeType").HasValue("Employee");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ManageSchoolAPI.Models.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("TeacherEmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentId");

                    b.HasIndex("TeacherEmployeeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ManageSchoolAPI.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ManageSchoolAPI.Models.Janitor", b =>
                {
                    b.HasBaseType("ManageSchoolAPI.Models.Employee");

                    b.HasDiscriminator().HasValue("Janitor");
                });

            modelBuilder.Entity("ManageSchoolAPI.Models.Teacher", b =>
                {
                    b.HasBaseType("ManageSchoolAPI.Models.Employee");

                    b.Property<int>("Professions")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("ManageSchoolAPI.Models.Employee", b =>
                {
                    b.HasOne("ManageSchoolAPI.Models.User", "Manager")
                        .WithMany("Employees")
                        .HasForeignKey("ManagerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("ManageSchoolAPI.Models.Student", b =>
                {
                    b.HasOne("ManageSchoolAPI.Models.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherEmployeeId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ManageSchoolAPI.Models.User", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ManageSchoolAPI.Models.Teacher", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
