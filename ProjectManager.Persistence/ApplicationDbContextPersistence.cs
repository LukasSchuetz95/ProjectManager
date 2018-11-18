using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjectManager.Persistence
{
    public class ApplicationDbContextPersistence : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }

        public DbSet<EmployeeTask> EmployeeTasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskQualification> TaskQualifications { get; set; }

        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();
            Debug.Write(configuration.ToString());
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, DeptLocation = "Wels", DeptName = "Headquarter" });

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 2, DeptLocation = "Wien", DeptName = "Development" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 112412,
                    Firstname = "Lukas",
                    Lastname = "Schuetz",
                    Birthdate = new DateTime(1995, 4, 22),
                    HiringDate = new DateTime(2011, 12, 24),
                    Phonenumber = "0660/ 4878 299",
                    Residence = "Bad Hall",
                    StreetNameAndNr = "Roemerstr. 41",
                    ZipCode = "4540",
                    Status = EmployeeStatusType.Auszeit,
                    Job = "Software Developer",
                    DepartmentId = 1,
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 2214,
                    Firstname = "Thomas",
                    Lastname = "Baurnberger",
                    Birthdate = new DateTime(1994, 11, 22),
                    HiringDate = new DateTime(2012, 9, 27),
                    Phonenumber = "0660/ 4878 333",
                    Residence = "Kematen am Innbach",
                    StreetNameAndNr = "See 44",
                    ZipCode = "4633",
                    Status = EmployeeStatusType.Beschäftigt,
                    Job = "Web-Developer",
                    DepartmentId = 1,
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 3214,
                    Firstname = "Manuel",
                    Lastname = "Mairinger",
                    Birthdate = new DateTime(1990, 10, 5),
                    HiringDate = new DateTime(2010, 2, 12),
                    Phonenumber = "0660/ 4878 444",
                    Residence = "Irgendwo",
                    StreetNameAndNr = "Weiss i ned",
                    ZipCode = "Ka Ahnung",
                    Status = EmployeeStatusType.Gekündigt,
                    Job = "Software Developer",
                    DepartmentId = 2,
                });



            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1214,
                    AppoName = "Arztbesuch",
                    AppoType = AppointmentType.Meeting,
                    EmployeeId = 112412,
                    Startdate = new DateTime(2020, 10, 30, 6, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 8, 00, 0),
                    Information = "Muss zum Arzt"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 224234,
                    AppoName = "Meeting",
                    AppoType = AppointmentType.Urlaub,
                    EmployeeId = 112412,
                    Startdate = new DateTime(2020, 10, 30, 8, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 9, 00, 0),
                    Information = "Habe ein Meeting"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 323423,
                    AppoName = "test1",
                    AppoType = AppointmentType.Meeting,
                    EmployeeId = 112412,
                    Startdate = new DateTime(2020, 10, 30, 10, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 11, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 44356,
                    AppoName = "test2",
                    AppoType = AppointmentType.Arztbesuch,
                    EmployeeId = 112412,
                    Startdate = new DateTime(2020, 10, 30, 12, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 13, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 5246,
                    AppoName = "test3",
                    AppoType = AppointmentType.Andere,
                    EmployeeId = 112412,
                    Startdate = new DateTime(2020, 10, 30, 14, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 15, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 64256,
                    AppoName = "test4",
                    AppoType = AppointmentType.Zeitausgleich,
                    EmployeeId = 2214,
                    Startdate = new DateTime(2020, 10, 30, 6, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 7, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 7246,
                    AppoName = "test5",
                    AppoType = AppointmentType.Meeting,
                    EmployeeId = 2214,
                    Startdate = new DateTime(2020, 10, 30, 8, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 9, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 8246,
                    AppoName = "test6",
                    AppoType = AppointmentType.Arztbesuch,
                    EmployeeId = 2214,
                    Startdate = new DateTime(2020, 10, 30, 10, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 11, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 965747,
                    AppoName = "test7",
                    AppoType = AppointmentType.Andere,
                    EmployeeId = 2214,
                    Startdate = new DateTime(2020, 10, 30, 12, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 13, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1026246,
                    AppoName = "test8",
                    AppoType = AppointmentType.Andere,
                    EmployeeId = 2214,
                    Startdate = new DateTime(2020, 10, 30, 14, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 15, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 11246,
                    AppoName = "test9",
                    AppoType = AppointmentType.Zeitausgleich,
                    EmployeeId = 3214,
                    Startdate = new DateTime(2020, 10, 30, 6, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 7, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 12246,
                    AppoName = "test10",
                    AppoType = AppointmentType.Arztbesuch,
                    EmployeeId = 3214,
                    Startdate = new DateTime(2020, 10, 30, 8, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 9, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 13246,
                    AppoName = "test11",
                    AppoType = AppointmentType.Arztbesuch,
                    EmployeeId = 3214,
                    Startdate = new DateTime(2020, 10, 30, 10, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 11, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 142456,
                    AppoName = "test12",
                    AppoType = AppointmentType.Arztbesuch,
                    EmployeeId = 3214,
                    Startdate = new DateTime(2020, 10, 30, 12, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 13, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 15426,
                    AppoName = "test13",
                    AppoType = AppointmentType.Meeting,
                    EmployeeId = 3214,
                    Startdate = new DateTime(2020, 10, 30, 14, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 15, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1246,
                    ProjectName = "Diplomarbeit",
                    Status = ProjectStatusType.Abgeschlossen,
                    Startdate = new DateTime(2020, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(2020, 10, 30, 15, 30, 0),
                    ValuedTime = "500",
                    Information = "Dieses Projekt benötigt noch viel Zuneigung",
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 2426,
                    ProjectName = "Project1",
                    Status = ProjectStatusType.Laufend,
                    Startdate = new DateTime(2021, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(2022, 10, 30, 15, 30, 0),
                    ValuedTime = "500",
                    Information = "Dieses Projekt benötigt noch viel Zuneigung",
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 3246,
                    ProjectName = "Project2",
                    Status = ProjectStatusType.Planung,
                    Startdate = new DateTime(2023, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(2024, 10, 30, 15, 30, 0),
                    ValuedTime = "500",
                    Information = "Dieses Projekt benötigt noch viel Zuneigung",
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 42456,
                    ProjectName = "Project3",
                    Status = ProjectStatusType.Laufend,
                    Startdate = new DateTime(2025, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    ValuedTime = "500",
                    Information = "Dieses Projekt benötigt noch viel Zuneigung",
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 1246,
                    EmployeeId = 112412,
                    ProjectId = 1246,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 2246,
                    EmployeeId = 112412,
                    ProjectId = 2426,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 3246,
                    EmployeeId = 112412,
                    ProjectId = 3246,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 4246,
                    EmployeeId = 112412,
                    ProjectId = 42456,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 5246,
                    EmployeeId = 2214,
                    ProjectId = 1246,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 6215,
                    EmployeeId = 2214,
                    ProjectId = 2426,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 71234,
                    EmployeeId = 2214,
                    ProjectId = 3246,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 83465,
                    EmployeeId = 3214,
                    ProjectId = 1246,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 9634,
                    EmployeeId = 3214,
                    ProjectId = 2426,
                    Projectmanager = false,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 1111,
                    ProjectId = 1246,
                    FixedTask = false,
                    TaskName = "Test1",
                    Status = TaskStatusType.InArbeit,
                    Information = "Erster Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 2222,
                    ProjectId = 1246,
                    FixedTask = false,
                    TaskName = "Test2",
                    Status = TaskStatusType.Erledigt,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 3333,
                    ProjectId = 1246,
                    FixedTask = false,
                    TaskName = "Test3",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 4444,
                    ProjectId = 1246,
                    FixedTask = false,
                    TaskName = "Test4",
                    Status = TaskStatusType.InArbeit,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 5555,
                    ProjectId = 1246,
                    FixedTask = false,
                    TaskName = "Test5",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 6666,
                    ProjectId = 2426,
                    FixedTask = false,
                    TaskName = "Test6",
                    Status = TaskStatusType.InArbeit,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 7777,
                    ProjectId = 2426,
                    FixedTask = false,
                    TaskName = "Test7",
                    Status = TaskStatusType.InArbeit,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 8888,
                    ProjectId = 2426,
                    FixedTask = false,
                    TaskName = "Test8",
                    Status = TaskStatusType.Erledigt,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Niedrig,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 9999,
                    ProjectId = 2426,
                    FixedTask = false,
                    TaskName = "Test9",
                    Status = TaskStatusType.InArbeit,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Niedrig,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 10000,
                    ProjectId = 2426,
                    FixedTask = false,
                    TaskName = "Test10",
                    Status = TaskStatusType.InArbeit,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Niedrig,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 11111,
                    ProjectId = 3246,
                    FixedTask = false,
                    TaskName = "Test11",
                    Status = TaskStatusType.InArbeit,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 12222,
                    ProjectId = 3246,
                    FixedTask = false,
                    TaskName = "Test12",
                    Status = TaskStatusType.InArbeit,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 13333,
                    ProjectId = 3246,
                    FixedTask = false,
                    TaskName = "Test13",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 14444,
                    ProjectId = 3246,
                    FixedTask = false,
                    TaskName = "Test14",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 15555,
                    ProjectId = 3246,
                    FixedTask = false,
                    TaskName = "Test15",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 16666,
                    ProjectId = 42456,
                    FixedTask = false,
                    TaskName = "Test16",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 17777,
                    ProjectId = 42456,
                    FixedTask = false,
                    TaskName = "Test17",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 18888,
                    ProjectId = 42456,
                    FixedTask = false,
                    TaskName = "Test18",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 19999,
                    ProjectId = 42456,
                    FixedTask = false,
                    TaskName = "Test19",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 1968,
                    EmployeeId = 112412,
                    TaskId = 1111,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 2242,
                    EmployeeId = 112412,
                    TaskId = 2222,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 1435,
                    EmployeeId = 112412,
                    TaskId = 3333,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 8678,
                    EmployeeId = 112412,
                    TaskId = 4444,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 7475,
                    EmployeeId = 112412,
                    TaskId = 5555,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 4567,
                    EmployeeId = 112412,
                    TaskId = 6666,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 3435,
                    EmployeeId = 2214,
                    TaskId = 7777,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 3445,
                    EmployeeId = 2214,
                    TaskId = 8888,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 3254,
                    EmployeeId = 2214,
                    TaskId = 9999,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 12433,
                    EmployeeId = 2214,
                    TaskId = 10000,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 54664,
                    EmployeeId = 2214,
                    TaskId = 11111,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 34543,
                    EmployeeId = 2214,
                    TaskId = 12222,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 23532,
                    EmployeeId = 2214,
                    TaskId = 13333,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 21434,
                    EmployeeId = 3214,
                    TaskId = 14444,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 96767,
                    EmployeeId = 3214,
                    TaskId = 15555,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 57868,
                    EmployeeId = 3214,
                    TaskId = 16666,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 32534,
                    EmployeeId = 3214,
                    TaskId = 17777,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 324556,
                    EmployeeId = 3214,
                    TaskId = 18888,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 19324,
                    EmployeeId = 3214,
                    TaskId = 19999,
                });

            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = 1111,
                    QualificationName = "Projekt Manager",
                });

            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = 2222,
                    QualificationName = "CSharp",
                });

            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = 3333,
                    QualificationName = "Html",
                });

            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = 4444,
                    QualificationName = "Pflichtenheft",
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 1111,
                    QualificationId = 1111,
                    EmployeeId = 112412,
                    Information = "Sehr guter Projekt Manager",
                    SkillLevel = SkillLevelType.Sehrgut,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 2222,
                    QualificationId = 2222,
                    EmployeeId = 112412,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Gut,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 3333,
                    QualificationId = 3333,
                    EmployeeId = 112412,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Befriedigend,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 4444,
                    QualificationId = 4444,
                    EmployeeId = 112412,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Genügend,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 5555,
                    QualificationId = 1111,
                    EmployeeId = 2214,
                    Information = "Test",
                    SkillLevel = SkillLevelType.NichtGenügend,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                 new EmployeeQualification
                 {
                     Id = 6666,
                     QualificationId = 3333,
                     EmployeeId = 2214,
                     Information = "Test",
                     SkillLevel = SkillLevelType.Gut,
                 });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 7777,
                    QualificationId = 4444,
                    EmployeeId = 2214,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Genügend,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 8888,
                    QualificationId = 3333,
                    EmployeeId = 3214,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Befriedigend,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 9999,
                    QualificationId = 4444,
                    EmployeeId = 3214,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Sehrgut,
                });

        }
    }
}
