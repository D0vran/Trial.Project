using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trial.Project.Authors;
using Trial.Project.Books;
using Trial.Project.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Trial.Project.Authors
{
    public class EfCoreAuthorRepository
        : EfCoreRepository<ProjectDbContext, Author, Guid>,
        IAuthorRepository
    {
        public EfCoreAuthorRepository(IDbContextProvider<ProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        public async Task<Author> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);

            
        }

        public async Task<List<Author>> GetListAsync(int skipCount, 
                                                    int maxResultCount, 
                                                    string sorting, 
                                                    string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                author => author.Name.Contains(filter)
                ).OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
