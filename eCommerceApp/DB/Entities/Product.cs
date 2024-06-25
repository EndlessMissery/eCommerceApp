using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.DB.Entities;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [MaxLength(255)]
    public string? Description { get; set; }
    
    public decimal Price { get; set; }
    
    public int Stock { get; set; }
    
    [NotMapped]
    public bool IsActive => Stock > 0;
}