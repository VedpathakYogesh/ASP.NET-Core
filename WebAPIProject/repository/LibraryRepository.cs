using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Entities;

namespace WebAPIProject.repository
{
    public class LibraryRepository : ILibraryRepository<Author>
    {
        readonly LibraryContext _libraryContext;

        public LibraryRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public IEnumerable<Author> GetAllAuthor()
        {
            return _libraryContext.Authors.ToList();
        }
    }
}
