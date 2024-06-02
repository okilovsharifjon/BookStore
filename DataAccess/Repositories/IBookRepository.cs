using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using StoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IBookRepository
    {
        public Task<int> CreateAsync(Book book, CancellationToken token = default);
        public Task<Book> GetAsync(int id, CancellationToken token = default);
        public Task UpdateAsync(int id, Book book, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
    }
}
