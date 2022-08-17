using ApiClientRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ApiClientRazor.Pages.Books
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Book book { get; set; } = default!;

        private string host = "https://localhost:44304";

        public async Task OnGetAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{host}/api/Books/{id}"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Book>(data)!;
                }
            }
        }

        public async Task<ActionResult> OnPostAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync($"{host}/api/Books/{book.Id}", book))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Book>(data)!;
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
