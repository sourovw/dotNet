using ApiClientRazor.Models;
using ApiClientRazor.Repositories.Interfaces;
using Newtonsoft.Json;

namespace ApiClientRazor.Repositories.Services
{
    public class BooksRepository : IBooksRepository
    {
        private string host = "https://localhost:44304";

        // Index
        public async Task<IList<Book>> GetBooks()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{host}/api/Books"))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IList<Book>>(data)!;
                    return result;
                }
            }
        }

        // Create
        public async Task AddBook(Book book)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync($"{host}/api/Books", book))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<Book>(data);
                }
            }
        }

        // Details
        public async Task<Book> GetBook(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{host}/api/Books/{id}"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Book>(data)!;
                        return result;
                    }
                }
            }
            
            return null!;
        }

        // Update
        public async Task UpdateBook(Book book)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync($"{host}/api/Books/{book.Id}", book))
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<Book>(data);
                }
            }
        }

        // Delete
        public async Task DeleteBook(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"{host}/api/Books/{id}");
            }
        }
    }
}
