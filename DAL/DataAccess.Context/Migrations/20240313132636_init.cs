using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "matches",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Player1Id = table.Column<string>(type: "text", nullable: true),
                    Player2Id = table.Column<string>(type: "text", nullable: true),
                    Bid = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_matches_users_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_matches_users_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "gametransactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    MatchId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gametransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gametransactions_matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "matches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "matcheshistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    WinnerId = table.Column<string>(type: "text", nullable: true),
                    LosserId = table.Column<string>(type: "text", nullable: true),
                    TransactionsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matcheshistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_matcheshistories_gametransactions_TransactionsId",
                        column: x => x.TransactionsId,
                        principalTable: "gametransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_matcheshistories_users_LosserId",
                        column: x => x.LosserId,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_matcheshistories_users_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    SenderId = table.Column<string>(type: "text", nullable: true),
                    RecivierId = table.Column<string>(type: "text", nullable: true),
                    Ammount = table.Column<decimal>(type: "numeric", nullable: false),
                    TimeOfTransation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GameTransactionsId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_gametransactions_GameTransactionsId",
                        column: x => x.GameTransactionsId,
                        principalTable: "gametransactions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_users_RecivierId",
                        column: x => x.RecivierId,
                        principalTable: "users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_gametransactions_MatchId",
                table: "gametransactions",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_matches_Player1Id",
                table: "matches",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_matches_Player2Id",
                table: "matches",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_matcheshistories_LosserId",
                table: "matcheshistories",
                column: "LosserId");

            migrationBuilder.CreateIndex(
                name: "IX_matcheshistories_TransactionsId",
                table: "matcheshistories",
                column: "TransactionsId");

            migrationBuilder.CreateIndex(
                name: "IX_matcheshistories_WinnerId",
                table: "matcheshistories",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_GameTransactionsId",
                table: "transactions",
                column: "GameTransactionsId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_RecivierId",
                table: "transactions",
                column: "RecivierId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_SenderId",
                table: "transactions",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "matcheshistories");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "gametransactions");

            migrationBuilder.DropTable(
                name: "matches");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
