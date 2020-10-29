using Microsoft.EntityFrameworkCore.Migrations;

namespace ticketsDemo.Migrations
{
    public partial class addForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tickets_assigneeId",
                table: "tickets",
                column: "assigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_statusId",
                table: "tickets",
                column: "statusId");

            migrationBuilder.CreateIndex(
                name: "IX_tickets_submitterId",
                table: "tickets",
                column: "submitterId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_assigneeId",
                table: "comments",
                column: "assigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ticketID",
                table: "comments",
                column: "ticketID");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_assignee_assigneeId",
                table: "comments",
                column: "assigneeId",
                principalTable: "assignee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_tickets_ticketID",
                table: "comments",
                column: "ticketID",
                principalTable: "tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_assignee_assigneeId",
                table: "tickets",
                column: "assigneeId",
                principalTable: "assignee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_status_statusId",
                table: "tickets",
                column: "statusId",
                principalTable: "status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_submitter_1_submitterId",
                table: "tickets",
                column: "submitterId",
                principalTable: "submitter_1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_assignee_assigneeId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_tickets_ticketID",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_assignee_assigneeId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_status_statusId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_submitter_1_submitterId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_assigneeId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_statusId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_tickets_submitterId",
                table: "tickets");

            migrationBuilder.DropIndex(
                name: "IX_comments_assigneeId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_ticketID",
                table: "comments");
        }
    }
}
