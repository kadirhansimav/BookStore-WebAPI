using BookStore.DataAccess.Abstract;
using BookStore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book)
        {
           Create(book);
        }

        public void DeleteOneBook(Book book)
        {
            Delete(book);
        }

        public async Task<List<Book>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await FindAll(trackChanges).ToListAsync();
            return books;
        }

        public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book = await FindByCondition(b=>b.Id.Equals(id), trackChanges).SingleOrDefaultAsync() ;
            return book;
        }

        public void UpdateOneBook(Book book)
        {
            Update(book);
        }
    }
}
