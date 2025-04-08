using Microsoft.EntityFrameworkCore;
using task_10.Models;

namespace task_10;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Book> BooksDb { get; set; }
}