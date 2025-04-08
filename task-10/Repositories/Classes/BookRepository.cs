using Microsoft.EntityFrameworkCore;
using task_10.Models;
using task_10.Repositories.Interfaces;

namespace task_10.Repositories.Classes;

public class BookRepository : IRepository<Book>
{
    private AppDbContext _context;
    private DbSet<Book> _booksDb;

    public BookRepository(AppDbContext context)
    {
        _context = context;
        _booksDb = context.Set<Book>();
    }
    
    public async Task<List<Book>> GetAllAsync()
    {
        return await _booksDb.ToListAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return await _booksDb.FindAsync(id);
    }

    public async Task<Book> CreateAsync(Book book)
    {
        var createdBook = await _booksDb.AddAsync(book);
        await _context.SaveChangesAsync();
        return createdBook.Entity;
    }

    public async Task<Book> UpdateAsync(Book book)
    {
        _booksDb.Update(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> DeleteAsync(Book book)
    {
        _booksDb.Remove(book);
        await _context.SaveChangesAsync();
        return book;
    }
}