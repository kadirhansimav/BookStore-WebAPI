using BookStore.DataAccess.Abstract;
using BookStore.DataAccess.EFCore;
using BookStore.Services.Abstract;
using BookStore.Services.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WepAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BookStoreDb")));

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
          
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IServiceManager, ServiceManager>();
        }
    }
}
