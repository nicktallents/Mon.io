﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace monioapp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    GoogleAccountID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    UserID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Budget_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingsCategory_Main",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    UserID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsCategory_Main", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SavingsCategory_Main_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budget_Income",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Value = table.Column<double>(nullable: false),
                    IsTaxable = table.Column<bool>(nullable: false, defaultValue: true),
                    BudgetID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget_Income", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Budget_Income_Budget_BudgetID",
                        column: x => x.BudgetID,
                        principalTable: "Budget",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingsCategory_BalanceTransfer",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    SavingsCategoryToID = table.Column<long>(nullable: false),
                    SavingsCategoryFromID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsCategory_BalanceTransfer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SavingsCategory_BalanceTransfer_SavingsCategory_Main_Savings~",
                        column: x => x.SavingsCategoryFromID,
                        principalTable: "SavingsCategory_Main",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavingsCategory_BalanceTransfer_SavingsCategory_Main_Saving~1",
                        column: x => x.SavingsCategoryToID,
                        principalTable: "SavingsCategory_Main",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingsCategory_Child",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    SavingsCategory_MainID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsCategory_Child", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SavingsCategory_Child_SavingsCategory_Main_SavingsCategory_M~",
                        column: x => x.SavingsCategory_MainID,
                        principalTable: "SavingsCategory_Main",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budget_ExpenseCategory",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BudgetID = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    InitialValue = table.Column<double>(nullable: false),
                    Type = table.Column<bool>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    SavingsCategory_ChildID = table.Column<long>(nullable: false),
                    OverflowExpenseCategoryToID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget_ExpenseCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Budget_ExpenseCategory_Budget_ExpenseCategory_OverflowExpens~",
                        column: x => x.OverflowExpenseCategoryToID,
                        principalTable: "Budget_ExpenseCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Budget_ExpenseCategory_SavingsCategory_Child_SavingsCategory~",
                        column: x => x.SavingsCategory_ChildID,
                        principalTable: "SavingsCategory_Child",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(maxLength: 45, nullable: false),
                    Reason = table.Column<string>(maxLength: 45, nullable: true),
                    Cost = table.Column<double>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Budget_ExpenseCategoryID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Expense_Budget_ExpenseCategory_Budget_ExpenseCategoryID",
                        column: x => x.Budget_ExpenseCategoryID,
                        principalTable: "Budget_ExpenseCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense_Bill",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<double>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Budget_ExpenseCategoryID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense_Bill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Expense_Bill_Budget_ExpenseCategory_Budget_ExpenseCategoryID",
                        column: x => x.Budget_ExpenseCategoryID,
                        principalTable: "Budget_ExpenseCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_UserID",
                table: "Budget",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_ExpenseCategory_OverflowExpenseCategoryToID",
                table: "Budget_ExpenseCategory",
                column: "OverflowExpenseCategoryToID");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_ExpenseCategory_SavingsCategory_ChildID",
                table: "Budget_ExpenseCategory",
                column: "SavingsCategory_ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_Income_BudgetID",
                table: "Budget_Income",
                column: "BudgetID");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_Budget_ExpenseCategoryID",
                table: "Expense",
                column: "Budget_ExpenseCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_Bill_Budget_ExpenseCategoryID",
                table: "Expense_Bill",
                column: "Budget_ExpenseCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsCategory_BalanceTransfer_SavingsCategoryFromID",
                table: "SavingsCategory_BalanceTransfer",
                column: "SavingsCategoryFromID");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsCategory_BalanceTransfer_SavingsCategoryToID",
                table: "SavingsCategory_BalanceTransfer",
                column: "SavingsCategoryToID");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsCategory_Child_SavingsCategory_MainID",
                table: "SavingsCategory_Child",
                column: "SavingsCategory_MainID");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsCategory_Main_UserID",
                table: "SavingsCategory_Main",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budget_Income");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "Expense_Bill");

            migrationBuilder.DropTable(
                name: "SavingsCategory_BalanceTransfer");

            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "Budget_ExpenseCategory");

            migrationBuilder.DropTable(
                name: "SavingsCategory_Child");

            migrationBuilder.DropTable(
                name: "SavingsCategory_Main");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
