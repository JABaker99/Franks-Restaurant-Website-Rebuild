using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FranksRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MenuType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "password", "admin" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Cost", "Description", "MenuType", "Name" },
                values: new object[,]
                {
                    { 1, 7.99m, "Tequila, lime juice, triple sec", 0, "Margarita" },
                    { 2, 8.49m, "Whiskey, bitters, sugar, orange peel", 0, "Old Fashioned" },
                    { 3, 6.99m, "Vodka, tomato juice, spices", 0, "Bloody Mary" },
                    { 4, 7.49m, "Whiskey, lemon juice, simple syrup", 0, "Whiskey Sour" },
                    { 5, 8.99m, "Juicy beef burger", 1, "Cheeseburger" },
                    { 6, 7.99m, "Grilled chicken sandwich", 1, "Chicken Sandwich" },
                    { 7, 6.99m, "Bacon, Lettuce, and Tomato", 1, "BLT Sandwich" },
                    { 8, 9.49m, "Crispy fish with taco sauce", 1, "Fish Tacos" },
                    { 9, 19.99m, "Grilled ribeye with a side", 2, "Ribeye Steak" },
                    { 10, 13.99m, "Classic spaghetti with meat sauce", 2, "Spaghetti Bolognese" },
                    { 11, 18.99m, "Grilled salmon served with rice", 2, "Salmon Fillet" },
                    { 12, 14.99m, "Chicken topped with cheese & marinara", 2, "Chicken Parmesan" },
                    { 13, 2.99m, "Crispy golden fries", 3, "French Fries" },
                    { 14, 3.49m, "Crispy battered onion rings", 3, "Onion Rings" },
                    { 15, 4.99m, "Fresh mixed vegetables with dressing", 3, "Garden Salad" },
                    { 16, 3.49m, "Creamy mashed potatoes", 3, "Mashed Potatoes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
