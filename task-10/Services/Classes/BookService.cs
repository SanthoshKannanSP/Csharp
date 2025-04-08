using task_10.Exceptions;
using task_10.Models;
using task_10.Repositories.Interfaces;
using task_10.Services.Interfaces;

namespace task_10.Services.Classes;

public class BookService : IBookService
{
    private IRepository<Book> _bookRepository;
    private ILogger<BookService> _logger;

    public BookService(IRepository<Book> bookRepository, ILogger<BookService> logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }
    
    public async Task<List<Book>> GetAllBooksAsync()
    {
        _logger.LogInformation("Fetching all books");
        return await _bookRepository.GetAllAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        _logger.LogInformation($"Fetching book with id {id}");
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
            throw new ResourceNotFoundException("Book",id);
        return book;
    }
    
    public async Task<Book> CreateBookAsync(Book book)
    {
        _logger.LogInformation("Creating new book");
        return await _bookRepository.CreateAsync(book);
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        _logger.LogInformation($"Updating book with id {book.BookId}");
        var existingBook = await _bookRepository.GetByIdAsync(book.BookId);
        if (existingBook == null)
            throw new ResourceNotFoundException("Book", book.BookId);
        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        return await _bookRepository.UpdateAsync(existingBook);
    }

    public async Task<Book> DeleteBookAsync(int id)
    {
        _logger.LogInformation($"Deleting book with id {id}");
        var existingBook = await _bookRepository.GetByIdAsync(id);
        if (existingBook == null)
            throw new ResourceNotFoundException("Book", id);
        return await _bookRepository.DeleteAsync(existingBook);
    }
}