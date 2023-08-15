using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Abstract
{
    public interface IServiceManager
    {
        public IBookService BookService { get; }
        public ICategoryService CategoryService { get; }
    }
}
