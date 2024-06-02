using Microsoft.EntityFrameworkCore;
using StoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class AuthorRepository(StoreDbContext dbContext)
    {
        private readonly StoreDbContext _dbContext = dbContext;
        public async Task CreateAsync(Author author, CancellationToken token = default)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
        }
        public Author Get(string name)
        {
            var normalizedName = name.ToLower();
            var author = _dbContext.Authors
                                     .SingleOrDefault(x => x.Name.ToLower() == normalizedName);
            return author;
        }

    }
}
