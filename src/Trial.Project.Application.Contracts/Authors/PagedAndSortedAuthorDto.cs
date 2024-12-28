using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Trial.Project.Authors
{
    public class PagedAndSortedAuthorDto : PagedAndSortedResultRequestDto
    {
        public string? Filter {  get; set; } 
    }
}
