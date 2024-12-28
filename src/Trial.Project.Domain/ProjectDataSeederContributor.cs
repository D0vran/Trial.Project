using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Trial.Project.Books;

namespace Trial.Project
{
    public class ProjectDataSeederContributor 
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        public ProjectDataSeederContributor(IRepository<Book, Guid> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "48 Laws of Power",
                        Type = BookType.Science,
                        PublishDate = new DateTime().AddYears(1996),
                        Price = 14.99f
                    });
            }
        }
    }
}
