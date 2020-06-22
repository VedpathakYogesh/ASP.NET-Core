using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIProject.Entities;
using WebAPIProject.repository;

namespace WebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryRepository<Author> _libraryRepository;

        public LibrariesController(ILibraryRepository<Author> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        /// <summary>
        /// GetAllAuthor
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       // [Route("GetAllAuthor")]
        public IActionResult GetAllAuthor()
        {
            IEnumerable<Author> authors = _libraryRepository.GetAllAuthor();

            return Ok(authors);
        }
    }
}