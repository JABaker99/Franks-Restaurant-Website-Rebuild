namespace FranksRestaurant.Models
{
    /// <summary>
    /// Represents the error view model used to pass error information to the view, including the request ID.
    /// </summary>
    /// <author>Jacob Baker</author>
    /// <version>Fall 2025</version>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the request, typically used for logging or tracking errors.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether the request ID should be displayed in the error view.
        /// </summary>
        /// <returns>True if the <see cref="RequestId"/> is not null or empty; otherwise, false.</returns>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
