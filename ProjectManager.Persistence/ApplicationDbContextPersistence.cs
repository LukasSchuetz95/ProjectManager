using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManager.Core.Entities;
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
            modelBuilder.Entity<Qualification>().HasData(
                new { Id = 1, QualificationName = "Test1" });

            modelBuilder.Entity<Qualification>().HasData(
                new { Id = 2, QualificationName = "Test2" });

            modelBuilder.Entity<Qualification>().HasData(
                new { Id = 3, QualificationName = "Test3" });

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, DeptLocation = "Wels", DeptName = "Headquarter" });

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 2, DeptLocation = "Wien", DeptName = "Development" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Firstname = "Lukas",
                    Lastname = "Schuetz",
                    Birthdate = DateTime.Now,
                    HiringDate = DateTime.Now,
                    Phonenumber = "0660/ 4878 299",
                    Residence = "Bad Hall",
                    StreetNameAndNr = "Roemerstr. 41",
                    ZipCode = "4540",
                    Status = "Beschaeftigt",
                    Job = "Software Developer",
                    Projectmanager = true,
                    DepartmentId = 1,
                    Timestamp = null
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 2,
                    Firstname = "Thomas",
                    Lastname = "Baurnberger",
                    Birthdate = DateTime.Now,
                    HiringDate = DateTime.Now,
                    Phonenumber = "0660/ 4878 333",
                    Residence = "Kematen am Innbach",
                    StreetNameAndNr = "Weiss i ned",
                    ZipCode = "Ka Ahnung",
                    Status = "Beschaeftigt",
                    Job = "Database Developer",
                    Projectmanager = false,
                    DepartmentId = 1,
                    Timestamp = null
                });

            modelBuilder.Entity<Employee>().HasData(
                new
                {
                    Id = 3,
                    Firstname = "Manuel",
                    Lastname = "Mairinger",
                    Birthdate = DateTime.Now,
                    HiringDate = DateTime.Now,
                    Phonenumber = "0660/ 4878 444",
                    Residence = "Irgendwo",
                    StreetNameAndNr = "Weiss i ned",
                    ZipCode = "Ka Ahnung",
                    Status = "Beschaeftigt",
                    Job = "Software Developer",
                    Projectmanager = true,
                    DepartmentId = 2
                });



            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    AppoName = "Arztbesuch",
                    AppoType = "Arzt",
                    EmployeeId = 1,
                    Startdate = new DateTime(2020, 10, 30, 6, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 8, 00, 0),
                    Information = "Muss zum Arzt"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 2,
                    AppoName = "Meeting",
                    AppoType = "Meeting",
                    EmployeeId = 1,
                    Startdate = new DateTime(2020, 10, 30, 8, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 9, 00, 0),
                    Information = "Habe ein Meeting"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 3,
                    AppoName = "test1",
                    AppoType = "test",
                    EmployeeId = 1,
                    Startdate = new DateTime(2020, 10, 30, 10, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 11, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 4,
                    AppoName = "test2",
                    AppoType = "test",
                    EmployeeId = 1,
                    Startdate = new DateTime(2020, 10, 30, 12, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 13, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 5,
                    AppoName = "test3",
                    AppoType = "test",
                    EmployeeId = 1,
                    Startdate = new DateTime(2020, 10, 30, 14, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 15, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 6,
                    AppoName = "test4",
                    AppoType = "test",
                    EmployeeId = 2,
                    Startdate = new DateTime(2020, 10, 30, 6, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 7, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 7,
                    AppoName = "test5",
                    AppoType = "test",
                    EmployeeId = 2,
                    Startdate = new DateTime(2020, 10, 30, 8, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 9, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 8,
                    AppoName = "test6",
                    AppoType = "test",
                    EmployeeId = 2,
                    Startdate = new DateTime(2020, 10, 30, 10, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 11, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 9,
                    AppoName = "test7",
                    AppoType = "test",
                    EmployeeId = 2,
                    Startdate = new DateTime(2020, 10, 30, 12, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 13, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 10,
                    AppoName = "test8",
                    AppoType = "test",
                    EmployeeId = 2,
                    Startdate = new DateTime(2020, 10, 30, 14, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 15, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 11,
                    AppoName = "test9",
                    AppoType = "test",
                    EmployeeId = 3,
                    Startdate = new DateTime(2020, 10, 30, 6, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 7, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 12,
                    AppoName = "test10",
                    AppoType = "test",
                    EmployeeId = 3,
                    Startdate = new DateTime(2020, 10, 30, 8, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 9, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 13,
                    AppoName = "test11",
                    AppoType = "test",
                    EmployeeId = 3,
                    Startdate = new DateTime(2020, 10, 30, 10, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 11, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 14,
                    AppoName = "test12",
                    AppoType = "test",
                    EmployeeId = 3,
                    Startdate = new DateTime(2020, 10, 30, 12, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 13, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 15,
                    AppoName = "test13",
                    AppoType = "test",
                    EmployeeId = 3,
                    Startdate = new DateTime(2020, 10, 30, 14, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 15, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    ProjectName = "Diplomarbeit",
                    Status = "Undefiniert",
                    Startdate = new DateTime(2020, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(2020, 10, 30, 15, 30, 0),
                    ValuedTime = "500",
                    Information = "Dieses Projekt benötigt noch viel Zuneigung",
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 2,
                    ProjectName = "Project1",
                    Status = "Undefiniert",
                    Startdate = new DateTime(2021, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(2022, 10, 30, 15, 30, 0),
                    ValuedTime = "500",
                    Information = "Dieses Projekt benötigt noch viel Zuneigung",
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 3,
                    ProjectName = "Project2",
                    Status = "Undefiniert",
                    Startdate = new DateTime(2023, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(2024, 10, 30, 15, 30, 0),
                    ValuedTime = "500",
                    Information = "Dieses Projekt benötigt noch viel Zuneigung",
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 4,
                    ProjectName = "Project3",
                    Status = "Undefiniert",
                    Startdate = new DateTime(2025, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    ValuedTime = "500",
                    Information = "Dieses Projekt benötigt noch viel Zuneigung",
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 1,
                    EmployeeId = 1,
                    ProjectId = 1,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 2,
                    EmployeeId = 1,
                    ProjectId = 2,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 3,
                    EmployeeId = 1,
                    ProjectId = 3,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 4,
                    EmployeeId = 1,
                    ProjectId = 4,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 5,
                    EmployeeId = 2,
                    ProjectId = 1,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 6,
                    EmployeeId = 2,
                    ProjectId = 2,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 7,
                    EmployeeId = 2,
                    ProjectId = 3,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 8,
                    EmployeeId = 3,
                    ProjectId = 1,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 9,
                    EmployeeId = 3,
                    ProjectId = 2,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 1,
                    ProjectId = 1,
                    FixedTask = false,
                    TaskName = "Test1",
                    Status = "Processing",
                    Information = "Erster Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 2,
                    ProjectId = 1,
                    FixedTask = false,
                    TaskName = "Test2",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 3,
                    ProjectId = 1,
                    FixedTask = false,
                    TaskName = "Test3",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 4,
                    ProjectId = 1,
                    FixedTask = false,
                    TaskName = "Test4",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 5,
                    ProjectId = 1,
                    FixedTask = false,
                    TaskName = "Test5",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 6,
                    ProjectId = 2,
                    FixedTask = false,
                    TaskName = "Test6",
                    Status = "Processing",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 7,
                    ProjectId = 2,
                    FixedTask = false,
                    TaskName = "Test7",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 8,
                    ProjectId = 2,
                    FixedTask = false,
                    TaskName = "Test8",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 9,
                    ProjectId = 2,
                    FixedTask = false,
                    TaskName = "Test9",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 10,
                    ProjectId = 2,
                    FixedTask = false,
                    TaskName = "Test10",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 11,
                    ProjectId = 3,
                    FixedTask = false,
                    TaskName = "Test11",
                    Status = "Processing",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 12,
                    ProjectId = 3,
                    FixedTask = false,
                    TaskName = "Test12",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 13,
                    ProjectId = 3,
                    FixedTask = false,
                    TaskName = "Test13",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 14,
                    ProjectId = 3,
                    FixedTask = false,
                    TaskName = "Test14",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 15,
                    ProjectId = 3,
                    FixedTask = false,
                    TaskName = "Test15",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 16,
                    ProjectId = 4,
                    FixedTask = false,
                    TaskName = "Test16",
                    Status = "Processing",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 17,
                    ProjectId = 4,
                    FixedTask = false,
                    TaskName = "Test17",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 18,
                    ProjectId = 4,
                    FixedTask = false,
                    TaskName = "Test18",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 19,
                    ProjectId = 4,
                    FixedTask = false,
                    TaskName = "Test19",
                    Status = "undefiniert",
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Startdate = new DateTime(2026, 10, 30, 15, 30, 0),
                    Priority = 3,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 1,
                    EmployeeId = 1,
                    TaskId = 1,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 2,
                    EmployeeId = 1,
                    TaskId = 2,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 3,
                    EmployeeId = 1,
                    TaskId = 3,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 4,
                    EmployeeId = 1,
                    TaskId = 4,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 5,
                    EmployeeId = 1,
                    TaskId = 5,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 6,
                    EmployeeId = 1,
                    TaskId = 6,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 7,
                    EmployeeId = 2,
                    TaskId = 7,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 8,
                    EmployeeId = 2,
                    TaskId = 8,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 9,
                    EmployeeId = 2,
                    TaskId = 9,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 10,
                    EmployeeId = 2,
                    TaskId = 10,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 11,
                    EmployeeId = 2,
                    TaskId = 11,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 12,
                    EmployeeId = 2,
                    TaskId = 12,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 13,
                    EmployeeId = 2,
                    TaskId = 13,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 14,
                    EmployeeId = 3,
                    TaskId = 14,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 15,
                    EmployeeId = 3,
                    TaskId = 15,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 16,
                    EmployeeId = 3,
                    TaskId = 16,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 17,
                    EmployeeId = 3,
                    TaskId = 17,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 18,
                    EmployeeId = 3,
                    TaskId = 18,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 19,
                    EmployeeId = 3,
                    TaskId = 19,
                });

        }
    }
}
