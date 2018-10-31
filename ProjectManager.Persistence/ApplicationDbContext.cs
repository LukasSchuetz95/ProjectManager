using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectManager.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }

        public DbSet<EmployeeTask> EmployeeTasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<Core.Entities.Task> Tasks { get; set; }

        public DbSet<User> Users { get; set; }

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
                new Department{ Id = 1, DeptLocation = "Wels", DeptName = "Headquarter" });

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 2, DeptLocation = "Wien", DeptName = "Development" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Firstname = "Lukas",
                    Lastname = "Schuetz",
                    Birthdate = DateTime.Now,
                    Email = "lukas.schuetz1@gmail.com",
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
                    Email = "thomasbaurn@outlook.com",
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
                    Email = "mairinger-manuel@gmx.at",
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

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Admin = true,
                    EmployeeId = 1,
                    Password = "lukiluki",
                    PasswordCode = null,
                    UserName = "LSchuetz"
                });

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 2,
                   Admin = true,
                   EmployeeId = 2,
                   Password = "baumibaumi",
                   PasswordCode = null,
                   UserName = "TBaurnberger"
               });

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 3,
                   Admin = false,
                   EmployeeId = 3,
                   Password = "mairinger",
                   PasswordCode = null,
                   UserName = "MMairinger"
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






        }
    }
}
