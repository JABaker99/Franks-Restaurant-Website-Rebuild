using System.ComponentModel.DataAnnotations;

namespace FranksRestaurant.Models
{
    /// <summary>
    /// Represents a menu item in the restaurant's menu. This class contains properties for the item’s name, type, description, and cost,
    /// along with validation for each field to ensure proper data integrity.
    /// </summary>
    /// <author>Jacob Baker</author>
    /// <version>Fall 2025</version>
    public class MenuItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the menu item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the menu item.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the menu item (e.g., Drink, Lunch, Dinner, or Side).
        /// </summary>
        [Required(ErrorMessage = "Menu type is required.")]
        [EnumDataType(typeof(MenuType), ErrorMessage = "Menu type must be one of the following: Drink, Lunch, Dinner, or Side.")]
        public MenuType MenuType { get; set; }

        /// <summary>
        /// Gets or sets the description of the menu item.
        /// </summary>
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the cost of the menu item.
        /// </summary>
        [Required(ErrorMessage = "Cost is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cost must be greater than 0.")]
        public decimal Cost { get; set; }
    }


}
