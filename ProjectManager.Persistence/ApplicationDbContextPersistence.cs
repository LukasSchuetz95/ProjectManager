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

        public DbSet<DashboardDisplay> DashboardDisplay { get; set; }

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
                    AppoName = "termin1",
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
                    AppoName = "termin2",
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
                    AppoName = "termin3",
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
                    AppoName = "termin4",
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
                    AppoName = "termin5",
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
                    AppoName = "termin6",
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
                    AppoName = "termin7",
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
                    AppoName = "termin8",
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
                    AppoName = "termin9",
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
                    AppoName = "termin10",
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
                    AppoName = "termin11",
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
                    AppoName = "termin12",
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
                    AppoName = "termin13",
                    AppoType = AppointmentType.Meeting,
                    EmployeeId = 3,
                    Startdate = new DateTime(2020, 10, 30, 14, 30, 0),
                    Enddate = new DateTime(2020, 10, 30, 15, 30, 0),
                    Information = "Das ist ein Test"
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 6969,
                    ProjectName = "Allgemein",
                    Status = ProjectStatusType.Laufend,
                    Startdate = new DateTime(2015, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(9999, 10, 30, 15, 30, 0),
                    ValuedTime = null,
                    Information = "This project contains all tasks who can't be added to a specified project",
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1246,
                    ProjectName = "Diplomarbeit",
                    Status = ProjectStatusType.Laufend,
                    Startdate = new DateTime(2020, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(2020, 10, 30, 15, 30, 0),
                    ValuedTime = "500",
                    Information = "This project needs love",
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
                    Information = "This project needs love",
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
                    Information = "This project needs love",
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
                    Information = "This project needs love",
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

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 1,
                    EmployeeId = 1,
                    ProjectId = 6969,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 2,
                    EmployeeId = 2,
                    ProjectId = 6969,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 3,
                    EmployeeId = 3,
                    ProjectId = 6969,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 4,
                    EmployeeId = 4,
                    ProjectId = 6969,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 5,
                    EmployeeId = 5,
                    ProjectId = 6969,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 6,
                    EmployeeId = 6,
                    ProjectId = 6969,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 7,
                    EmployeeId = 7,
                    ProjectId = 6969,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 8,
                    EmployeeId = 8,
                    ProjectId = 6969,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 9,
                    EmployeeId = 9,
                    ProjectId = 6969,
                    Projectmanager = true,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 10,
                    EmployeeId = 10,
                    ProjectId = 6969,
                    Projectmanager = true,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 1111,
                    ProjectId = 1246,
                    FixedTask = false,
                    TaskName = "Test1",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Erster Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2030, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
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
                    Created = new DateTime(2026, 10, 30, 15, 30, 0),
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
                    Deadline = new DateTime(2030, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 4444,
                    ProjectId = 1246,
                    FixedTask = false,
                    TaskName = "Test4",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2030, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
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
                    Deadline = new DateTime(2030, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 6666,
                    ProjectId = 2426,
                    FixedTask = false,
                    TaskName = "Test6",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 7777,
                    ProjectId = 2426,
                    FixedTask = false,
                    TaskName = "Test7",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
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
                    Enddate = new DateTime(2018, 10, 30, 15, 30, 0),
                    Created = new DateTime(2016, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Niedrig,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 9999,
                    ProjectId = 2426,
                    FixedTask = false,
                    TaskName = "Test9",
                    Status = TaskStatusType.Erledigt,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2018, 10, 30, 15, 30, 0),
                    Created = new DateTime(2016, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Niedrig,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 10000,
                    ProjectId = 2426,
                    FixedTask = false,
                    TaskName = "Test10",
                    Status = TaskStatusType.Erledigt,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2018, 10, 30, 15, 30, 0),
                    Created = new DateTime(2016, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Niedrig,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 11111,
                    ProjectId = 3246,
                    FixedTask = false,
                    TaskName = "Test11",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 12222,
                    ProjectId = 3246,
                    FixedTask = false,
                    TaskName = "Test12",
                    Status = TaskStatusType.Erledigt,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2018, 10, 30, 15, 30, 0),
                    Created = new DateTime(2016, 10, 30, 15, 30, 0),
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
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
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
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
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
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 16666,
                    ProjectId = 42456,
                    FixedTask = false,
                    TaskName = "Test16",
                    Status = TaskStatusType.Erledigt,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = new DateTime(2018, 10, 30, 15, 30, 0),
                    Created = new DateTime(2016, 10, 30, 15, 30, 0),
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
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
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
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
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
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 990,
                    ProjectId = 6969,
                    FixedTask = false,
                    TaskName = "General1High",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 991,
                    ProjectId = 6969,
                    FixedTask = false,
                    TaskName = "General2Medium",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 992,
                    ProjectId = 6969,
                    FixedTask = false,
                    TaskName = "General3medium",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 993,
                    ProjectId = 6969,
                    FixedTask = false,
                    TaskName = "general4High",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 994,
                    ProjectId = 6969,
                    FixedTask = false,
                    TaskName = "general5High",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2026, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 100,
                    EmployeeId = 1,
                    TaskId = 1111,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 101,
                    EmployeeId = 1,
                    TaskId = 2222,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 102,
                    EmployeeId = 1,
                    TaskId = 3333,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 103,
                    EmployeeId = 1,
                    TaskId = 4444,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 104,
                    EmployeeId = 1,
                    TaskId = 5555,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 105,
                    EmployeeId = 1,
                    TaskId = 6666,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 106,
                    EmployeeId = 2,
                    TaskId = 7777,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 107,
                    EmployeeId = 2,
                    TaskId = 8888,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 108,
                    EmployeeId = 2,
                    TaskId = 9999,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 109,
                    EmployeeId = 2,
                    TaskId = 10000,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 110,
                    EmployeeId = 2,
                    TaskId = 11111,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 111,
                    EmployeeId = 2,
                    TaskId = 12222,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 112,
                    EmployeeId = 2,
                    TaskId = 13333,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 113,
                    EmployeeId = 3,
                    TaskId = 14444,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 114,
                    EmployeeId = 3,
                    TaskId = 15555,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 115,
                    EmployeeId = 3,
                    TaskId = 16666,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 116,
                    EmployeeId = 3,
                    TaskId = 17777,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 117,
                    EmployeeId = 3,
                    TaskId = 18888,
                    Picked = false,
                });

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 118,
                    EmployeeId = 3,
                    TaskId = 19999,
                    Picked = false,
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

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 5,
                   TaskId = 990,
                   QualificationId = 1111,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 6,
                   TaskId = 990,
                   QualificationId = 2222,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 7,
                   TaskId = 990,
                   QualificationId = 3333,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 8,
                   TaskId = 990,
                   QualificationId = 4444,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 9,
                   TaskId = 991,
                   QualificationId = 1111,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 10,
                   TaskId = 991,
                   QualificationId = 2222,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 11,
                   TaskId = 991,
                   QualificationId = 3333,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 12,
                   TaskId = 991,
                   QualificationId = 4444,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 13,
                   TaskId = 992,
                   QualificationId = 1111,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 14,
                   TaskId = 992,
                   QualificationId = 2222,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 15,
                   TaskId = 993,
                   QualificationId = 3333,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 16,
                   TaskId = 993,
                   QualificationId = 4444,
               });

            modelBuilder.Entity<TaskQualification>().HasData(
               new TaskQualification
               {
                   Id = 17,
                   TaskId = 994,
                   QualificationId = 2222,
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

            #region Test: LoadProjectFeedData

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1000,
                    Firstname = "Testamon",
                    Lastname = "Testa",
                    Birthdate = new DateTime(1996, 5, 27),
                    HiringDate = new DateTime(2010, 12, 24),
                    Phonenumber = "0000000000",
                    Residence = "Wels",
                    StreetNameAndNr = "Manstreet",
                    ZipCode = "4540",
                    Status = EmployeeStatusType.Beschäftigt,
                    Job = "Software Developer",
                    DepartmentId = 1,
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1000,
                    ProjectName = "Testakulär",
                    Status = ProjectStatusType.Laufend,
                    Startdate = new DateTime(2015, 10, 30, 14, 30, 0),
                    Deadline = new DateTime(9999, 10, 30, 15, 30, 0),
                    ValuedTime = null,
                    Information = "This project contains all tasks who can't be added to a specified project",
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 1000,
                    EmployeeId = 1000,
                    ProjectId = 1000,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 1100,
                    EmployeeId = 1000,
                    ProjectId = 6969,
                    Projectmanager = false,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 1000,
                    ProjectId = 1000,
                    FixedTask = false,
                    TaskName = "FeedTest1",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2030, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 1100,
                    ProjectId = 1000,
                    FixedTask = false,
                    TaskName = "FeedTest2",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2030, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 1110,
                    ProjectId = 1000,
                    FixedTask = false,
                    TaskName = "FeedTest3",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2030, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Mittel,
                });

            //GeneralTaskTest
            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    Id = 2000,
                    ProjectId = 6969,
                    FixedTask = false,
                    TaskName = "GeneralFeedTest3",
                    Status = TaskStatusType.NichtBegonnen,
                    Information = "Task",
                    ValuedTime = "400",
                    Deadline = new DateTime(2010, 10, 30, 15, 30, 0),
                    Enddate = null,
                    Created = new DateTime(2010, 10, 30, 15, 30, 0),
                    Priority = PriorityType.Hoch,
                });

            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = 1000,
                    QualificationName = "Testy",
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 1000,
                    QualificationId = 1000,
                    EmployeeId = 1000,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Sehrgut,
                });

            modelBuilder.Entity<TaskQualification>().HasData(
                new TaskQualification
                {
                    Id = 1000,
                    TaskId = 1000,
                    QualificationId = 1000,
                });

            modelBuilder.Entity<TaskQualification>().HasData(
                new TaskQualification
                {
                    Id = 1001,
                    TaskId = 1100,
                    QualificationId = 1000,
                });

            modelBuilder.Entity<TaskQualification>().HasData(
                new TaskQualification
                {
                    Id = 1011,
                    TaskId = 1110,
                    QualificationId = 1000,
                });

            modelBuilder.Entity<TaskQualification>().HasData(
                new TaskQualification
                {
                    Id = 2000,
                    TaskId = 2000,
                    QualificationId = 1000,
                });

            //Zuweisungstest
            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    Id = 1000,
                    EmployeeId = 1000,
                    TaskId = 1000,
                    Picked = false,
                });

            //Test für Tasks die anderen zugeteilten wurden
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 2000,
                    Firstname = "Testine",
                    Lastname = "Testakulär",
                    Birthdate = new DateTime(1997, 6, 12),
                    HiringDate = new DateTime(2012, 10, 19),
                    Phonenumber = "066498234435",
                    Residence = "Wels",
                    StreetNameAndNr = "Testreet",
                    ZipCode = "8998",
                    Status = EmployeeStatusType.Beschäftigt,
                    Job = "Software Developer",
                    DepartmentId = 1,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 2000,
                    EmployeeId = 2000,
                    ProjectId = 1000,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id = 2200,
                    EmployeeId = 2000,
                    ProjectId = 6969,
                    Projectmanager = false,
                });

            modelBuilder.Entity<EmployeeQualification>().HasData(
                new EmployeeQualification
                {
                    Id = 2000,
                    QualificationId = 1000,
                    EmployeeId = 2000,
                    Information = "Test",
                    SkillLevel = SkillLevelType.Sehrgut,
                });

            #endregion
        }
    }
}
