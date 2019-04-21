﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManager.Persistence;

namespace ProjectManager.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContextPersistence))]
    partial class ApplicationDbContextPersistenceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectManager.Core.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppoName");

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
                        new { Id = 1, AppoName = "Arztbesuch", AppoType = 1, EmployeeId = 1, Enddate = new DateTime(2020, 10, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), Information = "Muss zum Arzt", Startdate = new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 2, AppoName = "Meeting", AppoType = 3, EmployeeId = 1, Enddate = new DateTime(2020, 10, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), Information = "Habe ein Meeting", Startdate = new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 3, AppoName = "termin1", AppoType = 1, EmployeeId = 1, Enddate = new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 4, AppoName = "termin2", AppoType = 0, EmployeeId = 1, Enddate = new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 5, AppoName = "termin3", AppoType = 4, EmployeeId = 1, Enddate = new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 6, AppoName = "termin4", AppoType = 2, EmployeeId = 2, Enddate = new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 7, AppoName = "termin5", AppoType = 1, EmployeeId = 2, Enddate = new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 8, AppoName = "termin6", AppoType = 0, EmployeeId = 2, Enddate = new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 9, AppoName = "termin7", AppoType = 4, EmployeeId = 2, Enddate = new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 10, AppoName = "termin8", AppoType = 4, EmployeeId = 2, Enddate = new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 11, AppoName = "termin9", AppoType = 2, EmployeeId = 3, Enddate = new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 12, AppoName = "termin10", AppoType = 0, EmployeeId = 3, Enddate = new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 13, AppoName = "termin11", AppoType = 0, EmployeeId = 3, Enddate = new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 14, AppoName = "termin12", AppoType = 0, EmployeeId = 3, Enddate = new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                        new { Id = 15, AppoName = "termin13", AppoType = 1, EmployeeId = 3, Enddate = new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "Das ist ein Test", Startdate = new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.DashboardDisplay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentId");

                    b.Property<int>("EmployeeId");

                    b.Property<bool>("Finished");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("SpecificInformation");

                    b.Property<DateTime>("Startdatum");

                    b.Property<int>("TaskId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("DashboardDisplay");
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
                        new { Id = 2, DeptLocation = "Wien", DeptName = "Development" },
                        new { Id = 3, DeptLocation = "Linz", DeptName = "Testdepartment" },
                        new { Id = 4, DeptLocation = "Salzburg", DeptName = "Werbekompanie" },
                        new { Id = 5, DeptLocation = "Prag", DeptName = "Labor" }
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
                        new { Id = 1, Birthdate = new DateTime(1995, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), DepartmentId = 1, Firstname = "Lukas", HiringDate = new DateTime(2011, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), Job = "Software Developer", Lastname = "Schuetz", Phonenumber = "0660/ 4878 299", Residence = "Bad Hall", Status = 1, StreetNameAndNr = "Roemerstr. 41", ZipCode = "4540" },
                        new { Id = 2, Birthdate = new DateTime(1994, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), DepartmentId = 1, Firstname = "Thomas", HiringDate = new DateTime(2012, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), Job = "Web-Developer", Lastname = "Baurnberger", Phonenumber = "0660/ 4878 333", Residence = "Kematen am Innbach", Status = 0, StreetNameAndNr = "See 44", ZipCode = "4633" },
                        new { Id = 3, Birthdate = new DateTime(1990, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), DepartmentId = 2, Firstname = "Manuel", HiringDate = new DateTime(2010, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), Job = "Software Developer", Lastname = "Mairinger", Phonenumber = "0660/ 4878 444", Residence = "Irgendwo", Status = 2, StreetNameAndNr = "Weiss i ned", ZipCode = "4020" }
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
                        new { Id = 1246, EmployeeId = 1, ProjectId = 1246, Projectmanager = false },
                        new { Id = 2246, EmployeeId = 1, ProjectId = 2426, Projectmanager = false },
                        new { Id = 3246, EmployeeId = 1, ProjectId = 3246, Projectmanager = true },
                        new { Id = 4246, EmployeeId = 1, ProjectId = 42456, Projectmanager = true },
                        new { Id = 5246, EmployeeId = 2, ProjectId = 1246, Projectmanager = false },
                        new { Id = 6215, EmployeeId = 2, ProjectId = 2426, Projectmanager = true },
                        new { Id = 71234, EmployeeId = 2, ProjectId = 3246, Projectmanager = false },
                        new { Id = 83465, EmployeeId = 3, ProjectId = 1246, Projectmanager = true },
                        new { Id = 9634, EmployeeId = 3, ProjectId = 2426, Projectmanager = false },
                        new { Id = 1, EmployeeId = 1, ProjectId = 6969, Projectmanager = true },
                        new { Id = 2, EmployeeId = 2, ProjectId = 6969, Projectmanager = false },
                        new { Id = 3, EmployeeId = 3, ProjectId = 6969, Projectmanager = false },
                        new { Id = 1150, EmployeeId = 1, ProjectId = 1000, Projectmanager = true }
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
                        new { Id = 1111, EmployeeId = 1, Information = "Sehr guter Projekt Manager", QualificationId = 1111, SkillLevel = 0 },
                        new { Id = 2222, EmployeeId = 1, Information = "Test", QualificationId = 2222, SkillLevel = 1 },
                        new { Id = 3333, EmployeeId = 1, Information = "Test", QualificationId = 3333, SkillLevel = 2 },
                        new { Id = 4444, EmployeeId = 1, Information = "Test", QualificationId = 4444, SkillLevel = 3 },
                        new { Id = 5555, EmployeeId = 3, Information = "Test", QualificationId = 1111, SkillLevel = 4 },
                        new { Id = 6666, EmployeeId = 2, Information = "Test", QualificationId = 3333, SkillLevel = 1 },
                        new { Id = 7777, EmployeeId = 2, Information = "Test", QualificationId = 4444, SkillLevel = 3 },
                        new { Id = 8888, EmployeeId = 3, Information = "Test", QualificationId = 3333, SkillLevel = 2 },
                        new { Id = 9999, EmployeeId = 3, Information = "Test", QualificationId = 4444, SkillLevel = 0 }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.EmployeeTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<int?>("PassedTaskId");

                    b.Property<bool>("Picked");

                    b.Property<int>("TaskId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PassedTaskId");

                    b.HasIndex("TaskId");

                    b.ToTable("EmployeeTask");

                    b.HasData(
                        new { Id = 100, EmployeeId = 1, Picked = false, TaskId = 1111 },
                        new { Id = 101, EmployeeId = 1, Picked = false, TaskId = 2222 },
                        new { Id = 102, EmployeeId = 1, Picked = false, TaskId = 3333 },
                        new { Id = 103, EmployeeId = 1, Picked = false, TaskId = 4444 },
                        new { Id = 104, EmployeeId = 1, Picked = false, TaskId = 5555 },
                        new { Id = 105, EmployeeId = 1, Picked = false, TaskId = 6666 },
                        new { Id = 106, EmployeeId = 2, Picked = false, TaskId = 7777 },
                        new { Id = 107, EmployeeId = 2, Picked = false, TaskId = 8888 },
                        new { Id = 108, EmployeeId = 2, Picked = false, TaskId = 9999 },
                        new { Id = 109, EmployeeId = 2, Picked = false, TaskId = 10000 },
                        new { Id = 110, EmployeeId = 2, Picked = false, TaskId = 11111 },
                        new { Id = 111, EmployeeId = 2, Picked = false, TaskId = 12222 },
                        new { Id = 112, EmployeeId = 2, Picked = false, TaskId = 13333 },
                        new { Id = 113, EmployeeId = 3, Picked = false, TaskId = 14444 },
                        new { Id = 114, EmployeeId = 3, Picked = false, TaskId = 15555 },
                        new { Id = 115, EmployeeId = 3, Picked = false, TaskId = 16666 },
                        new { Id = 116, EmployeeId = 3, Picked = false, TaskId = 17777 },
                        new { Id = 117, EmployeeId = 3, Picked = false, TaskId = 18888 },
                        new { Id = 118, EmployeeId = 3, Picked = false, TaskId = 19999 }
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
                        new { Id = 6969, Deadline = new DateTime(9999, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "This project contains all tasks who can't be added to a specified project", ProjectName = "General", Startdate = new DateTime(2015, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), Status = 1 },
                        new { Id = 1246, Deadline = new DateTime(2019, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), Information = "", ProjectName = "Diploma", Startdate = new DateTime(2018, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 1, ValuedTime = "500" },
                        new { Id = 2426, Deadline = new DateTime(2022, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "This project needs love", ProjectName = "Mustermann GmbH", Startdate = new DateTime(2021, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), Status = 1, ValuedTime = "500" },
                        new { Id = 3246, Deadline = new DateTime(2024, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "This project needs love", ProjectName = "Internal Module", Startdate = new DateTime(2023, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), Status = 0, ValuedTime = "500" },
                        new { Id = 42456, Deadline = new DateTime(2017, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), Information = "This project needs love", ProjectName = "New Module", Startdate = new DateTime(2016, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), Status = 1, ValuedTime = "500" },
                        new { Id = 1000, Deadline = new DateTime(9999, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Information = "This project contains all tasks who can't be added to a specified project", ProjectName = "Test", Startdate = new DateTime(2015, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), Status = 1 }
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
                        new { Id = 1111, QualificationName = "Project Manager" },
                        new { Id = 2222, QualificationName = "CSharp" },
                        new { Id = 3333, QualificationName = "Html" },
                        new { Id = 4444, QualificationName = "Backend" },
                        new { Id = 1000, QualificationName = "Testy" }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Deadline");

                    b.Property<DateTime?>("Enddate");

                    b.Property<bool>("FixedTask");

                    b.Property<string>("Information");

                    b.Property<int>("Priority");

                    b.Property<int>("ProjectId");

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
                        new { Id = 1, Created = new DateTime(2019, 5, 2, 16, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2019, 5, 2, 12, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2019, 5, 2, 16, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "There are plenty of tutorials on how to do that.", Priority = 1, ProjectId = 1246, Status = 1, TaskName = "Clean Espresso Machine", ValuedTime = "4" },
                        new { Id = 1111, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2030, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), FixedTask = true, Information = "", Priority = 1, ProjectId = 1246, Status = 2, TaskName = "Sort Files", ValuedTime = "400" },
                        new { Id = 2222, Created = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 1246, Status = 0, TaskName = "Add another Table", ValuedTime = "400" },
                        new { Id = 3333, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 1246, Status = 2, TaskName = "Create the Database", ValuedTime = "400" },
                        new { Id = 4444, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = true, Information = "Task", Priority = 0, ProjectId = 1246, Status = 0, TaskName = "Frontend: Create Project Views", ValuedTime = "400" },
                        new { Id = 5555, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 1246, Status = 0, TaskName = "Contact Customer", ValuedTime = "400" },
                        new { Id = 6666, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 2426, Status = 0, TaskName = "Test6", ValuedTime = "400" },
                        new { Id = 7777, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 2426, Status = 0, TaskName = "Test7", ValuedTime = "400" },
                        new { Id = 8888, Created = new DateTime(2016, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2018, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 2, ProjectId = 2426, Status = 2, TaskName = "Test8", ValuedTime = "400" },
                        new { Id = 9999, Created = new DateTime(2016, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2018, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 2, ProjectId = 2426, Status = 2, TaskName = "Test9", ValuedTime = "400" },
                        new { Id = 10000, Created = new DateTime(2016, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2018, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 2, ProjectId = 2426, Status = 2, TaskName = "Test10", ValuedTime = "400" },
                        new { Id = 11111, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 3246, Status = 0, TaskName = "Test11", ValuedTime = "400" },
                        new { Id = 12222, Created = new DateTime(2016, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2018, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 3246, Status = 2, TaskName = "Test12", ValuedTime = "400" },
                        new { Id = 13333, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 3246, Status = 0, TaskName = "Test13", ValuedTime = "400" },
                        new { Id = 14444, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 3246, Status = 0, TaskName = "Test14", ValuedTime = "400" },
                        new { Id = 15555, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 3246, Status = 0, TaskName = "Test15", ValuedTime = "400" },
                        new { Id = 16666, Created = new DateTime(2016, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Enddate = new DateTime(2018, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 42456, Status = 2, TaskName = "Test16", ValuedTime = "400" },
                        new { Id = 17777, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 42456, Status = 0, TaskName = "Test17", ValuedTime = "400" },
                        new { Id = 18888, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 42456, Status = 0, TaskName = "Test18", ValuedTime = "400" },
                        new { Id = 19999, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 42456, Status = 0, TaskName = "Test19", ValuedTime = "400" },
                        new { Id = 990, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 6969, Status = 0, TaskName = "General1High", ValuedTime = "400" },
                        new { Id = 991, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 6969, Status = 0, TaskName = "General2Medium", ValuedTime = "400" },
                        new { Id = 992, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 6969, Status = 0, TaskName = "General3medium", ValuedTime = "400" },
                        new { Id = 993, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 6969, Status = 0, TaskName = "general4High", ValuedTime = "400" },
                        new { Id = 994, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 6969, Status = 0, TaskName = "general5High", ValuedTime = "400" },
                        new { Id = 1000, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 1000, Status = 0, TaskName = "FeedTest1", ValuedTime = "400" },
                        new { Id = 1100, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 1000, Status = 0, TaskName = "FeedTest2", ValuedTime = "400" },
                        new { Id = 1110, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 1, ProjectId = 1000, Status = 0, TaskName = "FeedTest3", ValuedTime = "400" },
                        new { Id = 2000, Created = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), Deadline = new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), FixedTask = false, Information = "Task", Priority = 0, ProjectId = 6969, Status = 0, TaskName = "GeneralFeedTest3", ValuedTime = "400" }
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

                    b.HasData(
                        new { Id = 1, QualificationId = 2222, TaskId = 19999 },
                        new { Id = 2, QualificationId = 1111, TaskId = 19999 },
                        new { Id = 3, QualificationId = 1111, TaskId = 18888 },
                        new { Id = 4, QualificationId = 1111, TaskId = 17777 },
                        new { Id = 5, QualificationId = 1111, TaskId = 990 },
                        new { Id = 6, QualificationId = 2222, TaskId = 990 },
                        new { Id = 7, QualificationId = 3333, TaskId = 990 },
                        new { Id = 8, QualificationId = 4444, TaskId = 990 },
                        new { Id = 9, QualificationId = 1111, TaskId = 991 },
                        new { Id = 10, QualificationId = 2222, TaskId = 991 },
                        new { Id = 11, QualificationId = 3333, TaskId = 991 },
                        new { Id = 12, QualificationId = 4444, TaskId = 991 },
                        new { Id = 13, QualificationId = 1111, TaskId = 992 },
                        new { Id = 14, QualificationId = 2222, TaskId = 992 },
                        new { Id = 15, QualificationId = 3333, TaskId = 993 },
                        new { Id = 16, QualificationId = 4444, TaskId = 993 },
                        new { Id = 17, QualificationId = 2222, TaskId = 994 },
                        new { Id = 1000, QualificationId = 1000, TaskId = 1000 },
                        new { Id = 1001, QualificationId = 1000, TaskId = 1100 },
                        new { Id = 1011, QualificationId = 1000, TaskId = 1110 },
                        new { Id = 2000, QualificationId = 1000, TaskId = 2000 }
                    );
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.Appointment", b =>
                {
                    b.HasOne("ProjectManager.Core.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectManager.Core.Entities.DashboardDisplay", b =>
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

                    b.HasOne("ProjectManager.Core.Entities.Employee", "PassedTask")
                        .WithMany()
                        .HasForeignKey("PassedTaskId");

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
