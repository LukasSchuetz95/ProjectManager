﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManager.Persistence;

namespace ProjectManager.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContextPersistence))]
    [Migration("20190305192758_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectManager.Core.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppoName")
                        .IsRequired();

                    b.Property<int>("AppoType");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("Enddate");

                    b.Property<string>("Information");

                    b.Property<DateTime>("Startdate");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Appointment");

                    b.HasData(
                        new { Id = 1214, AppoName = "Arztbesuch", AppoType = 1, EmployeeId = 112412, Enddate = new DateTime(2020, 10, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), Information = "Muss zum Arzt", Startdate = new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 224234, AppoName = "Meeting", AppoType = 3, EmployeeId = 112412, Enddate = new DateTime(2020, 10, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), Information = "Habe ein Meeting", Startdate = new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 323423, AppoName = "test1", AppoType = 1, EmployeeId = 112412, Enddate = new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 44356, AppoName = "test2", AppoType = 0, EmployeeId = 112412, Enddate = new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 5246, AppoName = "test3", AppoType = 4, EmployeeId = 112412, Enddate = new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 64256, AppoName = "test4", AppoType = 2, EmployeeId = 2214, Enddate = new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 7246, AppoName = "test5", AppoType = 1, EmployeeId = 2214, Enddate = new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 8246, AppoName = "test6", AppoType = 0, EmployeeId = 2214, Enddate = new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 965747, AppoName = "test7", AppoType = 4, EmployeeId = 2214, Enddate = new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 1026246, AppoName = "test8", AppoType = 4, EmployeeId = 2214, Enddate = new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 11246, AppoName = "test9", AppoType = 2, EmployeeId = 3214, Enddate = new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 12246, AppoName = "test10", AppoType = 0, EmployeeId = 3214, Enddate = new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 13246, AppoName = "test11", AppoType = 0, EmployeeId = 3214, Enddate = new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 142456, AppoName = "test12", AppoType = 0, EmployeeId = 3214, Enddate = new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 15426, AppoName = "test13", AppoType = 1, EmployeeId = 3214, Enddate = new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeptLocation")
                        .IsRequired();

                    b.Property<string>("DeptName")
                        .IsRequired();

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasData(
                        new { Id = 1, DeptLocation = "Wels", DeptName = "Headquarter" },
                        new { Id = 2, DeptLocation = "Wien", DeptName = "Development" }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthdate");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<DateTime?>("HiringDate");

                    b.Property<string>("Job");

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Phonenumber");

                    b.Property<byte[]>("Profilepicture");

                    b.Property<string>("Residence");

                    b.Property<int>("Status");

                    b.Property<string>("StreetNameAndNr");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");

                    b.HasData(
                        new { Id = 112412, Birthdate = new DateTime(1995, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), DepartmentId = 1, Firstname = "Lukas", HiringDate = new DateTime(2011, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), Job = "Software Developer", Lastname = "Schuetz", Phonenumber = "0660/ 4878 299", Residence = "Bad Hall", Status = 1, StreetNameAndNr = "Roemerstr. 41", ZipCode = "4540" },
                        new { Id = 2214, Birthdate = new DateTime(1994, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), DepartmentId = 1, Firstname = "Thomas", HiringDate = new DateTime(2012, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), Job = "Web-Developer", Lastname = "Baurnberger", Phonenumber = "0660/ 4878 333", Residence = "Kematen am Innbach", Status = 0, StreetNameAndNr = "See 44", ZipCode = "4633" },
                        new { Id = 3214, Birthdate = new DateTime(1990, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), DepartmentId = 2, Firstname = "Manuel", HiringDate = new DateTime(2010, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), Job = "Software Developer", Lastname = "Mairinger", Phonenumber = "0660/ 4878 444", Residence = "Irgendwo", Status = 2, StreetNameAndNr = "Weiss i ned", ZipCode = "Ka Ahnung" }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.EmployeeProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<int>("ProjectId");

                    b.Property<bool>("Projectmanager");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProject");

                    b.HasData(
                        new { Id = 1246, EmployeeId = 112412, ProjectId = 1246, Projectmanager = false },
                        new { Id = 2246, EmployeeId = 112412, ProjectId = 2426, Projectmanager = false },
                        new { Id = 3246, EmployeeId = 112412, ProjectId = 3246, Projectmanager = true },
                        new { Id = 4246, EmployeeId = 112412, ProjectId = 42456, Projectmanager = true },
                        new { Id = 5246, EmployeeId = 2214, ProjectId = 1246, Projectmanager = false },
                        new { Id = 6215, EmployeeId = 2214, ProjectId = 2426, Projectmanager = true },
                        new { Id = 71234, EmployeeId = 2214, ProjectId = 3246, Projectmanager = false },
                        new { Id = 83465, EmployeeId = 3214, ProjectId = 1246, Projectmanager = true },
                        new { Id = 9634, EmployeeId = 3214, ProjectId = 2426, Projectmanager = false }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.EmployeeQualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Information");

                    b.Property<int>("QualificationId");

                    b.Property<int>("SkillLevel");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("QualificationId");

                    b.ToTable("EmployeeQualification");

                    b.HasData(
                        new { Id = 1111, EmployeeId = 112412, Information = "Sehr guter Projekt Manager", QualificationId = 1111, SkillLevel = 0 },
                        new { Id = 2222, EmployeeId = 112412, Information = "Test", QualificationId = 2222, SkillLevel = 1 },
                        new { Id = 3333, EmployeeId = 112412, Information = "Test", QualificationId = 3333, SkillLevel = 2 },
                        new { Id = 4444, EmployeeId = 112412, Information = "Test", QualificationId = 4444, SkillLevel = 3 },
                        new { Id = 5555, EmployeeId = 2214, Information = "Test", QualificationId = 1111, SkillLevel = 4 },
                        new { Id = 6666, EmployeeId = 2214, Information = "Test", QualificationId = 3333, SkillLevel = 1 },
                        new { Id = 7777, EmployeeId = 2214, Information = "Test", QualificationId = 4444, SkillLevel = 3 },
                        new { Id = 8888, EmployeeId = 3214, Information = "Test", QualificationId = 3333, SkillLevel = 2 },
                        new { Id = 9999, EmployeeId = 3214, Information = "Test", QualificationId = 4444, SkillLevel = 0 }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.EmployeeTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<int>("TaskId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TaskId");

                    b.ToTable("EmployeeTask");

                    b.HasData(
                        new { Id = 1968, EmployeeId = 112412, TaskId = 1111 },
                        new { Id = 2242, EmployeeId = 112412, TaskId = 2222 },
                        new { Id = 1435, EmployeeId = 112412, TaskId = 3333 },
                        new { Id = 8678, EmployeeId = 112412, TaskId = 4444 },
                        new { Id = 7475, EmployeeId = 112412, TaskId = 5555 },
                        new { Id = 4567, EmployeeId = 112412, TaskId = 6666 },
                        new { Id = 3435, EmployeeId = 2214, TaskId = 7777 },
                        new { Id = 3445, EmployeeId = 2214, TaskId = 8888 },
                        new { Id = 3254, EmployeeId = 2214, TaskId = 9999 },
                        new { Id = 12433, EmployeeId = 2214, TaskId = 10000 },
                        new { Id = 54664, EmployeeId = 2214, TaskId = 11111 },
                        new { Id = 34543, EmployeeId = 2214, TaskId = 12222 },
                        new { Id = 23532, EmployeeId = 2214, TaskId = 13333 },
                        new { Id = 21434, EmployeeId = 3214, TaskId = 14444 },
                        new { Id = 96767, EmployeeId = 3214, TaskId = 15555 },
                        new { Id = 57868, EmployeeId = 3214, TaskId = 16666 },
                        new { Id = 32534, EmployeeId = 3214, TaskId = 17777 },
                        new { Id = 324556, EmployeeId = 3214, TaskId = 18888 },
                        new { Id = 19324, EmployeeId = 3214, TaskId = 19999 }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Deadline");

                    b.Property<DateTime?>("Enddate");

                    b.Property<string>("Information");

                    b.Property<string>("ProjectName")
                        .IsRequired();

                    b.Property<DateTime?>("Startdate");

                    b.Property<int>("Status");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ValuedTime");

                    b.HasKey("Id");

                    b.ToTable("Project");

                    b.HasData(
                        new { Id = 1246, Deadline = new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "Dieses Projekt benötigt noch viel Zuneigung", ProjectName = "Diplomarbeit", Startdate = new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), Status = 2, ValuedTime = "500" },
                        new { Id = 2426, Deadline = new DateTime(2022, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "Dieses Projekt benötigt noch viel Zuneigung", ProjectName = "Project1", Startdate = new DateTime(2021, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, ValuedTime = "500" },
                        new { Id = 3246, Deadline = new DateTime(2024, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "Dieses Projekt benötigt noch viel Zuneigung", ProjectName = "Project2", Startdate = new DateTime(2023, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, ValuedTime = "500" },
                        new { Id = 42456, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "Dieses Projekt benötigt noch viel Zuneigung", ProjectName = "Project3", Startdate = new DateTime(2025, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, ValuedTime = "500" }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QualificationName")
                        .IsRequired();

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Qualification");

                    b.HasData(
                        new { Id = 1111, QualificationName = "Projekt Manager" },
                        new { Id = 2222, QualificationName = "CSharp" },
                        new { Id = 3333, QualificationName = "Html" },
                        new { Id = 4444, QualificationName = "Pflichtenheft" }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Deadline");

                    b.Property<DateTime>("Enddate");

                    b.Property<bool>("FixedTask");

                    b.Property<string>("Information");

                    b.Property<int>("Priority");

                    b.Property<int>("ProjectId");

                    b.Property<DateTime>("Startdate");

                    b.Property<int>("Status");

                    b.Property<string>("TaskName")
                        .IsRequired();

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ValuedTime");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Task");

                    b.HasData(
                        new { Id = 1111, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Erster Task", Priority = 1, ProjectId = 1246, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, TaskName = "Test1", ValuedTime = "400" },
                        new { Id = 2222, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 1246, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 2, TaskName = "Test2", ValuedTime = "400" },
                        new { Id = 3333, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 1246, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, TaskName = "Test3", ValuedTime = "400" },
                        new { Id = 4444, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 1246, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, TaskName = "Test4", ValuedTime = "400" },
                        new { Id = 5555, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 1246, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, TaskName = "Test5", ValuedTime = "400" },
                        new { Id = 6666, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 2426, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, TaskName = "Test6", ValuedTime = "400" },
                        new { Id = 7777, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 2426, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, TaskName = "Test7", ValuedTime = "400" },
                        new { Id = 8888, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 2, ProjectId = 2426, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 2, TaskName = "Test8", ValuedTime = "400" },
                        new { Id = 9999, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 2, ProjectId = 2426, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, TaskName = "Test9", ValuedTime = "400" },
                        new { Id = 10000, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 2, ProjectId = 2426, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, TaskName = "Test10", ValuedTime = "400" },
                        new { Id = 11111, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 3246, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, TaskName = "Test11", ValuedTime = "400" },
                        new { Id = 12222, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 3246, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, TaskName = "Test12", ValuedTime = "400" },
                        new { Id = 13333, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 3246, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, TaskName = "Test13", ValuedTime = "400" },
                        new { Id = 14444, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 3246, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, TaskName = "Test14", ValuedTime = "400" },
                        new { Id = 15555, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 3246, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, TaskName = "Test15", ValuedTime = "400" },
                        new { Id = 16666, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 42456, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, TaskName = "Test16", ValuedTime = "400" },
                        new { Id = 17777, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 42456, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, TaskName = "Test17", ValuedTime = "400" },
                        new { Id = 18888, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 42456, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, TaskName = "Test18", ValuedTime = "400" },
                        new { Id = 19999, Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 42456, Startdate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, TaskName = "Test19", ValuedTime = "400" }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.TaskQualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QualificationId");

                    b.Property<int>("TaskId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("QualificationId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskQualification");
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.Appointment", b =>
                {
                    b.HasOne("ProjectManager.Core.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.Employee", b =>
                {
                    b.HasOne("ProjectManager.Core.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.EmployeeProject", b =>
                {
                    b.HasOne("ProjectManager.Core.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectManager.Core.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.EmployeeQualification", b =>
                {
                    b.HasOne("ProjectManager.Core.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectManager.Core.Entities.Qualification", "Qualification")
                        .WithMany()
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.EmployeeTask", b =>
                {
                    b.HasOne("ProjectManager.Core.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectManager.Core.Entities.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.Task", b =>
                {
                    b.HasOne("ProjectManager.Core.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.TaskQualification", b =>
                {
                    b.HasOne("ProjectManager.Core.Entities.Qualification", "Qualification")
                        .WithMany()
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectManager.Core.Entities.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}