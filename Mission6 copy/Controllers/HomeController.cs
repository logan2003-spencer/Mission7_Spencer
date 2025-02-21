using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;


namespace Mission6.Controllers;

public class HomeController : Controller
{
    private MovieFormContext _context;
    
    public HomeController(MovieFormContext temp) // Constructor
    {
        _context = temp;
    }
    // private readonly ILogger<HomeController> _logger;
    //
    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // This will request to get the information from the movie form
    [HttpGet]
    
    public IActionResult MovieForm()
    {
        return View();
    }
    
    // This will send the information to the database
    [HttpPost]
    public IActionResult MovieForm(Form response)
    {
        _context.Forms.Add(response); // Add record to the database 
        _context.SaveChanges();
        
        return View("Confirmation");
    }
    
}