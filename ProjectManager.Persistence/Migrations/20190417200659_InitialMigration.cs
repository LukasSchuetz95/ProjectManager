using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DeptLocation = table.Column<string>(nullable: false),
                    DeptName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ProjectName = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Startdate = table.Column<DateTime>(nullable: true),
                    Enddate = table.Column<DateTime>(nullable: true),
                    ValuedTime = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    QualificationName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Job = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Profilepicture = table.Column<byte[]>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    StreetNameAndNr = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Residence = table.Column<string>(nullable: true),
                    HiringDate = table.Column<DateTime>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    TaskName = table.Column<string>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FixedTask = table.Column<bool>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Enddate = table.Column<DateTime>(nullable: true),
                    ValuedTime = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    AppoName = table.Column<string>(nullable: true),
                    AppoType = table.Column<int>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    Startdate = table.Column<DateTime>(nullable: false),
                    Enddate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardDisplay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Startdatum = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Finished = table.Column<bool>(nullable: false),
                    SpecificInformation = table.Column<string>(nullable: true),
                    TaskId = table.Column<int>(nullable: false),
                    AppointmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardDisplay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardDisplay_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Projectmanager = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeQualification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    QualificationId = table.Column<int>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    SkillLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeQualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeQualification_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeQualification_Qualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    Picked = table.Column<bool>(nullable: false),
                    PassedTaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTask_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTask_Employee_PassedTaskId",
                        column: x => x.PassedTaskId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTask_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskQualification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TaskId = table.Column<int>(nullable: false),
                    QualificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskQualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskQualification_Qualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskQualification_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "DeptLocation", "DeptName", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Wels", "Headquarter", null },
                    { 2, "Wien", "Development", null },
                    { 3, "Linz", "Testdepartment", null },
                    { 4, "Salzburg", "Werbekompanie", null },
                    { 5, "Prag", "Labor", null }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Deadline", "Enddate", "Information", "ProjectName", "Startdate", "Status", "Timestamp", "ValuedTime" },
                values: new object[,]
                {
                    { 6969, new DateTime(9999, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "This project contains all tasks who can't be added to a specified project", "Allgemein", new DateTime(2015, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, null, null },
                    { 1246, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "This project needs love", "Diplomarbeit", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, null, "500" },
                    { 2426, new DateTime(2022, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "This project needs love", "Project1", new DateTime(2021, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, null, "500" },
                    { 3246, new DateTime(2024, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "This project needs love", "Project2", new DateTime(2023, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 0, null, "500" },
                    { 42456, new DateTime(2017, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "This project needs love", "Project3", new DateTime(2016, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "500" },
                    { 1000, new DateTime(9999, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "This project contains all tasks who can't be added to a specified project", "Testakulär", new DateTime(2015, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Qualification",
                columns: new[] { "Id", "QualificationName", "Timestamp" },
                values: new object[,]
                {
                    { 1111, "Project Manager", null },
                    { 2222, "CSharp", null },
                    { 3333, "Html", null },
                    { 4444, "Backend", null },
                    { 1000, "Testy", null }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Birthdate", "DepartmentId", "Firstname", "HiringDate", "Job", "Lastname", "Phonenumber", "Profilepicture", "Residence", "Status", "StreetNameAndNr", "Timestamp", "ZipCode" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lukas", new DateTime(2011, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Schuetz", "0660/ 4878 299", null, "Bad Hall", 1, "Roemerstr. 41", null, "4540" },
                    { 9, new DateTime(1993, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Raimond", new DateTime(2012, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Hoad", "90445343454", null, "Department 99", 0, "Brooklyn street", null, "Ka Ahnung" },
                    { 8, new DateTime(1993, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Rosa", new DateTime(2012, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Diaz", "90445343454", null, "Department 99", 0, "Brooklyn street", null, "Ka Ahnung" },
                    { 7, new DateTime(1993, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Amy", new DateTime(2012, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web-Developer", "Santiago", "90445343454", null, "Department 99", 1, "Brooklyn street", null, "Ka Ahnung" },
                    { 10, new DateTime(1990, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Todd", new DateTime(2010, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Sharvez", "0660/ 4878 444", null, "Hollywoo", 1, "Beachstreet", null, "0000" },
                    { 5, new DateTime(1950, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Rick", new DateTime(2017, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web-Developer", "Sanchez", "039454646453", null, "Interdimensional", 0, "streetytreetstreet", null, "Ka Ahnung" },
                    { 6, new DateTime(1990, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Jack", new DateTime(2017, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web-Developer", "Peralta", "6784352363465", null, "Department 99", 2, "Brooklyn street", null, "Ka Ahnung" },
                    { 3, new DateTime(1990, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Manuel", new DateTime(2010, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Mairinger", "0660/ 4878 444", null, "Irgendwo", 2, "Weiss i ned", null, "Ka Ahnung" },
                    { 2000, new DateTime(1997, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Testine", new DateTime(2012, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Testakulär", "066498234435", null, "Wels", 0, "Testreet", null, "8998" },
                    { 1000, new DateTime(1996, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Testamon", new DateTime(2010, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Testa", "0000000000", null, "Wels", 0, "Manstreet", null, "4540" },
                    { 2, new DateTime(1994, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Thomas", new DateTime(2012, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web-Developer", "Baurnberger", "0660/ 4878 333", null, "Kematen am Innbach", 0, "See 44", null, "4633" },
                    { 4, new DateTime(1960, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Bojack", new DateTime(2014, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Horseman", "0676/9876534", null, "Hollywoo", 0, "Beachstreet 5", null, "Ka Ahnung" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Created", "Deadline", "Enddate", "FixedTask", "Information", "Priority", "ProjectId", "Status", "TaskName", "Timestamp", "ValuedTime" },
                values: new object[,]
                {
                    { 13333, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 3246, 0, "Test13", null, "400" },
                    { 10000, new DateTime(2016, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 2, 2426, 2, "Test10", null, "400" },
                    { 11111, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 1, 3246, 0, "Test11", null, "400" },
                    { 12222, new DateTime(2016, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 3246, 2, "Test12", null, "400" },
                    { 14444, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 3246, 0, "Test14", null, "400" },
                    { 1000, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 1000, 0, "FeedTest1", null, "400" },
                    { 16666, new DateTime(2016, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 42456, 2, "Test16", null, "400" },
                    { 17777, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 42456, 0, "Test17", null, "400" },
                    { 18888, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 42456, 0, "Test18", null, "400" },
                    { 19999, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 42456, 0, "Test19", null, "400" },
                    { 9999, new DateTime(2016, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 2, 2426, 2, "Test9", null, "400" },
                    { 15555, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 3246, 0, "Test15", null, "400" },
                    { 8888, new DateTime(2016, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 2, 2426, 2, "Test8", null, "400" },
                    { 2222, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1246, 2, "Test2", null, "400" },
                    { 6666, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 1, 2426, 0, "Test6", null, "400" },
                    { 5555, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 1, 1246, 0, "Test5", null, "400" },
                    { 4444, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 1246, 0, "Test4", null, "400" },
                    { 3333, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 1246, 0, "Test3", null, "400" },
                    { 1100, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 1, 1000, 0, "FeedTest2", null, "400" },
                    { 1111, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Erster Task", 1, 1246, 0, "Test1", null, "400" },
                    { 2000, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 6969, 0, "GeneralFeedTest3", null, "400" },
                    { 994, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 6969, 0, "general5High", null, "400" },
                    { 993, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 6969, 0, "general4High", null, "400" },
                    { 992, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 1, 6969, 0, "General3medium", null, "400" },
                    { 991, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 1, 6969, 0, "General2Medium", null, "400" },
                    { 990, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 0, 6969, 0, "General1High", null, "400" },
                    { 7777, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 1, 2426, 0, "Test7", null, "400" },
                    { 1110, new DateTime(2010, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, false, "Task", 1, 1000, 0, "FeedTest3", null, "400" }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "AppoName", "AppoType", "EmployeeId", "Enddate", "Information", "Startdate", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Arztbesuch", 1, 1, new DateTime(2020, 10, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Muss zum Arzt", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "Meeting", 3, 1, new DateTime(2020, 10, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), "Habe ein Meeting", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "termin1", 1, 1, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "termin2", 0, 1, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, "termin3", 4, 1, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, "termin9", 2, 3, new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, "termin10", 0, 3, new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, "termin11", 0, 3, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, "termin12", 0, 3, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, "termin13", 1, 3, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, "termin8", 4, 2, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, "termin7", 4, 2, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, "termin6", 0, 2, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, "termin5", 1, 2, new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, "termin4", 2, 2, new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProject",
                columns: new[] { "Id", "EmployeeId", "ProjectId", "Projectmanager", "Timestamp" },
                values: new object[,]
                {
                    { 9634, 3, 2426, false, null },
                    { 2200, 2000, 6969, false, null },
                    { 3, 3, 6969, true, null },
                    { 4, 4, 6969, true, null },
                    { 5, 5, 6969, true, null },
                    { 6, 6, 6969, true, null },
                    { 7, 7, 6969, true, null },
                    { 8, 8, 6969, true, null },
                    { 9, 9, 6969, true, null },
                    { 83465, 3, 1246, true, null },
                    { 2000, 2000, 1000, false, null },
                    { 10, 10, 6969, true, null },
                    { 1, 1, 6969, true, null },
                    { 1000, 1000, 1000, false, null },
                    { 1246, 1, 1246, false, null },
                    { 2246, 1, 2426, false, null },
                    { 3246, 1, 3246, true, null },
                    { 2, 2, 6969, true, null },
                    { 71234, 2, 3246, false, null },
                    { 6215, 2, 2426, true, null },
                    { 5246, 2, 1246, false, null },
                    { 4246, 1, 42456, true, null },
                    { 1100, 1000, 6969, false, null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeQualification",
                columns: new[] { "Id", "EmployeeId", "Information", "QualificationId", "SkillLevel", "Timestamp" },
                values: new object[,]
                {
                    { 1111, 1, "Sehr guter Projekt Manager", 1111, 0, null },
                    { 9999, 3, "Test", 4444, 0, null },
                    { 1000, 1000, "Test", 1000, 0, null },
                    { 5555, 3, "Test", 1111, 4, null },
                    { 2222, 1, "Test", 2222, 1, null },
                    { 3333, 1, "Test", 3333, 2, null },
                    { 4444, 1, "Test", 4444, 3, null },
                    { 6666, 2, "Test", 3333, 1, null },
                    { 2000, 2000, "Test", 1000, 0, null },
                    { 7777, 2, "Test", 4444, 3, null },
                    { 8888, 3, "Test", 3333, 2, null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTask",
                columns: new[] { "Id", "EmployeeId", "PassedTaskId", "Picked", "TaskId", "Timestamp" },
                values: new object[,]
                {
                    { 111, 2, null, false, 12222, null },
                    { 100, 1, null, false, 1111, null },
                    { 101, 1, null, false, 2222, null },
                    { 102, 1, null, false, 3333, null },
                    { 106, 2, null, false, 7777, null },
                    { 104, 1, null, false, 5555, null },
                    { 105, 1, null, false, 6666, null },
                    { 107, 2, null, false, 8888, null },
                    { 108, 2, null, false, 9999, null },
                    { 103, 1, null, false, 4444, null },
                    { 112, 2, null, false, 13333, null },
                    { 110, 2, null, false, 11111, null },
                    { 114, 3, null, false, 15555, null },
                    { 115, 3, null, false, 16666, null },
                    { 116, 3, null, false, 17777, null },
                    { 117, 3, null, false, 18888, null },
                    { 118, 3, null, false, 19999, null },
                    { 109, 2, null, false, 10000, null },
                    { 1000, 1000, null, false, 1000, null },
                    { 113, 3, null, false, 14444, null }
                });

            migrationBuilder.InsertData(
                table: "TaskQualification",
                columns: new[] { "Id", "QualificationId", "TaskId", "Timestamp" },
                values: new object[,]
                {
                    { 4, 1111, 17777, null },
                    { 3, 1111, 18888, null },
                    { 1, 2222, 19999, null },
                    { 1000, 1000, 1000, null },
                    { 2, 1111, 19999, null },
                    { 14, 2222, 992, null },
                    { 17, 2222, 994, null },
                    { 16, 4444, 993, null },
                    { 15, 3333, 993, null },
                    { 13, 1111, 992, null },
                    { 12, 4444, 991, null },
                    { 11, 3333, 991, null },
                    { 10, 2222, 991, null },
                    { 9, 1111, 991, null },
                    { 8, 4444, 990, null },
                    { 7, 3333, 990, null },
                    { 6, 2222, 990, null },
                    { 5, 1111, 990, null },
                    { 1001, 1000, 1100, null },
                    { 2000, 1000, 2000, null },
                    { 1011, 1000, 1110, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_EmployeeId",
                table: "Appointment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardDisplay_EmployeeId",
                table: "DashboardDisplay",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_EmployeeId",
                table: "EmployeeProject",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectId",
                table: "EmployeeProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualification_EmployeeId",
                table: "EmployeeQualification",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualification_QualificationId",
                table: "EmployeeQualification",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_EmployeeId",
                table: "EmployeeTask",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_PassedTaskId",
                table: "EmployeeTask",
                column: "PassedTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_TaskId",
                table: "EmployeeTask",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ProjectId",
                table: "Task",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskQualification_QualificationId",
                table: "TaskQualification",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskQualification_TaskId",
                table: "TaskQualification",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "DashboardDisplay");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "EmployeeQualification");

            migrationBuilder.DropTable(
                name: "EmployeeTask");

            migrationBuilder.DropTable(
                name: "TaskQualification");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
