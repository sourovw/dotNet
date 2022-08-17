using ApiClientRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ApiClientRazor.Pages.Books
{
    public class DetailsModel : PageModel
    {
        public Book book { get; set; } = default!;

        private string host = "https://localhost:44304";

        public async Task OnGetAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{host}/api/Books/{id}"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        book = JsonConvert.DeserializeObject<Book>(data)!;
                    }
                }
            }
        }
    }
}
