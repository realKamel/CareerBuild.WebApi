using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.AppData.Migrations
{
    /// <inheritdoc />
    public partial class RemovePhaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Phases_PhaseId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_ExamsId",
                table: "UserExams");

            migrationBuilder.DropTable(
                name: "PhaseSkills");

            migrationBuilder.DropTable(
                name: "UserPhases");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropIndex(
                name: "IX_UserExams_UserEmail",
                table: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_Courses_PhaseId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "EstimatedDurationInHours",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "PhaseId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "ExamsId",
                table: "UserExams",
                newName: "ExamId");

            migrationBuilder.RenameIndex(
                name: "IX_UserExams_ExamsId",
                table: "UserExams",
                newName: "IX_UserExams_ExamId");

            migrationBuilder.RenameColumn(
                name: "PhaseId",
                table: "Exams",
                newName: "ExamOrderNumber");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "UserTracks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "UserSkills",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "UserJobs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastAttemptDate",
                table: "UserExams",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "FinishedAt",
                table: "UserExams",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProviderName",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiresAt",
                table: "Jobs",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseOrderInTrack",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CoverUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    FinishedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CertificateUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTracks_UserEmail_TrackId",
                table: "UserTracks",
                columns: new[] { "UserEmail", "TrackId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_UserEmail_SkillId",
                table: "UserSkills",
                columns: new[] { "UserEmail", "SkillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserJobs_UserEmail_JobId",
                table: "UserJobs",
                columns: new[] { "UserEmail", "JobId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserExams_UserEmail_ExamId",
                table: "UserExams",
                columns: new[] { "UserEmail", "ExamId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_TrackId",
                table: "Exams",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TrackId",
                table: "Courses",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserEmail_CourseId",
                table: "UserCourses",
                columns: new[] { "UserEmail", "CourseId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Tracks_TrackId",
                table: "Courses",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Tracks_TrackId",
                table: "Exams",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Exams_ExamId",
                table: "UserExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Tracks_TrackId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Tracks_TrackId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_ExamId",
                table: "UserExams");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserTracks_UserEmail_TrackId",
                table: "UserTracks");

            migrationBuilder.DropIndex(
                name: "IX_UserSkills_UserEmail_SkillId",
                table: "UserSkills");

            migrationBuilder.DropIndex(
                name: "IX_UserJobs_UserEmail_JobId",
                table: "UserJobs");

            migrationBuilder.DropIndex(
                name: "IX_UserExams_UserEmail_ExamId",
                table: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_TrackId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TrackId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ProviderName",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "CourseOrderInTrack",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CoverUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "ExamId",
                table: "UserExams",
                newName: "ExamsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserExams_ExamId",
                table: "UserExams",
                newName: "IX_UserExams_ExamsId");

            migrationBuilder.RenameColumn(
                name: "ExamOrderNumber",
                table: "Exams",
                newName: "PhaseId");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "UserTracks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "UserSkills",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "UserJobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAttemptDate",
                table: "UserExams",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishedAt",
                table: "UserExams",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedDurationInHours",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiresAt",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhaseId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Courses",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(type: "int", nullable: true),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EstimatedDurationInHours = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhaseSkills",
                columns: table => new
                {
                    PhaseId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    RecommendationReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhaseSkills", x => new { x.PhaseId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_PhaseSkills_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhaseSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPhases",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    PhaseId = table.Column<int>(type: "int", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhases", x => new { x.TrackId, x.PhaseId });
                    table.ForeignKey(
                        name: "FK_UserPhases_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPhases_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExams_UserEmail",
                table: "UserExams",
                column: "UserEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PhaseId",
                table: "Courses",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Phases_ExamId",
                table: "Phases",
                column: "ExamId",
                unique: true,
                filter: "[ExamId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Phases_TrackId",
                table: "Phases",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseSkills_SkillId",
                table: "PhaseSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhases_PhaseId",
                table: "UserPhases",
                column: "PhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Phases_PhaseId",
                table: "Courses",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Exams_ExamsId",
                table: "UserExams",
                column: "ExamsId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
