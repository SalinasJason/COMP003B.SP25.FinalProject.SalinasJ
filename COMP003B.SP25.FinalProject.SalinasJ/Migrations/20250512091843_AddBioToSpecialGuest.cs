using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.SP25.FinalProject.SalinasJ.Migrations
{
    /// <inheritdoc />
    public partial class AddBioToSpecialGuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "SpecialGuests",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "SpecialGuests");
        }
    }
}
