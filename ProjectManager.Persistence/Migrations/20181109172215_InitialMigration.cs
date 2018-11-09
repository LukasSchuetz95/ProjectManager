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
                    { 1, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Diplomarbeit", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 0, null, "500" },
                    { 2, new DateTime(2022, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Project1", new DateTime(2021, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, null, "500" },
                    { 3, new DateTime(2024, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Project2", new DateTime(2023, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 2, null, "500" },
                    { 4, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), null, "Dieses Projekt benötigt noch viel Zuneigung", "Project3", new DateTime(2025, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, null, "500" }
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
                    { 1, new DateTime(2018, 11, 9, 18, 22, 14, 625, DateTimeKind.Local), 1, "Lukas", new DateTime(2018, 11, 9, 18, 22, 14, 627, DateTimeKind.Local), "Software Developer", "Schuetz", "0660/ 4878 299", null, true, "Bad Hall", 1, "Roemerstr. 41", null, "4540" },
                    { 2, new DateTime(2018, 11, 9, 18, 22, 14, 627, DateTimeKind.Local), 1, "Thomas", new DateTime(2018, 11, 9, 18, 22, 14, 627, DateTimeKind.Local), "Database Developer", "Baurnberger", "0660/ 4878 333", null, false, "Kematen am Innbach", 0, "Weiss i ned", null, "Ka Ahnung" },
                    { 3, new DateTime(2018, 11, 9, 18, 22, 14, 627, DateTimeKind.Local), 2, "Manuel", new DateTime(2018, 11, 9, 18, 22, 14, 627, DateTimeKind.Local), "Software Developer", "Mairinger", "0660/ 4878 444", null, true, "Irgendwo", 2, "Weiss i ned", null, "Ka Ahnung" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Deadline", "Enddate", "FixedTask", "Information", "Priority", "ProjectId", "Startdate", "Status", "TaskName", "Timestamp", "ValuedTime" },
                values: new object[,]
                {
                    { 17, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 4, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test17", null, "400" },
                    { 16, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 4, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test16", null, "400" },
                    { 15, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 3, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test15", null, "400" },
                    { 14, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 3, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test14", null, "400" },
                    { 13, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 3, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test13", null, "400" },
                    { 12, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 3, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test12", null, "400" },
                    { 11, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 3, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test11", null, "400" },
                    { 10, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test10", null, "400" },
                    { 8, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test8", null, "400" },
                    { 18, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 4, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test18", null, "400" },
                    { 7, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test7", null, "400" },
                    { 6, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test6", null, "400" },
                    { 5, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test5", null, "400" },
                    { 4, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test4", null, "400" },
                    { 3, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 2, "Test3", null, "400" },
                    { 2, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 1, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, "Test2", null, "400" },
                    { 1, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Erster Task", 1, 1, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test1", null, "400" },
                    { 9, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 1, 2, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test9", null, "400" },
                    { 19, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), false, "Task", 0, 4, new DateTime(2026, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, "Test19", null, "400" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppoName", "AppoType", "EmployeeId", "Enddate", "Information", "Startdate", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Arztbesuch", 2, 1, new DateTime(2020, 10, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Muss zum Arzt", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, "test12", 0, 3, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, "test11", 0, 3, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, "test10", 0, 3, new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, "test9", 1, 3, new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, "test8", 3, 2, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, "test7", 3, 2, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, "test6", 0, 2, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, "test5", 2, 2, new DateTime(2020, 10, 30, 9, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, "test13", 2, 3, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "Meeting", 1, 1, new DateTime(2020, 10, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), "Habe ein Meeting", new DateTime(2020, 10, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, "test4", 1, 2, new DateTime(2020, 10, 30, 7, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 6, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "test1", 2, 1, new DateTime(2020, 10, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "test2", 0, 1, new DateTime(2020, 10, 30, 13, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 12, 30, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, "test3", 3, 1, new DateTime(2020, 10, 30, 15, 30, 0, 0, DateTimeKind.Unspecified), "Das ist ein Test", new DateTime(2020, 10, 30, 14, 30, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "Id", "EmployeeId", "ProjectId", "Timestamp" },
                values: new object[,]
                {
                    { 9, 3, 2, null },
                    { 8, 3, 1, null },
                    { 4, 1, 4, null },
                    { 6, 2, 2, null },
                    { 5, 2, 1, null },
                    { 1, 1, 1, null },
                    { 2, 1, 2, null },
                    { 3, 1, 3, null },
                    { 7, 2, 3, null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTasks",
                columns: new[] { "Id", "EmployeeId", "TaskId", "Timestamp" },
                values: new object[,]
                {
                    { 11, 2, 11, null },
                    { 17, 3, 17, null },
                    { 16, 3, 16, null },
                    { 15, 3, 15, null },
                    { 14, 3, 14, null },
                    { 13, 2, 13, null },
                    { 12, 2, 12, null },
                    { 10, 2, 10, null },
                    { 3, 1, 3, null },
                    { 8, 2, 8, null },
                    { 7, 2, 7, null },
                    { 6, 1, 6, null },
                    { 5, 1, 5, null },
                    { 4, 1, 4, null },
                    { 2, 1, 2, null },
                    { 1, 1, 1, null },
                    { 18, 3, 18, null },
                    { 9, 2, 9, null },
                    { 19, 3, 19, null }
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
