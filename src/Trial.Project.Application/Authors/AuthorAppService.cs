using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Trial.Project.Authors
{
    public class AuthorAppService
        : ProjectAppService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;

        public AuthorAppService(IAuthorRepository authorRepository, AuthorManager authorManager)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }

        public async Task<AuthorDto> CreateAsync(CreateUpdateAuthorDto input)
        {
            var author = await _authorManager.CreateAsync(input.Name,
                                                    input.BirthDate,
                                                    input.ShortBio);


            await _authorRepository.InsertAsync(author);
            return ObjectMapper.Map<Author,  AuthorDto>(author);

        }

        public async Task DeleteAsync(Guid id)
        {
            
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        public async Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedAuthorDto input)
        {
            if (input.Sorting == null)
            {
                input.Sorting = nameof(Author.Name);
            }
            var authors = await _authorRepository.GetListAsync(input.SkipCount,
                                                    input.MaxResultCount,
                                                    input.Sorting,
                                                    input.Filter);

            var totalCount = input.Filter == null ?
                        await _authorRepository.CountAsync()
                        : await _authorRepository.CountAsync(
                            author => author.Name.Contains(input.Filter));

            return new PagedResultDto<AuthorDto>(
                                     totalCount,
                                     ObjectMapper.Map<List<Author>, List<AuthorDto>>(authors));
        }
        public async Task<AuthorDto> UpdateAsync(Guid id, CreateUpdateAuthorDto input)
        {
            var existingAuthor = await _authorRepository.GetAsync(id);
            if (existingAuthor.Name != input.Name)
            { 
                existingAuthor.Name = input.Name;
            }
            existingAuthor.BirthDate = input.BirthDate;
            existingAuthor.ShortBio = input.ShortBio;

            return ObjectMapper.Map<Author, AuthorDto>(existingAuthor);
        }
    }
}
