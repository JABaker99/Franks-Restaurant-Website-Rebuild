using FranksRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// The MenuController is responsible for managing the restaurant's menu, including displaying,
/// adding, editing, and deleting menu items. It handles the interaction between the menu data
/// and the views, with admin-level actions for menu management.
/// </summary>
/// <author>Jacob Baker</author>
/// <version>Fall 2025</version>
public class MenuController : Controller
{
    private readonly FranksDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuController"/> class.
    /// </summary>
    /// <param name="context">The database context used for accessing menu-related data.</param>
    public MenuController(FranksDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Displays the Index view of the menu, grouped by menu type, and checks if the user is an admin.
    /// </summary>
    /// <returns>The Index view with grouped menu items.</returns>
    [HttpGet]
    public IActionResult Index(string sortField = "Name", string sortDir = "asc", MenuType? sortGroup = null)
    {
        ViewBag.IsAdmin = HttpContext.Session.GetString("AdminLoggedIn") == "True";

        ViewData["SortField"] = sortField;
        ViewData["SortDir"] = sortDir;
        ViewData["SortGroup"] = sortGroup;

        var groupedMenuItems = _context.MenuItems
            .AsEnumerable()
            .GroupBy(m => m.MenuType)
            .ToList();

        return View(groupedMenuItems);
    }

    /// <summary>
    /// Deletes a menu item based on its ID and saves the changes to the database.
    /// </summary>
    /// <param name="id">The ID of the menu item to be deleted.</param>
    /// <returns>A redirect to the Index view after the item is deleted.</returns>
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var menuItem = _context.MenuItems.FirstOrDefault(m => m.Id == id);
        if (menuItem != null)
        {
            _context.MenuItems.Remove(menuItem);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    /// <summary>
    /// Displays the Add/Edit menu view, allowing admins to add or edit a menu item. 
    /// If an ID is provided, the existing menu item is loaded for editing.
    /// </summary>
    /// <param name="id">The ID of the menu item to be edited (optional).</param>
    /// <returns>The AddAndEdit view with a menu item for adding or editing.</returns>
    [HttpGet]
    public IActionResult AddAndEdit(int? id)
    {
        ViewBag.IsAdmin = HttpContext.Session.GetString("AdminLoggedIn") == "True";

        if (id == null)
        {
            ViewBag.MenuTypes = Enum.GetValues(typeof(MenuType)).Cast<MenuType>().ToList();
            return View(new MenuItem());
        }

        var menuItem = _context.MenuItems.FirstOrDefault(m => m.Id == id);
        if (menuItem == null)
        {
            return NotFound();
        }

        ViewBag.MenuTypes = Enum.GetValues(typeof(MenuType)).Cast<MenuType>().ToList();
        return View(menuItem);
    }

    /// <summary>
    /// Handles the post request for adding or editing a menu item. It validates the model and updates
    /// or adds the menu item in the database.
    /// </summary>
    /// <param name="menuItem">The menu item to be added or edited.</param>
    /// <returns>A redirect to the Index view if successful, or the AddAndEdit view with errors if validation fails.</returns>
    [HttpPost]
    public IActionResult AddAndEdit(MenuItem menuItem)
    {
        if (ModelState.IsValid)
        {
            if (!Enum.IsDefined(typeof(MenuType), menuItem.MenuType))
            {
                ModelState.AddModelError("MenuType", "Invalid menu type selected.");
                return View(menuItem);
            }

            if (menuItem.Id == 0)
            {
                _context.MenuItems.Add(menuItem);
            }
            else
            {
                _context.MenuItems.Update(menuItem);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(menuItem);
    }
}
