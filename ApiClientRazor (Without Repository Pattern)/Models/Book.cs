using System.ComponentModel.DataAnnotations;

namespace ApiClientRazor.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
    }
}
