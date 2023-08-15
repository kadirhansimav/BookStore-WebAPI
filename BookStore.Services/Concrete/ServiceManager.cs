using BookStore.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        public ServiceManager(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }


        public IBookService BookService => _bookService;

        public ICategoryService CategoryService => _categoryService;
    }
}
