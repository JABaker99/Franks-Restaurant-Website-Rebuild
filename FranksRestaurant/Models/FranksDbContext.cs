using Microsoft.EntityFrameworkCore;

namespace FranksRestaurant.Models
{

    /// <summary>
    /// Represents the database context for the FranksRestaurant application, providing access to the database and 
    /// managing the entities, including MenuItems and Admins. It inherits from <see cref="DbContext"/> to handle 
    /// the database operations.
    /// </summary>
    /// <author>Jacob Baker</author>
    /// <version>Fall 2025</version>
    public class FranksDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FranksDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the database context.</param>
        public FranksDbContext(DbContextOptions<FranksDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the collection of menu items in the database.
        /// </summary>
        public DbSet<MenuItem> MenuItems { get; set; }

        /// <summary>
        /// Gets or sets the collection of administrators in the database.
        /// </summary>
        public DbSet<Admin> Admins { get; set; }

        /// <summary>
        /// Configures the model to seed the database with initial data, including predefined menu items and an admin.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the entity model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Username = "admin",
                    Password = "password"
                }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Margarita", MenuType = MenuType.Drink, Description = "Tequila, lime juice, triple sec", Cost = 7.99m },
                new MenuItem { Id = 2, Name = "Old Fashioned", MenuType = MenuType.Drink, Description = "Whiskey, bitters, sugar, orange peel", Cost = 8.49m },
                new MenuItem { Id = 3, Name = "Bloody Mary", MenuType = MenuType.Drink, Description = "Vodka, tomato juice, spices", Cost = 6.99m },
                new MenuItem { Id = 4, Name = "Whiskey Sour", MenuType = MenuType.Drink, Description = "Whiskey, lemon juice, simple syrup", Cost = 7.49m },

                new MenuItem { Id = 5, Name = "Cheeseburger", MenuType = MenuType.Lunch, Description = "Juicy beef burger", Cost = 8.99m },
                new MenuItem { Id = 6, Name = "Chicken Sandwich", MenuType = MenuType.Lunch, Description = "Grilled chicken sandwich", Cost = 7.99m },
                new MenuItem { Id = 7, Name = "BLT Sandwich", MenuType = MenuType.Lunch, Description = "Bacon, Lettuce, and Tomato", Cost = 6.99m },
                new MenuItem { Id = 8, Name = "Fish Tacos", MenuType = MenuType.Lunch, Description = "Crispy fish with taco sauce", Cost = 9.49m },

                new MenuItem { Id = 9, Name = "Ribeye Steak", MenuType = MenuType.Dinner, Description = "Grilled ribeye with a side", Cost = 19.99m },
                new MenuItem { Id = 10, Name = "Spaghetti Bolognese", MenuType = MenuType.Dinner, Description = "Classic spaghetti with meat sauce", Cost = 13.99m },
                new MenuItem { Id = 11, Name = "Salmon Fillet", MenuType = MenuType.Dinner, Description = "Grilled salmon served with rice", Cost = 18.99m },
                new MenuItem { Id = 12, Name = "Chicken Parmesan", MenuType = MenuType.Dinner, Description = "Chicken topped with cheese & marinara", Cost = 14.99m },

                new MenuItem { Id = 13, Name = "French Fries", MenuType = MenuType.Side, Description = "Crispy golden fries", Cost = 2.99m },
                new MenuItem { Id = 14, Name = "Onion Rings", MenuType = MenuType.Side, Description = "Crispy battered onion rings", Cost = 3.49m },
                new MenuItem { Id = 15, Name = "Garden Salad", MenuType = MenuType.Side, Description = "Fresh mixed vegetables with dressing", Cost = 4.99m },
                new MenuItem { Id = 16, Name = "Mashed Potatoes", MenuType = MenuType.Side, Description = "Creamy mashed potatoes", Cost = 3.49m }
            );
        }
    }
}
