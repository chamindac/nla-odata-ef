using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Logging;
using NLA.ODATA.EF.API.Data;
using NLA.ODATA.EF.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLA.ODATA.EF.API.Controllers
{
    public class AuthorsController : ODataController
    {
        private readonly BooksDBContext _booksDBContext;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(ILogger<AuthorsController> logger, BooksDBContext booksDBContext)
        {
            _logger = logger;
            _booksDBContext = booksDBContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_booksDBContext.Authors.AsQueryable());
        }

        public IActionResult Post([FromBody] Author author)
        {
            _booksDBContext.Authors.Add(author);
            _booksDBContext.SaveChanges();
            return Created(author);
        }

        public IActionResult Put(int key, [FromBody] Author author)
        {
            _booksDBContext.Authors.Update(author);
            _booksDBContext.SaveChanges();
            return Ok(author);
        }

        public IActionResult Delete(int key)
        {
            _booksDBContext.Authors.Remove(_booksDBContext.Authors.Find(key));
            _booksDBContext.SaveChanges();
            return NoContent();
        }
    }
}
