using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Trial.Project.Authors
{
    public class AuthorAlreadyExistsExeption : BusinessException
    {
        public AuthorAlreadyExistsExeption(string name)
            : base(BookStoreDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData(nameof(name), name);
        }
    }
}
