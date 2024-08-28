using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadITAPI.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publisher_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher_Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.Publisher_Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    book_ISBN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Book_Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Book_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    copies = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    fk_Publisher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.book_ISBN);
                    table.ForeignKey(
                        name: "FK_books_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_publishers_fk_Publisher_id",
                        column: x => x.fk_Publisher_id,
                        principalTable: "publishers",
                        principalColumn: "Publisher_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    user_Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    state = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    postalcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fk_Publisher_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_publishers_fk_Publisher_id",
                        column: x => x.fk_Publisher_id,
                        principalTable: "publishers",
                        principalColumn: "Publisher_Id");
                });

            migrationBuilder.CreateTable(
                name: "Requstions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fk_book_ISBN = table.Column<int>(type: "int", nullable: false),
                    fk_Publisher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requstions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requstions_books_fk_book_ISBN",
                        column: x => x.fk_book_ISBN,
                        principalTable: "books",
                        principalColumn: "book_ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requstions_publishers_fk_Publisher_id",
                        column: x => x.fk_Publisher_id,
                        principalTable: "publishers",
                        principalColumn: "Publisher_Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_book_ISBN = table.Column<int>(type: "int", nullable: false),
                    Application_UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_Id);
                    table.ForeignKey(
                        name: "FK_orders_books_fk_book_ISBN",
                        column: x => x.fk_book_ISBN,
                        principalTable: "books",
                        principalColumn: "book_ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_users_Application_UserId",
                        column: x => x.Application_UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_book_ISBN = table.Column<int>(type: "int", nullable: false),
                    Application_UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_books_fk_book_ISBN",
                        column: x => x.fk_book_ISBN,
                        principalTable: "books",
                        principalColumn: "book_ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_users_Application_UserId",
                        column: x => x.Application_UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_category_id",
                table: "books",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_books_fk_Publisher_id",
                table: "books",
                column: "fk_Publisher_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Application_UserId",
                table: "orders",
                column: "Application_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_fk_book_ISBN",
                table: "orders",
                column: "fk_book_ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Requstions_fk_book_ISBN",
                table: "Requstions",
                column: "fk_book_ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Requstions_fk_Publisher_id",
                table: "Requstions",
                column: "fk_Publisher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Application_UserId",
                table: "Sales",
                column: "Application_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_fk_book_ISBN",
                table: "Sales",
                column: "fk_book_ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_users_fk_Publisher_id",
                table: "users",
                column: "fk_Publisher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "Requstions");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
