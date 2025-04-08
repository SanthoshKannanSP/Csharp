using Microsoft.AspNetCore.Mvc;
using task_10.Exceptions;
using task_10.Models;
using task_10.Services.Interfaces;

namespace task_10.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : Controller
{
    private IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    /// <summary>
    /// Retrieves all books.
    /// </summary>
    /// <returns>List of Book objects.</returns>
    /// <response code="200">Returns the list of all books.</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<Book>),StatusCodes.Status200OK)]
    public async Task<ActionResult<Book>> GetAllBooks()
    {
        var allBooks = await _bookService.GetAllBooksAsync();
        return Ok(allBooks);
    }
    
    /// <summary>
    /// Retrieves a single book by its ID.
    /// </summary>
    /// <param name="id">The ID of the book to retrieve.</param>
    /// <returns>The Book object with the specified ID.</returns>
    /// <response code="200">Returns the book with specified ID, if found.</response>
    /// <response code="404">If book with ID is not found.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Book),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Book>> GetBookById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return Ok(book);
    }

    /// <summary>
    /// Adds a new book
    /// </summary>
    /// <param name="book">The book to be added</param>
    /// <returns>The newly created Book object.</returns>
    /// <response code="200">Returns the newly created book.</response>
    [HttpPost("/add")]
    [ProducesResponseType(typeof(Book),StatusCodes.Status200OK)]
    public async Task<ActionResult<Book>> AddBook(Book book)
    {
        var createdBook = await _bookService.CreateBookAsync(book);
        return Ok(createdBook);
    }

    /// <summary>
    /// Updates an existing book.
    /// </summary>
    /// <param name="book">Book with updated details (book with same ID is already present).</param>
    /// <returns>The updated Book object.</returns>
    /// <response code="200">Returns the updated book.</response>
    /// <response code="404">If book with ID is not found.</response>
    [HttpPut("/update")]
    [ProducesResponseType(typeof(Book),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Book>> UpdateBook(Book book)
    {
        var updatedBook = await _bookService.UpdateBookAsync(book);
        return Ok(updatedBook);
    }

    /// <summary>
    /// Deletes a book by ID.
    /// </summary>
    /// <param name="id">The ID of the book to deleted (book with same ID is already present).</param>
    /// <returns>The deleted Book object.</returns>
    /// <response code="200">Returns the deleted book.</response>
    /// <response code="404">If the book with ID is not found.</response> 
    [HttpDelete("/delete/{id}")]
    [ProducesResponseType(typeof(Book),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Book>> DeleteBook(int id)
    {
        var deletedBook = await _bookService.DeleteBookAsync(id);
        return Ok(deletedBook);
    }
}