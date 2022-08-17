using Microsoft.EntityFrameworkCore;
using CrudAPI.Models;

namespace CrudAPI.Data
{
    public class CrudAPIContext : DbContext
    {
        public CrudAPIContext(DbContextOptions<CrudAPIContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = default!;
    }
}
