using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

// This model is a form getting details from the user and get the property along with setting it
public class Form
{
    // The first one is a key for the database
    [Key]
    public int MovieId { get; set; }
    
    // The rest below are needed details for each movie added
    public int CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]

    public Categories? Categories { get; set; }
    [Required(ErrorMessage = "Please enter the name of the movie.")]
    public string Title { get; set; }
    

    [Range(1888, 2025,ErrorMessage = "Please enter a movie made between 1888 and 2025")]
    public string Year { get; set; }
    
    public string? Director { get; set; }

    
    public string? Rating { get; set; }
    
    // Edited, LentTo, and Notes are not required
    [Required(ErrorMessage = "Please enter if this movie has been edited or not.")]
    public bool Edited { get; set; }
    
    public string?  LentTo { get; set; }
    
    [Required(ErrorMessage = "Please enter if this movie has been copied to plex or not.")]

    public bool CopiedToPlex {get; set;}
    
    [StringLength(25)]
    public string?  Notes { get; set; }
    
    
    
    
}