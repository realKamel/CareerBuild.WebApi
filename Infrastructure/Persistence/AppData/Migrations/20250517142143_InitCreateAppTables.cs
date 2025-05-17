using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.AppData.Migrations
{
    /// <inheritdoc />
    public partial class InitCreateAppTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAcquiredSkills",
                columns: table => new
                {
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AcquiredAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAcquiredSkills", x => x.UserEmail);
                });

            migrationBuilder.CreateTable(
                name: "UserAppliedJobs",
                columns: table => new
                {
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppliedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationStatusStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAppliedJobs", x => x.UserEmail);
                });

            migrationBuilder.CreateTable(
                name: "UserEnrolledTracks",
                columns: table => new
                {
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FinishedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    EnrollmentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEnrolledTracks", x => x.UserEmail);
                });

            migrationBuilder.CreateTable(
                name: "UserEnteredExams",
                columns: table => new
                {
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttemptCount = table.Column<int>(type: "int", nullable: false),
                    LastAttemptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEnteredExams", x => x.UserEmail);
                });

            migrationBuilder.CreateTable(
                name: "UserPassedPhases",
                columns: table => new
                {
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPassedPhases", x => x.UserEmail);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinSalary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MaxSalary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAppliedJobsUserEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.CheckConstraint("ensure_salary_Range_check", "[MaxSalary] >= [MinSalary]");
                    table.ForeignKey(
                        name: "FK_Jobs_UserAppliedJobs_UserAppliedJobsUserEmail",
                        column: x => x.UserAppliedJobsUserEmail,
                        principalTable: "UserAppliedJobs",
                        principalColumn: "UserEmail");
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedDuration = table.Column<TimeOnly>(type: "time", nullable: false),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEnrolledTracksUserEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_Tracks_UserEnrolledTracks_UserEnrolledTracksUserEmail",
                        column: x => x.UserEnrolledTracksUserEmail,
                        principalTable: "UserEnrolledTracks",
                        principalColumn: "UserEmail");
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassingScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExamScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    MaxAttemptCount = table.Column<int>(type: "int", nullable: false),
                    ExamLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEnteredExamsUserEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_UserEnteredExams_UserEnteredExamsUserEmail",
                        column: x => x.UserEnteredExamsUserEmail,
                        principalTable: "UserEnteredExams",
                        principalColumn: "UserEmail");
                });

            migrationBuilder.CreateTable(
                name: "TrackPrerequisites",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    PrerequisiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrerequisiteDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackPrerequisites", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_TrackPrerequisites_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedDuration = table.Column<TimeOnly>(type: "time", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    UserPassedPhasesUserEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phases_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phases_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phases_UserPassedPhases_UserPassedPhasesUserEmail",
                        column: x => x.UserPassedPhasesUserEmail,
                        principalTable: "UserPassedPhases",
                        principalColumn: "UserEmail");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeOnly>(type: "time", nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    UserAcquiredSkillsUserEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skills_UserAcquiredSkills_UserAcquiredSkillsUserEmail",
                        column: x => x.UserAcquiredSkillsUserEmail,
                        principalTable: "UserAcquiredSkills",
                        principalColumn: "UserEmail");
                });

            migrationBuilder.CreateTable(
                name: "JobRequiredSkills",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    RequiredProficiency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequiredSkills", x => new { x.JobId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobRequiredSkills_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobRequiredSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhaseProvidedSkills",
                columns: table => new
                {
                    PhaseId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    RecommendationReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhaseProvidedSkills", x => new { x.PhaseId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_PhaseProvidedSkills_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhaseProvidedSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_PhaseId",
                table: "Course",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_UserEnteredExamsUserEmail",
                table: "Exams",
                column: "UserEnteredExamsUserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequiredSkills_SkillId",
                table: "JobRequiredSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserAppliedJobsUserEmail",
                table: "Jobs",
                column: "UserAppliedJobsUserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseProvidedSkills_SkillId",
                table: "PhaseProvidedSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Phases_ExamId",
                table: "Phases",
                column: "ExamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phases_TrackId",
                table: "Phases",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Phases_UserPassedPhasesUserEmail",
                table: "Phases",
                column: "UserPassedPhasesUserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CourseID",
                table: "Skills",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ExamID",
                table: "Skills",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserAcquiredSkillsUserEmail",
                table: "Skills",
                column: "UserAcquiredSkillsUserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_UserEnrolledTracksUserEmail",
                table: "Tracks",
                column: "UserEnrolledTracksUserEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobRequiredSkills");

            migrationBuilder.DropTable(
                name: "PhaseProvidedSkills");

            migrationBuilder.DropTable(
                name: "TrackPrerequisites");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "UserAppliedJobs");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "UserAcquiredSkills");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "UserPassedPhases");

            migrationBuilder.DropTable(
                name: "UserEnteredExams");

            migrationBuilder.DropTable(
                name: "UserEnrolledTracks");
        }
    }
}
