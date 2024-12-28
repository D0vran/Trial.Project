using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Trial.Project.Authors
{
    public interface IAuthorAppService 
        : ICrudAppService<
            AuthorDto,
            Guid,
            PagedAndSortedAuthorDto,
            CreateUpdateAuthorDto> 
    {
    }
}
