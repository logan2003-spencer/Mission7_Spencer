using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

// Class called Categories for the second table
public class Categories
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}