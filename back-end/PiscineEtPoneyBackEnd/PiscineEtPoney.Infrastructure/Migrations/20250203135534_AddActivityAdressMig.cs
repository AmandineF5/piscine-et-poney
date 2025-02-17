using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiscineEtPoney.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityAdressMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Activities",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Activities");
        }
    }
}
