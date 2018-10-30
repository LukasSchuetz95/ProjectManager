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
        }
    }
}
