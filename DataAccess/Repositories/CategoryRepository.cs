using Microsoft.EntityFrameworkCore;
using StoreDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CategoryRepository(StoreDbContext dbContext)
    {
        private readonly StoreDbContext _dbContext = dbContext;

        public async Task CreateAsync(Category category, CancellationToken token = default)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }
        public Category Get(string name)
        {
            var normalizedName = name.ToLower();
            var category = _dbContext.Categories
                                     .SingleOrDefault(x => x.Name.ToLower() == normalizedName);
            return category;
        }



    }
}
