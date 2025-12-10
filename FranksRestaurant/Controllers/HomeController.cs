using System.Diagnostics;
using FranksRestaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace FranksRestaurant.Controllers
{
    /// <summary>
    /// The HomeController handles the main pages of the website, including the Index, About, and Gallery views.
    /// </summary>
    /// <author>Jacob Baker</author>
    /// <version>Fall 2025</version>
    public class HomeController : Controller
    {
        /// <summary>
        /// Displays the Index view of the website.
        /// </summary>
        /// <returns>The Index view.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Displays the About page of the website.
        /// </summary>
        /// <returns>The About view.</returns>
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Displays the Gallery page of the website.
        /// </summary>
        /// <returns>The Gallery view.</returns>
        [HttpGet]
        public IActionResult Gallery()
        {
            return View();
        }
    }
}
