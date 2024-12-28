using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Project.Books;

namespace Trial.Project.Books
{
    public class CreateUpdateBookDto
    {
        public string Name { get; set; }
        public BookType Type { get; set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }
    }
}
