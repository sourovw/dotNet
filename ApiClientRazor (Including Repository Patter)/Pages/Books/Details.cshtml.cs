using ApiClientRazor.Models;
using ApiClientRazor.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiClientRazor.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly IBooksRepository _service;

        public DetailsModel(IBooksRepository service)
        {
            _service = service;
        }

        public Book book { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            book = await _service.GetBook(id);
        }
    }
}
