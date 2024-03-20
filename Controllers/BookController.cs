using LibraryApp.DTO;
using LibraryApp.Interfaces;
using LibraryApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    /// <summary>
    ///     Book API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _libraryRepository;

        /// <summary>
        ///     Book API Constructor
        /// </summary>
        public BookController(IBookRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        /// <summary>
        ///     Returns sorted list of Book class by Publisher, Author then Title
        /// </summary>
        /// <response code="200">Returns sorted list of Book class by Publisher, Author then Title</response>
        /// <response code="400">Invalid request parameters. Please check your input.</response> 
        /// <response code="401">Unauthorized to access the resource.</response>
        /// <response code="403">Access denied. You do not have the necessary permissions.</response>
        /// <response code="500">An internal server error occurred.</response>

        [HttpGet]
        public async Task<List<BookDTO>> SortedListOfBook()
        {
            return await _libraryRepository.SortedListOfBook();
        }

        /// <summary>
        ///     Returns sorted list of Book class by Author then Title
        /// </summary>
        /// <response code="200">Returns sorted list of Book class by Author then Title</response>
        /// <response code="400">Invalid request parameters. Please check your input.</response> 
        /// <response code="401">Unauthorized to access the resource.</response>
        /// <response code="403">Access denied. You do not have the necessary permissions.</response>
        /// <response code="500">An internal server error occurred.</response>

        [HttpGet("[action]")]
        public async Task<List<BookDTO>> SortedListByAuthorAndTitle()
        {
            return await _libraryRepository.SortedListByAuthorAndTitle();
        }

        /// <summary>
        ///     Returns sorted list of Book class by Publisher, Author then Title using stored procedure
        /// </summary>
        /// <response code="200">Returns sorted list of Book class by Publisher, Author then Title using stored procedure</response>
        /// <response code="400">Invalid request parameters. Please check your input.</response> 
        /// <response code="401">Unauthorized to access the resource.</response>
        /// <response code="403">Access denied. You do not have the necessary permissions.</response>
        /// <response code="500">An internal server error occurred.</response>

        [HttpGet("[action]")]
        public async Task<List<BookDTO>> SortedListOfBookUsingSp()
        {
            return await _libraryRepository.SortedListOfBookUsingSp();
        }

        /// <summary>
        ///     Returns sorted list of Book class by Author then Title using stored procedure
        /// </summary>
        /// <response code="200">Returns sorted list of Book class by Author then Title using stored procedure</response>
        /// <response code="400">Invalid request parameters. Please check your input.</response> 
        /// <response code="401">Unauthorized to access the resource.</response>
        /// <response code="403">Access denied. You do not have the necessary permissions.</response>
        /// <response code="500">An internal server error occurred.</response>

        [HttpGet("[action]")]
        public async Task<List<BookDTO>> SortedListByAuthorAndTitleUsingSp()
        {
            return await _libraryRepository.SortedListByAuthorAndTitleUsingSp();
        }

        /// <summary>
        ///     Returns total price of books in Book class
        /// </summary>
        /// <response code="200">Returns total price of books in Book class</response>
        /// <response code="400">Invalid request parameters. Please check your input.</response> 
        /// <response code="401">Unauthorized to access the resource.</response>
        /// <response code="403">Access denied. You do not have the necessary permissions.</response>
        /// <response code="500">An internal server error occurred.</response>

        [HttpGet("[action]")]
        public async Task<decimal> TotalPrice()
        {
            return await _libraryRepository.TotalPrice();
        }

        /// <summary>
        ///     Returns a list of books saved to the database in memory
        /// </summary>
        /// <response code="200">Returns a list of books saved to the database in memory</response>
        /// <response code="400">Invalid request parameters. Please check your input.</response> 
        /// <response code="401">Unauthorized to access the resource.</response>
        /// <response code="403">Access denied. You do not have the necessary permissions.</response>
        /// <response code="500">An internal server error occurred.</response>

        [HttpGet("[action]")]
        public async Task<List<BookDTO>> SaveListOfBooksToDb()
        {
            return await _libraryRepository.SaveListOfBooksToDb();
        }

        /// <summary>
        ///     Returns a MLA Citation
        /// </summary>
        /// <response code="200">Returns a MLA Citation</response>
        /// <response code="400">Invalid request parameters. Please check your input.</response> 
        /// <response code="401">Unauthorized to access the resource.</response>
        /// <response code="403">Access denied. You do not have the necessary permissions.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("[action]")]
        public async Task<List<string>> MLACitation()
        {
            return await _libraryRepository.MLACitation();
        }

        /// <summary>
        ///     Returns Chicago citation
        /// </summary>
        /// <response code="200">Returns Chicago citation</response>
        /// <response code="400">Invalid request parameters. Please check your input.</response> 
        /// <response code="401">Unauthorized to access the resource.</response>
        /// <response code="403">Access denied. You do not have the necessary permissions.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("[action]")]
        public async Task<List<string>> ChicagoCitation()
        {
            return await _libraryRepository.ChicagoCitation();
        }

        /// <summary>
        ///     Save list of book to the database.
        /// </summary>
        /// <param name="books"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///         "publisher": "string",
        ///         "title": "string",
        ///         "authorLastName": "string",
        ///         "authorFirstName": "string",
        ///         "price": 0
        ///      }
        /// </remarks>
        /// <response code="200">Save list of book to the database</response>
        /// <response code="400">Invalid request parameters. Please check your input.</response> 
        /// <response code="401">Unauthorized to access the resource.</response>
        /// <response code="403">Access denied. You do not have the necessary permissions.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost]
        public async Task<SaveResponse> SaveListOfBooksToDb(List<Book> books)
        {
            try
            {
                return await _libraryRepository.SaveListOfBooksToDb(books);
            }
            catch (DbUpdateException ex)
            {
                string errors = ex.InnerException.Message;
                if (errors.Contains("IX_Book_Title"))
                {
                    throw new DbUpdateException("Book Title already exists");
                }
                else
                {
                    throw new Exception(ex.Message);    
                }
            }
        }
    }
}
