using System.ComponentModel.DataAnnotations;

namespace FranksRestaurant.Models
{
    /// <summary>
    /// Represents an administrator in the system. Contains properties for the admin's username and password,
    /// along with validation for required fields and string length.
    /// </summary>
    /// <author>Jacob Baker</author>
    /// <version>Fall 2025</version>
    public class Admin
    {
        /// <summary>
        /// Gets or sets the unique identifier for the administrator.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username for the administrator.
        /// </summary>
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username can't be longer than 50 characters.")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for the administrator.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters long.")]
        public string Password { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Admin"/> class.
        /// </summary>
        public Admin() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Admin"/> class with the specified username and password.
        /// </summary>
        /// <param name="username">The username of the administrator.</param>
        /// <param name="password">The password of the administrator.</param>
        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

}
