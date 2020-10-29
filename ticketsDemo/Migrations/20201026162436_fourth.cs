using Microsoft.EntityFrameworkCore.Migrations;

namespace ticketsDemo.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_submitter",
                table: "submitter");

            migrationBuilder.RenameTable(
                name: "submitter",
                newName: "submitter_1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_submitter_1",
                table: "submitter_1",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_submitter_1",
                table: "submitter_1");

            migrationBuilder.RenameTable(
                name: "submitter_1",
                newName: "submitter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_submitter",
                table: "submitter",
                column: "Id");
        }
    }
}
