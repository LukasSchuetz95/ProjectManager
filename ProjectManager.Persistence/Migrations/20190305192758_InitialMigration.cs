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
                    Startdate = table.Column<DateTime>(nullable: false),
                    Enddate = table.Column<DateTime>(nullable: false),
                    ValuedTime = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: false)
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
                    AppoName = table.Column<string>(nullable: false),
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
                    TaskId = table.Column<int>(nullable: false)
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
                    { 2, "Wien", "Development", null }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Deadline", "Enddate", "Information", "ProjectName", "Startdate", "Status", "Timestamp", "ValuedTime" },
                values: new object[,]
                {
                    { 1246, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Diplomarbeit", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, null, "500" },
                    { 2426, new DateTime(2022, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Project1", new DateTime(2021, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, null, "500" },
                    { 3246, new DateTime(2024, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Project2", new DateTime(2023, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 0, null, "500" },
                    { 42456, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Project3", new DateTime(2025, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, null, "500" }
                });

            migrationBuilder.InsertData(
                table: "Qualification",
                columns: new[] { "Id", "QualificationName", "Timestamp" },
                values: new object[,]
                {
                    { 1111, "Projekt Manager", null },
                    { 2222, "CSharp", null },
                    { 3333, "Html", null },
                    { 4444, "Pflichtenheft", null }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Birthdate", "DepartmentId", "Firstname", "HiringDate", "Job", "Lastname", "Phonenumber", "Profilepicture", "Residence", "Status", "StreetNameAndNr", "Timestamp", "ZipCode" },
                values: new object[,]
                {
                    { 112412, new DateTime(1995, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lukas", new DateTime(2011, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Schuetz", "0660/ 4878 299", null, "Bad Hall", 1, "Roemerstr. 41", null, "4540" },
                    { 2214, new DateTime(1994, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Thomas", new DateTime(2012, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web-Developer", "Baurnberger", "0660/ 4878 333", null, "Kematen am Innbach", 0, "See 44", null, "4633" },
                    { 3214, new DateTime(1990, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Manuel", new DateTime(2010, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Mairinger", "0660/ 4878 444", null, "Irgendwo", 2, "Weiss i ned", null, "Ka Ahnung" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Deadline", "Enddate", "FixedTask", "Information", "Priority", "ProjectId", "Startdate", "Status", "TaskName", "Timestamp", "ValuedTime" },
                values: new object[,]
                {
                    { 17777, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 42456, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test17", null, "400" },
                    { 16666, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 42456, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test16", null, "400" },
                    { 15555, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 3246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test15", null, "400" },
                    { 14444, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 3246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test14", null, "400" },
                    { 13333, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 3246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test13", null, "400" },
                    { 12222, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 3246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test12", null, "400" },
                    { 11111, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 3246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test11", null, "400" },
                    { 10000, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 2, 2426, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test10", null, "400" },
                    { 8888, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 2, 2426, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test8", null, "400" },
                    { 18888, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 42456, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test18", null, "400" },
                    { 7777, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2426, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test7", null, "400" },
                    { 6666, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2426, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test6", null, "400" },
                    { 5555, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test5", null, "400" },
                    { 4444, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test4", null, "400" },
                    { 3333, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test3", null, "400" },
                    { 2222, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test2", null, "400" },
                    { 1111, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Erster Task", 1, 1246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test1", null, "400" },
                    { 9999, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 2, 2426, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test9", null, "400" },
                    { 19999, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 42456, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test19", null, "400" }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "AppoName", "AppoType", "EmployeeId", "Enddate", "Information", "Startdate", "Timestamp" },
                values: new object[,]
                {
                    { 1214, "Arztbesuch", 1, 112412, new DateTime(2020, 10, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Muss zum Arzt", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 15426, "test13", 1, 3214, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 142456, "test12", 0, 3214, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 13246, "test11", 0, 3214, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 11246, "test9", 2, 3214, new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 1026246, "test8", 4, 2214, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 965747, "test7", 4, 2214, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 8246, "test6", 0, 2214, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 7246, "test5", 1, 2214, new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 64256, "test4", 2, 2214, new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 12246, "test10", 0, 3214, new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 224234, "Meeting", 3, 112412, new DateTime(2020, 10, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), "Habe ein Meeting", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 5246, "test3", 4, 112412, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 323423, "test1", 1, 112412, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 44356, "test2", 0, 112412, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProject",
                columns: new[] { "Id", "EmployeeId", "ProjectId", "Projectmanager", "Timestamp" },
                values: new object[,]
                {
                    { 4246, 112412, 42456, true, null },
                    { 3246, 112412, 3246, true, null },
                    { 2246, 112412, 2426, false, null },
                    { 1246, 112412, 1246, false, null },
                    { 5246, 2214, 1246, false, null },
                    { 6215, 2214, 2426, true, null },
                    { 71234, 2214, 3246, false, null },
                    { 9634, 3214, 2426, false, null },
                    { 83465, 3214, 1246, true, null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeQualification",
                columns: new[] { "Id", "EmployeeId", "Information", "QualificationId", "SkillLevel", "Timestamp" },
                values: new object[,]
                {
                    { 3333, 112412, "Test", 3333, 2, null },
                    { 9999, 3214, "Test", 4444, 0, null },
                    { 2222, 112412, "Test", 2222, 1, null },
                    { 8888, 3214, "Test", 3333, 2, null },
                    { 7777, 2214, "Test", 4444, 3, null },
                    { 6666, 2214, "Test", 3333, 1, null },
                    { 5555, 2214, "Test", 1111, 4, null },
                    { 1111, 112412, "Sehr guter Projekt Manager", 1111, 0, null },
                    { 4444, 112412, "Test", 4444, 3, null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTask",
                columns: new[] { "Id", "EmployeeId", "TaskId", "Timestamp" },
                values: new object[,]
                {
                    { 32534, 3214, 17777, null },
                    { 57868, 3214, 16666, null },
                    { 96767, 3214, 15555, null },
                    { 21434, 3214, 14444, null },
                    { 23532, 2214, 13333, null },
                    { 34543, 2214, 12222, null },
                    { 54664, 2214, 11111, null },
                    { 12433, 2214, 10000, null },
                    { 3435, 2214, 7777, null },
                    { 3445, 2214, 8888, null },
                    { 324556, 3214, 18888, null },
                    { 4567, 112412, 6666, null },
                    { 7475, 112412, 5555, null },
                    { 8678, 112412, 4444, null },
                    { 1435, 112412, 3333, null },
                    { 2242, 112412, 2222, null },
                    { 1968, 112412, 1111, null },
                    { 3254, 2214, 9999, null },
                    { 19324, 3214, 19999, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_EmployeeId",
                table: "Appointment",
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
