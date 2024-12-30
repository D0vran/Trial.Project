using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Trial.Project.Authors
{
    public class CreateUpdateAuthorDto : AuditedEntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string ShortBio {  get; set; }
    }
}
