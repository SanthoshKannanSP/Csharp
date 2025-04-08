using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using task_10.Exceptions;
using task_10.Models;
using task_10.Repositories.Interfaces;
using task_10.Services.Classes;
using task_10.Services.Interfaces;
using Xunit;

namespace task_10.Tests;

public class BookServiceTests
{
    private IBookService _bookService;
    private IRepository<Book> _bookRepository;

    public BookServiceTests()
    {
        _bookRepository = A.Fake<IRepository<Book>>();
        var logger = A.Fake<ILogger<BookService>>();
        _bookService = new BookService(_bookRepository, logger);
    }
    
    [Fact]
    public async Task GetAllBooksAsync_Returns_Correct_Number_Of_Books()
    {
        var books = A.CollectionOfDummy<Book>(5).ToList();
        A.CallTo(() => _bookRepository.GetAllAsync()).Returns(Task.FromResult(books));

        var returnedBooks = await _bookService.GetAllBooksAsync();
        Assert.Equal(5, returnedBooks.Count);
    }

    [Fact]
    public async Task GetBookByIdAsync_ValidId_Returns_Correct_Book()
    {
        var book = new Book() { BookId = 1, Title = "Nine Perfect Strangers", Author = "Liane Moriarty" };
        A.CallTo(() => _bookRepository.GetByIdAsync(1)).Returns(Task.FromResult(book));
        
        var returnedBook = await _bookService.GetBookByIdAsync(1);
        Assert.NotNull(returnedBook);
        Assert.Equal(1, returnedBook.BookId);
        Assert.Equal("Nine Perfect Strangers", returnedBook.Title);
        Assert.Equal("Liane Moriarty", returnedBook.Author);
    }

    [Fact]
    public async Task GetBookByIdAsync_InvalidId_Throws_Resource_Not_Found_Exception()
    {
        A.CallTo(() => _bookRepository.GetByIdAsync(999)).Throws(new ResourceNotFoundException("Book", 999));
        
        await Assert.ThrowsAsync<ResourceNotFoundException>(() => _bookService.GetBookByIdAsync(999));
    }

    [Fact]
    public async Task CreateBookAsync_Returns_Correct_Book()
    {
        var book = new Book() { Title = "Nine Perfect Strangers", Author = "Liane Moriarty"};
        var createdBook = new Book() { BookId = 1, Title = "Nine Perfect Strangers", Author = "Liane Moriarty" };
        A.CallTo(() => _bookRepository.CreateAsync(book)).Returns(Task.FromResult(createdBook));
        
        var returnedBook = await _bookService.CreateBookAsync(book);
        Assert.NotNull(returnedBook);
        Assert.True(returnedBook.BookId > 0);
        Assert.Equal("Nine Perfect Strangers", returnedBook.Title);
        Assert.Equal("Liane Moriarty", returnedBook.Author);
    }

    [Fact]
    public async Task updateBookAsync_ValidId_Returns_Correct_Book()
    {
        var book = new Book() { BookId = 1, Title = "Nine Perfect Strangers", Author = "Liane Moriarty" };
        var updatedBook = new Book() { BookId = 1, Title = "I Saw Him Die", Author = "Andrew Wilson" };
        A.CallTo(() => _bookRepository.GetByIdAsync(1)).Returns(Task.FromResult(book));
        A.CallTo(() => _bookRepository.UpdateAsync(A<Book>._)).ReturnsLazily((Book b) => Task.FromResult(b));

        var returnedBook = await _bookService.UpdateBookAsync(updatedBook);
        Assert.NotNull(returnedBook);
        Assert.Equal(1, returnedBook.BookId);
        Assert.Equal("I Saw Him Die", returnedBook.Title);
        Assert.Equal("Andrew Wilson", returnedBook.Author);
    }
    
    [Fact]
    public async Task updateBookAsync_InvalidId_Throws_Resource_Not_Found_Exception()
    {
        var updatedBook = new Book() { BookId = 999, Title = "I Saw Him Die", Author = "Andrew Wilson" };
        A.CallTo(() => _bookRepository.GetByIdAsync(999)).Throws(new ResourceNotFoundException("Book", 999));
        
        await Assert.ThrowsAsync<ResourceNotFoundException>(() => _bookService.UpdateBookAsync(updatedBook));
    }

    [Fact]
    public async Task DeleteBookAsync_ValidId_Returns_Correct_Book()
    {
        var book = new Book() { BookId = 1, Title = "I Saw Him Die", Author = "Andrew Wilson" };
        A.CallTo(() => _bookRepository.GetByIdAsync(1)).Returns(Task.FromResult(book));
        A.CallTo(() => _bookRepository.DeleteAsync(book)).Returns(Task.FromResult(book));
        
        var returnedBook = await _bookService.DeleteBookAsync(1);
        Assert.NotNull(returnedBook);
        Assert.Equal(1, returnedBook.BookId);
        Assert.Equal("I Saw Him Die", returnedBook.Title);
        Assert.Equal("Andrew Wilson", returnedBook.Author);
    }
    
    [Fact]
    public async Task DeleteBookAsync_InvalidId_Throws_Resource_NotFound_Exception()
    {
        A.CallTo(() => _bookRepository.GetByIdAsync(999)).Throws(new ResourceNotFoundException("Book", 999));
        
        await Assert.ThrowsAsync<ResourceNotFoundException>(() => _bookService.DeleteBookAsync(999));
    }
}