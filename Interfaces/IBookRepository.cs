using LibraryApp.DTO;
using LibraryApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BookDTO>> SortedListOfBook();
        Task<List<BookDTO>> SortedListByAuthorAndTitle();
        Task<List<BookDTO>> SortedListOfBookUsingSp();
        Task<List<BookDTO>> SortedListByAuthorAndTitleUsingSp();
        Task<decimal> TotalPrice();
        Task<List<BookDTO>> SaveListOfBooksToDb();
        Task<List<string>> MLACitation();
        Task<List<string>> ChicagoCitation();
        Task<SaveResponse> SaveListOfBooksToDb(List<Book> books);
    }
}
