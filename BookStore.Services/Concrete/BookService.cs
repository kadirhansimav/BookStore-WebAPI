using BookStore.DataAccess.Abstract;
using BookStore.Entities.Models;
using BookStore.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _manager;

        public BookService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<Book> CreateOneBookAsync(Book book)
        {
            if(book is null) throw new ArgumentNullException(nameof(book));

            _manager.Book.Create(book);
            await _manager.SaveAsync();
            return book;
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetByIdAndCheck(id,trackChanges);
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _manager.Book.GetAllBooksAsync(trackChanges);
            return books;
        }

        public Task<Book> GetOneBookByIdAsync(int id, bool trackChanges)
        {
           var entity = GetByIdAndCheck(id,trackChanges);
            return entity;  
        }

        public async Task UpdateOneBookAsync(int id, Book book, bool trackChanges)
        {
            var entity = GetByIdAndCheck(id, trackChanges);
            if (!id.Equals(book.Id))
            {
                throw new ArgumentException("Book ıd ve girilen id aynı değil.");
            }
             _manager.Book.Update(book);
            await _manager.SaveAsync();
        }
        public async Task<Book> GetByIdAndCheck(int id, bool trackChanges)
        {
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);

            if (entity is null)
                throw new ArgumentNullException(nameof(id));

            return entity;
        }
    }
}
