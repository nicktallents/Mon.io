﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using mon_io_app.DataLayer;
using System;

namespace monioapp.Migrations
{
    [DbContext(typeof(MonioContext))]
    [Migration("20180610231335_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("mon_io_app.Models.Budget", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Month");

                    b.Property<long?>("UserID")
                        .IsRequired();

                    b.Property<int>("Year");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Budget");
                });

            modelBuilder.Entity("mon_io_app.Models.Budget_ExpenseCategory", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("BudgetID");

                    b.Property<DateTime?>("DueDate");

                    b.Property<double>("InitialValue");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<long?>("OverflowExpenseCategoryToID");

                    b.Property<long?>("SavingsCategory_ChildID")
                        .IsRequired();

                    b.Property<bool>("Type");

                    b.HasKey("ID");

                    b.HasIndex("OverflowExpenseCategoryToID");

                    b.HasIndex("SavingsCategory_ChildID");

                    b.ToTable("Budget_ExpenseCategory");
                });

            modelBuilder.Entity("mon_io_app.Models.Budget_Income", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("BudgetID")
                        .IsRequired();

                    b.Property<bool>("IsTaxable")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<double>("Value");

                    b.HasKey("ID");

                    b.HasIndex("BudgetID");

                    b.ToTable("Budget_Income");
                });

            modelBuilder.Entity("mon_io_app.Models.Expense", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("Budget_ExpenseCategoryID")
                        .IsRequired();

                    b.Property<double>("Cost");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("Reason")
                        .HasMaxLength(45);

                    b.Property<DateTime>("TransactionDate");

                    b.HasKey("ID");

                    b.HasIndex("Budget_ExpenseCategoryID");

                    b.ToTable("Expense");
                });

            modelBuilder.Entity("mon_io_app.Models.Expense_Bill", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("Budget_ExpenseCategoryID")
                        .IsRequired();

                    b.Property<double>("Cost");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<DateTime>("TransactionDate");

                    b.HasKey("ID");

                    b.HasIndex("Budget_ExpenseCategoryID");

                    b.ToTable("Expense_Bill");
                });

            modelBuilder.Entity("mon_io_app.Models.SavingsCategory_BalanceTransfer", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<long?>("SavingsCategoryFromID")
                        .IsRequired();

                    b.Property<long?>("SavingsCategoryToID")
                        .IsRequired();

                    b.Property<DateTime>("TransactionDate");

                    b.Property<double>("Value");

                    b.HasKey("ID");

                    b.HasIndex("SavingsCategoryFromID");

                    b.HasIndex("SavingsCategoryToID");

                    b.ToTable("SavingsCategory_BalanceTransfer");
                });

            modelBuilder.Entity("mon_io_app.Models.SavingsCategory_Child", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Month");

                    b.Property<long?>("SavingsCategory_MainID")
                        .IsRequired();

                    b.Property<int>("Year");

                    b.HasKey("ID");

                    b.HasIndex("SavingsCategory_MainID");

                    b.ToTable("SavingsCategory_Child");
                });

            modelBuilder.Entity("mon_io_app.Models.SavingsCategory_Main", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<long?>("UserID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("SavingsCategory_Main");
                });

            modelBuilder.Entity("mon_io_app.Models.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("GoogleAccountID");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("mon_io_app.Models.Budget", b =>
                {
                    b.HasOne("mon_io_app.Models.User", "User")
                        .WithMany("Budgets")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("mon_io_app.Models.Budget_ExpenseCategory", b =>
                {
                    b.HasOne("mon_io_app.Models.Budget_ExpenseCategory", "OverflowExpenseCategoryTo")
                        .WithMany("OverflowExpenseCategoryFrom")
                        .HasForeignKey("OverflowExpenseCategoryToID");

                    b.HasOne("mon_io_app.Models.SavingsCategory_Child", "SavingsCategory_Child")
                        .WithMany("Budget_ExpenseCategories")
                        .HasForeignKey("SavingsCategory_ChildID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("mon_io_app.Models.Budget_Income", b =>
                {
                    b.HasOne("mon_io_app.Models.Budget", "Budget")
                        .WithMany("Budget_Incomes")
                        .HasForeignKey("BudgetID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("mon_io_app.Models.Expense", b =>
                {
                    b.HasOne("mon_io_app.Models.Budget_ExpenseCategory", "Budget_ExpenseCategory")
                        .WithMany("Expenses")
                        .HasForeignKey("Budget_ExpenseCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("mon_io_app.Models.Expense_Bill", b =>
                {
                    b.HasOne("mon_io_app.Models.Budget_ExpenseCategory", "Budget_ExpenseCategory")
                        .WithMany("Expense_Bills")
                        .HasForeignKey("Budget_ExpenseCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("mon_io_app.Models.SavingsCategory_BalanceTransfer", b =>
                {
                    b.HasOne("mon_io_app.Models.SavingsCategory_Main", "SavingsCategoryFrom")
                        .WithMany("BalanceTransfersSent")
                        .HasForeignKey("SavingsCategoryFromID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("mon_io_app.Models.SavingsCategory_Main", "SavingsCategoryTo")
                        .WithMany("BalanceTransfersReceived")
                        .HasForeignKey("SavingsCategoryToID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("mon_io_app.Models.SavingsCategory_Child", b =>
                {
                    b.HasOne("mon_io_app.Models.SavingsCategory_Main", "SavingsCategory_Main")
                        .WithMany("SavingsCategory_Children")
                        .HasForeignKey("SavingsCategory_MainID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("mon_io_app.Models.SavingsCategory_Main", b =>
                {
                    b.HasOne("mon_io_app.Models.User", "User")
                        .WithMany("SavingsCategories")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
