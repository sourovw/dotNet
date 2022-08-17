using ApiClientRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ApiClientRazor.Pages.Books
{
    public class IndexModel : PageModel
    {
        public IList<Book> books { get; set; } = default!;

        private string host = "https://localhost:44304";

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{host}/api/Books"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<IList<Book>>(data)!;
                }
            }
        }
    }
}
