using ApiClientRazor.Models;

namespace ApiClientRazor.Repositories.Interfaces
{
    public interface IBooksRepository
    {
        Task<IList<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}
