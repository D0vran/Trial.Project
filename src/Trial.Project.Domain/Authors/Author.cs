using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Trial.Project.Authors
{
    public class Author : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string ShortBio { get; set; }

        internal Author(Guid id,
                        string name,
                        DateTime birthDate,
                        string shortBio)
            :base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), AuthorConsts.MaxNameLength);
            BirthDate = birthDate;
            ShortBio = shortBio;
        }

        private Author()
        {
        }

        internal void ChangeName(string name)
        {
            Name = name;
        }


    }
}
