using FranksRestaurant.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace TestFranksRestaurant
{
    /// <summary>
    /// Test the Admin model for validation and constructor functionality.
    /// </summary>
    /// 
    /// @author Jacob Baker
    /// @version Fall 2025
    public class AdminTest
    {
        /// <summary>
        /// Tests if the Admin constructor correctly initializes the Admin object with valid values.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeAdmin_WithValidValues()
        {
            var username = "adminUser";
            var password = "securePassword123";

            var admin = new Admin(username, password);

            Assert.Equal(username, admin.Username);
            Assert.Equal(password, admin.Password);
        }

        /// <summary>
        /// Tests that the Username property is required and validation fails when it's empty.
        /// </summary>
        [Fact]
        public void Username_ShouldBeRequired()
        {
            var admin = new Admin("", "ValidPassword123");

            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "Username is required.");
        }

        /// <summary>
        /// Tests that the Password property is required and validation fails when it's empty.
        /// </summary>
        [Fact]
        public void Password_ShouldBeRequired()
        {
            var admin = new Admin("validUser", "");

            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "Password is required.");
        }

        /// <summary>
        /// Tests that the Username property does not exceed the maximum length of 50 characters.
        /// </summary>
        [Fact]
        public void Username_ShouldNotExceed_MaxLength()
        {
            var username = new string('a', 51);
            var admin = new Admin(username, "ValidPassword123");

            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "Username can't be longer than 50 characters.");
        }

        /// <summary>
        /// Tests that the Password property has a minimum length of 6 characters.
        /// </summary>
        [Fact]
        public void Password_ShouldHave_MinLength_Of6()
        {
            var admin = new Admin("validUser", "short");

            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "Password should be at least 6 characters long.");
        }

        /// <summary>
        /// Tests that the Password property does not exceed the maximum length of 100 characters.
        /// </summary>
        [Fact]
        public void Password_ShouldNotExceed_MaxLength()
        {
            var password = new string('a', 101); 
            var admin = new Admin("validUser", password);

            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.ErrorMessage == "Password should be at least 6 characters long.");
        }

        /// <summary>
        /// Tests if the Admin object is valid when both the Username and Password are valid.
        /// </summary>
        [Fact]
        public void Admin_ShouldBeValid_WhenUsernameAndPasswordAreValid()
        {
            var admin = new Admin("validUser", "ValidPassword123");

            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }
    }
}
