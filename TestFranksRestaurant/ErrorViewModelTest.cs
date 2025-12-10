using FranksRestaurant.Models;
using Xunit;

namespace TestFranksRestaurant
{
    /// <summary>
    /// Test class for the <see cref="ErrorViewModel"/> class.
    /// These tests validate the functionality of the <see cref="ShowRequestId"/> property and the constructor behavior.
    /// </summary>
    /// @Jacob Baker
    /// @Fall 2025
    public class ErrorViewModelTest
    {
        /// <summary>
        /// Test for <see cref="ErrorViewModel.ShowRequestId"/> when the <see cref="RequestId"/> is null.
        /// Verifies that <see cref="ShowRequestId"/> returns false when <see cref="RequestId"/> is null.
        /// </summary>
        [Fact]
        public void ShowRequestId_ShouldReturnFalse_WhenRequestIdIsNull()
        {
            var model = new ErrorViewModel { RequestId = null };

            var result = model.ShowRequestId;

            Assert.False(result);
        }

        /// <summary>
        /// Test for <see cref="ErrorViewModel.ShowRequestId"/> when the <see cref="RequestId"/> is an empty string.
        /// Verifies that <see cref="ShowRequestId"/> returns false when <see cref="RequestId"/> is empty.
        /// </summary>
        [Fact]
        public void ShowRequestId_ShouldReturnFalse_WhenRequestIdIsEmpty()
        {
            var model = new ErrorViewModel { RequestId = string.Empty };

            var result = model.ShowRequestId;

            Assert.False(result);
        }

        /// <summary>
        /// Test for <see cref="ErrorViewModel.ShowRequestId"/> when the <see cref="RequestId"/> is not empty.
        /// Verifies that <see cref="ShowRequestId"/> returns true when <see cref="RequestId"/> is not empty.
        /// </summary>
        [Fact]
        public void ShowRequestId_ShouldReturnTrue_WhenRequestIdIsNotEmpty()
        {
            var model = new ErrorViewModel { RequestId = "12345" };

            var result = model.ShowRequestId;

            Assert.True(result);
        }

        /// <summary>
        /// Test for <see cref="ErrorViewModel.ShowRequestId"/> when the constructor initializes the property with a non-null RequestId.
        /// Verifies that the constructor sets <see cref="ShowRequestId"/> to true when <see cref="RequestId"/> is not null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeShowRequestId_WhenRequestIdIsNotNull()
        {
            var model = new ErrorViewModel { RequestId = "SomeRequestId" };

            var result = model.ShowRequestId;

            Assert.True(result);
        }
    }
}