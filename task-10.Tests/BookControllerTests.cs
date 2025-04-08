using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using task_10.Controllers;
using task_10.Models;
using task_10.Services.Interfaces;
using Xunit;

namespace task_10.Tests;

public class BookControllerTests
{
        private readonly IBookService _bookService;
        private readonly BookController _controller;

        public BookControllerTests()
        {
            _bookService = A.Fake<IBookService>();
            _controller = new BookController(_bookService);
        }

        [Fact]
        public async Task GetAllBooks_Returns_Ok_With_Correct_Number_Of_Books()
        {
            var books = A.CollectionOfDummy<Book>(5).ToList();
            A.CallTo(() => _bookService.GetAllBooksAsync()).Returns(Task.FromResult(books));
            
            var result = await _controller.GetAllBooks();
            
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBooks = Assert.IsAssignableFrom<List<Book>>(okResult.Value);
            Assert.Equal(5, returnedBooks.Count);
        }

        [Fact]
        public async Task GetBookById_Returns_Ok_With_Correct_Book()
        {
            var book = new Book { BookId = 1, Title = "I Saw Him Die", Author = "Andrew Wilson" };
            A.CallTo(() => _bookService.GetBookByIdAsync(1)).Returns(book);

            var result = await _controller.GetBookById(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBook = Assert.IsType<Book>(okResult.Value);
            Assert.Equal(1, returnedBook.BookId);
            Assert.Equal("I Saw Him Die", returnedBook.Title);
            Assert.Equal("Andrew Wilson", returnedBook.Author);
        }

        [Fact]
        public async Task AddBook_Returns_Ok_With_Created_Book()
        {
            var book = new Book { Title = "I Saw Him Die", Author = "Andrew Wilson" };
            var createdBook = new Book { BookId = 1, Title = "I Saw Him Die", Author = "Andrew Wilson" };
            A.CallTo(() => _bookService.CreateBookAsync(book)).Returns(createdBook);

            var result = await _controller.AddBook(book);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBook = Assert.IsType<Book>(okResult.Value);
            Assert.Equal(1, returnedBook.BookId);
            Assert.Equal("I Saw Him Die", returnedBook.Title);
            Assert.Equal("Andrew Wilson", returnedBook.Author);
        }

        [Fact]
        public async Task UpdateBook_Returns_Ok_With_Updated_Book()
        {
            var updatedBook = new Book { BookId = 1, Title = "Nine Perfect Strangers", Author = "Liane Moriarty" };
            A.CallTo(() => _bookService.UpdateBookAsync(updatedBook)).Returns(updatedBook);

            var result = await _controller.UpdateBook(updatedBook);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBook = Assert.IsType<Book>(okResult.Value);
            Assert.Equal(1, returnedBook.BookId);
            Assert.Equal("Nine Perfect Strangers", returnedBook.Title);
            Assert.Equal("Liane Moriarty", returnedBook.Author);
        }

        [Fact]
        public async Task DeleteBook_Returns_Ok_With_Deleted_Book()
        {
            var deletedBook = new Book { BookId = 1, Title = "Nine Perfect Strangers", Author = "Liane Moriarty" };
            A.CallTo(() => _bookService.DeleteBookAsync(1)).Returns(deletedBook);

            var result = await _controller.DeleteBook(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBook = Assert.IsType<Book>(okResult.Value);
            Assert.Equal(1, returnedBook.BookId);
            Assert.Equal("Nine Perfect Strangers", returnedBook.Title);
            Assert.Equal("Liane Moriarty", returnedBook.Author);
        }

}