using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Abstract
{
    public interface IBookService
    {
       
        Task<Book> GetOneBookByIdAsync(int id, bool trackChanges);
        Task<Book> CreateOneBookAsync(Book book);
        Task UpdateOneBookAsync(int id, Book book, bool trackChanges);
        Task DeleteOneBookAsync(int id, bool trackChanges);
        Task<List<Book>> GetAllBooksAsync(bool trackChanges);
    }
}
