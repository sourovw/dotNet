using ApiClientRazor.Models;
using ApiClientRazor.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiClientRazor.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly IBooksRepository _service;

        public CreateModel(IBooksRepository service)
        {
            _service = service;
        }

        [BindProperty]
        public Book book { get; set; } = default!;

        public void OnGet() { }

        public async Task<ActionResult> OnPostAsync()
        {
            await _service.AddBook(book);
            return RedirectToPage("./Index");
        }
    }
}
