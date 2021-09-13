using Microsoft.EntityFrameworkCore.Migrations;

namespace NLA.ODATA.EF.API.Migrations
{
    public partial class UniqueIndx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Email",
                table: "Authors",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_ISBN",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_Email",
                table: "Authors");
        }
    }
}
