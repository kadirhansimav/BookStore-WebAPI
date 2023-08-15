
using BookStore.Entities.Models;

namespace BookStore.DataAccess.Abstract
{
    public interface IBookRepository:IRepositoryBase<Book>
    {
        Task<List<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetOneBookByIdAsync(int id, bool trackChanges);
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);
    }
}
