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
    [Route("api/ComuterScienceAPI")]
    public class ComuterScienceAPIController : Controller
    {


        private readonly LibraryContext _context;

        public ComuterScienceAPIController(LibraryContext context)
        {
            _context = context;
        }

        // GetAll() is automatically recognized as
        // http://localhost:<port #>/api/todo
        [HttpGet]
        public IEnumerable<ComuterScience> GetAll()
        {
            return _context.ComuterScience.ToList();
        }

        // GetById() is automatically recognized as
        // http://localhost:<port #>/api/todo/{id}

        // For example:
        // http://localhost:<port #>/api/todo/1

        [HttpGet("{id}", Name = "GetComuterScience")]
        public IActionResult GetById(long id)
        {
            var item = _context.ComuterScience.FirstOrDefault(t => t.BookId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

    }


}
