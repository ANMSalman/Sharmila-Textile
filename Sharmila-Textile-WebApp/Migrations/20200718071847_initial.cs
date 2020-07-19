using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sharmila_Textile_WebApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BALANCE_SHEET",
                columns: table => new
                {
                    BALANCE_SHEET_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IN_HAND_CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IN_HAND_CHEQUE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BANK_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IN_HOLD = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BALANCE_SHEET", x => x.BALANCE_SHEET_ID);
                });

            migrationBuilder.CreateTable(
                name: "CHEQUE_STATUS",
                columns: table => new
                {
                    CHEQUE_STATUS_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATUS_NAME = table.Column<string>(type: "varchar(50)", nullable: true),
                    STATUS_TYPE = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHEQUE_STATUS", x => x.CHEQUE_STATUS_ID);
                });

            migrationBuilder.CreateTable(
                name: "RECIPIENT",
                columns: table => new
                {
                    RECIPIENT_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECIPIENT_TYPE = table.Column<string>(type: "varchar(70)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECIPIENT", x => x.RECIPIENT_ID);
                });

            migrationBuilder.CreateTable(
                name: "STAFF",
                columns: table => new
                {
                    STAFF_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STAFF_NAME = table.Column<string>(type: "varchar(50)", nullable: true),
                    NIC = table.Column<string>(type: "varchar(12)", nullable: true),
                    ADDRESS = table.Column<string>(type: "varchar(max)", nullable: true),
                    CONTACT_NO = table.Column<string>(type: "varchar(10)", nullable: true),
                    CURRENT_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STAFF", x => x.STAFF_ID);
                });

            migrationBuilder.CreateTable(
                name: "SUMMARY",
                columns: table => new
                {
                    SUMMARY_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BTT_BILLS = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    NORMAL_BILLS = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_COLLECTION = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ACCOUNTABLE_COLLECTION = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_PAYMENT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ACCOUNTABLE_PAYMENT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_EXPENSE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ACCOUNTABLE_EXPENSE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_BANK_DEPOSIT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ACCOUNTABLE_BANK_DEPOSIT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_CUSTOMER_ACCOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ACCOUNTABLE_CUSTOMER_ACCOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_SUPPLIER_ACCOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ACCOUNTABLE_SUPPLIER_ACCOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SUMMARY_TOTAL = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CASH_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CHEQUE_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DATE = table.Column<DateTime>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUMMARY", x => x.SUMMARY_ID);
                });

            migrationBuilder.CreateTable(
                name: "OWN_CHEQUE",
                columns: table => new
                {
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHEQUE_CODE = table.Column<string>(type: "varchar(50)", nullable: true),
                    BANK = table.Column<string>(type: "varchar(70)", nullable: true),
                    BRANCH = table.Column<string>(type: "varchar(70)", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    DUE_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWN_CHEQUE", x => x.OWN_CHEQUE_ID);
                    table.ForeignKey(
                        name: "FK_OWN_CHEQUE_CHEQUE_STATUS_STATUS",
                        column: x => x.STATUS,
                        principalTable: "CHEQUE_STATUS",
                        principalColumn: "CHEQUE_STATUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHEQUE_CODE = table.Column<string>(type: "varchar(50)", nullable: true),
                    BANK = table.Column<string>(type: "varchar(70)", nullable: true),
                    BRANCH = table.Column<string>(type: "varchar(70)", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    DUE_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<long>(nullable: false),
                    FROM = table.Column<string>(type: "varchar(70)", nullable: true),
                    FROM_REFERENCE_ID = table.Column<long>(nullable: true),
                    FROM_REFERENCE_NOTE = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THIRD_PARTY_CHEQUE", x => x.THIRD_PARTY_CHEQUE_ID);
                    table.ForeignKey(
                        name: "FK_THIRD_PARTY_CHEQUE_CHEQUE_STATUS_STATUS",
                        column: x => x.STATUS,
                        principalTable: "CHEQUE_STATUS",
                        principalColumn: "CHEQUE_STATUS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STAFF_ATTACHMENT",
                columns: table => new
                {
                    ATTACHMENT_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTACHMENT_NAME = table.Column<string>(type: "varchar(max)", nullable: true),
                    ATTACHMENT_PATH = table.Column<string>(type: "varchar(max)", nullable: true),
                    MIME_TYPE = table.Column<string>(type: "varchar(200)", nullable: true),
                    STAFF_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STAFF_ATTACHMENT", x => x.ATTACHMENT_ID);
                    table.ForeignKey(
                        name: "FK_STAFF_ATTACHMENT_STAFF_STAFF_ID",
                        column: x => x.STAFF_ID,
                        principalTable: "STAFF",
                        principalColumn: "STAFF_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USER_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "varchar(10)", nullable: true),
                    PASSWORD = table.Column<string>(type: "varchar(50)", nullable: true),
                    CURRENT_STATUS = table.Column<int>(type: "int", nullable: false),
                    STAFF_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_USER_STAFF_STAFF_ID",
                        column: x => x.STAFF_ID,
                        principalTable: "STAFF",
                        principalColumn: "STAFF_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BANK_DEPOSIT",
                columns: table => new
                {
                    BANK_DEPOSIT_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IN_HAND_CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DATE = table.Column<DateTime>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_DEPOSIT", x => x.BANK_DEPOSIT_ID);
                    table.ForeignKey(
                        name: "FK_BANK_DEPOSIT_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUSTOMER_NAME = table.Column<string>(type: "varchar(50)", nullable: true),
                    NIC = table.Column<string>(type: "nchar(10)", nullable: true),
                    HOME_ADDRESS = table.Column<string>(type: "varchar(max)", nullable: true),
                    HOME_LAND_LINE = table.Column<string>(type: "nchar(10)", nullable: true),
                    OFFICE_ADDRESS = table.Column<string>(type: "varchar(max)", nullable: true),
                    OFFICE_LAND_LINE = table.Column<string>(type: "nchar(10)", nullable: true),
                    MOBILE = table.Column<string>(type: "nchar(10)", nullable: true),
                    OPENING_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CURRENT_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    CURRENT_STATUS = table.Column<int>(type: "int", nullable: false),
                    LAST_COLLECTION_DATE = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.CUSTOMER_ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXPENSE",
                columns: table => new
                {
                    EXPENSE_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IN_HAND_CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CHEQUE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DATE = table.Column<DateTime>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    PAYMENT_TYPE = table.Column<string>(type: "varchar(50)", nullable: true),
                    CREATED_BY = table.Column<long>(nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSE", x => x.EXPENSE_ID);
                    table.ForeignKey(
                        name: "FK_EXPENSE_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OWN_CHEQUE_ACTION_LOG",
                columns: table => new
                {
                    OWN_CHEQUE_ACTION_LOG_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false),
                    REFERENCE_ID = table.Column<long>(nullable: true),
                    RECIPIENT_ID = table.Column<long>(nullable: true),
                    CHEQUE_STATUS_ID = table.Column<long>(nullable: true),
                    USER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OWN_CHEQUE_ACTION_LOG", x => x.OWN_CHEQUE_ACTION_LOG_ID);
                    table.ForeignKey(
                        name: "FK_OWN_CHEQUE_ACTION_LOG_CHEQUE_STATUS_CHEQUE_STATUS_ID",
                        column: x => x.CHEQUE_STATUS_ID,
                        principalTable: "CHEQUE_STATUS",
                        principalColumn: "CHEQUE_STATUS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OWN_CHEQUE_ACTION_LOG_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OWN_CHEQUE_ACTION_LOG_RECIPIENT_RECIPIENT_ID",
                        column: x => x.RECIPIENT_ID,
                        principalTable: "RECIPIENT",
                        principalColumn: "RECIPIENT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OWN_CHEQUE_ACTION_LOG_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER",
                columns: table => new
                {
                    SUPPLIER_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SUPPLIER_NAME = table.Column<string>(type: "varchar(50)", nullable: true),
                    ADDRESS = table.Column<string>(type: "varchar(max)", nullable: true),
                    LANDLINE = table.Column<string>(type: "nchar(10)", nullable: true),
                    MOBILE = table.Column<string>(type: "nchar(10)", nullable: true),
                    OPENING_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CURRENT_BALANCE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    CURRENT_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER", x => x.SUPPLIER_ID);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                columns: table => new
                {
                    THIRD_PARTY_CHEQUE_ACTION_LOG_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false),
                    REFERENCE_ID = table.Column<long>(nullable: true),
                    RECIPIENT_ID = table.Column<long>(nullable: true),
                    CHEQUE_STATUS_ID = table.Column<long>(nullable: true),
                    USER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THIRD_PARTY_CHEQUE_ACTION_LOG", x => x.THIRD_PARTY_CHEQUE_ACTION_LOG_ID);
                    table.ForeignKey(
                        name: "FK_THIRD_PARTY_CHEQUE_ACTION_LOG_CHEQUE_STATUS_CHEQUE_STATUS_ID",
                        column: x => x.CHEQUE_STATUS_ID,
                        principalTable: "CHEQUE_STATUS",
                        principalColumn: "CHEQUE_STATUS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_THIRD_PARTY_CHEQUE_ACTION_LOG_RECIPIENT_RECIPIENT_ID",
                        column: x => x.RECIPIENT_ID,
                        principalTable: "RECIPIENT",
                        principalColumn: "RECIPIENT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_THIRD_PARTY_CHEQUE_ACTION_LOG_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_THIRD_PARTY_CHEQUE_ACTION_LOG_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BANK_DEPOSIT_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    BANK_DEPOSIT_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK_DEPOSIT_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.BANK_DEPOSIT_ID });
                    table.ForeignKey(
                        name: "FK_BANK_DEPOSIT_THIRD_PARTY_CHEQUE_BANK_DEPOSIT_BANK_DEPOSIT_ID",
                        column: x => x.BANK_DEPOSIT_ID,
                        principalTable: "BANK_DEPOSIT",
                        principalColumn: "BANK_DEPOSIT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BANK_DEPOSIT_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COLLECTION",
                columns: table => new
                {
                    COLLECTION_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CHEQUE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RETURNS = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DATE = table.Column<DateTime>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    COLLECTION_TYPE = table.Column<long>(nullable: false),
                    CUSTOMER_ID = table.Column<long>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLLECTION", x => x.COLLECTION_ID);
                    table.ForeignKey(
                        name: "FK_COLLECTION_CHEQUE_STATUS_COLLECTION_TYPE",
                        column: x => x.COLLECTION_TYPE,
                        principalTable: "CHEQUE_STATUS",
                        principalColumn: "CHEQUE_STATUS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COLLECTION_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COLLECTION_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_ACCOUNT",
                columns: table => new
                {
                    CUSTOMER_ACCOUNTS_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IN_HAND_CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DATE = table.Column<DateTime>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    ACCOUNT_TYPE = table.Column<string>(nullable: true),
                    CUSTOMER_ID = table.Column<long>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_ACCOUNT", x => x.CUSTOMER_ACCOUNTS_ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_ATTACHMENT",
                columns: table => new
                {
                    ATTACHMENT_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTACHMENT_NAME = table.Column<string>(type: "varchar(max)", nullable: true),
                    ATTACHMENT_PATH = table.Column<string>(type: "varchar(max)", nullable: true),
                    MIME_TYPE = table.Column<string>(type: "varchar(200)", nullable: true),
                    CUSTOMER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_ATTACHMENT", x => x.ATTACHMENT_ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ATTACHMENT_CUSTOMER_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXPENSE_OWN_CHEQUE",
                columns: table => new
                {
                    EXPENSE_ID = table.Column<long>(nullable: false),
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSE_OWN_CHEQUE", x => new { x.OWN_CHEQUE_ID, x.EXPENSE_ID });
                    table.ForeignKey(
                        name: "FK_EXPENSE_OWN_CHEQUE_EXPENSE_EXPENSE_ID",
                        column: x => x.EXPENSE_ID,
                        principalTable: "EXPENSE",
                        principalColumn: "EXPENSE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EXPENSE_OWN_CHEQUE_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXPENSE_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    EXPENSE_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSE_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.EXPENSE_ID });
                    table.ForeignKey(
                        name: "FK_EXPENSE_THIRD_PARTY_CHEQUE_EXPENSE_EXPENSE_ID",
                        column: x => x.EXPENSE_ID,
                        principalTable: "EXPENSE",
                        principalColumn: "EXPENSE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EXPENSE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_ACCOUNT",
                columns: table => new
                {
                    SUPPLIER_ACCOUNTS_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    DATE = table.Column<DateTime>(nullable: false),
                    ACCOUNT_TYPE = table.Column<string>(nullable: true),
                    SUPPLIER_ID = table.Column<long>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_ACCOUNT", x => x.SUPPLIER_ACCOUNTS_ID);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_SUPPLIER_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "SUPPLIER",
                        principalColumn: "SUPPLIER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_ATTACHMENT",
                columns: table => new
                {
                    ATTACHMENT_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATTACHMENT_NAME = table.Column<string>(type: "varchar(max)", nullable: true),
                    ATTACHMENT_PATH = table.Column<string>(type: "varchar(max)", nullable: true),
                    MIME_TYPE = table.Column<string>(type: "varchar(200)", nullable: true),
                    SUPPLIER_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_ATTACHMENT", x => x.ATTACHMENT_ID);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ATTACHMENT_SUPPLIER_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "SUPPLIER",
                        principalColumn: "SUPPLIER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_PAYMENT",
                columns: table => new
                {
                    SUPPLIER_PAYMENT_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "varchar(100)", nullable: true),
                    CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IN_HAND_CASH = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CHEQUE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RETURNS = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PURCHASE = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DATE = table.Column<DateTime>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    PAYMENT_TYPE = table.Column<long>(nullable: false),
                    SUPPLIER_ID = table.Column<long>(nullable: false),
                    CREATED_BY = table.Column<long>(nullable: false),
                    REMARK = table.Column<string>(type: "varchar(100)", nullable: true),
                    STATUS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_PAYMENT", x => x.SUPPLIER_PAYMENT_ID);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_USER_CREATED_BY",
                        column: x => x.CREATED_BY,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_CHEQUE_STATUS_PAYMENT_TYPE",
                        column: x => x.PAYMENT_TYPE,
                        principalTable: "CHEQUE_STATUS",
                        principalColumn: "CHEQUE_STATUS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_SUPPLIER_SUPPLIER_ID",
                        column: x => x.SUPPLIER_ID,
                        principalTable: "SUPPLIER",
                        principalColumn: "SUPPLIER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COLLECTION_OWN_CHEQUE",
                columns: table => new
                {
                    COLLECTION_ID = table.Column<long>(nullable: false),
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLLECTION_OWN_CHEQUE", x => new { x.OWN_CHEQUE_ID, x.COLLECTION_ID });
                    table.ForeignKey(
                        name: "FK_COLLECTION_OWN_CHEQUE_COLLECTION_COLLECTION_ID",
                        column: x => x.COLLECTION_ID,
                        principalTable: "COLLECTION",
                        principalColumn: "COLLECTION_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COLLECTION_OWN_CHEQUE_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COLLECTION_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    COLLECTION_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLLECTION_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.COLLECTION_ID });
                    table.ForeignKey(
                        name: "FK_COLLECTION_THIRD_PARTY_CHEQUE_COLLECTION_COLLECTION_ID",
                        column: x => x.COLLECTION_ID,
                        principalTable: "COLLECTION",
                        principalColumn: "COLLECTION_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COLLECTION_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_ACCOUNT_OWN_CHEQUE",
                columns: table => new
                {
                    CUSTOMER_ACCOUNTS_ID = table.Column<long>(nullable: false),
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_ACCOUNT_OWN_CHEQUE", x => new { x.OWN_CHEQUE_ID, x.CUSTOMER_ACCOUNTS_ID });
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_OWN_CHEQUE_CUSTOMER_ACCOUNT_CUSTOMER_ACCOUNTS_ID",
                        column: x => x.CUSTOMER_ACCOUNTS_ID,
                        principalTable: "CUSTOMER_ACCOUNT",
                        principalColumn: "CUSTOMER_ACCOUNTS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_OWN_CHEQUE_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    CUSTOMER_ACCOUNTS_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.CUSTOMER_ACCOUNTS_ID });
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE_CUSTOMER_ACCOUNT_CUSTOMER_ACCOUNTS_ID",
                        column: x => x.CUSTOMER_ACCOUNTS_ID,
                        principalTable: "CUSTOMER_ACCOUNT",
                        principalColumn: "CUSTOMER_ACCOUNTS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_ACCOUNT_OWN_CHEQUE",
                columns: table => new
                {
                    SUPPLIER_ACCOUNTS_ID = table.Column<long>(nullable: false),
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_ACCOUNT_OWN_CHEQUE", x => new { x.OWN_CHEQUE_ID, x.SUPPLIER_ACCOUNTS_ID });
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_OWN_CHEQUE_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_OWN_CHEQUE_SUPPLIER_ACCOUNT_SUPPLIER_ACCOUNTS_ID",
                        column: x => x.SUPPLIER_ACCOUNTS_ID,
                        principalTable: "SUPPLIER_ACCOUNT",
                        principalColumn: "SUPPLIER_ACCOUNTS_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    SUPPLIER_ACCOUNTS_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.SUPPLIER_ACCOUNTS_ID });
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE_SUPPLIER_ACCOUNT_SUPPLIER_ACCOUNTS_ID",
                        column: x => x.SUPPLIER_ACCOUNTS_ID,
                        principalTable: "SUPPLIER_ACCOUNT",
                        principalColumn: "SUPPLIER_ACCOUNTS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_PAYMENT_OWN_CHEQUE",
                columns: table => new
                {
                    SUPPLIER_PAYMENT_ID = table.Column<long>(nullable: false),
                    OWN_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_PAYMENT_OWN_CHEQUE", x => new { x.OWN_CHEQUE_ID, x.SUPPLIER_PAYMENT_ID });
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_OWN_CHEQUE_OWN_CHEQUE_OWN_CHEQUE_ID",
                        column: x => x.OWN_CHEQUE_ID,
                        principalTable: "OWN_CHEQUE",
                        principalColumn: "OWN_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_OWN_CHEQUE_SUPPLIER_PAYMENT_SUPPLIER_PAYMENT_ID",
                        column: x => x.SUPPLIER_PAYMENT_ID,
                        principalTable: "SUPPLIER_PAYMENT",
                        principalColumn: "SUPPLIER_PAYMENT_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE",
                columns: table => new
                {
                    SUPPLIER_PAYMENT_ID = table.Column<long>(nullable: false),
                    THIRD_PARTY_CHEQUE_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE", x => new { x.THIRD_PARTY_CHEQUE_ID, x.SUPPLIER_PAYMENT_ID });
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE_SUPPLIER_PAYMENT_SUPPLIER_PAYMENT_ID",
                        column: x => x.SUPPLIER_PAYMENT_ID,
                        principalTable: "SUPPLIER_PAYMENT",
                        principalColumn: "SUPPLIER_PAYMENT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_THIRD_PARTY_CHEQUE_ID",
                        column: x => x.THIRD_PARTY_CHEQUE_ID,
                        principalTable: "THIRD_PARTY_CHEQUE",
                        principalColumn: "THIRD_PARTY_CHEQUE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BANK_DEPOSIT_CREATED_BY",
                table: "BANK_DEPOSIT",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_BANK_DEPOSIT_THIRD_PARTY_CHEQUE_BANK_DEPOSIT_ID",
                table: "BANK_DEPOSIT_THIRD_PARTY_CHEQUE",
                column: "BANK_DEPOSIT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COLLECTION_COLLECTION_TYPE",
                table: "COLLECTION",
                column: "COLLECTION_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_COLLECTION_CREATED_BY",
                table: "COLLECTION",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_COLLECTION_CUSTOMER_ID",
                table: "COLLECTION",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COLLECTION_OWN_CHEQUE_COLLECTION_ID",
                table: "COLLECTION_OWN_CHEQUE",
                column: "COLLECTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COLLECTION_THIRD_PARTY_CHEQUE_COLLECTION_ID",
                table: "COLLECTION_THIRD_PARTY_CHEQUE",
                column: "COLLECTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_CREATED_BY",
                table: "CUSTOMER",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ACCOUNT_CREATED_BY",
                table: "CUSTOMER_ACCOUNT",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ACCOUNT_CUSTOMER_ID",
                table: "CUSTOMER_ACCOUNT",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ACCOUNT_OWN_CHEQUE_CUSTOMER_ACCOUNTS_ID",
                table: "CUSTOMER_ACCOUNT_OWN_CHEQUE",
                column: "CUSTOMER_ACCOUNTS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE_CUSTOMER_ACCOUNTS_ID",
                table: "CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE",
                column: "CUSTOMER_ACCOUNTS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ATTACHMENT_CUSTOMER_ID",
                table: "CUSTOMER_ATTACHMENT",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXPENSE_CREATED_BY",
                table: "EXPENSE",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_EXPENSE_OWN_CHEQUE_EXPENSE_ID",
                table: "EXPENSE_OWN_CHEQUE",
                column: "EXPENSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXPENSE_THIRD_PARTY_CHEQUE_EXPENSE_ID",
                table: "EXPENSE_THIRD_PARTY_CHEQUE",
                column: "EXPENSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWN_CHEQUE_STATUS",
                table: "OWN_CHEQUE",
                column: "STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_OWN_CHEQUE_ACTION_LOG_CHEQUE_STATUS_ID",
                table: "OWN_CHEQUE_ACTION_LOG",
                column: "CHEQUE_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWN_CHEQUE_ACTION_LOG_OWN_CHEQUE_ID",
                table: "OWN_CHEQUE_ACTION_LOG",
                column: "OWN_CHEQUE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWN_CHEQUE_ACTION_LOG_RECIPIENT_ID",
                table: "OWN_CHEQUE_ACTION_LOG",
                column: "RECIPIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OWN_CHEQUE_ACTION_LOG_USER_ID",
                table: "OWN_CHEQUE_ACTION_LOG",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STAFF_ATTACHMENT_STAFF_ID",
                table: "STAFF_ATTACHMENT",
                column: "STAFF_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_CREATED_BY",
                table: "SUPPLIER",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_ACCOUNT_CREATED_BY",
                table: "SUPPLIER_ACCOUNT",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_ACCOUNT_SUPPLIER_ID",
                table: "SUPPLIER_ACCOUNT",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_ACCOUNT_OWN_CHEQUE_SUPPLIER_ACCOUNTS_ID",
                table: "SUPPLIER_ACCOUNT_OWN_CHEQUE",
                column: "SUPPLIER_ACCOUNTS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE_SUPPLIER_ACCOUNTS_ID",
                table: "SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE",
                column: "SUPPLIER_ACCOUNTS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_ATTACHMENT_SUPPLIER_ID",
                table: "SUPPLIER_ATTACHMENT",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_PAYMENT_CREATED_BY",
                table: "SUPPLIER_PAYMENT",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_PAYMENT_PAYMENT_TYPE",
                table: "SUPPLIER_PAYMENT",
                column: "PAYMENT_TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_PAYMENT_SUPPLIER_ID",
                table: "SUPPLIER_PAYMENT",
                column: "SUPPLIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_PAYMENT_OWN_CHEQUE_SUPPLIER_PAYMENT_ID",
                table: "SUPPLIER_PAYMENT_OWN_CHEQUE",
                column: "SUPPLIER_PAYMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE_SUPPLIER_PAYMENT_ID",
                table: "SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE",
                column: "SUPPLIER_PAYMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_THIRD_PARTY_CHEQUE_STATUS",
                table: "THIRD_PARTY_CHEQUE",
                column: "STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_THIRD_PARTY_CHEQUE_ACTION_LOG_CHEQUE_STATUS_ID",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                column: "CHEQUE_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_THIRD_PARTY_CHEQUE_ACTION_LOG_RECIPIENT_ID",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                column: "RECIPIENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_THIRD_PARTY_CHEQUE_ACTION_LOG_THIRD_PARTY_CHEQUE_ID",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                column: "THIRD_PARTY_CHEQUE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_THIRD_PARTY_CHEQUE_ACTION_LOG_USER_ID",
                table: "THIRD_PARTY_CHEQUE_ACTION_LOG",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_STAFF_ID",
                table: "USER",
                column: "STAFF_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BALANCE_SHEET");

            migrationBuilder.DropTable(
                name: "BANK_DEPOSIT_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "COLLECTION_OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "COLLECTION_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "CUSTOMER_ACCOUNT_OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "CUSTOMER_ACCOUNT_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "CUSTOMER_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "EXPENSE_OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "EXPENSE_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "OWN_CHEQUE_ACTION_LOG");

            migrationBuilder.DropTable(
                name: "STAFF_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SUMMARY");

            migrationBuilder.DropTable(
                name: "SUPPLIER_ACCOUNT_OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "SUPPLIER_ACCOUNT_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "SUPPLIER_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "SUPPLIER_PAYMENT_OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "SUPPLIER_PAYMENT_THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "THIRD_PARTY_CHEQUE_ACTION_LOG");

            migrationBuilder.DropTable(
                name: "BANK_DEPOSIT");

            migrationBuilder.DropTable(
                name: "COLLECTION");

            migrationBuilder.DropTable(
                name: "CUSTOMER_ACCOUNT");

            migrationBuilder.DropTable(
                name: "EXPENSE");

            migrationBuilder.DropTable(
                name: "SUPPLIER_ACCOUNT");

            migrationBuilder.DropTable(
                name: "OWN_CHEQUE");

            migrationBuilder.DropTable(
                name: "SUPPLIER_PAYMENT");

            migrationBuilder.DropTable(
                name: "RECIPIENT");

            migrationBuilder.DropTable(
                name: "THIRD_PARTY_CHEQUE");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "SUPPLIER");

            migrationBuilder.DropTable(
                name: "CHEQUE_STATUS");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "STAFF");
        }
    }
}
