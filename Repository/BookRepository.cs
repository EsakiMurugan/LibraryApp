using AutoMapper;
using LibraryApp.DAL;
using LibraryApp.DTO;
using LibraryApp.Interfaces;
using LibraryApp.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(LibraryDbContext db, IMapper mapper, ILogger<BookRepository> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<BookDTO>> SortedListOfBook()
        {
            try
            {
                _logger.LogInformation("Entered into SortedListOfBook at " + DateTime.Now);
                var sortedBooks = await (from i in _db.Book
                                         orderby i.Publisher, i.AuthorLastName, i.AuthorFirstName, i.Title
                                         select i).ToListAsync();

                _logger.LogInformation("Returns sorted list of Book class");
                return _mapper.Map<List<BookDTO>>(sortedBooks);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BookDTO>> SortedListByAuthorAndTitle()
        {
            try
            {
                _logger.LogInformation("Entered into SortedListWithAuthorAndTitle at " + DateTime.Now);
                var sortedBooks = await _db.Book.
                                  OrderBy(x => x.AuthorLastName).
                                  ThenBy(x => x.AuthorFirstName).
                                  ThenBy(x => x.Title).ToListAsync();

                _logger.LogInformation("Returns sorted list of Book class by Author then Title");
                return _mapper.Map<List<BookDTO>>(sortedBooks);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BookDTO>> SortedListOfBookUsingSp()
        {
            try
            {
                _logger.LogInformation("Entered into SortedListOfBookUsingSp at " + DateTime.Now);
                var sortedBooks = await _db.Book.FromSqlRaw("EXEC sp_BookListSorted").ToListAsync();

                _logger.LogInformation("Returns sorted list of Book class using stored procedure");
                return _mapper.Map<List<BookDTO>>(sortedBooks);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<BookDTO>> SortedListByAuthorAndTitleUsingSp()
        {
            try
            {
                _logger.LogInformation("Entered into SortedListByAuthorAndTitleUsingSp at " + DateTime.Now);
                var sortedBooks = await _db.Book.FromSqlRaw("EXEC sp_SortedBookListByAuthorThenTitle").ToListAsync();

                _logger.LogInformation("Returns sorted list of Book class by Author then Title using stored procedure");
                return _mapper.Map<List<BookDTO>>(sortedBooks);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<decimal> TotalPrice()
        {
            try
            {
                _logger.LogInformation("Entered into TotalPrice method at " + DateTime.Now);
                var totalPrice = _db.Book.Sum(x => x.Price);
                _logger.LogInformation("Returns total price of books in Book class at " + DateTime.Now);
                return totalPrice;
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<BookDTO>> SaveListOfBooksToDb()
        {
            _logger.LogInformation("Entered into SaveListOfBooksToDb method at " + DateTime.Now);
            List<Book> books = new List<Book>
            {
                new Book { Publisher = "John Wiley & Sons", Title = "Technical Analysis of the Financial Markets",
                    AuthorLastName = "Murphy", AuthorFirstName = "John", Price = 2295},
                new Book { Publisher = "John Wiley & Sons", Title = "Common Stocks and Uncommon Profits",
                    AuthorLastName = "Fisher", AuthorFirstName = "Philip", Price = 323},
                new Book { Publisher = "Penguin Business", Title = "Random Walk Down Wall Street",
                    AuthorLastName = "Malkiel", AuthorFirstName = "Burton", Price = 499},
                new Book { Publisher = "Penguin Books", Title = "Extraordinary Popular Delusions and the Madness of Crowds",
                    AuthorLastName = "Mackay", AuthorFirstName = "Charles", Price = 225},
                new Book { Publisher = "Penguin Business", Title = "Liar's Poker",
                    AuthorLastName = "Lewis", AuthorFirstName = "Michael", Price = 299},
            };
            try
            {
                await _db.Book.AddRangeAsync(books.ToList());
                await _db.SaveChangesAsync();

                _logger.LogInformation("Returns a list of books saved to the database in memory" + DateTime.Now);
                return _mapper.Map<List<BookDTO>>(books);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<string>> MLACitation()
        {
            try
            {
                List<string> res = new List<string>();

                var books = await (from i in _db.Book select i).ToListAsync();
                foreach (var pr in books)
                {
                    res.Add(pr.Citation);
                }
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<string>> ChicagoCitation()
        {
            try
            {
                List<string> res = new List<string>();

                var books = await (from i in _db.Book select i).ToListAsync();
                foreach (var pr in books)
                {
                    res.Add(pr.Chicago);
                }
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}

