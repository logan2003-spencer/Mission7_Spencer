using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;


namespace Mission6.Controllers;

public class HomeController : Controller
{
    private MovieFormContext _context;
    
    public HomeController(MovieFormContext temp) 
    {
        _context = temp;
    }

    
    // Route to the index page and passes the view
    public IActionResult Index()
    {
        return View(); 
    }

    // Route to the privacy view.
    public IActionResult Privacy()
    {
        return View();
    }

    // This will request to get the information from the movie form
    [HttpGet]
    public IActionResult MovieForm()
    {
        ViewBag.Categories = _context.Categories.ToList();
        return View("MovieForm", new Form());
    }
    
    // This will send the information to the database
    [HttpPost]
    
    public IActionResult MovieForm(Form response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); // Add the new movie with its category
            _context.SaveChanges();
        
            return RedirectToAction("Index"); // Redirect to the Index page
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(response);
        }
    

    


    }
    
    // Route to the WaitList view
    public IActionResult WaitList()
    {
        // Linq query, pulling from database in .net
        var movies = _context.Movies.Include(x => x.Categories).ToList();
        return View(movies);
    }

    
[HttpGet]

// Route to Edit the form
public IActionResult Edit(int formId)
{
    var recordToEdit = _context.Movies
        .Include(f => f.Categories)  // Ensure that Category is loaded, just in case it's needed for display
        .SingleOrDefault(x => x.MovieId == formId);

    if (recordToEdit == null)
    {
        return NotFound();  // Handle case when the form isn't found
    }

    ViewBag.Categories = _context.Categories.ToList();
    return View("MovieForm", recordToEdit);
}

[HttpPost]
public IActionResult Edit(Form updatedInfo)

    {
        _context.Update(updatedInfo);  
        _context.SaveChanges();  
        return RedirectToAction("WaitList");  
    }

public IActionResult Delete(int formId)
{
    var recordToDelete = _context.Movies
        .SingleOrDefault(x => x.MovieId == formId);

    if (recordToDelete == null)
    {
        return NotFound();  // If no record found, return 404 page
    }

    return View(recordToDelete);  // Pass the record to the view
}

[HttpPost]
public IActionResult Delete(Form form)
{
    _context.Movies.Remove(form);
    _context.SaveChanges();
    
    return RedirectToAction("WaitList");
}

}

