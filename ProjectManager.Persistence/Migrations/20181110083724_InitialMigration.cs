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
                name: "Departments",
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
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
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
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    QualificationName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Job = table.Column<string>(nullable: true),
                    Projectmanager = table.Column<bool>(nullable: false),
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
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
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
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
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
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeQualifications",
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
                    table.PrimaryKey("PK_EmployeeQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeQualifications_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTasks",
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
                    table.PrimaryKey("PK_EmployeeTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskQualifications",
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
                    table.PrimaryKey("PK_TaskQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskQualifications_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskQualifications_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptLocation", "DeptName", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Wels", "Headquarter", null },
                    { 2, "Wien", "Development", null }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Deadline", "Enddate", "Information", "ProjectName", "Startdate", "Status", "Timestamp", "ValuedTime" },
                values: new object[,]
                {
                    { 1246, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Diplomarbeit", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 0, null, "500" },
                    { 2426, new DateTime(2022, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Project1", new DateTime(2021, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, null, "500" },
                    { 3246, new DateTime(2024, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Project2", new DateTime(2023, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, null, "500" },
                    { 42456, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Project3", new DateTime(2025, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, null, "500" }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "QualificationName", "Timestamp" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 5, null },
                    { 3, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthdate", "DepartmentId", "Firstname", "HiringDate", "Job", "Lastname", "Phonenumber", "Profilepicture", "Projectmanager", "Residence", "Status", "StreetNameAndNr", "Timestamp", "ZipCode" },
                values: new object[,]
                {
                    { 112412, new DateTime(2018, 11, 10, 9, 37, 23, 775, DateTimeKind.Local), 1, "Lukas", new DateTime(2018, 11, 10, 9, 37, 23, 777, DateTimeKind.Local), "Software Developer", "Schuetz", "0660/ 4878 299", null, true, "Bad Hall", 1, "Roemerstr. 41", null, "4540" },
                    { 2214, new DateTime(2018, 11, 10, 9, 37, 23, 777, DateTimeKind.Local), 1, "Thomas", new DateTime(2018, 11, 10, 9, 37, 23, 777, DateTimeKind.Local), "Web-Developer", "Baurnberger", "0660/ 4878 333", null, false, "Kematen am Innbach", 0, "See 44", null, "4633" },
                    { 3214, new DateTime(2018, 11, 10, 9, 37, 23, 777, DateTimeKind.Local), 2, "Manuel", new DateTime(2018, 11, 10, 9, 37, 23, 777, DateTimeKind.Local), "Software Developer", "Mairinger", "0660/ 4878 444", null, true, "Irgendwo", 2, "Weiss i ned", null, "Ka Ahnung" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Deadline", "Enddate", "FixedTask", "Information", "Priority", "ProjectId", "Startdate", "Status", "TaskName", "Timestamp", "ValuedTime" },
                values: new object[,]
                {
                    { 17777, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 42456, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test17", null, "400" },
                    { 16666, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 42456, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test16", null, "400" },
                    { 15555, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 3246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test15", null, "400" },
                    { 14444, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 3246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test14", null, "400" },
                    { 13333, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 3246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test13", null, "400" },
                    { 12222, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 3246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test12", null, "400" },
                    { 11111, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 3246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test11", null, "400" },
                    { 10000, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2426, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test10", null, "400" },
                    { 8888, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2426, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test8", null, "400" },
                    { 18888, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 42456, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test18", null, "400" },
                    { 7777, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2426, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test7", null, "400" },
                    { 6666, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2426, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test6", null, "400" },
                    { 5555, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test5", null, "400" },
                    { 4444, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test4", null, "400" },
                    { 3333, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test3", null, "400" },
                    { 2222, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test2", null, "400" },
                    { 1111, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Erster Task", 1, 1246, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test1", null, "400" },
                    { 9999, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2426, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test9", null, "400" },
                    { 19999, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 42456, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test19", null, "400" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppoName", "AppoType", "EmployeeId", "Enddate", "Information", "Startdate", "Timestamp" },
                values: new object[,]
                {
                    { 1214, "Arztbesuch", 2, 112412, new DateTime(2020, 10, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Muss zum Arzt", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 142456, "test12", 0, 3214, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 13246, "test11", 0, 3214, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 12246, "test10", 0, 3214, new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 11246, "test9", 1, 3214, new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 1026246, "test8", 3, 2214, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 965747, "test7", 3, 2214, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 8246, "test6", 0, 2214, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 7246, "test5", 2, 2214, new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 15426, "test13", 2, 3214, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 224234, "Meeting", 1, 112412, new DateTime(2020, 10, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), "Habe ein Meeting", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 64256, "test4", 1, 2214, new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 323423, "test1", 2, 112412, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 44356, "test2", 0, 112412, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 5246, "test3", 3, 112412, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "Id", "EmployeeId", "ProjectId", "Timestamp" },
                values: new object[,]
                {
                    { 9634, 3214, 2426, null },
                    { 83465, 3214, 1246, null },
                    { 4246, 112412, 42456, null },
                    { 6215, 2214, 2426, null },
                    { 5246, 2214, 1246, null },
                    { 1246, 112412, 1246, null },
                    { 2246, 112412, 2426, null },
                    { 3246, 112412, 3246, null },
                    { 71234, 2214, 3246, null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTasks",
                columns: new[] { "Id", "EmployeeId", "TaskId", "Timestamp" },
                values: new object[,]
                {
                    { 54664, 2214, 11111, null },
                    { 32534, 3214, 17777, null },
                    { 57868, 3214, 16666, null },
                    { 96767, 3214, 15555, null },
                    { 21434, 3214, 14444, null },
                    { 23532, 2214, 13333, null },
                    { 34543, 2214, 12222, null },
                    { 12433, 2214, 10000, null },
                    { 1435, 112412, 3333, null },
                    { 3445, 2214, 8888, null },
                    { 3435, 2214, 7777, null },
                    { 4567, 112412, 6666, null },
                    { 7475, 112412, 5555, null },
                    { 8678, 112412, 4444, null },
                    { 2242, 112412, 2222, null },
                    { 1968, 112412, 1111, null },
                    { 324556, 3214, 18888, null },
                    { 3254, 2214, 9999, null },
                    { 19324, 3214, 19999, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_EmployeeId",
                table: "Appointments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_EmployeeId",
                table: "EmployeeProjects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_ProjectId",
                table: "EmployeeProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_EmployeeId",
                table: "EmployeeQualifications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeQualifications_QualificationId",
                table: "EmployeeQualifications",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_EmployeeId",
                table: "EmployeeTasks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_TaskId",
                table: "EmployeeTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskQualifications_QualificationId",
                table: "TaskQualifications",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskQualifications_TaskId",
                table: "TaskQualifications",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "EmployeeQualifications");

            migrationBuilder.DropTable(
                name: "EmployeeTasks");

            migrationBuilder.DropTable(
                name: "TaskQualifications");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
