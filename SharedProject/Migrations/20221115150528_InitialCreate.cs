using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SharedProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mortgages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoanAmount = table.Column<double>(type: "REAL", nullable: false),
                    InterestRate = table.Column<double>(type: "REAL", nullable: false),
                    LoanTerm = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mortgages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Mortgages",
                columns: new[] { "Id", "InterestRate", "LoanAmount", "LoanTerm" },
                values: new object[,]
                {
                    { 1, 6.0, 8000000.0, 30 },
                    { 2, 5.0, 4000000.0, 20 },
                    { 3, 4.0, 5000000.0, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mortgages");
        }
    }
}
