using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class relateHostelAndStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HostelName",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "HostelID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_HostelID",
                table: "Students",
                column: "HostelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Hostels_HostelID",
                table: "Students",
                column: "HostelID",
                principalTable: "Hostels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Hostels_HostelID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_HostelID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "HostelID",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "HostelName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
