using System.ComponentModel.DataAnnotations;

namespace CrudAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
