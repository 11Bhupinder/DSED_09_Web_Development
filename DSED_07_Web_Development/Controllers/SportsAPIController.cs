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
    [Route("api/SportsAPI")]
    public class SportsAPIController : Controller
    {

        private readonly LibraryContext _context;

        public SportsAPIController(LibraryContext context)
        {
            _context = context;
        }

        // GetAll() is automatically recognized as
        // http://localhost:<port #>/api/todo
        [HttpGet]
        public IEnumerable<Sports> GetAll()
        {
            return _context.Sports.ToList();
        }

        // GetById() is automatically recognized as
        // http://localhost:<port #>/api/todo/{id}

        // For example:
        // http://localhost:<port #>/api/todo/1

        [HttpGet("{id}", Name = "GetSports")]
        public IActionResult GetById(long id)
        {
            var item = _context.Sports.FirstOrDefault(t => t.SportId== id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}