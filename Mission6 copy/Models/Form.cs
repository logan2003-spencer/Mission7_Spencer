using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

// This model is a form getting details from the user and get the property along with setting it
public class Form
{
    // The first one is a key for the database
    [Key]
    
    public int MovieID { get; set; }
    
    // The rest below are needed details for each movie added
    [Required]
    public string Category { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Year { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public string Rating { get; set; }
    
    // Edited, LentTo, and Notes are not required
    public bool Edited { get; set; }
    
    public string LentTo { get; set; }
    
    [StringLength(25)]
    public string Notes { get; set; }
    
    
    
    
}