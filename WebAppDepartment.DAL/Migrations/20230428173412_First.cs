using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppDepartment.DAL.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Evaluation = table.Column<int>(type: "integer", nullable: false),
                    Budget = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSet_DepartmentSet_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DepartmentSet",
                columns: new[] { "Id", "Budget", "Evaluation", "Name" },
                values: new object[,]
                {
                    { 1, 27064.0, 4, "Prodction" },
                    { 2, 2706400.0, 5, "R&D" },
                    { 3, 270600.0, 3, "Prodction" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeSet",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "ali" },
                    { 2, 1, "mo" },
                    { 3, 2, "fo" },
                    { 4, 2, "to" },
                    { 5, 3, "do" },
                    { 6, 3, "lo" },
                    { 7, 3, "po" },
                    { 8, 1, "al" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSet_DepartmentId",
                table: "EmployeeSet",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSet");

            migrationBuilder.DropTable(
                name: "DepartmentSet");
        }
    }
}
