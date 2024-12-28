using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Project.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Trial.Project.Books
{
    public class BookAppService 
        : CrudAppService<
            Book,
            BookDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateBookDto>, 
            IBookAppService
    {
        public BookAppService(IRepository<Book, Guid> bookRepository)
            :base(bookRepository)
        {
            GetPolicyName = ProjectPermissions.Books.Default;
            GetListPolicyName = ProjectPermissions.Books.Default;
            CreatePolicyName = ProjectPermissions.Books.Create;
            UpdatePolicyName = ProjectPermissions.Books.Edit;
            DeletePolicyName = ProjectPermissions.Books.Delete;
        }
    }
}
