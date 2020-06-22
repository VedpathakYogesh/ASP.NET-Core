using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProject.repository
{
   public interface ILibraryRepository<T>
    {
        IEnumerable<T> GetAllAuthor();
    }
}
