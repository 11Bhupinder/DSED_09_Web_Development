using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSED_07_Web_Development.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSED_07_Web_Development.Controllers
{
    [Produces("application/json")]
    [Route("api/NovelsAPI")]
    public class NovelsAPIController : Controller
    {

        private readonly LibraryContext _context;

        public NovelsAPIController(LibraryContext context)
        {
            _context = context;
        }

        // GetAll() is automatically recognized as
        // http://localhost:<port #>/api/todo
        [HttpGet]
        public IEnumerable<Novels> GetAll()
        {
            return _context.Novels.ToList();
        }

        // GetById() is automatically recognized as
        // http://localhost:<port #>/api/todo/{id}

        // For example:
        // http://localhost:<port #>/api/todo/1

        [HttpGet("{id}", Name = "GetNovels")]
        public IActionResult GetById(long id)
        {
            var item = _context.Novels.FirstOrDefault(t => t.NovelId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

    }
}