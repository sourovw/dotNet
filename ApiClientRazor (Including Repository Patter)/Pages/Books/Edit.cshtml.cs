using ApiClientRazor.Models;
using ApiClientRazor.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiClientRazor.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBooksRepository _service;

        public EditModel(IBooksRepository service)
        {
            _service = service;
        }

        [BindProperty]
        public Book book { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            book = await _service.GetBook(id);
        }

        public async Task<ActionResult> OnPostAsync()
        {
            await _service.UpdateBook(book);
            return RedirectToPage("./Index");
        }
    }
}
