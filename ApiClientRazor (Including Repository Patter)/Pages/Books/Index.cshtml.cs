using ApiClientRazor.Models;
using ApiClientRazor.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiClientRazor.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly IBooksRepository _service;

        public IndexModel(IBooksRepository service)
        {
            _service = service;
        }

        public IList<Book> books { get; set; } = default!;

        public async Task OnGetAsync()
        {
            books = await _service.GetBooks();
        }
    }
}
