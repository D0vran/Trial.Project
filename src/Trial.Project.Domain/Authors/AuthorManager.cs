using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.OpenIddict.Authorizations;

namespace Trial.Project.Authors
{
    public class AuthorManager : DomainService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorManager(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> CreateAsync(string name,
                                              DateTime birthDate,
                                              string shortBio)
        {
            var existing = await _authorRepository.FindByNameAsync(name);

            var existingAuthor = await _authorRepository.FindByNameAsync(name);
            if (existingAuthor is not null)
            {
                throw new AuthorAlreadyExistsExeption(name);
            }

            return new Author(GuidGenerator.Create(),
                              name, 
                              birthDate, 
                              shortBio);
        }

        public async Task ChangeNameAsync(Author author, string name)
        {
            Check.NotNull(author, nameof(author));
            Check.NotNullOrWhiteSpace(name, nameof(name), AuthorConsts.MaxNameLength);

            var existingAuthor = await _authorRepository.FindByNameAsync(name);
            
            if (existingAuthor is not null && existingAuthor.Id != author.Id)
            {
                throw new AuthorAlreadyExistsExeption(name);
            }

            author.ChangeName(name);
        }
    }
}
