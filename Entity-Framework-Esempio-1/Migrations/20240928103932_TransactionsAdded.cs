using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework_Esempio_1.Migrations
{
    /// <inheritdoc />
    public partial class TransactionsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Subscriptions_TypeId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Transactions",
                newName: "SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TypeId",
                table: "Transactions",
                newName: "IX_Transactions_SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Subscriptions_SubscriptionId",
                table: "Transactions",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Subscriptions_SubscriptionId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "Transactions",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_SubscriptionId",
                table: "Transactions",
                newName: "IX_Transactions_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Subscriptions_TypeId",
                table: "Transactions",
                column: "TypeId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
