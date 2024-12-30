using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Trial.Project.Books;
using Trial.Project.Authors;

namespace Trial.Project
{
    public class ProjectDataSeederContributor 
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;
        public ProjectDataSeederContributor(IRepository<Book, Guid> bookRepository,
                                            IAuthorRepository authorRepository,
                                            AuthorManager authorManager)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _bookRepository.GetCountAsync() > 0)
            {
                return;
            }

            var robertGrin = await _authorRepository.InsertAsync
            (
                await _authorManager.CreateAsync(
                    "Robert Grin",
                    new DateTime(1947),
                    "He is famous")
            );

            await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "48 Laws of Power",
                        Type = BookType.Science,
                        PublishDate = new DateTime().AddYears(1996),
                        Price = 14.99f,
                        AuthorId = robertGrin.Id
                    }, 
                    autoSave: true
                    );
        }
    }
}
