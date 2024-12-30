using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Trial.Project.Authors
{
    public interface IAuthorAppService 
        : IApplicationService 
    {
        Task<AuthorDto> CreateAsync(CreateUpdateAuthorDto input);
        Task<AuthorDto> UpdateAsync(Guid id, CreateUpdateAuthorDto input);
        Task<AuthorDto> GetAsync(Guid id);
        Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedAuthorDto input);
        Task DeleteAsync(Guid id);
    }
}
