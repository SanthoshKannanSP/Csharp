using task_10.Models;

namespace task_10.Services.Interfaces;

public interface IBookService
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task<Book> CreateBookAsync(Book book);
    Task<Book> UpdateBookAsync(Book book);
    Task<Book> DeleteBookAsync(int id);
}