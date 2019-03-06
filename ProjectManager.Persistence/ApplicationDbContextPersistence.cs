using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManager.Core.Entities;
using ProjectManager.Core.Enum;
using System;
using System.Diagnostics;

namespace ProjectManager.Persistence
{
    public class ApplicationDbContextPersistence : DbContext
    {
        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<EmployeeQualification> EmployeeQualification { get; set; }

        public DbSet<EmployeeTask> EmployeeTask { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<Qualification> Qualification { get; set; }

        public DbSet<Task> Task { get; set; }

        public DbSet<TaskQualification> TaskQualification { get; set; }

        public DbSet<EmployeeProject> EmployeeProject { get; set; }

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

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 3, DeptLocation = "Linz", DeptName = "Testdepartment" });

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 4, DeptLocation = "Salzburg", DeptName = "Werbekompanie" });

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 5, DeptLocation = "Prag", DeptName = "Labor" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
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
                    Id = 2,
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
                    Id = 3,
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

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 4,
                    Firstname = "Bojack",
                    Lastname = "Horseman",
                    Birthdate = new DateTime(1960, 2, 2),
                    HiringDate = new DateTime(2014, 7, 6),
                    Phonenumber = "0676/9876534",
                    Residence = "Hollywoo",
                    StreetNameAndNr = "Beachstreet 5",
                    ZipCode = "Ka Ahnung",
                    Status = EmployeeStatusType.Beschäftigt,
                    Job = "Software Developer",
                    DepartmentId = 2,
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 5,
                    Firstname = "Rick",
                    Lastname = "Sanchez",
                    Birthdate = new DateTime(1950, 4, 3),
                    HiringDate = new DateTime(2017, 8, 1),
                    Phonenumber = "039454646453",
                    Residence = "Interdimensional",
                    StreetNameAndNr = "streetytreetstreet",
                    ZipCode = "Ka Ahnung",
                    Status = EmployeeStatusType.Beschäftigt,
                    Job = "Web-Developer",
                    DepartmentId = 2,
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 6,
                    Firstname = "Jack",
                    Lastname = "Peralta",
                    Birthdate = new DateTime(1990, 7, 12),
                    HiringDate = new DateTime(2017, 12, 9),
                    Phonenumber = "6784352363465",
                    Residence = "Department 99",
                    StreetNameAndNr = "Brooklyn street",
                    ZipCode = "Ka Ahnung",
                    Status = EmployeeStatusType.Gekündigt,
                    Job = "Web-Developer",
                    DepartmentId = 5,
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 7,
                    Firstname = "Amy",
                    Lastname = "Santiago",
                    Birthdate = new DateTime(1993, 12, 10),
                    HiringDate = new DateTime(2012, 2, 4),
                    Phonenumber = "90445343454",
                    Residence = "Department 99",
                    StreetNameAndNr = "Brooklyn street",
                    ZipCode = "Ka Ahnung",
                    Status = EmployeeStatusType.Auszeit,
                    Job = "Web-Developer",
                    DepartmentId = 5,
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 8,
                    Firstname = "Rosa",
                    Lastname = "Diaz",
                    Birthdate = new DateTime(1993, 12, 10),
                    HiringDate = new DateTime(2012, 8, 4),
                    Phonenumber = "90445343454",
                    Residence = "Department 99",
                    StreetNameAndNr = "Brooklyn street",
                    ZipCode = "Ka Ahnung",
                    Status = EmployeeStatusType.Beschäftigt,
                    Job = "Software Developer",
                    DepartmentId = 5,
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 9,
                    Firstname = "Raimond",
                    Lastname = "Hoad",
                    Birthdate = new DateTime(1993, 12, 10),
                    HiringDate = new DateTime(2012, 2, 9),
                    Phonenumber = "90445343454",
                    Residence = "Department 99",
                    StreetNameAndNr = "Brooklyn street",
                    ZipCode = "Ka Ahnung",
                    Status = EmployeeStatusType.Beschäftigt,
                    Job = "Software Developer",
                    DepartmentId = 5,
                });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 10,
                    Firstname = "Todd",
                    Lastname = "Sharvez",
                    Birthdate = new DateTime(1990, 10, 5),
                    HiringDate = new DateTime(2010, 2, 12),
                    Phonenumber = "0660/ 4878 444",
                    Residence = "Hollywoo",
                    StreetNameAndNr = "Beachstreet",
                    ZipCode = "0000",
                    Status = EmployeeStatusType.Auszeit,
                    Job = "Software Developer",
                    DepartmentId = 2,
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    AppoName = "Arztbesuch",
                    AppoType = AppointmentType.Meeting,
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
                    AppoType = AppointmentType.Urlaub,
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
                    AppoType = AppointmentType.Meeting,
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
                    AppoType = AppointmentType.Arztbesuch,
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
                    AppoType = AppointmentType.Andere,
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
                    AppoType = AppointmentType.Zeitausgleich,
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
                    AppoType = AppointmentType.Meeting,
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
                    AppoType = AppointmentType.Arztbesuch,
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
                    AppoType = AppointmentType.Andere,
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
                    AppoType = AppointmentType.Andere,
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
                    AppoType = AppointmentType.Zeitausgleich,
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
                    AppoType = AppointmentType.Arztbesuch,
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
                    AppoType = AppointmentType.Arztbesuch,
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
                    AppoType = AppointmentType.Arztbesuch,
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
                    AppoType = AppointmentType.Meeting,
                    EmployeeId = 3,
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
                    EmployeeId = 1,
                    ProjectId = 1246,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 2246,
                    EmployeeId = 1,
                    ProjectId = 2426,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 3246,
                    EmployeeId = 1,
                    ProjectId = 3246,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 4246,
                    EmployeeId = 1,
                    ProjectId = 42456,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 5246,
                    EmployeeId = 2,
                    ProjectId = 1246,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 6215,
                    EmployeeId = 2,
                    ProjectId = 2426,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 71234,
                    EmployeeId = 2,
                    ProjectId = 3246,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 83465,
                    EmployeeId = 3,
                    ProjectId = 1246,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 9634,
                    EmployeeId = 3,
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
                    EmployeeId = 1,
                    TaskId = 1111,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 2242,
                    EmployeeId = 1,
                    TaskId = 2222,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 1435,
                    EmployeeId = 1,
                    TaskId = 3333,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 8678,
                    EmployeeId = 1,
                    TaskId = 4444,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 7475,
                    EmployeeId = 1,
                    TaskId = 5555,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 4567,
                    EmployeeId = 1,
                    TaskId = 6666,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 3435,
                    EmployeeId = 2,
                    TaskId = 7777,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 3445,
                    EmployeeId = 2,
                    TaskId = 8888,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 3254,
                    EmployeeId = 2,
                    TaskId = 9999,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 12433,
                    EmployeeId = 2,
                    TaskId = 10000,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 54664,
                    EmployeeId = 2,
                    TaskId = 11111,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 34543,
                    EmployeeId = 2,
                    TaskId = 12222,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 23532,
                    EmployeeId = 2,
                    TaskId = 13333,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 21434,
                    EmployeeId = 3,
                    TaskId = 14444,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 96767,
                    EmployeeId = 3,
                    TaskId = 15555,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 57868,
                    EmployeeId = 3,
                    TaskId = 16666,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 32534,
                    EmployeeId = 3,
                    TaskId = 17777,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 324556,
                    EmployeeId = 3,
                    TaskId = 18888,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 19324,
                    EmployeeId = 3,
                    TaskId = 19999,
                });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 1,
                   TaskId = 19999,
                   QualificationId = 2222,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
                new TaskQualification
                {
                    Id=2,
                    TaskId=19999,
                    QualificationId=1111,
                });

            modelBuilder.Entity<TaskQualification>().HasData(
                new TaskQualification
                {
                    Id = 3,
                    TaskId = 18888,
                    QualificationId = 1111,
                });

            modelBuilder.Entity<TaskQualification>().HasData(
                new TaskQualification
                {
                    Id = 4,
                    TaskId = 17777,
                    QualificationId = 1111,
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
                    EmployeeId = 1,
                    Information = "Sehr guter Projekt Manager",
                    SkillLevel = SkillLevelType.Sehrgut,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 2222,
                    QualificationId = 2222,
                    EmployeeId = 1,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Gut,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 3333,
                    QualificationId = 3333,
                    EmployeeId = 1,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Befriedigend,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 4444,
                    QualificationId = 4444,
                    EmployeeId = 1,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Genügend,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 5555,
                    QualificationId = 1111,
                    EmployeeId = 3,
                    Information = "Test",
                    SkillLevel = SkillLevelType.NichtGenügend,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                 new EmployeeQualification
                 {
                     Id = 6666,
                     QualificationId = 3333,
                     EmployeeId = 2,
                     Information = "Test",
                     SkillLevel = SkillLevelType.Gut,
                 });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 7777,
                    QualificationId = 4444,
                    EmployeeId = 2,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Genügend,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 8888,
                    QualificationId = 3333,
                    EmployeeId = 3,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Befriedigend,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 9999,
                    QualificationId = 4444,
                    EmployeeId = 3,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Sehrgut,
                });


        }
    }
}
