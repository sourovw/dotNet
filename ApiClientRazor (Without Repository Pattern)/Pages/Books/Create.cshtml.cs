using ApiClientRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ApiClientRazor.Pages.Books
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Book book { get; set; } = default!;

        private string host = "https://localhost:44304";

        public void OnGet() { }

        public async Task<ActionResult> OnPostAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync($"{host}/api/Books", book))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Book>(data)!;
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
