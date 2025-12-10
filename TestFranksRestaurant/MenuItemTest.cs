using FranksRestaurant.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace TestFranksRestaurant
{
    /// <summary>
    /// Unit tests for the <see cref="MenuItem"/> class to validate its data annotations and business logic.
    /// </summary>
    /// <author>Jacob Baker</author>
    /// <version>Fall 2025</version>
    public class MenuItemTest
    {
        /// <summary>
        /// Tests if the <see cref="MenuItem.Name"/> property is required and does not exceed the maximum length of 100 characters.
        /// </summary>
        [Fact]
        public void Name_ShouldBeRequired_AndMaxLength()
        {
            var menuItem = new MenuItem
            {
                Name = new string('A', 101),
                Description = "A delicious pizza",
                Cost = 12.99M,
                MenuType = MenuType.Drink
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(menuItem, null, null);
            var isValid = Validator.TryValidateObject(menuItem, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "Name can't be longer than 100 characters.");
        }

        /// <summary>
        /// Tests if an invalid <see cref="MenuType"/> value (not from the enum) causes a validation error.
        /// </summary>
        [Fact]
        public void MenuType_ShouldBeValidEnum()
        {
            var menuItem = new MenuItem
            {
                Name = "Pizza",
                Description = "A delicious pizza",
                Cost = 12.99M,
                MenuType = (MenuType)999
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(menuItem, null, null);
            var isValid = Validator.TryValidateObject(menuItem, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "Menu type must be one of the following: Drink, Lunch, Dinner, or Side.");
        }

        /// <summary>
        /// Tests that the <see cref="MenuItem.MenuType"/> property is valid when a valid <see cref="MenuType"/> enum value is provided.
        /// </summary>
        [Fact]
        public void MenuType_ShouldBeValidEnum_WhenValidValueIsProvided()
        {
            var menuItem = new MenuItem
            {
                Name = "Pizza",
                Description = "A delicious pizza",
                Cost = 12.99M,
                MenuType = MenuType.Dinner
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(menuItem, null, null);
            var isValid = Validator.TryValidateObject(menuItem, validationContext, validationResults, true);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        /// <summary>
        /// Tests if the <see cref="MenuItem.Description"/> property is required and does not exceed the maximum length of 500 characters.
        /// </summary>
        [Fact]
        public void Description_ShouldBeRequired_AndMaxLength()
        {
            var menuItem = new MenuItem
            {
                Name = "Pizza",
                Description = new string('A', 501),
                Cost = 12.99M,
                MenuType = MenuType.Drink
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(menuItem, null, null);
            var isValid = Validator.TryValidateObject(menuItem, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "Description can't be longer than 500 characters.");
        }

        /// <summary>
        /// Tests if the <see cref="MenuItem.Cost"/> property is required and that it must be greater than zero.
        /// </summary>
        [Fact]
        public void Cost_ShouldBeRequired_AndGreaterThanZero()
        {
            var menuItem = new MenuItem
            {
                Name = "Pizza",
                Description = "A delicious pizza",
                Cost = 0,
                MenuType = MenuType.Drink
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(menuItem, null, null);
            var isValid = Validator.TryValidateObject(menuItem, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "Cost must be greater than 0.");
        }

        /// <summary>
        /// Tests if the <see cref="MenuItem"/> model is valid when all required properties are properly set.
        /// </summary>
        [Fact]
        public void MenuItem_ShouldBeValid_WhenValidDataIsProvided()
        {
            var menuItem = new MenuItem
            {
                Name = "Pizza",
                Description = "A delicious pizza",
                Cost = 12.99M,
                MenuType = MenuType.Dinner
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(menuItem, null, null);
            var isValid = Validator.TryValidateObject(menuItem, validationContext, validationResults, true);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }
    }
}
