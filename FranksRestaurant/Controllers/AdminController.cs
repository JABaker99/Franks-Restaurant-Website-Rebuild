using FranksRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

/// <summary>
/// The AdminController is responsible for handling the administrative functionalities of the restaurant's website.
/// It includes actions for logging in and logging out an administrator, and it manages session states for admin access.
/// </summary>
/// <author>Jacob Baker</author>
/// <version>Fall 2025</version>
public class AdminController : Controller
{
    private readonly FranksDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="AdminController"/> class.
    /// </summary>
    /// <param name="context">The database context used for accessing the database.</param>
    public AdminController(FranksDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Displays the login view for administrators.
    /// </summary>
    /// <returns>The Login view.</returns>
    public IActionResult Login()
    {
        return View();
    }

    /// <summary>
    /// Handles the login process for an administrator.
    /// It verifies the provided username and password, and if valid, logs the admin into the session.
    /// </summary>
    /// <param name="username">The username of the administrator.</param>
    /// <param name="password">The password of the administrator.</param>
    /// <returns>A redirect to the Menu page if login is successful, or the Login view with an error message if invalid.</returns>
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var admin = _context.Admins.FirstOrDefault(a => a.Username == username && a.Password == password);

        if (admin != null)
        {
            HttpContext.Session.SetString("AdminLoggedIn", "True");
            return RedirectToAction("Index", "Menu");
        }

        ViewBag.ErrorMessage = "Invalid username or password.";
        return View();
    }

    /// <summary>
    /// Logs the administrator out by removing the admin session and redirecting to the Menu page.
    /// </summary>
    /// <returns>A redirect to the Menu page after logging out.</returns>
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("AdminLoggedIn");
        return RedirectToAction("Index", "Menu");
    }
}