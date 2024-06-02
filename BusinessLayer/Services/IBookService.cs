using StoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBookService
    {
        public Task<int> CreateAsync(BookDto book, CancellationToken token = default);
        public Task<Book> GetAsync(int id, CancellationToken token = default);
        public Task UpdateAsync(int id, BookDto book, CancellationToken token = default);
        public Task DeleteAsync(int id, CancellationToken token = default);
    }
}
