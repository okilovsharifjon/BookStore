using Microsoft.EntityFrameworkCore;
using StoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookRepository(StoreDbContext dbContext) : IBookRepository
    {
        private readonly StoreDbContext _dbContext = dbContext;

        public async Task<int> CreateAsync(Book book, CancellationToken token = default)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book.Id;
        }
        public async Task<Book> GetAsync(int id, CancellationToken token = default)
            => await _dbContext.Books.SingleAsync(x => x.Id.Equals(id), token);
        public async Task UpdateAsync(int id, Book book, CancellationToken token = default)
        {
            Book updatebook = await _dbContext.Books.SingleAsync(x => x.Id.Equals(id), token);
            updatebook.Name = book.Name;
            updatebook.Price = book.Price;
            updatebook.Image = book.Image;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id, CancellationToken token = default)
        {
            await _dbContext.Books.Where(x => x.Id.Equals(id)).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
        }
    }
}
